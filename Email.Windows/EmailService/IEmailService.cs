using Email.Windows.Model;
using System;
using System.Threading.Tasks;

namespace Email.Windows.EmailService
{
    /// <summary>
    /// 邮件服务
    /// </summary>
    public interface IEmailService
    {
        /// <summary>
        /// 异步获取邮件信息
        /// </summary>
        /// <param name="action">获取回调</param>
        /// <param name="number">获取多少条</param>
        /// <returns></returns>
        Task mailAsync(Action<EmailListView, int, int> action, int? number);
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="toEmail">接受邮箱</param>
        /// <param name="title">标题</param>
        /// <param name="body">内容</param>
        /// <returns></returns>
        Task<string> SendMailAsync(string toEmail, string title, string body);
        /// <summary>
        /// 获取所有文件夹
        /// </summary>
        /// <returns></returns>
        Task Folders();
    }
}
