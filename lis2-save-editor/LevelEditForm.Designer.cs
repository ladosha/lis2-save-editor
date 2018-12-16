namespace lis2_save_editor
{
    partial class LevelEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LevelEditForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageInteractions = new System.Windows.Forms.TabPage();
            this.flowLayoutPanelInteractions = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPagePOI = new System.Windows.Forms.TabPage();
            this.dataGridViewPOIs = new System.Windows.Forms.DataGridView();
            this.tabPageWUI = new System.Windows.Forms.TabPage();
            this.dataGridViewWUIs = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabPageInteractions.SuspendLayout();
            this.tabPagePOI.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPOIs)).BeginInit();
            this.tabPageWUI.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWUIs)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageInteractions);
            this.tabControl1.Controls.Add(this.tabPagePOI);
            this.tabControl1.Controls.Add(this.tabPageWUI);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(620, 261);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageInteractions
            // 
            this.tabPageInteractions.Controls.Add(this.flowLayoutPanelInteractions);
            this.tabPageInteractions.Location = new System.Drawing.Point(4, 22);
            this.tabPageInteractions.Name = "tabPageInteractions";
            this.tabPageInteractions.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInteractions.Size = new System.Drawing.Size(612, 235);
            this.tabPageInteractions.TabIndex = 0;
            this.tabPageInteractions.Text = "Interactions";
            this.tabPageInteractions.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanelInteractions
            // 
            this.flowLayoutPanelInteractions.AutoScroll = true;
            this.flowLayoutPanelInteractions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelInteractions.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanelInteractions.Name = "flowLayoutPanelInteractions";
            this.flowLayoutPanelInteractions.Size = new System.Drawing.Size(606, 229);
            this.flowLayoutPanelInteractions.TabIndex = 0;
            // 
            // tabPagePOI
            // 
            this.tabPagePOI.Controls.Add(this.dataGridViewPOIs);
            this.tabPagePOI.Location = new System.Drawing.Point(4, 22);
            this.tabPagePOI.Name = "tabPagePOI";
            this.tabPagePOI.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePOI.Size = new System.Drawing.Size(612, 235);
            this.tabPagePOI.TabIndex = 1;
            this.tabPagePOI.Text = "Points of Interest";
            this.tabPagePOI.UseVisualStyleBackColor = true;
            // 
            // dataGridViewPOIs
            // 
            this.dataGridViewPOIs.AllowUserToAddRows = false;
            this.dataGridViewPOIs.AllowUserToDeleteRows = false;
            this.dataGridViewPOIs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewPOIs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPOIs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewPOIs.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewPOIs.Name = "dataGridViewPOIs";
            this.dataGridViewPOIs.Size = new System.Drawing.Size(606, 229);
            this.dataGridViewPOIs.TabIndex = 0;
            this.dataGridViewPOIs.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView_CellBeginEdit);
            this.dataGridViewPOIs.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPOIs_CellEndEdit);
            // 
            // tabPageWUI
            // 
            this.tabPageWUI.Controls.Add(this.dataGridViewWUIs);
            this.tabPageWUI.Location = new System.Drawing.Point(4, 22);
            this.tabPageWUI.Name = "tabPageWUI";
            this.tabPageWUI.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageWUI.Size = new System.Drawing.Size(612, 235);
            this.tabPageWUI.TabIndex = 2;
            this.tabPageWUI.Text = "Volumes";
            this.tabPageWUI.UseVisualStyleBackColor = true;
            // 
            // dataGridViewWUIs
            // 
            this.dataGridViewWUIs.AllowUserToAddRows = false;
            this.dataGridViewWUIs.AllowUserToDeleteRows = false;
            this.dataGridViewWUIs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewWUIs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWUIs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewWUIs.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewWUIs.Name = "dataGridViewWUIs";
            this.dataGridViewWUIs.Size = new System.Drawing.Size(606, 229);
            this.dataGridViewWUIs.TabIndex = 1;
            this.dataGridViewWUIs.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView_CellBeginEdit);
            this.dataGridViewWUIs.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewWUIs_CellEndEdit);
            // 
            // LevelEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 261);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "LevelEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit level";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LevelEditForm_FormClosing);
            this.Load += new System.EventHandler(this.LevelEditForm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LevelEditForm_KeyPress);
            this.tabControl1.ResumeLayout(false);
            this.tabPageInteractions.ResumeLayout(false);
            this.tabPagePOI.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPOIs)).EndInit();
            this.tabPageWUI.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWUIs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageInteractions;
        private System.Windows.Forms.TabPage tabPagePOI;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelInteractions;
        private System.Windows.Forms.DataGridView dataGridViewPOIs;
        private System.Windows.Forms.TabPage tabPageWUI;
        private System.Windows.Forms.DataGridView dataGridViewWUIs;
    }
}