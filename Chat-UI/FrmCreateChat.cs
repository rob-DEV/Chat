using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Chat_Core;

namespace Chat_UI
{
    public partial class FrmCreateChat : Form
    {
        public FrmCreateChat()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void btnSendJoinRequest_Click(object sender, EventArgs e)
        {
            Chat chat = Chat.Create(txtChatPassword.Text);

            FrmChat chatWindow = new FrmChat(chat);

            chatWindow.ShowDialog();

        }
    }
}
