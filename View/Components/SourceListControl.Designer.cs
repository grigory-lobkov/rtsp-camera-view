namespace View.Components
{
    partial class SourceListControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SourceListControl));
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "Cam1"}, 0, System.Drawing.SystemColors.WindowText, System.Drawing.SystemColors.Window, new System.Drawing.Font("Microsoft Sans Serif", 8.25F));
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "Cam2"}, 1, System.Drawing.SystemColors.WindowText, System.Drawing.SystemColors.Window, new System.Drawing.Font("Microsoft Sans Serif", 8.25F));
            this.cameraContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.typeViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.largeIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smallIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.largeListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smallListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ascendingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.descendingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disabledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.newCameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifyCameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cameraIconsImageList = new System.Windows.Forms.ImageList(this.components);
            this.viewPanel = new System.Windows.Forms.Panel();
            this.listView = new System.Windows.Forms.ListView();
            this.cameraContextMenuStrip.SuspendLayout();
            this.viewPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // cameraContextMenuStrip
            // 
            this.cameraContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.typeViewToolStripMenuItem,
            this.sortTypeToolStripMenuItem,
            this.toolStripSeparator1,
            this.newCameraToolStripMenuItem,
            this.modifyCameraToolStripMenuItem});
            this.cameraContextMenuStrip.Name = "contextMenuStrip1";
            this.cameraContextMenuStrip.Size = new System.Drawing.Size(181, 120);
            // 
            // typeViewToolStripMenuItem
            // 
            this.typeViewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.largeIconsToolStripMenuItem,
            this.smallIconsToolStripMenuItem,
            this.largeListToolStripMenuItem,
            this.smallListToolStripMenuItem});
            this.typeViewToolStripMenuItem.Name = "typeViewToolStripMenuItem";
            this.typeViewToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.typeViewToolStripMenuItem.Text = "Type View";
            // 
            // largeIconsToolStripMenuItem
            // 
            this.largeIconsToolStripMenuItem.Name = "largeIconsToolStripMenuItem";
            this.largeIconsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.largeIconsToolStripMenuItem.Text = "Large Icons";
            // 
            // smallIconsToolStripMenuItem
            // 
            this.smallIconsToolStripMenuItem.Name = "smallIconsToolStripMenuItem";
            this.smallIconsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.smallIconsToolStripMenuItem.Text = "Small Icons";
            // 
            // largeListToolStripMenuItem
            // 
            this.largeListToolStripMenuItem.Name = "largeListToolStripMenuItem";
            this.largeListToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.largeListToolStripMenuItem.Text = "Large List";
            // 
            // smallListToolStripMenuItem
            // 
            this.smallListToolStripMenuItem.Name = "smallListToolStripMenuItem";
            this.smallListToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.smallListToolStripMenuItem.Text = "Small List";
            // 
            // sortTypeToolStripMenuItem
            // 
            this.sortTypeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ascendingToolStripMenuItem,
            this.descendingToolStripMenuItem,
            this.disabledToolStripMenuItem});
            this.sortTypeToolStripMenuItem.Name = "sortTypeToolStripMenuItem";
            this.sortTypeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sortTypeToolStripMenuItem.Text = "Sorting";
            // 
            // ascendingToolStripMenuItem
            // 
            this.ascendingToolStripMenuItem.Name = "ascendingToolStripMenuItem";
            this.ascendingToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ascendingToolStripMenuItem.Text = "Ascending";
            // 
            // descendingToolStripMenuItem
            // 
            this.descendingToolStripMenuItem.Name = "descendingToolStripMenuItem";
            this.descendingToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.descendingToolStripMenuItem.Text = "Descending";
            // 
            // disabledToolStripMenuItem
            // 
            this.disabledToolStripMenuItem.Name = "disabledToolStripMenuItem";
            this.disabledToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.disabledToolStripMenuItem.Text = "Disabled";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // newCameraToolStripMenuItem
            // 
            this.newCameraToolStripMenuItem.Name = "newCameraToolStripMenuItem";
            this.newCameraToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newCameraToolStripMenuItem.Text = "New Camera";
            // 
            // modifyCameraToolStripMenuItem
            // 
            this.modifyCameraToolStripMenuItem.Name = "modifyCameraToolStripMenuItem";
            this.modifyCameraToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.modifyCameraToolStripMenuItem.Text = "Modify Camera";
            // 
            // cameraIconsImageList
            // 
            this.cameraIconsImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("cameraIconsImageList.ImageStream")));
            this.cameraIconsImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.cameraIconsImageList.Images.SetKeyName(0, "cam1.png");
            this.cameraIconsImageList.Images.SetKeyName(1, "cam2.png");
            // 
            // viewPanel
            // 
            this.viewPanel.Controls.Add(this.listView);
            this.viewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewPanel.Location = new System.Drawing.Point(0, 0);
            this.viewPanel.Margin = new System.Windows.Forms.Padding(0);
            this.viewPanel.Name = "viewPanel";
            this.viewPanel.Size = new System.Drawing.Size(268, 299);
            this.viewPanel.TabIndex = 42;
            // 
            // listView
            // 
            this.listView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView.ContextMenuStrip = this.cameraContextMenuStrip;
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView.HideSelection = false;
            this.listView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.listView.LabelEdit = true;
            this.listView.LargeImageList = this.cameraIconsImageList;
            this.listView.Location = new System.Drawing.Point(0, 0);
            this.listView.Margin = new System.Windows.Forms.Padding(0);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(268, 299);
            this.listView.SmallImageList = this.cameraIconsImageList;
            this.listView.TabIndex = 3;
            this.listView.TileSize = new System.Drawing.Size(150, 150);
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.List;
            this.listView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ListView_MouseDown);
            // 
            // SourceListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.viewPanel);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "SourceListControl";
            this.Size = new System.Drawing.Size(268, 299);
            this.cameraContextMenuStrip.ResumeLayout(false);
            this.viewPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList cameraIconsImageList;
        private System.Windows.Forms.ContextMenuStrip cameraContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem typeViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem largeIconsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem smallIconsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem largeListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem smallListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sortTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ascendingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem descendingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disabledToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem newCameraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifyCameraToolStripMenuItem;
        private System.Windows.Forms.Panel viewPanel;
        private System.Windows.Forms.ListView listView;
    }
}
