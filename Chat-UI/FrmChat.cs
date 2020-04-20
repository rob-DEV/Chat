using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
            this.CenterToScreen();

            m_Chat = chat;

            this.Text = string.Format("Chat : {0}", m_Chat.ShortID);

        }

        private void FrmChat_Load(object sender, EventArgs e)
        {
            MessageWatcher();
        }

        private Task<string> Poll()
        {
            Task<string> pollMessagesTask = Task.Run(() =>
            {
                string result = string.Empty;
                Thread.Sleep(200);
                //check server for messages
                m_Chat.CheckForMessages();
                txtChatWindow.Text = "";
                foreach (Chat_Core.Message message in m_Chat.Messages)
                {
                    result += string.Format("{0}:\t{1}\r\n", message.Sender, message.Content);
                }

                return result;
            });

            return pollMessagesTask;
        }

        private async void MessageWatcher()
        {
            while(true)
            {        
                string result = await Poll();
                txtChatWindow.Text = result;

            }

        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            if (txtMessage.Text.Length > 0)
            {
                m_Chat.SendMessage(new Chat_Core.Message(Environment.MachineName, txtMessage.Text));
                txtMessage.Text = "";
            }
        }

    }
}
