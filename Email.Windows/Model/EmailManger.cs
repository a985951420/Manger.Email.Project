using System;
using System.Data.SQLite;

namespace Email.Windows.Model
{
    /// <summary>
    /// 邮件管理
    /// </summary>
    public class EmailManger
    {
        /// <summary>
        /// 编号
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string PassWord { get; set; }
        /// <summary>
        /// 发送条数
        /// </summary>
        public long SendNumber { get; set; }
        /// <summary>
        /// 发送最大条数
        /// </summary>
        public long SendMax { get; set; }
        /// <summary>
        /// 发送时间
        /// </summary>
        public string SendTime { get; set; }
        /// <summary>
        /// 发送时间
        /// </summary>
        public DateTime? SendDateTime { get; set; }
        /// <summary>
        /// 同步时间
        /// </summary>
        public string Synchronization { get; set; }
        /// <summary>
        /// 同步时间
        /// </summary>
        public DateTime? SynchronizationTime
        {
            get
            {
                if (string.IsNullOrEmpty(Synchronization))
                    return null;
                return DateTime.Parse(Synchronization);
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
                var sql = " INSERT INTO email_Manger(email, password,sendnumber,sendmax,sendtime,Synchronization)  values(@email, @password,@SendNumber,@SendMax,@SendTime,@Synchronization)";
                return Tuple.Create(sql, new SQLiteParameter[] {
                    new SQLiteParameter("@email",this.Email),
                    new SQLiteParameter("@password",this.PassWord),
                    new SQLiteParameter("@sendnumber",this.SendNumber),
                    new SQLiteParameter("@sendmax",this.SendMax),
                    new SQLiteParameter("@sendtime",this.SendTime),
                    new SQLiteParameter("@Synchronization",this.Synchronization),
                });
            }
        }

        /// <summary>
        /// UpdateSQL
        /// </summary>
        /// <returns></returns>
        public Tuple<string, SQLiteParameter[]> UpdateByEmailSql
        {
            get
            {
                var sql = "UPDATE email_Manger SET password = @password WHERE email = @email";
                return Tuple.Create(sql, new SQLiteParameter[] {
                    new SQLiteParameter("@email",this.Email),
                    new SQLiteParameter("@password",this.PassWord)
                });
            }
        }

        /// <summary>
        /// UpdateSQL
        /// </summary>
        /// <returns></returns>
        public Tuple<string, SQLiteParameter[]> UpdateBySynchronizationSql
        {
            get
            {
                var sql = "UPDATE email_Manger SET Synchronization = @Synchronization WHERE email = @email";
                return Tuple.Create(sql, new SQLiteParameter[] {
                    new SQLiteParameter("@email",this.Email),
                    new SQLiteParameter("@Synchronization",this.Synchronization)
                });
            }
        }

        /// <summary>
        /// 插入SQL
        /// </summary>
        /// <returns></returns>
        public Tuple<string, SQLiteParameter[]> AnySql
        {
            get
            {
                var sql = "SELECT COUNT(1) FROM email_Manger WHERE email = @email";
                return Tuple.Create(sql, new SQLiteParameter[] {
                    new SQLiteParameter("@email",this.Email),
                });
            }
        }

        /// <summary>
        /// ID删除
        /// </summary>
        /// <returns></returns>
        public Tuple<string, SQLiteParameter[]> DeleteByIdSql
        {
            get
            {
                var sql = "DELETE FROM email_Manger Where id=@id";
                return Tuple.Create(sql, new SQLiteParameter[] {
                new SQLiteParameter("@id",this.Id)});
            }
        }
        /// <summary>
        /// Email删除
        /// </summary>
        /// <returns></returns>
        public Tuple<string, SQLiteParameter[]> GetByEmailSql
        {
            get
            {
                var sql = "SELECT * FROM email_Manger Where email=@email LIMIT 1";
                return Tuple.Create(sql, new SQLiteParameter[] {
                    new SQLiteParameter("@email",this.Email)
                });
            }
        }
        /// <summary>
        /// 更新发送次数
        /// </summary>
        public Tuple<string, SQLiteParameter[]> UpdateSendNumber
        {
            get
            {
                var sql = "UPDATE email_Manger SET sendnumber = sendnumber + 1,sendtime = @sendtime WHERE email = @email";
                return Tuple.Create(sql, new SQLiteParameter[] {
                    new SQLiteParameter("@email",this.Email),
                    new SQLiteParameter("@sendtime",this.SendTime)
                });
            }
        }

        /// <summary>
        /// 更新发送次数
        /// </summary>
        public Tuple<string, SQLiteParameter[]> ResetSendNumber
        {
            get
            {
                var sql = "UPDATE email_Manger SET sendnumber = 0,sendtime = @sendtime WHERE email = @email";
                return Tuple.Create(sql, new SQLiteParameter[] {
                    new SQLiteParameter("@email",this.Email),
                    new SQLiteParameter("@sendtime",this.SendTime)
                });
            }
        }

        /// <summary>
        /// 查询SQL
        /// </summary>
        /// <returns></returns>
        public string SelectSql
        {
            get
            {
                var sql = "SELECT * FROM email_Manger";
                return sql;
            }
        }
    }
}