namespace Chat_UI
{
    partial class FrmCreateChat
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
            this.btnCreateChat = new System.Windows.Forms.Button();
            this.lblChatPassword = new System.Windows.Forms.Label();
            this.txtChatPassword = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCreateChat
            // 
            this.btnCreateChat.Location = new System.Drawing.Point(110, 85);
            this.btnCreateChat.Name = "btnCreateChat";
            this.btnCreateChat.Size = new System.Drawing.Size(119, 23);
            this.btnCreateChat.TabIndex = 0;
            this.btnCreateChat.Text = "Create Chat";
            this.btnCreateChat.UseVisualStyleBackColor = true;
            this.btnCreateChat.Click += new System.EventHandler(this.btnSendJoinRequest_Click);
            // 
            // lblChatPassword
            // 
            this.lblChatPassword.AutoSize = true;
            this.lblChatPassword.Location = new System.Drawing.Point(58, 35);
            this.lblChatPassword.Name = "lblChatPassword";
            this.lblChatPassword.Size = new System.Drawing.Size(81, 13);
            this.lblChatPassword.TabIndex = 4;
            this.lblChatPassword.Text = "Chat Password:";
            // 
            // txtChatPassword
            // 
            this.txtChatPassword.Location = new System.Drawing.Point(145, 32);
            this.txtChatPassword.Name = "txtChatPassword";
            this.txtChatPassword.PasswordChar = '*';
            this.txtChatPassword.Size = new System.Drawing.Size(129, 20);
            this.txtChatPassword.TabIndex = 3;
            // 
            // FrmCreateChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 128);
            this.Controls.Add(this.lblChatPassword);
            this.Controls.Add(this.txtChatPassword);
            this.Controls.Add(this.btnCreateChat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCreateChat";
            this.Text = "Create a Chat";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreateChat;
        private System.Windows.Forms.Label lblChatPassword;
        private System.Windows.Forms.TextBox txtChatPassword;
    }
}