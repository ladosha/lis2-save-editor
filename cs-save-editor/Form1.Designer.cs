namespace cs_save_editor
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.textBoxSavePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonSaveEdits = new System.Windows.Forms.Button();
            this.buttonAbout = new System.Windows.Forms.Button();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageGeneral = new System.Windows.Forms.TabPage();
            this.dateTimePickerSaveTime = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxSubContextPath = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxEPName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxGameStarted = new System.Windows.Forms.CheckBox();
            this.textBoxSubContextName = new System.Windows.Forms.TextBox();
            this.textBoxSubContextID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxMapName = new System.Windows.Forms.TextBox();
            this.textBoxCPName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPageInventory = new System.Windows.Forms.TabPage();
            this.tabControlInventory = new System.Windows.Forms.TabControl();
            this.tabPageInv = new System.Windows.Forms.TabPage();
            this.dataGridViewInventory1 = new System.Windows.Forms.DataGridView();
            this.tabPageBackpack = new System.Windows.Forms.TabPage();
            this.dataGridViewInventory2 = new System.Windows.Forms.DataGridView();
            this.tabPagePockets = new System.Windows.Forms.TabPage();
            this.dataGridViewInventory3 = new System.Windows.Forms.DataGridView();
            this.tabPageSeenNotifs = new System.Windows.Forms.TabPage();
            this.dataGridViewSeenNotifs = new System.Windows.Forms.DataGridView();
            this.tabPageSeenTutos = new System.Windows.Forms.TabPage();
            this.dataGridViewSeenTutos = new System.Windows.Forms.DataGridView();
            this.tabPageFacts = new System.Windows.Forms.TabPage();
            this.dataGridViewFacts = new System.Windows.Forms.DataGridView();
            this.tabPageWorld = new System.Windows.Forms.TabPage();
            this.dataGridViewWorld = new System.Windows.Forms.DataGridView();
            this.tabPageLevels = new System.Windows.Forms.TabPage();
            this.tabPageMetrics = new System.Windows.Forms.TabPage();
            this.tabPageSeenPics = new System.Windows.Forms.TabPage();
            this.dataGridViewSeenPics = new System.Windows.Forms.DataGridView();
            this.tabPagePhone = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPageOutfits = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelChangesWarning = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabControlMain.SuspendLayout();
            this.tabPageGeneral.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPageInventory.SuspendLayout();
            this.tabControlInventory.SuspendLayout();
            this.tabPageInv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInventory1)).BeginInit();
            this.tabPageBackpack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInventory2)).BeginInit();
            this.tabPagePockets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInventory3)).BeginInit();
            this.tabPageSeenNotifs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSeenNotifs)).BeginInit();
            this.tabPageSeenTutos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSeenTutos)).BeginInit();
            this.tabPageFacts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFacts)).BeginInit();
            this.tabPageWorld.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWorld)).BeginInit();
            this.tabPageSeenPics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSeenPics)).BeginInit();
            this.tabPagePhone.SuspendLayout();
            this.tabPageOutfits.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxSavePath
            // 
            this.textBoxSavePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSavePath.Location = new System.Drawing.Point(98, 5);
            this.textBoxSavePath.Name = "textBoxSavePath";
            this.textBoxSavePath.Size = new System.Drawing.Size(433, 20);
            this.textBoxSavePath.TabIndex = 0;
            this.textBoxSavePath.TextChanged += new System.EventHandler(this.textBoxSavePath_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Path to save file:";
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowse.Location = new System.Drawing.Point(537, 3);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(54, 23);
            this.buttonBrowse.TabIndex = 2;
            this.buttonBrowse.Text = "Browse";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLoad.Location = new System.Drawing.Point(597, 3);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(54, 23);
            this.buttonLoad.TabIndex = 3;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // buttonSaveEdits
            // 
            this.buttonSaveEdits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSaveEdits.Enabled = false;
            this.buttonSaveEdits.Location = new System.Drawing.Point(597, 33);
            this.buttonSaveEdits.Name = "buttonSaveEdits";
            this.buttonSaveEdits.Size = new System.Drawing.Size(54, 23);
            this.buttonSaveEdits.TabIndex = 4;
            this.buttonSaveEdits.Text = "Save";
            this.buttonSaveEdits.UseVisualStyleBackColor = true;
            this.buttonSaveEdits.Click += new System.EventHandler(this.buttonSaveEdits_Click);
            // 
            // buttonAbout
            // 
            this.buttonAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAbout.Location = new System.Drawing.Point(537, 33);
            this.buttonAbout.Name = "buttonAbout";
            this.buttonAbout.Size = new System.Drawing.Size(54, 23);
            this.buttonAbout.TabIndex = 5;
            this.buttonAbout.Text = "About";
            this.buttonAbout.UseVisualStyleBackColor = true;
            this.buttonAbout.Click += new System.EventHandler(this.buttonAbout_Click);
            // 
            // tabControlMain
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.tabControlMain, 4);
            this.tabControlMain.Controls.Add(this.tabPageGeneral);
            this.tabControlMain.Controls.Add(this.tabPageInventory);
            this.tabControlMain.Controls.Add(this.tabPageSeenNotifs);
            this.tabControlMain.Controls.Add(this.tabPageSeenTutos);
            this.tabControlMain.Controls.Add(this.tabPageFacts);
            this.tabControlMain.Controls.Add(this.tabPageWorld);
            this.tabControlMain.Controls.Add(this.tabPageLevels);
            this.tabControlMain.Controls.Add(this.tabPageMetrics);
            this.tabControlMain.Controls.Add(this.tabPageSeenPics);
            this.tabControlMain.Controls.Add(this.tabPagePhone);
            this.tabControlMain.Controls.Add(this.tabPageOutfits);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Enabled = false;
            this.tabControlMain.ItemSize = new System.Drawing.Size(49, 20);
            this.tabControlMain.Location = new System.Drawing.Point(3, 63);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(648, 481);
            this.tabControlMain.TabIndex = 6;
            // 
            // tabPageGeneral
            // 
            this.tabPageGeneral.Controls.Add(this.dateTimePickerSaveTime);
            this.tabPageGeneral.Controls.Add(this.label8);
            this.tabPageGeneral.Controls.Add(this.textBoxSubContextPath);
            this.tabPageGeneral.Controls.Add(this.label7);
            this.tabPageGeneral.Controls.Add(this.groupBox1);
            this.tabPageGeneral.Controls.Add(this.textBoxSubContextID);
            this.tabPageGeneral.Controls.Add(this.label5);
            this.tabPageGeneral.Controls.Add(this.textBoxMapName);
            this.tabPageGeneral.Controls.Add(this.textBoxCPName);
            this.tabPageGeneral.Controls.Add(this.label4);
            this.tabPageGeneral.Controls.Add(this.label3);
            this.tabPageGeneral.Location = new System.Drawing.Point(4, 24);
            this.tabPageGeneral.Name = "tabPageGeneral";
            this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGeneral.Size = new System.Drawing.Size(640, 453);
            this.tabPageGeneral.TabIndex = 0;
            this.tabPageGeneral.Text = "General";
            this.tabPageGeneral.UseVisualStyleBackColor = true;
            // 
            // dateTimePickerSaveTime
            // 
            this.dateTimePickerSaveTime.CustomFormat = "dd MMMM yyyy HH:mm";
            this.dateTimePickerSaveTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerSaveTime.Location = new System.Drawing.Point(382, 122);
            this.dateTimePickerSaveTime.Name = "dateTimePickerSaveTime";
            this.dateTimePickerSaveTime.Size = new System.Drawing.Size(203, 20);
            this.dateTimePickerSaveTime.TabIndex = 14;
            this.dateTimePickerSaveTime.ValueChanged += new System.EventHandler(this.dateTimePickerSaveTime_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(322, 122);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Save time";
            // 
            // textBoxSubContextPath
            // 
            this.textBoxSubContextPath.Location = new System.Drawing.Point(382, 96);
            this.textBoxSubContextPath.Name = "textBoxSubContextPath";
            this.textBoxSubContextPath.Size = new System.Drawing.Size(203, 20);
            this.textBoxSubContextPath.TabIndex = 12;
            this.textBoxSubContextPath.TextChanged += new System.EventHandler(this.textBoxSubContextPath_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(289, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "SubContext Path";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBoxEPName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.checkBoxGameStarted);
            this.groupBox1.Controls.Add(this.textBoxSubContextName);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(6, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 96);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Header (LIS 2)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "SubContext Name";
            // 
            // textBoxEPName
            // 
            this.textBoxEPName.Location = new System.Drawing.Point(105, 19);
            this.textBoxEPName.Name = "textBoxEPName";
            this.textBoxEPName.Size = new System.Drawing.Size(100, 20);
            this.textBoxEPName.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Episode Name";
            // 
            // checkBoxGameStarted
            // 
            this.checkBoxGameStarted.AutoSize = true;
            this.checkBoxGameStarted.Location = new System.Drawing.Point(105, 71);
            this.checkBoxGameStarted.Name = "checkBoxGameStarted";
            this.checkBoxGameStarted.Size = new System.Drawing.Size(89, 17);
            this.checkBoxGameStarted.TabIndex = 7;
            this.checkBoxGameStarted.Text = "Game started";
            this.checkBoxGameStarted.UseVisualStyleBackColor = true;
            // 
            // textBoxSubContextName
            // 
            this.textBoxSubContextName.Location = new System.Drawing.Point(105, 45);
            this.textBoxSubContextName.Name = "textBoxSubContextName";
            this.textBoxSubContextName.Size = new System.Drawing.Size(100, 20);
            this.textBoxSubContextName.TabIndex = 9;
            // 
            // textBoxSubContextID
            // 
            this.textBoxSubContextID.Location = new System.Drawing.Point(382, 70);
            this.textBoxSubContextID.Name = "textBoxSubContextID";
            this.textBoxSubContextID.Size = new System.Drawing.Size(203, 20);
            this.textBoxSubContextID.TabIndex = 6;
            this.textBoxSubContextID.TextChanged += new System.EventHandler(this.textBoxSubContextID_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(300, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "SubContext ID";
            // 
            // textBoxMapName
            // 
            this.textBoxMapName.Location = new System.Drawing.Point(382, 44);
            this.textBoxMapName.Name = "textBoxMapName";
            this.textBoxMapName.Size = new System.Drawing.Size(203, 20);
            this.textBoxMapName.TabIndex = 4;
            this.textBoxMapName.TextChanged += new System.EventHandler(this.textBoxMapName_TextChanged);
            // 
            // textBoxCPName
            // 
            this.textBoxCPName.Location = new System.Drawing.Point(382, 18);
            this.textBoxCPName.Name = "textBoxCPName";
            this.textBoxCPName.Size = new System.Drawing.Size(203, 20);
            this.textBoxCPName.TabIndex = 3;
            this.textBoxCPName.TextChanged += new System.EventHandler(this.textBoxCPName_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(317, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Map Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(289, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Checkpoint Name";
            // 
            // tabPageInventory
            // 
            this.tabPageInventory.Controls.Add(this.tabControlInventory);
            this.tabPageInventory.Location = new System.Drawing.Point(4, 24);
            this.tabPageInventory.Name = "tabPageInventory";
            this.tabPageInventory.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInventory.Size = new System.Drawing.Size(640, 453);
            this.tabPageInventory.TabIndex = 1;
            this.tabPageInventory.Text = "Inventory";
            this.tabPageInventory.UseVisualStyleBackColor = true;
            // 
            // tabControlInventory
            // 
            this.tabControlInventory.Controls.Add(this.tabPageInv);
            this.tabControlInventory.Controls.Add(this.tabPageBackpack);
            this.tabControlInventory.Controls.Add(this.tabPagePockets);
            this.tabControlInventory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlInventory.Location = new System.Drawing.Point(3, 3);
            this.tabControlInventory.Name = "tabControlInventory";
            this.tabControlInventory.SelectedIndex = 0;
            this.tabControlInventory.Size = new System.Drawing.Size(634, 447);
            this.tabControlInventory.TabIndex = 1;
            this.tabControlInventory.Tag = "Chris";
            // 
            // tabPageInv
            // 
            this.tabPageInv.Controls.Add(this.dataGridViewInventory1);
            this.tabPageInv.Location = new System.Drawing.Point(4, 22);
            this.tabPageInv.Name = "tabPageInv";
            this.tabPageInv.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInv.Size = new System.Drawing.Size(626, 421);
            this.tabPageInv.TabIndex = 0;
            this.tabPageInv.Text = "Inventory";
            this.tabPageInv.UseVisualStyleBackColor = true;
            // 
            // dataGridViewInventory1
            // 
            this.dataGridViewInventory1.AllowUserToResizeRows = false;
            this.dataGridViewInventory1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewInventory1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInventory1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewInventory1.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewInventory1.Name = "dataGridViewInventory1";
            this.dataGridViewInventory1.Size = new System.Drawing.Size(620, 415);
            this.dataGridViewInventory1.TabIndex = 1;
            this.dataGridViewInventory1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView_CellBeginEdit);
            this.dataGridViewInventory1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewInventory1_CellEndEdit);
            this.dataGridViewInventory1.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_RowValidated);
            this.dataGridViewInventory1.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView_RowValidating);
            this.dataGridViewInventory1.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView_UserAddedRow);
            this.dataGridViewInventory1.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridView_UserDeletingRow);
            // 
            // tabPageBackpack
            // 
            this.tabPageBackpack.Controls.Add(this.dataGridViewInventory2);
            this.tabPageBackpack.Location = new System.Drawing.Point(4, 22);
            this.tabPageBackpack.Name = "tabPageBackpack";
            this.tabPageBackpack.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBackpack.Size = new System.Drawing.Size(626, 421);
            this.tabPageBackpack.TabIndex = 1;
            this.tabPageBackpack.Text = "Backpack";
            this.tabPageBackpack.UseVisualStyleBackColor = true;
            // 
            // dataGridViewInventory2
            // 
            this.dataGridViewInventory2.AllowUserToResizeRows = false;
            this.dataGridViewInventory2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewInventory2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInventory2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewInventory2.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewInventory2.Name = "dataGridViewInventory2";
            this.dataGridViewInventory2.Size = new System.Drawing.Size(620, 415);
            this.dataGridViewInventory2.TabIndex = 1;
            this.dataGridViewInventory2.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView_CellBeginEdit);
            this.dataGridViewInventory2.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewInventory2_CellEndEdit);
            this.dataGridViewInventory2.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_RowValidated);
            this.dataGridViewInventory2.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView_RowValidating);
            this.dataGridViewInventory2.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView_UserAddedRow);
            this.dataGridViewInventory2.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridView_UserDeletingRow);
            // 
            // tabPagePockets
            // 
            this.tabPagePockets.Controls.Add(this.dataGridViewInventory3);
            this.tabPagePockets.Location = new System.Drawing.Point(4, 22);
            this.tabPagePockets.Name = "tabPagePockets";
            this.tabPagePockets.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePockets.Size = new System.Drawing.Size(626, 421);
            this.tabPagePockets.TabIndex = 2;
            this.tabPagePockets.Text = "Pockets";
            this.tabPagePockets.UseVisualStyleBackColor = true;
            // 
            // dataGridViewInventory3
            // 
            this.dataGridViewInventory3.AllowUserToResizeRows = false;
            this.dataGridViewInventory3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewInventory3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInventory3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewInventory3.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewInventory3.Name = "dataGridViewInventory3";
            this.dataGridViewInventory3.Size = new System.Drawing.Size(620, 415);
            this.dataGridViewInventory3.TabIndex = 1;
            this.dataGridViewInventory3.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView_CellBeginEdit);
            this.dataGridViewInventory3.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewInventory3_CellEndEdit);
            this.dataGridViewInventory3.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_RowValidated);
            this.dataGridViewInventory3.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView_RowValidating);
            this.dataGridViewInventory3.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView_UserAddedRow);
            this.dataGridViewInventory3.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridView_UserDeletingRow);
            // 
            // tabPageSeenNotifs
            // 
            this.tabPageSeenNotifs.Controls.Add(this.dataGridViewSeenNotifs);
            this.tabPageSeenNotifs.Location = new System.Drawing.Point(4, 24);
            this.tabPageSeenNotifs.Name = "tabPageSeenNotifs";
            this.tabPageSeenNotifs.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSeenNotifs.Size = new System.Drawing.Size(640, 453);
            this.tabPageSeenNotifs.TabIndex = 2;
            this.tabPageSeenNotifs.Text = "Seen notifications";
            this.tabPageSeenNotifs.UseVisualStyleBackColor = true;
            // 
            // dataGridViewSeenNotifs
            // 
            this.dataGridViewSeenNotifs.AllowUserToAddRows = false;
            this.dataGridViewSeenNotifs.AllowUserToDeleteRows = false;
            this.dataGridViewSeenNotifs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSeenNotifs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSeenNotifs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSeenNotifs.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewSeenNotifs.Name = "dataGridViewSeenNotifs";
            this.dataGridViewSeenNotifs.ReadOnly = true;
            this.dataGridViewSeenNotifs.Size = new System.Drawing.Size(634, 447);
            this.dataGridViewSeenNotifs.TabIndex = 1;
            // 
            // tabPageSeenTutos
            // 
            this.tabPageSeenTutos.Controls.Add(this.dataGridViewSeenTutos);
            this.tabPageSeenTutos.Location = new System.Drawing.Point(4, 24);
            this.tabPageSeenTutos.Name = "tabPageSeenTutos";
            this.tabPageSeenTutos.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSeenTutos.Size = new System.Drawing.Size(640, 453);
            this.tabPageSeenTutos.TabIndex = 5;
            this.tabPageSeenTutos.Text = "Seen tutorials";
            this.tabPageSeenTutos.UseVisualStyleBackColor = true;
            // 
            // dataGridViewSeenTutos
            // 
            this.dataGridViewSeenTutos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSeenTutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSeenTutos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSeenTutos.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewSeenTutos.Name = "dataGridViewSeenTutos";
            this.dataGridViewSeenTutos.Size = new System.Drawing.Size(634, 447);
            this.dataGridViewSeenTutos.TabIndex = 1;
            this.dataGridViewSeenTutos.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView_CellBeginEdit);
            this.dataGridViewSeenTutos.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSeenTutos_CellEndEdit);
            this.dataGridViewSeenTutos.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_RowValidated);
            this.dataGridViewSeenTutos.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView_RowValidating);
            this.dataGridViewSeenTutos.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView_UserAddedRow);
            this.dataGridViewSeenTutos.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridView_UserDeletingRow);
            // 
            // tabPageFacts
            // 
            this.tabPageFacts.Controls.Add(this.dataGridViewFacts);
            this.tabPageFacts.Location = new System.Drawing.Point(4, 24);
            this.tabPageFacts.Name = "tabPageFacts";
            this.tabPageFacts.Size = new System.Drawing.Size(640, 453);
            this.tabPageFacts.TabIndex = 3;
            this.tabPageFacts.Text = "Facts";
            this.tabPageFacts.UseVisualStyleBackColor = true;
            // 
            // dataGridViewFacts
            // 
            this.dataGridViewFacts.AllowUserToAddRows = false;
            this.dataGridViewFacts.AllowUserToDeleteRows = false;
            this.dataGridViewFacts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewFacts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFacts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewFacts.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewFacts.Name = "dataGridViewFacts";
            this.dataGridViewFacts.Size = new System.Drawing.Size(640, 453);
            this.dataGridViewFacts.TabIndex = 0;
            this.dataGridViewFacts.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView_CellBeginEdit);
            this.dataGridViewFacts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewFacts_CellContentClick);
            this.dataGridViewFacts.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewFacts_CellEndEdit);
            // 
            // tabPageWorld
            // 
            this.tabPageWorld.Controls.Add(this.dataGridViewWorld);
            this.tabPageWorld.Location = new System.Drawing.Point(4, 24);
            this.tabPageWorld.Name = "tabPageWorld";
            this.tabPageWorld.Size = new System.Drawing.Size(640, 453);
            this.tabPageWorld.TabIndex = 4;
            this.tabPageWorld.Text = "Packages";
            this.tabPageWorld.UseVisualStyleBackColor = true;
            // 
            // dataGridViewWorld
            // 
            this.dataGridViewWorld.AllowUserToAddRows = false;
            this.dataGridViewWorld.AllowUserToDeleteRows = false;
            this.dataGridViewWorld.AllowUserToResizeRows = false;
            this.dataGridViewWorld.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewWorld.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWorld.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewWorld.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewWorld.Name = "dataGridViewWorld";
            this.dataGridViewWorld.Size = new System.Drawing.Size(640, 453);
            this.dataGridViewWorld.TabIndex = 0;
            this.dataGridViewWorld.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView_CellBeginEdit);
            this.dataGridViewWorld.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewWorld_CellEndEdit);
            // 
            // tabPageLevels
            // 
            this.tabPageLevels.Location = new System.Drawing.Point(4, 24);
            this.tabPageLevels.Name = "tabPageLevels";
            this.tabPageLevels.Size = new System.Drawing.Size(640, 453);
            this.tabPageLevels.TabIndex = 6;
            this.tabPageLevels.Text = "Levels";
            this.tabPageLevels.UseVisualStyleBackColor = true;
            // 
            // tabPageMetrics
            // 
            this.tabPageMetrics.AutoScroll = true;
            this.tabPageMetrics.Location = new System.Drawing.Point(4, 24);
            this.tabPageMetrics.Name = "tabPageMetrics";
            this.tabPageMetrics.Size = new System.Drawing.Size(640, 453);
            this.tabPageMetrics.TabIndex = 7;
            this.tabPageMetrics.Text = "Metrics";
            this.tabPageMetrics.UseVisualStyleBackColor = true;
            // 
            // tabPageSeenPics
            // 
            this.tabPageSeenPics.Controls.Add(this.dataGridViewSeenPics);
            this.tabPageSeenPics.Location = new System.Drawing.Point(4, 24);
            this.tabPageSeenPics.Name = "tabPageSeenPics";
            this.tabPageSeenPics.Size = new System.Drawing.Size(640, 453);
            this.tabPageSeenPics.TabIndex = 8;
            this.tabPageSeenPics.Text = "Seen pictures";
            this.tabPageSeenPics.UseVisualStyleBackColor = true;
            // 
            // dataGridViewSeenPics
            // 
            this.dataGridViewSeenPics.AllowUserToResizeRows = false;
            this.dataGridViewSeenPics.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSeenPics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSeenPics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSeenPics.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewSeenPics.Name = "dataGridViewSeenPics";
            this.dataGridViewSeenPics.Size = new System.Drawing.Size(640, 453);
            this.dataGridViewSeenPics.TabIndex = 1;
            this.dataGridViewSeenPics.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView_CellBeginEdit);
            this.dataGridViewSeenPics.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_RowValidated);
            this.dataGridViewSeenPics.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView_RowValidating);
            this.dataGridViewSeenPics.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView_UserAddedRow);
            this.dataGridViewSeenPics.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridView_UserDeletingRow);
            // 
            // tabPagePhone
            // 
            this.tabPagePhone.Controls.Add(this.label9);
            this.tabPagePhone.Location = new System.Drawing.Point(4, 24);
            this.tabPagePhone.Name = "tabPagePhone";
            this.tabPagePhone.Size = new System.Drawing.Size(640, 453);
            this.tabPagePhone.TabIndex = 9;
            this.tabPagePhone.Text = "Phone";
            this.tabPagePhone.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "(LIS2 Only)";
            // 
            // tabPageOutfits
            // 
            this.tabPageOutfits.Controls.Add(this.label10);
            this.tabPageOutfits.Location = new System.Drawing.Point(4, 24);
            this.tabPageOutfits.Name = "tabPageOutfits";
            this.tabPageOutfits.Size = new System.Drawing.Size(640, 453);
            this.tabPageOutfits.TabIndex = 10;
            this.tabPageOutfits.Text = "Outfits";
            this.tabPageOutfits.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "(LIS2 Only)";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.Controls.Add(this.tabControlMain, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonSaveEdits, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonLoad, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonAbout, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonBrowse, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxSavePath, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelChangesWarning, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(654, 541);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // labelChangesWarning
            // 
            this.labelChangesWarning.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelChangesWarning.AutoSize = true;
            this.labelChangesWarning.ForeColor = System.Drawing.Color.Red;
            this.labelChangesWarning.Location = new System.Drawing.Point(98, 38);
            this.labelChangesWarning.Name = "labelChangesWarning";
            this.labelChangesWarning.Size = new System.Drawing.Size(433, 13);
            this.labelChangesWarning.TabIndex = 9;
            this.labelChangesWarning.Text = "Save file changed! Press Load to update.";
            this.labelChangesWarning.Visible = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Save file|*.sav";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 541);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(670, 400);
            this.Name = "MainForm";
            this.Text = "Captain Spirit Save Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControlMain.ResumeLayout(false);
            this.tabPageGeneral.ResumeLayout(false);
            this.tabPageGeneral.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPageInventory.ResumeLayout(false);
            this.tabControlInventory.ResumeLayout(false);
            this.tabPageInv.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInventory1)).EndInit();
            this.tabPageBackpack.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInventory2)).EndInit();
            this.tabPagePockets.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInventory3)).EndInit();
            this.tabPageSeenNotifs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSeenNotifs)).EndInit();
            this.tabPageSeenTutos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSeenTutos)).EndInit();
            this.tabPageFacts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFacts)).EndInit();
            this.tabPageWorld.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWorld)).EndInit();
            this.tabPageSeenPics.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSeenPics)).EndInit();
            this.tabPagePhone.ResumeLayout(false);
            this.tabPagePhone.PerformLayout();
            this.tabPageOutfits.ResumeLayout(false);
            this.tabPageOutfits.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSavePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button buttonSaveEdits;
        private System.Windows.Forms.Button buttonAbout;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageGeneral;
        private System.Windows.Forms.TabPage tabPageInventory;
        private System.Windows.Forms.CheckBox checkBoxGameStarted;
        private System.Windows.Forms.TextBox textBoxSubContextID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxMapName;
        private System.Windows.Forms.TextBox textBoxCPName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPageSeenNotifs;
        private System.Windows.Forms.TabPage tabPageFacts;
        private System.Windows.Forms.TabPage tabPageWorld;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxEPName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxSubContextName;
        private System.Windows.Forms.DataGridView dataGridViewSeenNotifs;
        private System.Windows.Forms.TabPage tabPageSeenTutos;
        private System.Windows.Forms.DataGridView dataGridViewSeenTutos;
        private System.Windows.Forms.DateTimePicker dateTimePickerSaveTime;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxSubContextPath;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dataGridViewFacts;
        private System.Windows.Forms.DataGridView dataGridViewWorld;
        private System.Windows.Forms.TabPage tabPageLevels;
        private System.Windows.Forms.TabPage tabPageMetrics;
        private System.Windows.Forms.TabPage tabPageSeenPics;
        private System.Windows.Forms.TabPage tabPagePhone;
        private System.Windows.Forms.TabPage tabPageOutfits;
        private System.Windows.Forms.TabControl tabControlInventory;
        private System.Windows.Forms.TabPage tabPageInv;
        private System.Windows.Forms.DataGridView dataGridViewInventory1;
        private System.Windows.Forms.TabPage tabPageBackpack;
        private System.Windows.Forms.DataGridView dataGridViewInventory2;
        private System.Windows.Forms.TabPage tabPagePockets;
        private System.Windows.Forms.DataGridView dataGridViewInventory3;
        private System.Windows.Forms.DataGridView dataGridViewSeenPics;
        private System.Windows.Forms.Label labelChangesWarning;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}

