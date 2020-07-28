using Email.Windows.Model;
using System;
using System.Windows.Forms;

namespace Email.Windows
{
    public partial class AddEmail : BaseForm
    {
        bool isedit = false;
        public AddEmail()
        {
            InitializeComponent();
        }
        public AddEmail(string email) : this()
        {
            isedit = true;
            var sql = new EmailManger { Email = email }.GetByEmailSql;
            var model = Db.ExecuteFirstOrDefault<EmailManger>(sql.Item1, sql.Item2);
            txt_email.Text = model.Email;
            txt_password.Text = model.PassWord;
            txt_email.BackColor = System.Drawing.SystemColors.Control;
            txt_password.Focus();
            txt_email.KeyPress += txt_logger_KeyPress;
        }

        /// <summary>
        /// 不允许日志被修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_logger_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 3)
                e.Handled = true;
        }


        /// <summary>
        /// 添加按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_addEamil_Click(object sender, EventArgs e)
        {
            var email = txt_email.Text.Trim();
            var password = txt_password.Text.Trim();
            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("邮箱不能为空！", "错误提示");
                return;
            }
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("密码不能为空！", "错误提示");
                return;
            }

            if (!isedit)
            {
                var anysql = new EmailManger { Email = email }.AnySql;
                var any = Db.ExecuteScalar<int>(anysql.Item1, anysql.Item2);
                if (any > 0)
                {
                    MessageBox.Show("邮件已存在！", "错误提示");
                    return;
                }
                var insetSql = new EmailManger { Email = email, PassWord = password, SendMax = 100, SendNumber = 0 }.InsertSql;
                Db.ExecuteNonQuery(insetSql.Item1, insetSql.Item2);
            }
            else
            {
                var updatesql = new EmailManger { Email = email, PassWord = password }.UpdateByEmailSql;
                Db.ExecuteNonQuery(updatesql.Item1, updatesql.Item2);
            }
            this.Close();
        }
    }
}
