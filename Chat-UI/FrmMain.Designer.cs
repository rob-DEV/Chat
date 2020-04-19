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
            this.btnTesting = new System.Windows.Forms.Button();
            this.txtTesting = new System.Windows.Forms.TextBox();
            this.btnCreateChat = new System.Windows.Forms.Button();
            this.btnJoinChat = new System.Windows.Forms.Button();
            this.btnGenerateRSA = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTesting
            // 
            this.btnTesting.Location = new System.Drawing.Point(12, 12);
            this.btnTesting.Name = "btnTesting";
            this.btnTesting.Size = new System.Drawing.Size(776, 23);
            this.btnTesting.TabIndex = 0;
            this.btnTesting.Text = "Request Client Indentifier";
            this.btnTesting.UseVisualStyleBackColor = true;
            this.btnTesting.Click += new System.EventHandler(this.btnTesting_Click);
            // 
            // txtTesting
            // 
            this.txtTesting.Location = new System.Drawing.Point(12, 163);
            this.txtTesting.Multiline = true;
            this.txtTesting.Name = "txtTesting";
            this.txtTesting.Size = new System.Drawing.Size(776, 109);
            this.txtTesting.TabIndex = 1;
            // 
            // btnCreateChat
            // 
            this.btnCreateChat.Location = new System.Drawing.Point(12, 41);
            this.btnCreateChat.Name = "btnCreateChat";
            this.btnCreateChat.Size = new System.Drawing.Size(776, 23);
            this.btnCreateChat.TabIndex = 2;
            this.btnCreateChat.Text = "Create Chat";
            this.btnCreateChat.UseVisualStyleBackColor = true;
            this.btnCreateChat.Click += new System.EventHandler(this.btnCreateChat_Click);
            // 
            // btnJoinChat
            // 
            this.btnJoinChat.Location = new System.Drawing.Point(12, 70);
            this.btnJoinChat.Name = "btnJoinChat";
            this.btnJoinChat.Size = new System.Drawing.Size(776, 23);
            this.btnJoinChat.TabIndex = 3;
            this.btnJoinChat.Text = "Join Chat";
            this.btnJoinChat.UseVisualStyleBackColor = true;
            this.btnJoinChat.Click += new System.EventHandler(this.btnJoinChat_Click);
            // 
            // btnGenerateRSA
            // 
            this.btnGenerateRSA.Location = new System.Drawing.Point(12, 99);
            this.btnGenerateRSA.Name = "btnGenerateRSA";
            this.btnGenerateRSA.Size = new System.Drawing.Size(776, 23);
            this.btnGenerateRSA.TabIndex = 4;
            this.btnGenerateRSA.Text = "Generate RSA";
            this.btnGenerateRSA.UseVisualStyleBackColor = true;
            this.btnGenerateRSA.Click += new System.EventHandler(this.btnGenerateRSA_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnGenerateRSA);
            this.Controls.Add(this.btnJoinChat);
            this.Controls.Add(this.btnCreateChat);
            this.Controls.Add(this.txtTesting);
            this.Controls.Add(this.btnTesting);
            this.Name = "FrmMain";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTesting;
        private System.Windows.Forms.TextBox txtTesting;
        private System.Windows.Forms.Button btnCreateChat;
        private System.Windows.Forms.Button btnJoinChat;
        private System.Windows.Forms.Button btnGenerateRSA;
    }
}

