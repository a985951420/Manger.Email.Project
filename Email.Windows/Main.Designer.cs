using ComponentFactory.Krypton.Toolkit;
using Email.Windows.Tools;
using System.Windows.Forms;

namespace Email.Windows
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.log_cms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Menu_empty = new System.Windows.Forms.ToolStripMenuItem();
            this.dateNow_timer = new System.Windows.Forms.Timer(this.components);
            this.cms_add = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Menu_GetEmail = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuAllBackEmail = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Add = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Update = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_GetAllEmail = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.tabControl_Main = new System.Windows.Forms.TabControl();
            this.tab_Inbox = new System.Windows.Forms.TabPage();
            this.kryptonGroupBox2 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.panel_Files = new System.Windows.Forms.Panel();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.txt_sendTime = new Email.Windows.Tools.AsyncTextBoxControl();
            this.txt_sender = new Email.Windows.Tools.AsyncTextBoxControl();
            this.txt_title = new Email.Windows.Tools.AsyncTextBoxControl();
            this.label8 = new Email.Windows.Tools.AsyncLabelControl();
            this.label7 = new Email.Windows.Tools.AsyncLabelControl();
            this.label6 = new Email.Windows.Tools.AsyncLabelControl();
            this.label5 = new Email.Windows.Tools.AsyncLabelControl();
            this.kryptonGroupBox1 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.kryptonGroupBox4 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.txt_logger = new Email.Windows.Tools.AsyncTextBoxControl();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lbl_thisNumber = new Email.Windows.Tools.AsyncLabelControl();
            this.TreeView_Email = new System.Windows.Forms.TreeView();
            this.lbl_progressbar = new Email.Windows.Tools.AsyncProgressBarControl();
            this.txt_current = new Email.Windows.Tools.AsyncTextBoxControl();
            this.lbl_time = new Email.Windows.Tools.AsyncLabelControl();
            this.btn_up = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.lbl_Count = new Email.Windows.Tools.AsyncLabelControl();
            this.lbl_email = new Email.Windows.Tools.AsyncTextBoxControl();
            this.grid_View = new Email.Windows.Tools.AsyncDataGridView();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SendTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_down = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.label9 = new Email.Windows.Tools.AsyncLabelControl();
            this.label13 = new Email.Windows.Tools.AsyncLabelControl();
            this.label2 = new Email.Windows.Tools.AsyncLabelControl();
            this.marqueeLabel1 = new Email.Windows.Tools.MarqueeLabel();
            this.label10 = new Email.Windows.Tools.AsyncLabelControl();
            this.lbl_totalPage = new Email.Windows.Tools.AsyncLabelControl();
            this.label11 = new Email.Windows.Tools.AsyncLabelControl();
            this.tab_send = new System.Windows.Forms.TabPage();
            this.txt_sendLogger = new AsyncTextBoxControl();
            this.btn_Send = new System.Windows.Forms.Button();
            this.pan_UserEmail = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_sendTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.treeView_EmailSendNumber = new System.Windows.Forms.TreeView();
            this.htmlEditor1 = new Email.Windows.Tools.HTMLEditor();
            this.kryptonGroupBox3 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.lbl_version = new Email.Windows.Tools.AsyncLabelControl();
            this.lbl_v = new Email.Windows.Tools.AsyncLabelControl();
            this.label4 = new Email.Windows.Tools.AsyncLabelControl();
            this.lbl_now = new Email.Windows.Tools.AsyncLabelControl();
            this.log_cms.SuspendLayout();
            this.cms_add.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.tabControl_Main.SuspendLayout();
            this.tab_Inbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2.Panel)).BeginInit();
            this.kryptonGroupBox2.Panel.SuspendLayout();
            this.kryptonGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox4.Panel)).BeginInit();
            this.kryptonGroupBox4.Panel.SuspendLayout();
            this.kryptonGroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_View)).BeginInit();
            this.tab_send.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox3.Panel)).BeginInit();
            this.kryptonGroupBox3.Panel.SuspendLayout();
            this.kryptonGroupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // log_cms
            // 
            this.log_cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_empty});
            this.log_cms.Name = "log_cms";
            this.log_cms.Size = new System.Drawing.Size(125, 26);
            // 
            // Menu_empty
            // 
            this.Menu_empty.Name = "Menu_empty";
            this.Menu_empty.Size = new System.Drawing.Size(124, 22);
            this.Menu_empty.Text = "清空日志";
            this.Menu_empty.Click += new System.EventHandler(this.Menu_empty_Click);
            // 
            // dateNow_timer
            // 
            this.dateNow_timer.Enabled = true;
            this.dateNow_timer.Interval = 1000;
            this.dateNow_timer.Tick += new System.EventHandler(this.dateNow_timer_Tick);
            // 
            // cms_add
            // 
            this.cms_add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.cms_add.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_GetEmail,
            this.MenuAllBackEmail,
            this.Menu_Add,
            this.Menu_Update,
            this.Menu_Delete,
            this.Menu_GetAllEmail});
            this.cms_add.Name = "cms_add";
            this.cms_add.Size = new System.Drawing.Size(149, 136);
            // 
            // Menu_GetEmail
            // 
            this.Menu_GetEmail.Name = "Menu_GetEmail";
            this.Menu_GetEmail.Size = new System.Drawing.Size(148, 22);
            this.Menu_GetEmail.Text = "获取最近邮件";
            this.Menu_GetEmail.Click += new System.EventHandler(this.Menu_GetEmail_Click);
            // 
            // MenuAllBackEmail
            // 
            this.MenuAllBackEmail.Name = "MenuAllBackEmail";
            this.MenuAllBackEmail.Size = new System.Drawing.Size(148, 22);
            this.MenuAllBackEmail.Text = "退件邮箱获取";
            this.MenuAllBackEmail.Click += new System.EventHandler(this.MenuAllBackEmail_Click);
            // 
            // Menu_Add
            // 
            this.Menu_Add.Name = "Menu_Add";
            this.Menu_Add.Size = new System.Drawing.Size(148, 22);
            this.Menu_Add.Text = "添加";
            this.Menu_Add.Click += new System.EventHandler(this.Menu_Add_Click);
            // 
            // Menu_Update
            // 
            this.Menu_Update.Name = "Menu_Update";
            this.Menu_Update.Size = new System.Drawing.Size(148, 22);
            this.Menu_Update.Text = "修改";
            this.Menu_Update.Click += new System.EventHandler(this.Menu_Update_Click);
            // 
            // Menu_Delete
            // 
            this.Menu_Delete.Name = "Menu_Delete";
            this.Menu_Delete.Size = new System.Drawing.Size(148, 22);
            this.Menu_Delete.Text = "删除";
            this.Menu_Delete.Click += new System.EventHandler(this.Menu_Delete_Click);
            // 
            // Menu_GetAllEmail
            // 
            this.Menu_GetAllEmail.Name = "Menu_GetAllEmail";
            this.Menu_GetAllEmail.Size = new System.Drawing.Size(148, 22);
            this.Menu_GetAllEmail.Text = "获取所有邮件";
            this.Menu_GetAllEmail.Click += new System.EventHandler(this.Menu_GetAllEmail_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "邮件管理助手";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.tabControl_Main);
            this.kryptonPanel1.Controls.Add(this.kryptonGroupBox3);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(1390, 716);
            this.kryptonPanel1.TabIndex = 42;
            // 
            // tabControl_Main
            // 
            this.tabControl_Main.Controls.Add(this.tab_Inbox);
            this.tabControl_Main.Controls.Add(this.tab_send);
            this.tabControl_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_Main.Location = new System.Drawing.Point(0, 0);
            this.tabControl_Main.Name = "tabControl_Main";
            this.tabControl_Main.SelectedIndex = 0;
            this.tabControl_Main.Size = new System.Drawing.Size(1390, 668);
            this.tabControl_Main.TabIndex = 47;
            // 
            // tab_Inbox
            // 
            this.tab_Inbox.Controls.Add(this.kryptonGroupBox2);
            this.tab_Inbox.Controls.Add(this.kryptonGroupBox1);
            this.tab_Inbox.Location = new System.Drawing.Point(4, 22);
            this.tab_Inbox.Name = "tab_Inbox";
            this.tab_Inbox.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Inbox.Size = new System.Drawing.Size(1382, 642);
            this.tab_Inbox.TabIndex = 0;
            this.tab_Inbox.Text = "收件箱";
            this.tab_Inbox.UseVisualStyleBackColor = true;
            // 
            // kryptonGroupBox2
            // 
            this.kryptonGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonGroupBox2.Location = new System.Drawing.Point(439, 3);
            this.kryptonGroupBox2.Name = "kryptonGroupBox2";
            // 
            // kryptonGroupBox2.Panel
            // 
            this.kryptonGroupBox2.Panel.Controls.Add(this.panel_Files);
            this.kryptonGroupBox2.Panel.Controls.Add(this.webBrowser1);
            this.kryptonGroupBox2.Panel.Controls.Add(this.txt_sendTime);
            this.kryptonGroupBox2.Panel.Controls.Add(this.txt_sender);
            this.kryptonGroupBox2.Panel.Controls.Add(this.txt_title);
            this.kryptonGroupBox2.Panel.Controls.Add(this.label8);
            this.kryptonGroupBox2.Panel.Controls.Add(this.label7);
            this.kryptonGroupBox2.Panel.Controls.Add(this.label6);
            this.kryptonGroupBox2.Panel.Controls.Add(this.label5);
            this.kryptonGroupBox2.Size = new System.Drawing.Size(940, 636);
            this.kryptonGroupBox2.TabIndex = 40;
            this.kryptonGroupBox2.Values.Heading = "邮件详情";
            // 
            // panel_Files
            // 
            this.panel_Files.Location = new System.Drawing.Point(80, 72);
            this.panel_Files.Margin = new System.Windows.Forms.Padding(2);
            this.panel_Files.Name = "panel_Files";
            this.panel_Files.Size = new System.Drawing.Size(860, 23);
            this.panel_Files.TabIndex = 46;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.webBrowser1.Location = new System.Drawing.Point(0, 99);
            this.webBrowser1.Margin = new System.Windows.Forms.Padding(2);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(12, 12);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(936, 513);
            this.webBrowser1.TabIndex = 45;
            this.webBrowser1.Url = new System.Uri("", System.UriKind.Relative);
            // 
            // txt_sendTime
            // 
            this.txt_sendTime.BackColor = System.Drawing.SystemColors.Control;
            this.txt_sendTime.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_sendTime.Location = new System.Drawing.Point(79, 48);
            this.txt_sendTime.Margin = new System.Windows.Forms.Padding(2);
            this.txt_sendTime.Name = "txt_sendTime";
            this.txt_sendTime.Size = new System.Drawing.Size(861, 23);
            this.txt_sendTime.TabIndex = 44;
            // 
            // txt_sender
            // 
            this.txt_sender.BackColor = System.Drawing.SystemColors.Control;
            this.txt_sender.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_sender.Location = new System.Drawing.Point(79, 27);
            this.txt_sender.Margin = new System.Windows.Forms.Padding(2);
            this.txt_sender.Name = "txt_sender";
            this.txt_sender.Size = new System.Drawing.Size(861, 23);
            this.txt_sender.TabIndex = 43;
            // 
            // txt_title
            // 
            this.txt_title.BackColor = System.Drawing.SystemColors.Control;
            this.txt_title.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_title.Location = new System.Drawing.Point(79, 6);
            this.txt_title.Margin = new System.Windows.Forms.Padding(2);
            this.txt_title.Name = "txt_title";
            this.txt_title.Size = new System.Drawing.Size(861, 23);
            this.txt_title.TabIndex = 42;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(32, 73);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 20);
            this.label8.TabIndex = 41;
            this.label8.Text = "附件:";
            this.label8.Values.Text = "附件:";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(7, 48);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 20);
            this.label7.TabIndex = 40;
            this.label7.Text = "发件时间:";
            this.label7.Values.Text = "发件时间:";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(32, 6);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 20);
            this.label6.TabIndex = 39;
            this.label6.Text = "标题:";
            this.label6.Values.Text = "标题:";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(5, 27);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 20);
            this.label5.TabIndex = 38;
            this.label5.Text = "发  件  人:";
            this.label5.Values.Text = "发  件  人:";
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.kryptonGroupBox1.Location = new System.Drawing.Point(3, 3);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonGroupBox4);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonLabel2);
            this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonLabel1);
            this.kryptonGroupBox1.Panel.Controls.Add(this.lbl_thisNumber);
            this.kryptonGroupBox1.Panel.Controls.Add(this.TreeView_Email);
            this.kryptonGroupBox1.Panel.Controls.Add(this.lbl_progressbar);
            this.kryptonGroupBox1.Panel.Controls.Add(this.txt_current);
            this.kryptonGroupBox1.Panel.Controls.Add(this.lbl_time);
            this.kryptonGroupBox1.Panel.Controls.Add(this.btn_up);
            this.kryptonGroupBox1.Panel.Controls.Add(this.lbl_Count);
            this.kryptonGroupBox1.Panel.Controls.Add(this.lbl_email);
            this.kryptonGroupBox1.Panel.Controls.Add(this.grid_View);
            this.kryptonGroupBox1.Panel.Controls.Add(this.btn_down);
            this.kryptonGroupBox1.Panel.Controls.Add(this.label9);
            this.kryptonGroupBox1.Panel.Controls.Add(this.label13);
            this.kryptonGroupBox1.Panel.Controls.Add(this.label2);
            this.kryptonGroupBox1.Panel.Controls.Add(this.marqueeLabel1);
            this.kryptonGroupBox1.Panel.Controls.Add(this.label10);
            this.kryptonGroupBox1.Panel.Controls.Add(this.lbl_totalPage);
            this.kryptonGroupBox1.Panel.Controls.Add(this.label11);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(436, 636);
            this.kryptonGroupBox1.TabIndex = 39;
            this.kryptonGroupBox1.Values.Heading = "邮箱信息";
            // 
            // kryptonGroupBox4
            // 
            this.kryptonGroupBox4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonGroupBox4.Location = new System.Drawing.Point(0, 454);
            this.kryptonGroupBox4.Name = "kryptonGroupBox4";
            // 
            // kryptonGroupBox4.Panel
            // 
            this.kryptonGroupBox4.Panel.Controls.Add(this.txt_logger);
            this.kryptonGroupBox4.Size = new System.Drawing.Size(432, 158);
            this.kryptonGroupBox4.TabIndex = 61;
            this.kryptonGroupBox4.Values.Heading = "日志";
            // 
            // txt_logger
            // 
            this.txt_logger.ContextMenuStrip = this.log_cms;
            this.txt_logger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_logger.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_logger.Location = new System.Drawing.Point(0, 0);
            this.txt_logger.Margin = new System.Windows.Forms.Padding(2);
            this.txt_logger.Multiline = true;
            this.txt_logger.Name = "txt_logger";
            this.txt_logger.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_logger.Size = new System.Drawing.Size(428, 134);
            this.txt_logger.TabIndex = 13;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(137, 35);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(75, 20);
            this.kryptonLabel2.TabIndex = 60;
            this.kryptonLabel2.Values.Text = "同步时间：";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(137, 6);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(75, 20);
            this.kryptonLabel1.TabIndex = 47;
            this.kryptonLabel1.Values.Text = "当前邮箱：";
            // 
            // lbl_thisNumber
            // 
            this.lbl_thisNumber.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_thisNumber.Location = new System.Drawing.Point(2, 431);
            this.lbl_thisNumber.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_thisNumber.Name = "lbl_thisNumber";
            this.lbl_thisNumber.Size = new System.Drawing.Size(49, 20);
            this.lbl_thisNumber.TabIndex = 57;
            this.lbl_thisNumber.Text = "第几封";
            this.lbl_thisNumber.Values.Text = "第几封";
            this.lbl_thisNumber.Visible = false;
            // 
            // TreeView_Email
            // 
            this.TreeView_Email.BackColor = System.Drawing.SystemColors.Window;
            this.TreeView_Email.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TreeView_Email.Location = new System.Drawing.Point(2, 2);
            this.TreeView_Email.Margin = new System.Windows.Forms.Padding(2);
            this.TreeView_Email.Name = "TreeView_Email";
            this.TreeView_Email.Size = new System.Drawing.Size(130, 79);
            this.TreeView_Email.TabIndex = 40;
            this.TreeView_Email.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TreeView_Email_MouseClick);
            this.TreeView_Email.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TreeView_Email_MouseDown);
            // 
            // lbl_progressbar
            // 
            this.lbl_progressbar.Location = new System.Drawing.Point(2, 422);
            this.lbl_progressbar.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_progressbar.Maximum = 1000;
            this.lbl_progressbar.Name = "lbl_progressbar";
            this.lbl_progressbar.Size = new System.Drawing.Size(192, 10);
            this.lbl_progressbar.TabIndex = 58;
            this.lbl_progressbar.Visible = false;
            // 
            // txt_current
            // 
            this.txt_current.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_current.Location = new System.Drawing.Point(266, 420);
            this.txt_current.Margin = new System.Windows.Forms.Padding(2);
            this.txt_current.Name = "txt_current";
            this.txt_current.Size = new System.Drawing.Size(23, 23);
            this.txt_current.TabIndex = 47;
            this.txt_current.Text = "1";
            this.txt_current.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbl_time
            // 
            this.lbl_time.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_time.Location = new System.Drawing.Point(208, 35);
            this.lbl_time.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_time.Name = "lbl_time";
            this.lbl_time.Size = new System.Drawing.Size(36, 20);
            this.lbl_time.TabIndex = 45;
            this.lbl_time.Text = "日期";
            this.lbl_time.Values.Text = "日期";
            // 
            // btn_up
            // 
            this.btn_up.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_up.Location = new System.Drawing.Point(212, 420);
            this.btn_up.Margin = new System.Windows.Forms.Padding(2);
            this.btn_up.Name = "btn_up";
            this.btn_up.Size = new System.Drawing.Size(23, 23);
            this.btn_up.TabIndex = 48;
            this.btn_up.Values.Text = "上";
            // 
            // lbl_Count
            // 
            this.lbl_Count.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Count.Location = new System.Drawing.Point(208, 61);
            this.lbl_Count.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Count.Name = "lbl_Count";
            this.lbl_Count.Size = new System.Drawing.Size(17, 20);
            this.lbl_Count.TabIndex = 42;
            this.lbl_Count.Text = "0";
            this.lbl_Count.Values.Text = "0";
            // 
            // lbl_email
            // 
            this.lbl_email.BackColor = this.BackColor;
            this.lbl_email.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_email.Location = new System.Drawing.Point(212, 7);
            this.lbl_email.Margin = new System.Windows.Forms.Padding(2);
            this.lbl_email.Name = "lbl_email";
            this.lbl_email.ReadOnly = true;
            this.lbl_email.Size = new System.Drawing.Size(200, 23);
            this.lbl_email.TabIndex = 55;
            this.lbl_email.TabStop = false;
            this.lbl_email.Text = "email";
            // 
            // grid_View
            // 
            this.grid_View.AllowUserToAddRows = false;
            this.grid_View.AllowUserToDeleteRows = false;
            this.grid_View.AllowUserToResizeColumns = false;
            this.grid_View.AllowUserToResizeRows = false;
            this.grid_View.BackgroundColor = System.Drawing.SystemColors.Control;
            this.grid_View.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grid_View.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.grid_View.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_View.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Title,
            this.SendTime});
            this.grid_View.Location = new System.Drawing.Point(0, 86);
            this.grid_View.Margin = new System.Windows.Forms.Padding(2);
            this.grid_View.Name = "grid_View";
            this.grid_View.ReadOnly = true;
            this.grid_View.RowHeadersVisible = false;
            this.grid_View.RowTemplate.Height = 23;
            this.grid_View.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid_View.Size = new System.Drawing.Size(418, 330);
            this.grid_View.TabIndex = 43;
            this.grid_View.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grid_View_CellMouseClick);
            // 
            // Title
            // 
            this.Title.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Title.DataPropertyName = "Title";
            this.Title.HeaderText = "标题";
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            this.Title.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // SendTime
            // 
            this.SendTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SendTime.DataPropertyName = "SendTime";
            this.SendTime.HeaderText = "发件时间";
            this.SendTime.Name = "SendTime";
            this.SendTime.ReadOnly = true;
            this.SendTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // btn_down
            // 
            this.btn_down.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_down.Location = new System.Drawing.Point(320, 420);
            this.btn_down.Margin = new System.Windows.Forms.Padding(2);
            this.btn_down.Name = "btn_down";
            this.btn_down.Size = new System.Drawing.Size(23, 23);
            this.btn_down.TabIndex = 49;
            this.btn_down.Values.Text = "下";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(239, 421);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 20);
            this.label9.TabIndex = 50;
            this.label9.Text = "第";
            this.label9.Values.Text = "第";
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(395, 421);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(23, 20);
            this.label13.TabIndex = 54;
            this.label13.Text = "页";
            this.label13.Values.Text = "页";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(150, 61);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 20);
            this.label2.TabIndex = 41;
            this.label2.Text = "邮件数：";
            this.label2.Values.Text = "邮件数：";
            // 
            // marqueeLabel1
            // 
            this.marqueeLabel1.AutoSize = true;
            this.marqueeLabel1.Location = new System.Drawing.Point(335, 69);
            this.marqueeLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.marqueeLabel1.Name = "marqueeLabel1";
            this.marqueeLabel1.Size = new System.Drawing.Size(77, 12);
            this.marqueeLabel1.TabIndex = 56;
            this.marqueeLabel1.Text = "有新邮件了！";
            this.marqueeLabel1.Visible = false;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(293, 421);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(23, 20);
            this.label10.TabIndex = 51;
            this.label10.Text = "页";
            this.label10.Values.Text = "页";
            // 
            // lbl_totalPage
            // 
            this.lbl_totalPage.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_totalPage.Location = new System.Drawing.Point(374, 421);
            this.lbl_totalPage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_totalPage.Name = "lbl_totalPage";
            this.lbl_totalPage.Size = new System.Drawing.Size(17, 20);
            this.lbl_totalPage.TabIndex = 53;
            this.lbl_totalPage.Text = "0";
            this.lbl_totalPage.Values.Text = "0";
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(347, 421);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(23, 20);
            this.label11.TabIndex = 52;
            this.label11.Text = "共";
            this.label11.Values.Text = "共";
            // 
            // tab_send
            // 
            this.tab_send.Controls.Add(this.txt_sendLogger);
            this.tab_send.Controls.Add(this.btn_Send);
            this.tab_send.Controls.Add(this.pan_UserEmail);
            this.tab_send.Controls.Add(this.label3);
            this.tab_send.Controls.Add(this.txt_sendTitle);
            this.tab_send.Controls.Add(this.label1);
            this.tab_send.Controls.Add(this.panel1);
            this.tab_send.Controls.Add(this.htmlEditor1);
            this.tab_send.Location = new System.Drawing.Point(4, 22);
            this.tab_send.Name = "tab_send";
            this.tab_send.Padding = new System.Windows.Forms.Padding(3);
            this.tab_send.Size = new System.Drawing.Size(1382, 642);
            this.tab_send.TabIndex = 1;
            this.tab_send.Text = "发件箱";
            this.tab_send.UseVisualStyleBackColor = true;
            // 
            // txt_sendLogger
            // 
            this.txt_sendLogger.Location = new System.Drawing.Point(290, 562);
            this.txt_sendLogger.Multiline = true;
            this.txt_sendLogger.Name = "txt_sendLogger";
            this.txt_sendLogger.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_sendLogger.Size = new System.Drawing.Size(1084, 77);
            this.txt_sendLogger.TabIndex = 7;
            this.txt_sendLogger.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_logger_KeyPress);
            // 
            // btn_Send
            // 
            this.btn_Send.Location = new System.Drawing.Point(209, 560);
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.Size = new System.Drawing.Size(75, 23);
            this.btn_Send.TabIndex = 6;
            this.btn_Send.Text = "发送";
            this.btn_Send.UseVisualStyleBackColor = true;
            this.btn_Send.Click += new System.EventHandler(this.btn_Send_Click);
            // 
            // pan_UserEmail
            // 
            this.pan_UserEmail.BackColor = System.Drawing.Color.Transparent;
            this.pan_UserEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pan_UserEmail.Location = new System.Drawing.Point(256, 38);
            this.pan_UserEmail.Name = "pan_UserEmail";
            this.pan_UserEmail.Size = new System.Drawing.Size(1118, 32);
            this.pan_UserEmail.TabIndex = 5;
            this.pan_UserEmail.Click += new System.EventHandler(this.pan_UserEmail_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(209, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "收件人：";
            // 
            // txt_sendTitle
            // 
            this.txt_sendTitle.Location = new System.Drawing.Point(256, 11);
            this.txt_sendTitle.Name = "txt_sendTitle";
            this.txt_sendTitle.Size = new System.Drawing.Size(1118, 21);
            this.txt_sendTitle.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(221, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "标题：";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.treeView_EmailSendNumber);
            this.panel1.Location = new System.Drawing.Point(0, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(203, 601);
            this.panel1.TabIndex = 1;
            // 
            // treeView_EmailSendNumber
            // 
            this.treeView_EmailSendNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_EmailSendNumber.Location = new System.Drawing.Point(0, 0);
            this.treeView_EmailSendNumber.Name = "treeView_EmailSendNumber";
            this.treeView_EmailSendNumber.Size = new System.Drawing.Size(203, 601);
            this.treeView_EmailSendNumber.TabIndex = 0;
            // 
            // htmlEditor1
            // 
            this.htmlEditor1.Location = new System.Drawing.Point(209, 76);
            this.htmlEditor1.MinimumSize = new System.Drawing.Size(20, 20);
            this.htmlEditor1.Name = "htmlEditor1";
            this.htmlEditor1.Size = new System.Drawing.Size(1165, 478);
            this.htmlEditor1.TabIndex = 0;
            // 
            // kryptonGroupBox3
            // 
            this.kryptonGroupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonGroupBox3.Location = new System.Drawing.Point(0, 668);
            this.kryptonGroupBox3.Name = "kryptonGroupBox3";
            // 
            // kryptonGroupBox3.Panel
            // 
            this.kryptonGroupBox3.Panel.Controls.Add(this.lbl_version);
            this.kryptonGroupBox3.Panel.Controls.Add(this.lbl_v);
            this.kryptonGroupBox3.Panel.Controls.Add(this.label4);
            this.kryptonGroupBox3.Panel.Controls.Add(this.lbl_now);
            this.kryptonGroupBox3.Size = new System.Drawing.Size(1390, 48);
            this.kryptonGroupBox3.TabIndex = 40;
            this.kryptonGroupBox3.Values.Heading = "信息";
            // 
            // lbl_version
            // 
            this.lbl_version.Location = new System.Drawing.Point(1327, 1);
            this.lbl_version.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_version.Name = "lbl_version";
            this.lbl_version.Size = new System.Drawing.Size(49, 20);
            this.lbl_version.TabIndex = 23;
            this.lbl_version.Text = "版本号";
            this.lbl_version.Values.Text = "版本号";
            // 
            // lbl_v
            // 
            this.lbl_v.Location = new System.Drawing.Point(1283, 1);
            this.lbl_v.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_v.Name = "lbl_v";
            this.lbl_v.Size = new System.Drawing.Size(49, 20);
            this.lbl_v.TabIndex = 22;
            this.lbl_v.Text = "版本：";
            this.lbl_v.Values.Text = "版本：";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(2, 2);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 20);
            this.label4.TabIndex = 20;
            this.label4.Text = "当前时间：";
            this.label4.Values.Text = "当前时间：";
            // 
            // lbl_now
            // 
            this.lbl_now.Location = new System.Drawing.Point(73, 2);
            this.lbl_now.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_now.Name = "lbl_now";
            this.lbl_now.Size = new System.Drawing.Size(60, 20);
            this.lbl_now.TabIndex = 21;
            this.lbl_now.Text = "2020-7-6";
            this.lbl_now.Values.Text = "2020-7-6";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1390, 716);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "邮箱管理助手";
            this.Load += new System.EventHandler(this.Main_Load);
            this.Resize += new System.EventHandler(this.Main_Resize);
            this.log_cms.ResumeLayout(false);
            this.cms_add.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.tabControl_Main.ResumeLayout(false);
            this.tab_Inbox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2.Panel)).EndInit();
            this.kryptonGroupBox2.Panel.ResumeLayout(false);
            this.kryptonGroupBox2.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2)).EndInit();
            this.kryptonGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            this.kryptonGroupBox1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox4.Panel)).EndInit();
            this.kryptonGroupBox4.Panel.ResumeLayout(false);
            this.kryptonGroupBox4.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox4)).EndInit();
            this.kryptonGroupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_View)).EndInit();
            this.tab_send.ResumeLayout(false);
            this.tab_send.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox3.Panel)).EndInit();
            this.kryptonGroupBox3.Panel.ResumeLayout(false);
            this.kryptonGroupBox3.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox3)).EndInit();
            this.kryptonGroupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer dateNow_timer;
        private ContextMenuStrip cms_add;
        private System.Windows.Forms.ToolStripMenuItem Menu_Add;
        private System.Windows.Forms.ToolStripMenuItem Menu_Delete;
        private System.Windows.Forms.ToolStripMenuItem Menu_Update;
        private System.Windows.Forms.ToolStripMenuItem Menu_GetAllEmail;
        private System.Windows.Forms.ToolStripMenuItem Menu_GetEmail;
        private NotifyIcon notifyIcon;
        private ToolStripMenuItem MenuAllBackEmail;
        private ContextMenuStrip log_cms;
        private ToolStripMenuItem Menu_empty;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private KryptonGroupBox kryptonGroupBox3;
        private AsyncLabelControl lbl_version;
        private AsyncLabelControl lbl_v;
        private AsyncLabelControl label4;
        private AsyncLabelControl lbl_now;
        private TabControl tabControl_Main;
        private TabPage tab_Inbox;
        private KryptonGroupBox kryptonGroupBox2;
        private Panel panel_Files;
        private WebBrowser webBrowser1;
        private AsyncTextBoxControl txt_sendTime;
        private AsyncTextBoxControl txt_sender;
        private AsyncTextBoxControl txt_title;
        private AsyncLabelControl label8;
        private AsyncLabelControl label7;
        private AsyncLabelControl label6;
        private AsyncLabelControl label5;
        private KryptonGroupBox kryptonGroupBox1;
        private KryptonGroupBox kryptonGroupBox4;
        private AsyncTextBoxControl txt_logger;
        private KryptonLabel kryptonLabel2;
        private KryptonLabel kryptonLabel1;
        private AsyncLabelControl lbl_thisNumber;
        private TreeView TreeView_Email;
        private AsyncProgressBarControl lbl_progressbar;
        private AsyncTextBoxControl txt_current;
        private AsyncLabelControl lbl_time;
        private KryptonButton btn_up;
        private AsyncLabelControl lbl_Count;
        private AsyncTextBoxControl lbl_email;
        private AsyncDataGridView grid_View;
        private DataGridViewTextBoxColumn Title;
        private DataGridViewTextBoxColumn SendTime;
        private KryptonButton btn_down;
        private AsyncLabelControl label9;
        private AsyncLabelControl label13;
        private AsyncLabelControl label2;
        private MarqueeLabel marqueeLabel1;
        private AsyncLabelControl label10;
        private AsyncLabelControl lbl_totalPage;
        private AsyncLabelControl label11;
        private TabPage tab_send;
        private HTMLEditor htmlEditor1;
        private Panel panel1;
        private TextBox txt_sendTitle;
        private Label label1;
        private Label label3;
        private Panel pan_UserEmail;
        private Button btn_Send;
        private TreeView treeView_EmailSendNumber;
        private AsyncTextBoxControl txt_sendLogger;
    }
}