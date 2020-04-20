namespace Chat_UI
{
    partial class FrmMain
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
            this.btnJoinChat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCreateChat
            // 
            this.btnCreateChat.Location = new System.Drawing.Point(12, 12);
            this.btnCreateChat.Name = "btnCreateChat";
            this.btnCreateChat.Size = new System.Drawing.Size(776, 23);
            this.btnCreateChat.TabIndex = 2;
            this.btnCreateChat.Text = "Create Chat";
            this.btnCreateChat.UseVisualStyleBackColor = true;
            this.btnCreateChat.Click += new System.EventHandler(this.btnCreateChat_Click);
            // 
            // btnJoinChat
            // 
            this.btnJoinChat.Location = new System.Drawing.Point(12, 41);
            this.btnJoinChat.Name = "btnJoinChat";
            this.btnJoinChat.Size = new System.Drawing.Size(776, 23);
            this.btnJoinChat.TabIndex = 3;
            this.btnJoinChat.Text = "Join Chat";
            this.btnJoinChat.UseVisualStyleBackColor = true;
            this.btnJoinChat.Click += new System.EventHandler(this.btnJoinChat_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 466);
            this.Controls.Add(this.btnJoinChat);
            this.Controls.Add(this.btnCreateChat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.Text = "Chat";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnCreateChat;
        private System.Windows.Forms.Button btnJoinChat;
    }
}

