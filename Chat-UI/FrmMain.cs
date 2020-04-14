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

    public partial class FrmMain : Form
    {
        private Client m_Client = null;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnTesting_Click(object sender, EventArgs e)
        {
            m_Client = Client.Get();

            Client.Get().Save();

        }

        private void btnCreateChat_Click(object sender, EventArgs e)
        {
            if (m_Client != null)
            {
                Chat chat = Chat.Create();
                FrmChat chatWindow = new FrmChat(chat);
                chatWindow.Show();
            }
        }

        private void btnJoinChat_Click(object sender, EventArgs e)
        {
            FrmJoinChat joinChatWindow = new FrmJoinChat();
            joinChatWindow.ShowDialog();
        }
    }
}
