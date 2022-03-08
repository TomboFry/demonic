using System;
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
