namespace Chat_UI
{
    partial class FrmJoinChat
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
            this.btnSendJoinRequest = new System.Windows.Forms.Button();
            this.txtChatID = new System.Windows.Forms.TextBox();
            this.lblJoinChat = new System.Windows.Forms.Label();
            this.lblChatPassword = new System.Windows.Forms.Label();
            this.txtChatPassword = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSendJoinRequest
            // 
            this.btnSendJoinRequest.Location = new System.Drawing.Point(110, 132);
            this.btnSendJoinRequest.Name = "btnSendJoinRequest";
            this.btnSendJoinRequest.Size = new System.Drawing.Size(119, 23);
            this.btnSendJoinRequest.TabIndex = 0;
            this.btnSendJoinRequest.Text = "Send Join Request";
            this.btnSendJoinRequest.UseVisualStyleBackColor = true;
            this.btnSendJoinRequest.Click += new System.EventHandler(this.btnSendJoinRequest_Click);
            // 
            // txtChatID
            // 
            this.txtChatID.Location = new System.Drawing.Point(145, 36);
            this.txtChatID.Name = "txtChatID";
            this.txtChatID.Size = new System.Drawing.Size(129, 20);
            this.txtChatID.TabIndex = 1;
            // 
            // lblJoinChat
            // 
            this.lblJoinChat.AutoSize = true;
            this.lblJoinChat.Location = new System.Drawing.Point(58, 39);
            this.lblJoinChat.Name = "lblJoinChat";
            this.lblJoinChat.Size = new System.Drawing.Size(46, 13);
            this.lblJoinChat.TabIndex = 2;
            this.lblJoinChat.Text = "Chat ID:";
            // 
            // lblChatPassword
            // 
            this.lblChatPassword.AutoSize = true;
            this.lblChatPassword.Location = new System.Drawing.Point(58, 75);
            this.lblChatPassword.Name = "lblChatPassword";
            this.lblChatPassword.Size = new System.Drawing.Size(81, 13);
            this.lblChatPassword.TabIndex = 4;
            this.lblChatPassword.Text = "Chat Password:";
            // 
            // txtChatPassword
            // 
            this.txtChatPassword.Location = new System.Drawing.Point(145, 72);
            this.txtChatPassword.Name = "txtChatPassword";
            this.txtChatPassword.PasswordChar = '*';
            this.txtChatPassword.Size = new System.Drawing.Size(129, 20);
            this.txtChatPassword.TabIndex = 3;
            // 
            // FrmJoinChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 177);
            this.Controls.Add(this.lblChatPassword);
            this.Controls.Add(this.txtChatPassword);
            this.Controls.Add(this.lblJoinChat);
            this.Controls.Add(this.txtChatID);
            this.Controls.Add(this.btnSendJoinRequest);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmJoinChat";
            this.Text = "FrmJoinChat";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSendJoinRequest;
        private System.Windows.Forms.TextBox txtChatID;
        private System.Windows.Forms.Label lblJoinChat;
        private System.Windows.Forms.Label lblChatPassword;
        private System.Windows.Forms.TextBox txtChatPassword;
    }
}