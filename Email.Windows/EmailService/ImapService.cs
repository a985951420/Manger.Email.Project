using Email.Windows.Model;
using Email.Windows.Tools;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Email.Windows.EmailService
{
    /// <summary>
    /// Imap服务
    /// </summary>
    public class ImapService : BaseService, IEmailService
    {
        /// <summary>
        /// 初始化服务
        /// </summary>
        public ImapService(EmailManger emailManger, EnumTools.EailType mailType = EnumTools.EailType.POP3) : base(emailManger, mailType)
        {

        }
        /// <summary>
        /// 客户端
        /// </summary>
        public ImapClient clientService
        {
            get
            {
                return ClientService<ImapClient>();
            }
        }

        /// <summary>
        /// 客户端
        /// </summary>
        public SmtpClient smtpService
        {
            get
            {
                return ClientService<SmtpClient>();
            }
        }

        /// <summary>
        /// 获取所有文件夹
        /// </summary>
        /// <returns></returns>
        public Task Folders()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 异步获取邮件信息
        /// </summary>
        /// <param name="action">获取回调</param>
        /// <param name="number">获取多少条</param>
        /// <returns></returns>
        public async Task mailAsync(Action<EmailListView, int, int> callBack, int? number)
        {
            using (var client = clientService)
            {
                try
                {
                    var inbox = client.Inbox;
                    inbox.Open(FolderAccess.ReadOnly);
                    if (inbox.Count > 0)
                    {
                        var total = inbox.Count - 1;
                        var thisNumber = 1;
                        for (int i = total; i >= 0; i--)
                        {
                            var message = inbox.GetMessage(i);
                            var filePath = AttachmentPath + message.MessageId + "\\";
                            var files = new List<string>();
                            foreach (MimeEntity attachment in message.Attachments)
                            {
                                if (!Directory.Exists(filePath))
                                    Directory.CreateDirectory(filePath);
                                var fileName = attachment.ContentDisposition?.FileName ?? attachment.ContentType.Name;
                                var lastName = filePath + fileName;
                                if (!File.Exists(lastName))
                                {
                                    using (var stream = File.Create(filePath + fileName))
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
                                files.Add(lastName.Replace(filePath, string.Empty));
                            }
                            var address = message.From.Select(x => (MailboxAddress)x).First();
                            var Visitor = new HtmlPreviewVisitor(AttachmentPath);
                            message.Accept(Visitor);
                            var model = new EmailListView
                            {
                                FromEmail = address.Address,
                                Title = message.Subject,
                                SendTime = message.Date.ToString("yyyy-MM-dd HH:mm:ss"),
                                MessageId = message.MessageId,
                                Body = message.TextBody,
                                Html = Visitor.HtmlBody,
                                MainEmail = EmailManger.Email,
                                Mark = 0,
                                Files = string.Join(",", files)
                            };
                            await Task.Run(() => callBack(model, thisNumber, inbox.Count)).ConfigureAwait(false);
                            if (number != null)
                            {
                                if (number - thisNumber <= 0)
                                    return;
                            }
                            thisNumber++;
                        }
                    }
                }
                catch (Exception ex)
                {
                    client.Disconnect(true);
                    throw ex;
                }
            }
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="toEmail">接收人</param>
        /// <param name="title">标题</param>
        /// <param name="body">内容</param>
        /// <returns></returns>
        public async Task<string> SendMailAsync(string toEmail, string title, string body)
        {
            var message = new MimeMessage();
            var bodyBuilder = new BodyBuilder();
            // from
            message.From.Add(new MailboxAddress(EmailManger.Email, EmailManger.Email));
            // to
            message.To.Add(new MailboxAddress(toEmail, toEmail));
            message.Subject = title;
            bodyBuilder.HtmlBody = body;
            message.Body = bodyBuilder.ToMessageBody();
            using (var client = smtpService)
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                try
                {
                    await client.SendAsync(message).ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    client.Disconnect(true);
                    return ex.Message;
                }
            }
            return string.Empty;
        }
    }
}
