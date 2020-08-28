using System.Windows.Forms;

namespace Email.Windows
{
    partial class AddEmail
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
            this.materialLabel1 = new System.Windows.Forms.Label();
            this.materialLabel2 = new System.Windows.Forms.Label();
            this.txt_email = new System.Windows.Forms.TextBox();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.btn_addEamil = new System.Windows.Forms.Button();
            this.txt_sendMax = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(83, 33);
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(40, 17);
            this.materialLabel1.TabIndex = 5;
            this.materialLabel1.Text = "邮箱:";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(83, 71);
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(40, 17);
            this.materialLabel2.TabIndex = 6;
            this.materialLabel2.Text = "密码:";
            // 
            // txt_email
            // 
            this.txt_email.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_email.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_email.Location = new System.Drawing.Point(135, 33);
            this.txt_email.MaxLength = 50;
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(244, 19);
            this.txt_email.TabIndex = 7;
            // 
            // txt_password
            // 
            this.txt_password.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_password.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_password.Location = new System.Drawing.Point(135, 69);
            this.txt_password.MaxLength = 50;
            this.txt_password.Name = "txt_password";
            this.txt_password.PasswordChar = '*';
            this.txt_password.Size = new System.Drawing.Size(244, 19);
            this.txt_password.TabIndex = 8;
            // 
            // btn_addEamil
            // 
            this.btn_addEamil.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_addEamil.Location = new System.Drawing.Point(135, 137);
            this.btn_addEamil.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_addEamil.Name = "btn_addEamil";
            this.btn_addEamil.Size = new System.Drawing.Size(244, 36);
            this.btn_addEamil.TabIndex = 9;
            this.btn_addEamil.Text = "确认添加";
            this.btn_addEamil.UseVisualStyleBackColor = true;
            this.btn_addEamil.Click += new System.EventHandler(this.btn_addEamil_Click);
            // 
            // txt_sendMax
            // 
            this.txt_sendMax.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_sendMax.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_sendMax.Location = new System.Drawing.Point(135, 106);
            this.txt_sendMax.MaxLength = 50;
            this.txt_sendMax.Name = "txt_sendMax";
            this.txt_sendMax.Size = new System.Drawing.Size(244, 19);
            this.txt_sendMax.TabIndex = 10;
            this.txt_sendMax.Text = "100";
            this.txt_sendMax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_sendMax_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label1.Location = new System.Drawing.Point(33, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "发送邮件上限:";
            // 
            // AddEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 188);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_sendMax);
            this.Controls.Add(this.btn_addEamil);
            this.Controls.Add(this.txt_password);
            this.Controls.Add(this.txt_email);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialLabel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEmail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加邮箱";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label materialLabel1;
        private Label materialLabel2;
        private TextBox txt_email;
        private TextBox txt_password;
        private Button btn_addEamil;
        private TextBox txt_sendMax;
        private Label label1;
    }
}