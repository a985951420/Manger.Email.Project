using Email.Windows.Model;
using Email.Windows.Tools;
using MailKit;
using MailKit.Net.Pop3;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Email.Windows.EmailService
{
    public interface IEmailLogicalService
    {
        /// <summary>
        /// 获取多少天之前的
        /// </summary>
        /// <param name="exists">是否本地已存在</param>
        /// <param name="callBack">获取返回</param>
        /// <param name="days">获取天数的</param>
        /// <param name="size">获取条数的</param>
        /// <returns></returns>
        Task GetByDays(Action<EmailListView, int, int> callBack, int? days);

        /// <summary>
        /// 获取总条数
        /// </summary>
        /// <returns></returns>
        Task<int> GetMessageCount();
    }

    /// <summary>
    /// 邮件获取服务
    /// </summary>
    public class EmailLogicalService : IEmailLogicalService
    {
        string _email = string.Empty;
        string _password = string.Empty;
        string _fileDirectory = string.Empty;

        EmailServiceInformation currentInfomationService;

        Dictionary<string, EmailServiceInformation> pop3 = new Dictionary<string, EmailServiceInformation>
        {
            {"@vip.163", new EmailServiceInformation{ HostName="pop.vip.163.com", Port=995, UseSsl =true } },
            {"@163",new EmailServiceInformation{ HostName="pop.163.com", Port=995, UseSsl =true } },
            {"@qq",new EmailServiceInformation{ HostName="pop.qq.com", Port=995, UseSsl =true } },
            {"@live",new EmailServiceInformation{HostName="outlook.office365.com",Port=995,UseSsl=true } },
            {"@outlook",new EmailServiceInformation{HostName="outlook.office365.com",Port=995,UseSsl=true } },
        };

        /// <summary>
        /// 邮箱服务
        /// </summary>
        /// <param name="email">邮箱</param>
        /// <param name="password">密码</param>
        /// <param name="fileDirectory">文件夹目录</param>
        public EmailLogicalService(string email, string password, string fileDirectory)
        {
            _email = email;
            _password = password;
            currentInfomationService = GetPop3Service(email);
            _fileDirectory = fileDirectory + _email + "\\";
        }

        /// <summary>
        /// 邮箱连接对象
        /// </summary>
        Pop3Client _Client
        {
            get
            {
                var client = new Pop3Client(new ProtocolLogger("imap.log"));
                client.Connect(currentInfomationService.HostName, currentInfomationService.Port, currentInfomationService.UseSsl);
                client.Authenticate(_email, _password);
                return client;
            }
        }
        EmailServiceInformation GetPop3Service(string email)
        {
            if (pop3.Any(s => email.Contains(s.Key)))
            {
                var service = pop3.FirstOrDefault(s => email.ToLower().Contains(s.Key.ToLower()));
                return service.Value;
            }
            throw new Exception("暂未实现该邮箱！");
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="number">index</param>
        /// <param name="exists">判断是否本地存在存在则不获取</param>
        /// <param name="client">客户端</param>
        /// <returns></returns>
        EmailListView GetById(int number, ref Pop3Client client)
        {
            var message = client.GetMessage(number);
            var path = _fileDirectory + message.MessageId + "\\";
            var attachments = message.Attachments;
            var files = new List<string>();
            foreach (MimeEntity attachment in message.Attachments)
            {
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                var fileName = attachment.ContentDisposition?.FileName ?? attachment.ContentType.Name;
                var lastName = path + fileName;
                if (!File.Exists(lastName))
                {
                    using (var stream = File.Create(path + fileName))
                    {
                        if (attachment is MessagePart)
                        {
                            var rfc822 = (MessagePart)attachment;
                            rfc822.Message.WriteTo(stream);
                        }
                        else
                        {
                            var part = (MimePart)attachment;
                            part.Content.DecodeTo(stream);
                        }
                    }
                }
                files.Add(lastName.Replace(_fileDirectory, string.Empty));
            }
            var address = message.From.Select(x => (MailboxAddress)x).First();
            var visitor = new HtmlPreviewVisitor(path);
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            var aa = client.GetMessageUids();
            message.Accept(visitor);
            return new EmailListView
            {
                FromEmail = address.Address,
                Title = message.Subject,
                SendTime = message.Date.ToString("yyyy-MM-dd HH:mm:ss"),
                MessageId = message.MessageId,
                Body = message.TextBody,
                Html = visitor.HtmlBody,
                Mark = 0,
                Files = string.Join(",", files)
            };
        }

        /// <summary>
        /// 获取多少天之前的
        /// </summary>
        /// <param name="exists">判断本地是否存在</param>
        /// <param name="callBack">获取立即返回</param>
        /// <param name="days">前多少天的</param>
        /// <returns></returns>
        public async Task GetByDays(Action<EmailListView, int, int> callBack, int? days = null)
        {
            if (days != null && days <= 0)
                throw new Exception("获取天数不能小于等于0天！");
            using (var client = _Client)
            {
                var interiorclient = client;
                int i = 0;
                var index = 0;
                try
                {
                    var count = await client.GetMessageCountAsync().ConfigureAwait(false) - 1;
                    for (i = count; i > 0; i--)
                    {
                        index++;
                        var message = GetById(i, ref interiorclient);
                        await Task.Run(() =>
                        {
                            callBack(message, index, count);
                        }).ConfigureAwait(false);
                        if (days != null)
                        {
                            if (message.SendTimeC == null)
                                continue;
                            var nowDate = DateTime.Now.AddDays((double)(days * -1));
                            var mix = new DateTime(nowDate.Year, nowDate.Month, nowDate.Day);
                            if (message.SendTimeC < mix)
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"第：{index} 条出现错误：" + ex.Message);
                }
                finally
                {
                    await client.DisconnectAsync(true).ConfigureAwait(false);
                    client.Dispose();
                    interiorclient = null;
                }
            }
        }

        /// <summary>
        /// 获取总条数
        /// </summary>
        /// <returns></returns>
        public async Task<int> GetMessageCount()
        {
            return await Task.Run(() =>
            {
                using (var client = _Client)
                {
                    try
                    {
                        return client.GetMessageCount();
                    }
                    catch (Exception ex)
                    {
                        client.Disconnect(true);
                        client.Dispose();
                        throw ex;
                    }
                }
            }).ConfigureAwait(false);
        }
    }
}
