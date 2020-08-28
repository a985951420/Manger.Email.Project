using Email.Windows.EmailService;
using Email.Windows.Model;
using Email.Windows.Tools;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Email.Windows
{
    public partial class Main : BaseForm
    {
        /// <summary> 
        /// Main
        /// </summary>
        public Main()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Main_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_Load(object sender, EventArgs e)
        {
            LoadTree();
            this.grid_View.AutoGenerateColumns = false;
            lbl_version.Text = "1.0";
        }

        #region EmailTree
        /// <summary>
        /// loadTree
        /// </summary>
        void LoadTree()
        {
            TreeView_Email.Nodes.Clear();
            treeView_EmailSendNumber.Nodes.Clear();
            var sql = new EmailManger().SelectSql;
            var all = Db.ExecuteQuery<EmailManger>(sql);
            foreach (var item in all)
            {
                var node1 = new TreeNode { Text = item.Email, Tag = item };
                var node2 = new TreeNode { Text = "To：" + item.SendNumber + " Total: " + item.SendMax + "  " + item.Email, Tag = item };
                treeView_EmailSendNumber.Nodes.Add(node2);
                TreeView_Email.Nodes.Add(node1);
            }
        }

        /// <summary>
        /// TreeView_Email_MouseDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeView_Email_MouseDown(object sender, MouseEventArgs e)
        {
            var trvOrg = TreeView_Email;
            if (e.Button != MouseButtons.Right) return;
            TreeNode node_here = trvOrg.GetNodeAt(e.X, e.Y);
            trvOrg.SelectedNode = node_here;
            var changePoint = PointToScreen(e.Location);
            cms_add.Show(changePoint);
        }

        /// <summary>
        /// 邮箱点击获取邮件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void TreeView_Email_MouseClick(object sender, MouseEventArgs e)
        {
            if ((sender as TreeView) != null && e.Button != MouseButtons.Right)
            {
                TreeView_Email.SelectedNode = TreeView_Email.GetNodeAt(e.X, e.Y);
                var emailModel = (EmailManger)TreeView_Email.SelectedNode.Tag;
                lbl_email.Text = emailModel.Email;
                lbl_email.Name = emailModel.PassWord;
                lbl_time.Text = emailModel.Synchronization;
                var emailTree = (EmailManger)TreeView_Email.SelectedNode.Tag;
                await InitCurrentPage(emailModel.Email, 1, pageSize).ConfigureAwait(false);
            }
        }
        #endregion

        #region DataGridView
        /// <summary>
        /// grid_View_CellMouseClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_View_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.Button == MouseButtons.Right)
                return;
            var emailModel = (EmailListView)this.grid_View.SelectedRows[0].Cells[0].Tag;

            if (emailModel.Mark == 0)
            {
                //标记为已读
                var markSql = new EmailListView { MessageId = emailModel.MessageId, Mark = 1 }.MarkSql;
                var result = Db.ExecuteNonQuery(markSql.Item1, markSql.Item2);
                this.grid_View.Rows[e.RowIndex].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#ccccd7");
                Logger($"邮件：{emailModel.MessageId} 被标记已读！");
                emailModel.Mark = 1;
                this.grid_View.SelectedRows[0].Cells[0].Tag = emailModel;
            }
            panel_Files.Controls.Clear();
            if (!string.IsNullOrEmpty(emailModel.Files))
            {
                var array = emailModel.Files.Split(',');
                foreach (var item in array)
                {
                    var fullpath = $"{Program.attachmentPath}{emailModel.MainEmail}\\{item}";
                    var suffix = Path.GetExtension(fullpath);
                    var name = Path.GetFileName(fullpath);
                    Button btn = new Button
                    {
                        Dock = DockStyle.Left,
                        Text = name,
                    };
                    btn.Click += (a, b) =>
                    {
                        SaveFileDialog file = new SaveFileDialog();
                        file.Filter = $"文件(*{suffix})|*{suffix}";
                        file.FileName = name;
                        if (file.ShowDialog() == DialogResult.OK)
                            File.Copy(fullpath, file.FileName);
                    };
                    ToolTip p = new ToolTip
                    {
                        ShowAlways = true
                    };
                    p.SetToolTip(btn, name);
                    panel_Files.Controls.Add(btn);
                }
            }

            txt_title.Text = emailModel.Title;
            txt_sender.Text = emailModel.FromEmail;
            txt_sendTime.Text = emailModel.SendTime;


            //var visitor = new HtmlPreviewVisitor();
            //message.Accept(visitor);

            webBrowser1.DocumentText = emailModel.Html;
        }
        /// <summary>
        /// dataGridView1_RowPostPaint
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
                e.RowBounds.Location.Y,
                grid_View.RowHeadersWidth - 4,
                e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                grid_View.RowHeadersDefaultCellStyle.Font,
                rectangle,
                grid_View.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }
        #endregion

        #region GetEmail
        /// <summary>
        /// 同步邮件
        /// </summary>
        /// <param name="model"></param>
        /// <param name="number"></param>
        async Task AsyncEmail(EmailManger model, int? number)
        {
            Logger($"邮箱：{model.Email} 正在获取邮件！");
            await UpdateEmailSynchronization(model.Email).ConfigureAwait(false);
            var service = EmailFactory.Service(model, EnumTools.EailType.Imap);
            try
            {
                await service.mailAsync(async (message, index, count) =>
                {
                    await DbValidation(message).ConfigureAwait(false);
                }, number);
            }
            catch (Exception ex)
            {
                Logger($"邮箱：{model.Email}  获取错误：" + ex.Message);
            }
            Logger($"邮箱：{model.Email} 获取完成！");
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="model">主邮箱</param>
        /// <param name="toEmail">接受邮箱</param>
        /// <param name="title">标题</param>
        /// <param name="body">内容</param>
        /// <returns></returns>
        async Task<string> SendEmail(EmailManger model, string toEmail, string title, string body)
        {
            var service = EmailFactory.Service(model, EnumTools.EailType.Smtp);
            return await service.SendMailAsync(toEmail, title, body).ConfigureAwait(false);
        }
        #endregion

        #region Menu
        /// <summary>
        /// 添加邮箱
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Menu_Add_Click(object sender, EventArgs e)
        {
            AddEmail addemail = new AddEmail();
            addemail.ShowDialog();
            LoadTree();
        }
        /// <summary>
        /// 删除邮箱
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Menu_Delete_Click(object sender, EventArgs e)
        {
            var node = TreeView_Email.SelectedNode;
            if (node == null)
                return;
            var confirmResult = MessageBox.Show("是否 删除：" + node.Text, "提示", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    var email = (EmailManger)node.Tag;
                    var deleteSql = new EmailManger() { Id = email.Id }.DeleteByIdSql;
                    var result = Db.ExecuteNonQuery(deleteSql.Item1, deleteSql.Item2);
                    if (result > 0)
                        LoadTree();
                    else
                        Logger("删除失败！");
                }
                catch (Exception ex)
                {
                    Logger("错误：" + ex.Message);
                }
            }
        }
        /// <summary>
        /// 删除邮箱
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Menu_Update_Click(object sender, EventArgs e)
        {
            var node = TreeView_Email.SelectedNode;
            if (node == null)
                return;
            AddEmail addemail = new AddEmail(node.Text);
            addemail.ShowDialog();
            LoadTree();
        }
        /// <summary>
        /// 获取所有邮件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Menu_GetAllEmail_Click(object sender, EventArgs e)
        {
            var node = TreeView_Email.SelectedNode;
            if (node == null)
                return;
            if (node.Name == "true")
            {
                Logger("正在获取所有邮件请耐心等待！");
                return;
            }
            node.Name = "true";
            var model = (EmailManger)node.Tag;
            await AsyncEmail(model, null);
            node.Name = "";
        }
        /// <summary>
        /// 获取一天前的邮件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Menu_GetEmail_Click(object sender, EventArgs e)
        {
            var node = TreeView_Email.SelectedNode;
            if (node == null)
                return;
            await UpdateEmailSynchronization(node.Text).ConfigureAwait(false);
            var model = (EmailManger)node.Tag;
            await AsyncEmail(model, 10);
        }
        /// <summary>
        /// 获取所有回件邮件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuAllBackEmail_Click(object sender, EventArgs e)
        {
            MessageBox.Show("暂未实现当前功能！", "提示信息");
            //var backSql = new EmailListView { Title = "退信" }.GetBackEmail;
            //var result = Db.ExecuteQuery<EmailListView>(backSql.Item1, backSql.Item2);

            //var email = new List<string>();
            //foreach (var item in result)
            //{
            //    var receiver = item.Body.Split(new char[] { '\r', '\n' }).Where(s => s.Contains("收件人")).FirstOrDefault();
            //    if (receiver != null)
            //        receiver = receiver.Replace("收件人", string.Empty);
            //    var emailAll = receiver.Replace(" ", string.Empty).Split(',');
            //    email.AddRange(emailAll);
            //}
            //Logger(email);
        }
        #endregion

        #region DB
        /// <summary>
        /// 验证数据
        /// </summary>
        /// <param name="emailListView"></param>
        /// <returns></returns>
        async Task DbValidation(EmailListView emailListView)
        {
            await Task.Run(() =>
            {
                var sql = emailListView.Any;
                var anycount = Db.ExecuteScalar<int>(sql.Item1, sql.Item2);
                if (anycount > 0)
                    return;
                var insertSql = emailListView.InsertSql;
                Db.ExecuteNonQuery(insertSql.Item1, insertSql.Item2);
            }).ConfigureAwait(false);
        }

        /// <summary>
        /// 立即同步邮箱更新时间
        /// </summary>
        /// <param name="eamil"></param>
        /// <returns></returns>
        async Task UpdateEmailSynchronization(string email)
        {
            await Task.Run(() =>
            {
                var uptime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                //更新树形结构更新时间
                foreach (TreeNode item in TreeView_Email.Nodes)
                {
                    if (item.Text == email)
                    {
                        var model = (EmailManger)item.Tag;
                        model.Synchronization = uptime;
                        break;
                    }
                }
                var updateSql = new EmailManger { Email = email, Synchronization = uptime }.UpdateBySynchronizationSql;
                Db.ExecuteNonQuery(updateSql.Item1, updateSql.Item2);
            }).ConfigureAwait(false);
        }
        #endregion

        #region Timer
        int UpdateSeconds = 60 * 3;
        /// <summary>
        /// 系统当前时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void dateNow_timer_Tick(object sender, EventArgs e)
        {
            var now = DateTime.Now;
            lbl_now.Text = now.ToString();
            var nowEmail = lbl_email.Text;
            var oldNumber = int.Parse(lbl_Count.Text);
            //更新树形结构更新时间
            foreach (TreeNode item in TreeView_Email.Nodes)
            {
                item.ForeColor = Color.Black;
                if (item.Tag == null)
                    continue;
                var model = (EmailManger)item.Tag;
                if (model.SynchronizationTime == null || model.SynchronizationTime?.AddSeconds(UpdateSeconds) < now)
                {
                    await AsyncEmail(model, 10).ConfigureAwait(false);
                }
                if (model.SendDateTime != null)
                {
                    var upvalue = model.SendDateTime.Value;
                    var thisdays = new DateTime(now.Year, now.Month, now.Day);
                    var updateDays = new DateTime(upvalue.Year, upvalue.Month, upvalue.Day);
                    if (thisdays > updateDays)
                    {
                        var updateNumberSql = new EmailManger { Email = model.Email, SendTime = now.ToString("yyyy-MM-dd HH：mm:ss") }.ResetSendNumber;
                        Db.ExecuteNonQuery(updateNumberSql.Item1, updateNumberSql.Item2);
                    }
                }
            }
            var thisEmailCountSql = new EmailListView { MainEmail = nowEmail }.Count;
            var count = Db.ExecuteScalar<int>(thisEmailCountSql.Item1, thisEmailCountSql.Item2);
            if (oldNumber != count)
                await Marquee(true).ConfigureAwait(false);
        }
        #endregion

        #region 日志输出

        static object _log = new object();

        /// <summary>
        /// 多条连续输出
        /// </summary>
        /// <param name="log"></param>
        void Logger(List<string> log)
        {
            var date = DateTime.Now.ToString("HH:mm:ss");
            lock (_log)
            {
                foreach (var item in log)
                {
                    txt_logger.Text = $"{date}：{item}" + Environment.NewLine + txt_logger.Text;
                }
            }
        }

        /// <summary>
        /// 单挑输出
        /// </summary>
        /// <param name="log"></param>
        void Logger(string log)
        {
            Logger(new List<string> { log });
        }

        /// <summary>
        /// 清空日志
        /// </summary>
        void LoggerEmpty()
        {
            txt_logger.Text = string.Empty;
        }

        static object _sendlog = new object();

        /// <summary>
        /// 多条连续输出
        /// </summary>
        /// <param name="log"></param>
        void SendLogger(List<string> log)
        {
            var date = DateTime.Now.ToString("HH:mm:ss");
            lock (_log)
            {
                foreach (var item in log)
                    txt_sendLogger.Text = $"{date}：{item}" + Environment.NewLine + txt_sendLogger.Text;
            }
        }

        /// <summary>
        /// 单条输出
        /// </summary>
        /// <param name="log"></param>
        void SendLogger(string log)
        {
            SendLogger(new List<string> { log });
        }

        /// <summary>
        /// 清空日志
        /// </summary>
        void SendLoggerEmpty()
        {
            txt_sendLogger.Text = string.Empty;
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
        #endregion

        #region Page
        int pageSize = 50;
        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btn_up_Click(object sender, EventArgs e)
        {
            int.TryParse(txt_current.Text, out int current);
            await InitCurrentPage(lbl_email.Text, --current, pageSize);
        }
        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btn_down_Click(object sender, EventArgs e)
        {
            int.TryParse(txt_current.Text, out int current);
            await InitCurrentPage(lbl_email.Text, ++current, pageSize);
        }

        /// <summary>
        /// 加载当前页
        /// </summary>
        /// <param name="mainEmail"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        async Task InitCurrentPage(string email, int pageIndex, int pageSize)
        {
            await Task.Run(() =>
            {
                var countsql = new EmailListView { MainEmail = email }.Count;
                var count = Db.ExecuteScalar<int>(countsql.Item1, countsql.Item2);
                var totalPage = count / pageSize + (count % pageSize == 0 ? 0 : 1);
                if (totalPage == 0)
                    pageIndex = 1;
                else if (pageIndex > totalPage)
                    pageIndex = totalPage;
                if (pageIndex <= 0)
                    pageIndex = 1;
                var pagesql = new EmailListView().Page(email, pageIndex, pageSize, "SendTime", "DESC");
                var list = Db.ExecuteQuery<EmailListView>(pagesql.Item1, pagesql.Item2);
                this.CallAsync(() =>
                {
                    grid_View.Rows.Clear();
                });
                lbl_Count.Text = count.ToString();
                lbl_totalPage.Text = totalPage.ToString();
                txt_current.Text = pageIndex.ToString();
                var rows = new List<DataGridViewRow>();
                foreach (var item in list)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(grid_View);
                    row.Cells[0].Value = item.Title;
                    row.Cells[0].Tag = item;
                    row.Cells[1].Value = item.SendTime;
                    if (item.Mark == 1)
                        row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#ccccd7");
                    rows.Add(row);
                }
                this.CallAsync(() =>
                {
                    grid_View.Rows.AddRange(rows.ToArray());
                });
                grid_View.ClearSelection();
            }).ConfigureAwait(false);
        }
        #endregion

        #region 提示新邮件
        public async Task Marquee(bool show)
        {
            if (show)
                await InitCurrentPage(lbl_email.Text, 1, pageSize).ConfigureAwait(false);
            //if (show)
            //    marqueeLabel1.Show();
            //else
            //    marqueeLabel1.Hide();
        }
        #endregion

        #region  notifyIcon
        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.Show();
                //还原窗体显示    
                WindowState = FormWindowState.Normal;
                //激活窗体并给予它焦点
                this.Activate();
                //任务栏区显示图标
                this.ShowInTaskbar = true;
                //托盘区图标隐藏
                notifyIcon.Visible = false;
            }
        }
        #endregion

        private void Main_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                this.ShowInTaskbar = false;
                this.notifyIcon.Visible = true;
            }
        }

        /// <summary>
        /// 清空日志
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Menu_empty_Click(object sender, EventArgs e)
        {
            LoggerEmpty();
        }

        private void btn_GetContent_Click(object sender, EventArgs e)
        {
            var html = htmlEditor1.GetHtml();
        }

        private void btn_setHtml_Click(object sender, EventArgs e)
        {
            htmlEditor1.SetContent("尼玛阿斯蒂芬");
        }

        private void btn_addUserEmail_Click(object sender, EventArgs e)
        {
            Button btn = new Button
            {
                Text = "随机",
                Dock = DockStyle.Left
            };
            pan_UserEmail.Controls.Add(btn);
        }

        private void pan_UserEmail_Click(object sender, EventArgs e)
        {

            var listEmail = new List<string>();
            foreach (var item in pan_UserEmail.Controls)
            {
                if (item is Button)
                    listEmail.Add((item as Button).Text);
            }

            var email_List = new Email_List(listEmail);
            email_List.ShowDialog();
            pan_UserEmail.Controls.Clear();
            foreach (var item in email_List.emailAll)
            {
                Button btn = new Button
                {
                    Text = item,
                    Dock = DockStyle.Left
                };
                pan_UserEmail.Controls.Add(btn);
            }
        }

        /// <summary>
        /// 发送邮件的所有邮箱
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btn_Send_Click(object sender, EventArgs e)
        {
            StatusControl(false);
            var maxSendNumber = 0M;
            var sendAllEmail = new List<TreeNode>();
            var sendUserAll = new List<string>();
            foreach (var item in pan_UserEmail.Controls)
            {
                if (item is Button)
                    sendUserAll.Add((item as Button).Text);
            }
            foreach (TreeNode item in TreeView_Email.Nodes)
            {
                var model = (EmailManger)item.Tag;
                if (model.SendMax > model.SendNumber)
                {
                    maxSendNumber += model.SendMax - model.SendNumber;
                    sendAllEmail.Add(item);
                }
            }
            if (sendAllEmail.Count <= 0)
            {
                MessageBox.Show("邮件次数都已经发送完了无法发送！");
                return;
            }
            if (sendUserAll.Count <= 0)
            {
                MessageBox.Show("收件人不存在！");
                return;
            }
            if (maxSendNumber < sendUserAll.Count)
            {
                var confirmResult = MessageBox.Show($"收件人：{sendUserAll.Count}个,邮件可发送:{maxSendNumber},是否还要继续发送。", "提示", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                    goto send;
            }
        send:
            SendLogger($"收件人：{sendUserAll.Count} 条！准备发送。");
            TreeNode thisNode = null;
            foreach (var item in sendUserAll)
            {
                if (thisNode == null)
                {
                    thisNode = sendAllEmail.FirstOrDefault(s => (s.Tag as EmailManger).SendMax > (s.Tag as EmailManger).SendNumber);
                    if (thisNode == null)
                    {
                        SendLogger("没有可以发送的邮箱了！");
                        goto enabled;
                    }
                }
                var model = (EmailManger)thisNode.Tag;
                model.SendNumber += 1;
                var html = string.Empty;
                this.CallAsync(() =>
                {
                    html = htmlEditor1.GetHtml();
                });
                var result = string.Empty;
                var now = DateTime.Now.ToString("yyyy-MM-dd");
                try
                {
                    result = await SendEmail(model, item, txt_sendTitle.Text, html).ConfigureAwait(false);
                    var updateNumberSql = new EmailManger { Email = model.Email, SendTime = now }.UpdateSendNumber;
                    Db.ExecuteNonQuery(updateNumberSql.Item1, updateNumberSql.Item2);
                }
                catch (Exception ex)
                {
                    result += ex.Message;
                }
                SendLogger($"发送邮箱：{model.Email} 当前第：{model.SendNumber}  发送给：{item}   错误：{result}");
                foreach (TreeNode itemcc in treeView_EmailSendNumber.Nodes)
                {
                    var sss = (EmailManger)itemcc.Tag;
                    if (sss.Email == model.Email)
                    {
                        var text = $"To：" + model.SendNumber + " Total: " + model.SendMax + "  " + model.Email;
                        this.CallAsync(() =>
                        {
                            itemcc.Text = text;
                            itemcc.Tag = model;
                        });
                    }
                }
            }
        enabled:
            StatusControl(true);
        }

        void StatusControl(bool enabled)
        {
            this.CallAsync(() =>
            {
                foreach (Control item in tab_send.Controls)
                    item.Enabled = enabled;
            });
        }
    }
}