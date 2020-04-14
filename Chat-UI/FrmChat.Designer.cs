namespace Chat_UI
{
    partial class FrmChat
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
            this.txtChatWindow = new System.Windows.Forms.TextBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.btnCheckTest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtChatWindow
            // 
            this.txtChatWindow.Location = new System.Drawing.Point(13, 13);
            this.txtChatWindow.Multiline = true;
            this.txtChatWindow.Name = "txtChatWindow";
            this.txtChatWindow.ReadOnly = true;
            this.txtChatWindow.Size = new System.Drawing.Size(775, 366);
            this.txtChatWindow.TabIndex = 0;
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(13, 386);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(775, 20);
            this.txtMessage.TabIndex = 1;
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Location = new System.Drawing.Point(309, 415);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(182, 23);
            this.btnSendMessage.TabIndex = 2;
            this.btnSendMessage.Text = "Send Message";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // btnCheckTest
            // 
            this.btnCheckTest.Location = new System.Drawing.Point(497, 415);
            this.btnCheckTest.Name = "btnCheckTest";
            this.btnCheckTest.Size = new System.Drawing.Size(182, 23);
            this.btnCheckTest.TabIndex = 3;
            this.btnCheckTest.Text = "Check";
            this.btnCheckTest.UseVisualStyleBackColor = true;
            this.btnCheckTest.Click += new System.EventHandler(this.btnCheckTest_Click);
            // 
            // FrmChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCheckTest);
            this.Controls.Add(this.btnSendMessage);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.txtChatWindow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmChat";
            this.Text = "FrmChat";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtChatWindow;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.Button btnCheckTest;
    }
}