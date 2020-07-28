using Email.Windows.Model;

namespace Email.Windows.EmailService
{
    /// <summary>
    /// 邮箱工厂
    /// </summary>
    public static class EmailFactory
    {
        /// <summary>
        /// 获取服务
        /// </summary>
        /// <param name="emailManger"></param>
        /// <param name="mailType"></param>
        /// <returns></returns>
        public static IEmailService Service(EmailManger emailManger, EnumTools.EailType mailType)
        {
            switch (mailType)
            {
                case EnumTools.EailType.POP3:
                    break;
                case EnumTools.EailType.Smtp:
                case EnumTools.EailType.Imap:
                    return new ImapService(emailManger, mailType);
                default:
                    break;
            }
            throw new System.Exception("暂未实现！");
        }
    }
}
