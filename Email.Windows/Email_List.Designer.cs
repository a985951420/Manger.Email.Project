namespace Email.Windows
{
    partial class Email_List
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_email = new System.Windows.Forms.Button();
            this.txt_emailSplit = new System.Windows.Forms.TextBox();
            this.bulk_splt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(393, 195);
            this.panel1.TabIndex = 0;
            // 
            // btn_email
            // 
            this.btn_email.Location = new System.Drawing.Point(2, 196);
            this.btn_email.Name = "btn_email";
            this.btn_email.Size = new System.Drawing.Size(75, 23);
            this.btn_email.TabIndex = 1;
            this.btn_email.Text = "确定";
            this.btn_email.UseVisualStyleBackColor = true;
            this.btn_email.Click += new System.EventHandler(this.btn_email_Click);
            // 
            // txt_emailSplit
            // 
            this.txt_emailSplit.Location = new System.Drawing.Point(167, 198);
            this.txt_emailSplit.Name = "txt_emailSplit";
            this.txt_emailSplit.Size = new System.Drawing.Size(217, 21);
            this.txt_emailSplit.TabIndex = 2;
            // 
            // bulk_splt
            // 
            this.bulk_splt.Location = new System.Drawing.Point(94, 197);
            this.bulk_splt.Name = "bulk_splt";
            this.bulk_splt.Size = new System.Drawing.Size(67, 23);
            this.bulk_splt.TabIndex = 3;
            this.bulk_splt.Text = "批量拆分";
            this.bulk_splt.UseVisualStyleBackColor = true;
            this.bulk_splt.Click += new System.EventHandler(this.bulk_splt_Click);
            // 
            // Email_List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 224);
            this.Controls.Add(this.bulk_splt);
            this.Controls.Add(this.txt_emailSplit);
            this.Controls.Add(this.btn_email);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Email_List";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Email_List";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_email;
        private System.Windows.Forms.TextBox txt_emailSplit;
        private System.Windows.Forms.Button bulk_splt;
    }
}