using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeMonic
{
    public partial class PanelNoServers : UserControl
    {
        public FormMusicBrowser parent;

        public PanelNoServers()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            parent.ShowServerList();
        }
    }
}
