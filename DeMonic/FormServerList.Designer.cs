namespace DeMonic
{
    partial class FormServerList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonAddServer = new System.Windows.Forms.Button();
            this.buttonEditServer = new System.Windows.Forms.Button();
            this.buttonRemoveServer = new System.Windows.Forms.Button();
            this.buttonUseServer = new System.Windows.Forms.Button();
            this.listBoxServers = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // buttonAddServer
            // 
            this.buttonAddServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddServer.Location = new System.Drawing.Point(249, 13);
            this.buttonAddServer.Name = "buttonAddServer";
            this.buttonAddServer.Size = new System.Drawing.Size(154, 32);
            this.buttonAddServer.TabIndex = 0;
            this.buttonAddServer.Text = "Add Server...";
            this.buttonAddServer.UseVisualStyleBackColor = true;
            this.buttonAddServer.Click += new System.EventHandler(this.buttonAddServer_Click);
            // 
            // buttonEditServer
            // 
            this.buttonEditServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEditServer.Location = new System.Drawing.Point(250, 89);
            this.buttonEditServer.Name = "buttonEditServer";
            this.buttonEditServer.Size = new System.Drawing.Size(154, 32);
            this.buttonEditServer.TabIndex = 2;
            this.buttonEditServer.Text = "Edit Selected Server...";
            this.buttonEditServer.UseVisualStyleBackColor = true;
            this.buttonEditServer.Visible = false;
            // 
            // buttonRemoveServer
            // 
            this.buttonRemoveServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRemoveServer.Location = new System.Drawing.Point(250, 127);
            this.buttonRemoveServer.Name = "buttonRemoveServer";
            this.buttonRemoveServer.Size = new System.Drawing.Size(154, 32);
            this.buttonRemoveServer.TabIndex = 3;
            this.buttonRemoveServer.Text = "Remove Selected Server";
            this.buttonRemoveServer.UseVisualStyleBackColor = true;
            this.buttonRemoveServer.Visible = false;
            this.buttonRemoveServer.Click += new System.EventHandler(this.buttonRemoveServer_Click);
            // 
            // buttonUseServer
            // 
            this.buttonUseServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUseServer.Location = new System.Drawing.Point(250, 51);
            this.buttonUseServer.Name = "buttonUseServer";
            this.buttonUseServer.Size = new System.Drawing.Size(154, 32);
            this.buttonUseServer.TabIndex = 1;
            this.buttonUseServer.Text = "Use Selected Server";
            this.buttonUseServer.UseVisualStyleBackColor = true;
            this.buttonUseServer.Visible = false;
            this.buttonUseServer.Click += new System.EventHandler(this.buttonUseServer_Click);
            // 
            // listBoxServers
            // 
            this.listBoxServers.FormattingEnabled = true;
            this.listBoxServers.HorizontalScrollbar = true;
            this.listBoxServers.Location = new System.Drawing.Point(12, 12);
            this.listBoxServers.Name = "listBoxServers";
            this.listBoxServers.Size = new System.Drawing.Size(231, 147);
            this.listBoxServers.TabIndex = 4;
            this.listBoxServers.SelectedIndexChanged += new System.EventHandler(this.listBoxServers_SelectedIndexChanged);
            // 
            // FormServerList
            // 
            this.AcceptButton = this.buttonUseServer;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 171);
            this.Controls.Add(this.listBoxServers);
            this.Controls.Add(this.buttonUseServer);
            this.Controls.Add(this.buttonRemoveServer);
            this.Controls.Add(this.buttonEditServer);
            this.Controls.Add(this.buttonAddServer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormServerList";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Server List";
            this.Load += new System.EventHandler(this.FormServerList_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonAddServer;
        private System.Windows.Forms.Button buttonEditServer;
        private System.Windows.Forms.Button buttonRemoveServer;
        private System.Windows.Forms.Button buttonUseServer;
        private System.Windows.Forms.ListBox listBoxServers;
    }
}