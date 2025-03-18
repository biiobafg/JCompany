namespace JCompany
{
    partial class ItemStudio
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemStudio));
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            addFolderToolStripMenuItem = new ToolStripMenuItem();
            loadFolderToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            saveCurrentToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            clearListToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            loadVanillaItemsToolStripMenuItem = new ToolStripMenuItem();
            reloadAllAssetsToolStripMenuItem = new ToolStripMenuItem();
            toolsToolStripMenuItem = new ToolStripMenuItem();
            exportAllIconsToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            ignoreLargsMediumSmallToolStripMenuItem = new ToolStripMenuItem();
            btn_AutoComment = new ToolStripMenuItem();
            toolStripSeparator5 = new ToolStripSeparator();
            showOnlyOverlapToolStripMenuItem = new ToolStripMenuItem();
            filterToolStripMenuItem = new ToolStripMenuItem();
            allToolStripMenuItem = new ToolStripMenuItem();
            presetsToolStripMenuItem = new ToolStripMenuItem();
            openPresetsToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            btn_SetUnturnedDir = new ToolStripMenuItem();
            btn_OpenWorkshopDir = new ToolStripMenuItem();
            btn_OpenIconDir = new ToolStripMenuItem();
            btn_OpenUnturnedDir = new ToolStripMenuItem();
            lv_Items = new ListView();
            Clm_ItemID = new ColumnHeader();
            Clm_Type = new ColumnHeader();
            Clm_Name = new ColumnHeader();
            tp_1 = new TabPage();
            txt_datEditor = new TextBox();
            tabControl1 = new TabControl();
            panel1 = new Panel();
            btn_OpenIconLocation = new Button();
            button1 = new Button();
            btn_OpenLocation = new Button();
            txt_Msg = new TextBox();
            txt_iconLocation = new TextBox();
            pxb_ItemIcon = new PictureBox();
            txt_engEditor = new TextBox();
            menuStrip1.SuspendLayout();
            tp_1.SuspendLayout();
            tabControl1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pxb_ItemIcon).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, toolsToolStripMenuItem, filterToolStripMenuItem, presetsToolStripMenuItem, settingsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1560, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { addFolderToolStripMenuItem, loadFolderToolStripMenuItem, toolStripSeparator1, saveCurrentToolStripMenuItem, toolStripSeparator2, clearListToolStripMenuItem, toolStripSeparator3, loadVanillaItemsToolStripMenuItem, reloadAllAssetsToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // addFolderToolStripMenuItem
            // 
            addFolderToolStripMenuItem.Name = "addFolderToolStripMenuItem";
            addFolderToolStripMenuItem.Size = new Size(180, 22);
            addFolderToolStripMenuItem.Text = "Add Folder";
            addFolderToolStripMenuItem.Click += addFolderToolStripMenuItem_Click;
            // 
            // loadFolderToolStripMenuItem
            // 
            loadFolderToolStripMenuItem.Name = "loadFolderToolStripMenuItem";
            loadFolderToolStripMenuItem.Size = new Size(180, 22);
            loadFolderToolStripMenuItem.Text = "Load Folder";
            loadFolderToolStripMenuItem.Click += loadFolderToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(177, 6);
            // 
            // saveCurrentToolStripMenuItem
            // 
            saveCurrentToolStripMenuItem.Name = "saveCurrentToolStripMenuItem";
            saveCurrentToolStripMenuItem.Size = new Size(180, 22);
            saveCurrentToolStripMenuItem.Text = "Save Current";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(177, 6);
            // 
            // clearListToolStripMenuItem
            // 
            clearListToolStripMenuItem.Name = "clearListToolStripMenuItem";
            clearListToolStripMenuItem.Size = new Size(180, 22);
            clearListToolStripMenuItem.Text = "Clear List";
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(177, 6);
            // 
            // loadVanillaItemsToolStripMenuItem
            // 
            loadVanillaItemsToolStripMenuItem.Name = "loadVanillaItemsToolStripMenuItem";
            loadVanillaItemsToolStripMenuItem.Size = new Size(180, 22);
            loadVanillaItemsToolStripMenuItem.Text = "Load Vanilla Items";
            loadVanillaItemsToolStripMenuItem.Click += loadVanillaItemsToolStripMenuItem_Click;
            // 
            // reloadAllAssetsToolStripMenuItem
            // 
            reloadAllAssetsToolStripMenuItem.Name = "reloadAllAssetsToolStripMenuItem";
            reloadAllAssetsToolStripMenuItem.Size = new Size(180, 22);
            reloadAllAssetsToolStripMenuItem.Text = "Reload All Assets";
            reloadAllAssetsToolStripMenuItem.Click += reloadAllAssetsToolStripMenuItem_Click;
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exportAllIconsToolStripMenuItem, toolStripSeparator4, ignoreLargsMediumSmallToolStripMenuItem, btn_AutoComment, toolStripSeparator5, showOnlyOverlapToolStripMenuItem });
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new Size(46, 20);
            toolsToolStripMenuItem.Text = "Tools";
            // 
            // exportAllIconsToolStripMenuItem
            // 
            exportAllIconsToolStripMenuItem.Name = "exportAllIconsToolStripMenuItem";
            exportAllIconsToolStripMenuItem.Size = new Size(225, 22);
            exportAllIconsToolStripMenuItem.Text = "Export All Icons";
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(222, 6);
            // 
            // ignoreLargsMediumSmallToolStripMenuItem
            // 
            ignoreLargsMediumSmallToolStripMenuItem.Checked = true;
            ignoreLargsMediumSmallToolStripMenuItem.CheckOnClick = true;
            ignoreLargsMediumSmallToolStripMenuItem.CheckState = CheckState.Checked;
            ignoreLargsMediumSmallToolStripMenuItem.Name = "ignoreLargsMediumSmallToolStripMenuItem";
            ignoreLargsMediumSmallToolStripMenuItem.Size = new Size(225, 22);
            ignoreLargsMediumSmallToolStripMenuItem.Text = "Ignore Largs, Medium, Small";
            // 
            // btn_AutoComment
            // 
            btn_AutoComment.Checked = true;
            btn_AutoComment.CheckOnClick = true;
            btn_AutoComment.CheckState = CheckState.Checked;
            btn_AutoComment.Name = "btn_AutoComment";
            btn_AutoComment.Size = new Size(225, 22);
            btn_AutoComment.Text = "Auto Comment";
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(222, 6);
            // 
            // showOnlyOverlapToolStripMenuItem
            // 
            showOnlyOverlapToolStripMenuItem.CheckOnClick = true;
            showOnlyOverlapToolStripMenuItem.Name = "showOnlyOverlapToolStripMenuItem";
            showOnlyOverlapToolStripMenuItem.Size = new Size(225, 22);
            showOnlyOverlapToolStripMenuItem.Text = "Show Only Overlap";
            // 
            // filterToolStripMenuItem
            // 
            filterToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { allToolStripMenuItem });
            filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            filterToolStripMenuItem.Size = new Size(45, 20);
            filterToolStripMenuItem.Text = "Filter";
            // 
            // allToolStripMenuItem
            // 
            allToolStripMenuItem.Checked = true;
            allToolStripMenuItem.CheckOnClick = true;
            allToolStripMenuItem.CheckState = CheckState.Checked;
            allToolStripMenuItem.Name = "allToolStripMenuItem";
            allToolStripMenuItem.Size = new Size(88, 22);
            allToolStripMenuItem.Text = "All";
            // 
            // presetsToolStripMenuItem
            // 
            presetsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openPresetsToolStripMenuItem });
            presetsToolStripMenuItem.Name = "presetsToolStripMenuItem";
            presetsToolStripMenuItem.Size = new Size(56, 20);
            presetsToolStripMenuItem.Text = "Presets";
            // 
            // openPresetsToolStripMenuItem
            // 
            openPresetsToolStripMenuItem.Name = "openPresetsToolStripMenuItem";
            openPresetsToolStripMenuItem.Size = new Size(143, 22);
            openPresetsToolStripMenuItem.Text = "Open Presets";
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { btn_SetUnturnedDir, btn_OpenWorkshopDir, btn_OpenIconDir, btn_OpenUnturnedDir });
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(61, 20);
            settingsToolStripMenuItem.Text = "Settings";
            // 
            // btn_SetUnturnedDir
            // 
            btn_SetUnturnedDir.Name = "btn_SetUnturnedDir";
            btn_SetUnturnedDir.Size = new Size(211, 22);
            btn_SetUnturnedDir.Text = "Set Unturned Directory";
            btn_SetUnturnedDir.Click += btn_setUnturnedDir;
            // 
            // btn_OpenWorkshopDir
            // 
            btn_OpenWorkshopDir.Name = "btn_OpenWorkshopDir";
            btn_OpenWorkshopDir.Size = new Size(211, 22);
            btn_OpenWorkshopDir.Text = "Open Workshop Directory";
            btn_OpenWorkshopDir.Click += btn_openWrkshop;
            // 
            // btn_OpenIconDir
            // 
            btn_OpenIconDir.Name = "btn_OpenIconDir";
            btn_OpenIconDir.Size = new Size(211, 22);
            btn_OpenIconDir.Text = "Open Icons Folder";
            btn_OpenIconDir.Click += btn_openIcons;
            // 
            // btn_OpenUnturnedDir
            // 
            btn_OpenUnturnedDir.Name = "btn_OpenUnturnedDir";
            btn_OpenUnturnedDir.Size = new Size(211, 22);
            btn_OpenUnturnedDir.Text = "Open Unturned Folder";
            btn_OpenUnturnedDir.Click += btn_openUnturnedDir;
            // 
            // lv_Items
            // 
            lv_Items.AllowColumnReorder = true;
            lv_Items.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            lv_Items.Columns.AddRange(new ColumnHeader[] { Clm_ItemID, Clm_Type, Clm_Name });
            lv_Items.FullRowSelect = true;
            lv_Items.Location = new Point(11, 27);
            lv_Items.Margin = new Padding(20);
            lv_Items.MultiSelect = false;
            lv_Items.Name = "lv_Items";
            lv_Items.Size = new Size(389, 794);
            lv_Items.TabIndex = 1;
            lv_Items.UseCompatibleStateImageBehavior = false;
            lv_Items.View = View.Details;
            lv_Items.ColumnClick += lv_Items_ColumnClick;
            lv_Items.SelectedIndexChanged += lv_Items_SelectedIndexChanged;
            // 
            // Clm_ItemID
            // 
            Clm_ItemID.Text = "ID";
            Clm_ItemID.Width = 70;
            // 
            // Clm_Type
            // 
            Clm_Type.Text = "Type";
            Clm_Type.Width = 70;
            // 
            // Clm_Name
            // 
            Clm_Name.Text = "Name";
            Clm_Name.Width = 240;
            // 
            // tp_1
            // 
            tp_1.Controls.Add(txt_datEditor);
            tp_1.Location = new Point(4, 24);
            tp_1.Name = "tp_1";
            tp_1.Padding = new Padding(3);
            tp_1.Size = new Size(787, 776);
            tp_1.TabIndex = 0;
            tp_1.Text = "Dat Editor";
            tp_1.UseVisualStyleBackColor = true;
            // 
            // txt_datEditor
            // 
            txt_datEditor.Dock = DockStyle.Fill;
            txt_datEditor.Location = new Point(3, 3);
            txt_datEditor.Multiline = true;
            txt_datEditor.Name = "txt_datEditor";
            txt_datEditor.ScrollBars = ScrollBars.Vertical;
            txt_datEditor.Size = new Size(781, 770);
            txt_datEditor.TabIndex = 0;
            txt_datEditor.WordWrap = false;
            txt_datEditor.TextChanged += txt_datEditor_TextChanged;
            txt_datEditor.KeyDown += txt_datEditor_KeyDown;
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tp_1);
            tabControl1.Location = new Point(410, 27);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(795, 804);
            tabControl1.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel1.Controls.Add(btn_OpenIconLocation);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(btn_OpenLocation);
            panel1.Controls.Add(txt_Msg);
            panel1.Controls.Add(txt_iconLocation);
            panel1.Controls.Add(pxb_ItemIcon);
            panel1.Controls.Add(txt_engEditor);
            panel1.Location = new Point(1204, 27);
            panel1.Name = "panel1";
            panel1.Size = new Size(344, 789);
            panel1.TabIndex = 3;
            // 
            // btn_OpenIconLocation
            // 
            btn_OpenIconLocation.Location = new Point(121, 173);
            btn_OpenIconLocation.Name = "btn_OpenIconLocation";
            btn_OpenIconLocation.Size = new Size(102, 46);
            btn_OpenIconLocation.TabIndex = 7;
            btn_OpenIconLocation.Text = "Open Icon Location";
            btn_OpenIconLocation.UseVisualStyleBackColor = true;
            btn_OpenIconLocation.Click += btn_OpenIconLocation_Click;
            // 
            // button1
            // 
            button1.Location = new Point(229, 173);
            button1.Name = "button1";
            button1.Size = new Size(108, 46);
            button1.TabIndex = 6;
            button1.Text = "Open Item Location";
            button1.UseVisualStyleBackColor = true;
            // 
            // btn_OpenLocation
            // 
            btn_OpenLocation.Location = new Point(7, 173);
            btn_OpenLocation.Name = "btn_OpenLocation";
            btn_OpenLocation.Size = new Size(108, 46);
            btn_OpenLocation.TabIndex = 5;
            btn_OpenLocation.Text = "Open Item Location";
            btn_OpenLocation.UseVisualStyleBackColor = true;
            btn_OpenLocation.Click += btn_OpenLocation_Click;
            // 
            // txt_Msg
            // 
            txt_Msg.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txt_Msg.Location = new Point(7, 143);
            txt_Msg.Multiline = true;
            txt_Msg.Name = "txt_Msg";
            txt_Msg.ReadOnly = true;
            txt_Msg.Size = new Size(330, 24);
            txt_Msg.TabIndex = 4;
            txt_Msg.Text = "Made by ._.dog (sunglasses emoji)";
            txt_Msg.TextAlign = HorizontalAlignment.Center;
            // 
            // txt_iconLocation
            // 
            txt_iconLocation.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            txt_iconLocation.Location = new Point(7, 425);
            txt_iconLocation.Name = "txt_iconLocation";
            txt_iconLocation.ReadOnly = true;
            txt_iconLocation.RightToLeft = RightToLeft.Yes;
            txt_iconLocation.Size = new Size(334, 23);
            txt_iconLocation.TabIndex = 3;
            // 
            // pxb_ItemIcon
            // 
            pxb_ItemIcon.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pxb_ItemIcon.BackgroundImageLayout = ImageLayout.None;
            pxb_ItemIcon.Location = new Point(7, 454);
            pxb_ItemIcon.Name = "pxb_ItemIcon";
            pxb_ItemIcon.Size = new Size(334, 332);
            pxb_ItemIcon.SizeMode = PictureBoxSizeMode.Zoom;
            pxb_ItemIcon.TabIndex = 2;
            pxb_ItemIcon.TabStop = false;
            // 
            // txt_engEditor
            // 
            txt_engEditor.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txt_engEditor.Location = new Point(3, 3);
            txt_engEditor.Multiline = true;
            txt_engEditor.Name = "txt_engEditor";
            txt_engEditor.Size = new Size(338, 134);
            txt_engEditor.TabIndex = 1;
            // 
            // ItemStudio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1560, 828);
            Controls.Add(panel1);
            Controls.Add(tabControl1);
            Controls.Add(lv_Items);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "ItemStudio";
            Text = "Form1";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tp_1.ResumeLayout(false);
            tp_1.PerformLayout();
            tabControl1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pxb_ItemIcon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem addFolderToolStripMenuItem;
        private ToolStripMenuItem loadFolderToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem saveCurrentToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem clearListToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem loadVanillaItemsToolStripMenuItem;
        private ToolStripMenuItem reloadAllAssetsToolStripMenuItem;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem exportAllIconsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem ignoreLargsMediumSmallToolStripMenuItem;
        private ToolStripMenuItem filterToolStripMenuItem;
        private ToolStripMenuItem presetsToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem showOnlyOverlapToolStripMenuItem;
        private ToolStripMenuItem allToolStripMenuItem;
        private ToolStripMenuItem openPresetsToolStripMenuItem;
        private ToolStripMenuItem btn_SetUnturnedDir;
        private ToolStripMenuItem btn_OpenWorkshopDir;
        private ToolStripMenuItem btn_OpenIconDir;
        private ToolStripMenuItem btn_OpenUnturnedDir;
        private ColumnHeader Clm_ItemID;
        private ColumnHeader Clm_Type;
        private ColumnHeader Clm_Name;
        protected ListView lv_Items;
        private TabPage tp_1;
        private TabControl tabControl1;
        private TextBox txt_datEditor;
        private PictureBox pictureBox1;
        private Panel panel1;
        protected internal TextBox txt_iconLocation;
        protected PictureBox pxb_ItemIcon;
        private TextBox txt_engEditor;
        private Button btn_OpenLocation;
        protected TextBox txt_Msg;
        private Button btn_OpenIconLocation;
        private Button button1;
        protected ToolStripMenuItem btn_AutoComment;
    }
}
