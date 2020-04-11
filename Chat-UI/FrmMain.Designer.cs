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
            this.txtTesting = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtTesting
            // 
            this.txtTesting.Location = new System.Drawing.Point(285, 206);
            this.txtTesting.Name = "txtTesting";
            this.txtTesting.Size = new System.Drawing.Size(260, 23);
            this.txtTesting.TabIndex = 0;
            this.txtTesting.Text = "Send Request Test";
            this.txtTesting.UseVisualStyleBackColor = true;
            this.txtTesting.Click += new System.EventHandler(this.txtTesting_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtTesting);
            this.Name = "FrmMain";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button txtTesting;
    }
}

