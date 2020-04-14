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
    public partial class FrmChat : Form
    {
        Chat m_Chat = null;

        public FrmChat(Chat chat)
        {
            InitializeComponent();

            m_Chat = chat;

            this.Text = string.Format("Chat : {0}", m_Chat.ShortID);

            MessageWatcher();
        }

        private async void MessageWatcher()
        {
            while(true)
            {

                //check server for messages
                m_Chat.CheckForMessages();
                txtChatWindow.Text = "";
                foreach (Chat_Core.Message message in m_Chat.Messages)
                {
                    txtChatWindow.Text += string.Format("{0}:\t{1}\r\n", message.Sender, message.Content);
                }
                await Task.Delay(500);
            }
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            m_Chat.SendMessage(new Chat_Core.Message(Environment.MachineName, txtMessage.Text));
            txtMessage.Text = "";
        }

        private void btnCheckTest_Click(object sender, EventArgs e)
        {

        }
    }
}
