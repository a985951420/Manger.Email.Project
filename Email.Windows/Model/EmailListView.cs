using System;
using System.Data.SQLite;

namespace Email.Windows.Model
{
    public class EmailListView
    {
        /// <summary>
        /// 消息Id
        /// </summary>
        public string MessageId { get; set; }
        /// <summary>
        /// 邮件标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 发送邮箱
        /// </summary>
        public string FromEmail { get; set; }
        /// <summary>
        /// 发送内容
        /// </summary>
        public string Html { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        /// 发送时间
        /// </summary>
        public string SendTime { get; set; }
        /// <summary>
        /// 主邮箱
        /// </summary>
        public string MainEmail { get; set; }
        /// <summary>
        /// 是否已读
        /// </summary>
        public long Mark { get; set; }
        /// <summary>
        /// 文件列表
        /// </summary>
        public string Files { get; set; }
        /// <summary>
        /// 发送时间
        /// </summary>
        public DateTime? SendTimeC
        {
            get
            {
                if (string.IsNullOrEmpty(SendTime))
                    return null;
                return DateTime.Parse(SendTime);
            }
        }
        /// <summary>
        /// 内容
        /// </summary>
        public string Text
        {
            get
            {
                return Html;
            }
        }

        /// <summary>
        /// 插入SQL
        /// </summary>
        /// <returns></returns>
        public Tuple<string, SQLiteParameter[]> InsertSql
        {
            get
            {
                var sql = $"INSERT INTO email_list VALUES(@MessageId,@Title,@FromEmail,@Html,@Body,@SendTime,@MainEmail,@Mark,@Files)";
                return Tuple.Create(sql, new SQLiteParameter[] {
                    new SQLiteParameter( "@MessageId", this.MessageId ),
                    new SQLiteParameter("@Title", this.Title ),
                    new SQLiteParameter("@FromEmail", this.FromEmail),
                    new SQLiteParameter("@Html", this.Html),
                    new SQLiteParameter("@Body", this.Body),
                    new SQLiteParameter("@SendTime", this.SendTime.ToString()),
                    new SQLiteParameter("@MainEmail", this.MainEmail),
                    new SQLiteParameter("@Mark", this.Mark),
                    new SQLiteParameter("@Files", this.Files),
                });
            }
        }

        /// <summary>
        /// 是否存在SQL
        /// </summary>
        /// <returns></returns>
        public Tuple<string, SQLiteParameter[]> Any
        {
            get
            {
                var sql = $"SELECT COUNT(1) FROM email_list Where MessageId = @messageid";
                return Tuple.Create(sql, new SQLiteParameter[] {
                    new SQLiteParameter("@MessageId", this.MessageId)
                });
            }
        }

        /// <summary>
        /// 是否存在SQL
        /// </summary>
        /// <returns></returns>
        public Tuple<string, SQLiteParameter[]> FirstOrDefault
        {
            get
            {
                var sql = $"SELECT * FROM email_list Where MessageId = @messageid LIMIT 1";
                return Tuple.Create(sql, new SQLiteParameter[] {
                    new SQLiteParameter("@MessageId", this.MessageId)
                });
            }
        }

        /// <summary>
        /// 分页SQL
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageCount"></param>
        /// <returns></returns>
        public Tuple<string, SQLiteParameter[]> Page(string mainEmail, int pageIndex, int pageSize, string orderby, string orderType)
        {
            return Tuple.Create($"SELECT * FROM email_list WHERE mainEmail = @mainEmail Order BY {orderby} {orderType} limit {(pageIndex - 1) * pageSize},{pageSize}",
                new SQLiteParameter[] {
                    new SQLiteParameter("@mainEmail",mainEmail)
            });
        }

        /// <summary>
        /// 查询总条数
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageCount"></param>
        /// <returns></returns>
        public Tuple<string, SQLiteParameter[]> Count
        {
            get
            {
                return Tuple.Create($"SELECT COUNT(1) FROM email_list WHERE mainEmail = @mainEmail", new SQLiteParameter[] {
                        new SQLiteParameter("@mainEmail",this.MainEmail)
                });
            }
        }

        /// <summary>
        /// 查询总条数
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageCount"></param>
        /// <returns></returns>
        public Tuple<string, SQLiteParameter[]> MarkSql
        {
            get
            {
                return Tuple.Create($"UPDATE email_list SET Mark = @Mark WHERE MessageId = @MessageId", new SQLiteParameter[] {
                        new SQLiteParameter("@MessageId",this.MessageId),
                        new SQLiteParameter("@Mark",this.Mark),
                });
            }
        }

        /// <summary>
        /// 获取所有退件邮件
        /// </summary>
        public Tuple<string, SQLiteParameter[]> GetBackEmail
        {
            get
            {
                var sql = "SELECT * FROM email_list Where Title like @Title";
                return Tuple.Create(sql, new SQLiteParameter[] {
                    new SQLiteParameter("@Title",$"%{this.Title}%")
                });
            }
        }
    }
}
