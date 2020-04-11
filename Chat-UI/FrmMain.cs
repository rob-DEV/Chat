using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Chat_UI
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void txtTesting_Click(object sender, EventArgs e)
        {
            var dict = new Dictionary<string, string>();
            dict.Add("client_pub_key", "3as1d5asd4fs35df4sd3f5s4df5s64fs6");

            Chat_Core.Request.Send(dict);
            
        }
    }
}
