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
    public partial class FrmJoinChat : Form
    {
        public FrmJoinChat()
        {
            InitializeComponent();
        }

        private void btnSendJoinRequest_Click(object sender, EventArgs e)
        {
            Chat chat = Chat.Join(txtChatID.Text, txtChatPassword.Text);

            FrmChat chatWindow = new FrmChat(chat);

            chatWindow.ShowDialog();

        }
    }
}
