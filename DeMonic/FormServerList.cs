using System;
using System.Windows.Forms;

namespace DeMonic
{
	public partial class FormServerList : Form
	{
		public FormServerList()
		{
			InitializeComponent();
		}

		private void SetDisplayList()
		{
			listBoxServers.Items.Clear();

			foreach (var server in DataServerList.serverList)
			{
				var display = $"{server.username}@{server.host}";

				if (server.active)
				{
					display += " (Active)";
				}

				listBoxServers.Items.Add(display);
			}
		}

		private void SetButtonVisibility()
		{
			var index = listBoxServers.SelectedIndex;
			var buttonsVisible = index >= 0;
			buttonUseServer.Visible = buttonsVisible;
			buttonEditServer.Visible = buttonsVisible;
			buttonRemoveServer.Visible = buttonsVisible;

			if (!buttonsVisible) return;
			buttonUseServer.Enabled = !DataServerList.serverList[index].active;
		}

		private void FormServerList_Load(object sender, EventArgs e)
		{
			SetDisplayList();
		}

		private void listBoxServers_SelectedIndexChanged(object sender, EventArgs e)
		{
			SetButtonVisibility();
		}

		private void buttonUseServer_Click(object sender, EventArgs e)
		{
			var index = listBoxServers.SelectedIndex;
			DataServerList.UseServer(index);
			SetDisplayList();
			listBoxServers.SetSelected(index, true);
		}

		private void buttonAddServer_Click(object sender, EventArgs e)
		{
			var dlg = new FormServerAddEdit();
			var response = dlg.ShowDialog();

			if (response == DialogResult.OK)
			{
				SetDisplayList();
				listBoxServers.SetSelected(listBoxServers.Items.Count - 1, true);
			}
		}

		private void buttonRemoveServer_Click(object sender, EventArgs e)
		{
			DataServerList.RemoveServer(listBoxServers.SelectedIndex);
			SetDisplayList();
			SetButtonVisibility();
		}
	}
}
