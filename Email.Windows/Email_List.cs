using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Email.Windows
{
    public partial class Email_List : BaseForm
    {
        Action<string> action = null;
        /// <summary>
        /// 所有邮箱
        /// </summary>
        public List<string> emailAll = new List<string>();
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="emails"></param>
        public Email_List(List<string> emails)
        {
            if (emails.Count <= 0)
                emails.Add(string.Empty);
            InitializeComponent();
            action = (email) =>
            {
                Panel showPanel = new Panel
                {
                    Dock = DockStyle.Top,
                    Height = 50,
                    BorderStyle = BorderStyle.None
                };
                Label lbl_Title = new Label
                {
                    AutoSize = true,
                    Size = new System.Drawing.Size(41, 12),
                    Location = new System.Drawing.Point(10, 20),
                    Text = "邮箱："
                };
                TextBox textBox = new TextBox
                {
                    Size = new System.Drawing.Size(270, 21),
                    Location = new System.Drawing.Point(52, 16),
                    Text = email
                };
                Button buttondel = new Button
                {
                    Size = new System.Drawing.Size(25, 23),
                    Location = new System.Drawing.Point(325, 14),
                    Text = "-",
                };
                buttondel.Click += (a, b) =>
                {
                    if (this.panel1.Controls.Count > 1)
                        this.panel1.Controls.Remove(showPanel);
                };
                Button buttonadd = new Button
                {
                    Size = new System.Drawing.Size(25, 23),
                    Location = new System.Drawing.Point(350, 14),
                    Text = "+",
                };
                var lineControl = new Control[] { lbl_Title, textBox, buttondel, buttonadd };
                showPanel.Controls.AddRange(lineControl);
                this.panel1.Controls.Add(showPanel);
                buttonadd.Click += (a, b) =>
                {
                    action(string.Empty);
                };
            };

            foreach (var item in emails)
            {
                action(item);
            }
        }

        private void btn_email_Click(object sender, EventArgs e)
        {
            foreach (Control item in panel1.Controls)
            {
                foreach (var itemControl in item.Controls)
                {
                    if (itemControl is TextBox)
                    {
                        var email = (itemControl as TextBox).Text;
                        if (!emailAll.Contains(email))
                        {
                            if (!string.IsNullOrEmpty(email))
                                emailAll.Add(email);
                        }
                    }
                }
            }
            this.Close();
        }

        public static Regex _regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", RegexOptions.CultureInvariant | RegexOptions.Compiled);
        private void bulk_splt_Click(object sender, EventArgs e)
        {
            var text = txt_emailSplit.Text;
            var email = text.Split(',');
            foreach (var item in email)
            {
                if (!_regex.IsMatch(item))
                {
                    MessageBox.Show($"邮箱：{item} 格式不正确！");
                    return;
                }
            }
            this.panel1.Controls.Clear();
            foreach (var item in email)
            {
                if (!string.IsNullOrEmpty(item))
                    action(item);
            }
        }
    }
}
