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
            this.CenterToScreen();

            //generate a client and save details in xml
            m_Client = Client.Get();

        }

        private void btnCreateChat_Click(object sender, EventArgs e)
        {
            FrmCreateChat createChatWindow = new FrmCreateChat();
            createChatWindow.ShowDialog();
        }

        private void btnJoinChat_Click(object sender, EventArgs e)
        {
            FrmJoinChat joinChatWindow = new FrmJoinChat();
            joinChatWindow.ShowDialog();
        }

    }
}
