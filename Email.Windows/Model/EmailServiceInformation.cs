namespace Email.Windows.Model
{
    public class EmailServiceInformation
    {
        /// <summary>
        /// 服务地址
        /// </summary>
        public string HostName { get; set; }
        /// <summary>
        /// 端口
        /// </summary>
        public int Port { get; set; }
        /// <summary>
        /// 使用HTTPS
        /// </summary>
        public bool UseSsl { get; set; }
        /// <summary>
        /// 服务类型
        /// </summary>
        public EnumTools.EailType Type { get; set; }
    }
}
