using System;
using System.Windows.Forms;

namespace DeMonic
{
	public partial class FormServerAddEdit : Form
	{
		public FormServerAddEdit()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			Close();
		}

		private void buttonSave_Click(object sender, EventArgs e)
		{
			var host = txtHost.Text;
			var user = txtUsername.Text;
			var pass = txtPassword.Text;
			var useHTTPS = chkUseHTTPS.Checked;
			var active = DataServerList.serverList.Count == 0;
			DataServerList.AddServer(new Server(host, user, pass, useHTTPS, active));

			this.DialogResult = DialogResult.OK;

			Close();
		}
	}
}
