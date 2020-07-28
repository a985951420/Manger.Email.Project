using Email.Windows.Model;
using Email.Windows.Tools;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Net.Pop3;
using MailKit.Net.Smtp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Email.Windows.EmailService
{
    /// <summary>
    /// 基础服务
    /// </summary>
    public class BaseService
    {
        /// <summary>
        /// 服务信息
        /// </summary>
        Dictionary<string, List<EmailServiceInformation>> service = new Dictionary<string, List<EmailServiceInformation>>
        {
            {"@vip.163", new List<EmailServiceInformation>{
                new EmailServiceInformation { HostName = "pop.vip.163.com", Port = 995, UseSsl = true, Type = EnumTools.EailType.POP3 }}
            },
            {"@163",new List<EmailServiceInformation>{
                new EmailServiceInformation { HostName = "pop.163.com", Port = 995, UseSsl = true, Type = EnumTools.EailType.POP3 }
            } },
            {"@qq",new List<EmailServiceInformation>{
                new EmailServiceInformation{ HostName="pop.qq.com", Port=995, UseSsl =true , Type= EnumTools.EailType.POP3},
                new EmailServiceInformation{ HostName="imap.qq.com", Port=993, UseSsl =true , Type= EnumTools.EailType.Imap},
                new EmailServiceInformation{ HostName="smtp.qq.com", Port=465, UseSsl =true , Type= EnumTools.EailType.Smtp},
            } },
            {"@live",new List<EmailServiceInformation>{
                new EmailServiceInformation{HostName="outlook.office365.com",Port=995,UseSsl=true , Type= EnumTools.EailType.POP3}
            } },
            {"@outlook",new List<EmailServiceInformation>{
                new EmailServiceInformation{HostName="outlook.office365.com",Port=995,UseSsl=true , Type= EnumTools.EailType.POP3}
            } }
        };

        /// <summary>
        /// 邮箱类型
        /// </summary>
        EnumTools.EailType _mailType;

        /// <summary>
        /// 附件路径
        /// </summary>
        protected string AttachmentPath { get { return Program.attachmentPath; } }

        /// <summary>
        /// 基础服务
        /// </summary>
        /// <param name="emailManger"></param>
        /// <param name="mailType"></param>
        public BaseService(EmailManger emailManger, EnumTools.EailType mailType = EnumTools.EailType.POP3)
        {
            Ensure.IsNull(emailManger);
            EmailManger = emailManger;
            _mailType = mailType;
            var visitor = new HtmlPreviewVisitor(AttachmentPath);
            if (!Directory.Exists(AttachmentPath))
                Directory.CreateDirectory(AttachmentPath);
        }


        /// <summary>
        /// 邮箱信息
        /// </summary>
        public EmailManger EmailManger { get; }

        /// <summary>
        /// 获取邮件服务
        /// </summary>
        /// <typeparam name="TClient">邮件客户端</typeparam>
        /// <returns></returns>
        public TClient ClientService<TClient>() where TClient : class, IMailService
        {
            var configuration = GetServiceConfiguration(EmailManger.Email, _mailType);
            IMailService service = null;
            switch (_mailType)
            {
                case EnumTools.EailType.POP3:
                    service = new Pop3Client();
                    break;
                case EnumTools.EailType.Imap:
                    service = new ImapClient();
                    break;
                case EnumTools.EailType.Smtp:
                    service = new SmtpClient();
                    break;
            }
            Ensure.IsNull(service);
            service.Connect(configuration.HostName, configuration.Port, configuration.UseSsl);
            service.Authenticate(EmailManger.Email, EmailManger.PassWord);
            return service as TClient;
        }

        /// <summary>
        /// 获取服务信息
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        EmailServiceInformation GetServiceConfiguration(string email, EnumTools.EailType eailType)
        {
            if (service.Any(s => email.Contains(s.Key) && s.Value.Any(c => c.Type == eailType)))
            {
                var value = service.FirstOrDefault(s => email.ToLower().Contains(s.Key.ToLower()));
                return value.Value.Where(s => s.Type == eailType).FirstOrDefault();
            }
            throw new Exception("暂未实现该邮箱！");
        }

        /// <summary>
        /// 获取所有邮箱服务
        /// </summary>
        public Dictionary<string, List<EmailServiceInformation>> AllEmailServiceInformation => service;
    }
}
