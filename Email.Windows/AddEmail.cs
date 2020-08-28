using Email.Windows.Model;
using System;
using System.Text.RegularExpressions;
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
            var sendMax = int.Parse(txt_sendMax.Text.Trim());
            if (!IsEmail(email))
            {
                MessageBox.Show("邮箱格式不正确！", "错误提示");
                return;
            }
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
            if (sendMax <= 0)
            {
                MessageBox.Show("最大发送条数不能小于等于0条！", "错误提示");
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
                var insetSql = new EmailManger { Email = email, PassWord = password, SendMax = sendMax, SendNumber = 0 }.InsertSql;
                Db.ExecuteNonQuery(insetSql.Item1, insetSql.Item2);
            }
            else
            {
                var updatesql = new EmailManger { Email = email, PassWord = password }.UpdateByEmailSql;
                Db.ExecuteNonQuery(updatesql.Item1, updatesql.Item2);
            }
            this.Close();
        }


        /// <summary>
        /// 验证EMail是否合法
        /// </summary>
        /// <param name="email">要验证的Email</param>
        public bool IsEmail(string email)
        {
            //如果为空，认为验证不合格
            if (string.IsNullOrEmpty(email))
                return false;
            //清除要验证字符串中的空格
            email = email.Trim();
            //模式字符串
            string pattern = @"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$";
            //验证
            return Regex.IsMatch(email, pattern);
        }

        private void txt_sendMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            //数字0~9所对应的keychar为48~57，小数点是46，Backspace是8
            e.Handled = true;
            //输入0-9和Backspace del 有效
            if ((e.KeyChar >= 47 && e.KeyChar <= 58) || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            if (e.KeyChar == 46)                       //小数点      
            {
                if (txt_sendMax.Text.Length <= 0)
                    e.Handled = true;           //小数点不能在第一位      
                else
                {
                    float f;
                    if (float.TryParse(txt_sendMax.Text + e.KeyChar.ToString(), out f))
                    {
                        e.Handled = false;
                    }
                }
            }

        }
    }
}
