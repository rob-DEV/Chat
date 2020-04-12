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

        public FrmChat()
        {
            InitializeComponent();

            m_Chat = Chat.Create();

            MessageWatcher();
        }

        private async void MessageWatcher()
        {
            while(true)
            {

                //check server for messages


                await Task.Delay(500);
            }
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            m_Chat.SendMessage(new Chat_Core.Message(Environment.MachineName, txtMessage.Text));
            txtMessage.Text = "";
        }
    }
}
