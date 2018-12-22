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
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageInteractions = new System.Windows.Forms.TabPage();
            this.flowLayoutPanelInteractions = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPagePOI = new System.Windows.Forms.TabPage();
            this.dataGridViewPOIs = new System.Windows.Forms.DataGridView();
            this.tabPageWUI = new System.Windows.Forms.TabPage();
            this.dataGridViewWUIs = new System.Windows.Forms.DataGridView();
            this.tabPageSequences = new System.Windows.Forms.TabPage();
            this.tabControlSequences = new System.Windows.Forms.TabControl();
            this.tabPageSeqStopped = new System.Windows.Forms.TabPage();
            this.dataGridViewSeqStopped = new System.Windows.Forms.DataGridView();
            this.tabPageSeqPlaying = new System.Windows.Forms.TabPage();
            this.dataGridViewSeqPlaying = new System.Windows.Forms.DataGridView();
            this.tabPageSeqOnStop = new System.Windows.Forms.TabPage();
            this.dataGridViewSeqOnStop = new System.Windows.Forms.DataGridView();
            this.tabPageSeqOnPlay = new System.Windows.Forms.TabPage();
            this.dataGridViewSeqOnPlay = new System.Windows.Forms.DataGridView();
            this.tabPageSeqOnHasLooped = new System.Windows.Forms.TabPage();
            this.dataGridViewSeqOnHasLooped = new System.Windows.Forms.DataGridView();
            this.tabPageSeqOnEvent = new System.Windows.Forms.TabPage();
            this.dataGridViewSeqOnEvent = new System.Windows.Forms.DataGridView();
            this.tabControlMain.SuspendLayout();
            this.tabPageInteractions.SuspendLayout();
            this.tabPagePOI.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPOIs)).BeginInit();
            this.tabPageWUI.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWUIs)).BeginInit();
            this.tabPageSequences.SuspendLayout();
            this.tabControlSequences.SuspendLayout();
            this.tabPageSeqStopped.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSeqStopped)).BeginInit();
            this.tabPageSeqPlaying.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSeqPlaying)).BeginInit();
            this.tabPageSeqOnStop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSeqOnStop)).BeginInit();
            this.tabPageSeqOnPlay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSeqOnPlay)).BeginInit();
            this.tabPageSeqOnHasLooped.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSeqOnHasLooped)).BeginInit();
            this.tabPageSeqOnEvent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSeqOnEvent)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageInteractions);
            this.tabControlMain.Controls.Add(this.tabPagePOI);
            this.tabControlMain.Controls.Add(this.tabPageWUI);
            this.tabControlMain.Controls.Add(this.tabPageSequences);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(620, 261);
            this.tabControlMain.TabIndex = 0;
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
            // tabPageSequences
            // 
            this.tabPageSequences.Controls.Add(this.tabControlSequences);
            this.tabPageSequences.Location = new System.Drawing.Point(4, 22);
            this.tabPageSequences.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageSequences.Name = "tabPageSequences";
            this.tabPageSequences.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.tabPageSequences.Size = new System.Drawing.Size(612, 235);
            this.tabPageSequences.TabIndex = 3;
            this.tabPageSequences.Text = "Sequences";
            this.tabPageSequences.UseVisualStyleBackColor = true;
            // 
            // tabControlSequences
            // 
            this.tabControlSequences.Controls.Add(this.tabPageSeqStopped);
            this.tabControlSequences.Controls.Add(this.tabPageSeqPlaying);
            this.tabControlSequences.Controls.Add(this.tabPageSeqOnStop);
            this.tabControlSequences.Controls.Add(this.tabPageSeqOnPlay);
            this.tabControlSequences.Controls.Add(this.tabPageSeqOnHasLooped);
            this.tabControlSequences.Controls.Add(this.tabPageSeqOnEvent);
            this.tabControlSequences.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSequences.Location = new System.Drawing.Point(0, 3);
            this.tabControlSequences.Name = "tabControlSequences";
            this.tabControlSequences.SelectedIndex = 0;
            this.tabControlSequences.Size = new System.Drawing.Size(612, 232);
            this.tabControlSequences.TabIndex = 0;
            // 
            // tabPageSeqStopped
            // 
            this.tabPageSeqStopped.Controls.Add(this.dataGridViewSeqStopped);
            this.tabPageSeqStopped.Location = new System.Drawing.Point(4, 22);
            this.tabPageSeqStopped.Name = "tabPageSeqStopped";
            this.tabPageSeqStopped.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSeqStopped.Size = new System.Drawing.Size(604, 206);
            this.tabPageSeqStopped.TabIndex = 0;
            this.tabPageSeqStopped.Text = "Stopped";
            this.tabPageSeqStopped.UseVisualStyleBackColor = true;
            // 
            // dataGridViewSeqStopped
            // 
            this.dataGridViewSeqStopped.AllowUserToAddRows = false;
            this.dataGridViewSeqStopped.AllowUserToDeleteRows = false;
            this.dataGridViewSeqStopped.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSeqStopped.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSeqStopped.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSeqStopped.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewSeqStopped.Name = "dataGridViewSeqStopped";
            this.dataGridViewSeqStopped.Size = new System.Drawing.Size(598, 200);
            this.dataGridViewSeqStopped.TabIndex = 0;
            this.dataGridViewSeqStopped.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView_CellBeginEdit);
            this.dataGridViewSeqStopped.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSeqStopped_CellEndEdit);
            // 
            // tabPageSeqPlaying
            // 
            this.tabPageSeqPlaying.Controls.Add(this.dataGridViewSeqPlaying);
            this.tabPageSeqPlaying.Location = new System.Drawing.Point(4, 22);
            this.tabPageSeqPlaying.Name = "tabPageSeqPlaying";
            this.tabPageSeqPlaying.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSeqPlaying.Size = new System.Drawing.Size(604, 206);
            this.tabPageSeqPlaying.TabIndex = 1;
            this.tabPageSeqPlaying.Text = "Playing";
            this.tabPageSeqPlaying.UseVisualStyleBackColor = true;
            // 
            // dataGridViewSeqPlaying
            // 
            this.dataGridViewSeqPlaying.AllowUserToAddRows = false;
            this.dataGridViewSeqPlaying.AllowUserToDeleteRows = false;
            this.dataGridViewSeqPlaying.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSeqPlaying.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSeqPlaying.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSeqPlaying.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewSeqPlaying.Name = "dataGridViewSeqPlaying";
            this.dataGridViewSeqPlaying.Size = new System.Drawing.Size(598, 200);
            this.dataGridViewSeqPlaying.TabIndex = 1;
            this.dataGridViewSeqPlaying.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView_CellBeginEdit);
            this.dataGridViewSeqPlaying.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSeqPlaying_CellEndEdit);
            // 
            // tabPageSeqOnStop
            // 
            this.tabPageSeqOnStop.Controls.Add(this.dataGridViewSeqOnStop);
            this.tabPageSeqOnStop.Location = new System.Drawing.Point(4, 22);
            this.tabPageSeqOnStop.Name = "tabPageSeqOnStop";
            this.tabPageSeqOnStop.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSeqOnStop.Size = new System.Drawing.Size(604, 206);
            this.tabPageSeqOnStop.TabIndex = 2;
            this.tabPageSeqOnStop.Text = "OnStop";
            this.tabPageSeqOnStop.UseVisualStyleBackColor = true;
            // 
            // dataGridViewSeqOnStop
            // 
            this.dataGridViewSeqOnStop.AllowUserToAddRows = false;
            this.dataGridViewSeqOnStop.AllowUserToDeleteRows = false;
            this.dataGridViewSeqOnStop.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSeqOnStop.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSeqOnStop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSeqOnStop.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewSeqOnStop.Name = "dataGridViewSeqOnStop";
            this.dataGridViewSeqOnStop.Size = new System.Drawing.Size(598, 200);
            this.dataGridViewSeqOnStop.TabIndex = 1;
            this.dataGridViewSeqOnStop.Tag = "OnStop";
            this.dataGridViewSeqOnStop.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView_CellBeginEdit);
            this.dataGridViewSeqOnStop.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSeqOnX_CellEndEdit);
            // 
            // tabPageSeqOnPlay
            // 
            this.tabPageSeqOnPlay.Controls.Add(this.dataGridViewSeqOnPlay);
            this.tabPageSeqOnPlay.Location = new System.Drawing.Point(4, 22);
            this.tabPageSeqOnPlay.Name = "tabPageSeqOnPlay";
            this.tabPageSeqOnPlay.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSeqOnPlay.Size = new System.Drawing.Size(604, 206);
            this.tabPageSeqOnPlay.TabIndex = 3;
            this.tabPageSeqOnPlay.Text = "OnPlay";
            this.tabPageSeqOnPlay.UseVisualStyleBackColor = true;
            // 
            // dataGridViewSeqOnPlay
            // 
            this.dataGridViewSeqOnPlay.AllowUserToAddRows = false;
            this.dataGridViewSeqOnPlay.AllowUserToDeleteRows = false;
            this.dataGridViewSeqOnPlay.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSeqOnPlay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSeqOnPlay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSeqOnPlay.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewSeqOnPlay.Name = "dataGridViewSeqOnPlay";
            this.dataGridViewSeqOnPlay.Size = new System.Drawing.Size(598, 200);
            this.dataGridViewSeqOnPlay.TabIndex = 1;
            this.dataGridViewSeqOnPlay.Tag = "OnPlay";
            this.dataGridViewSeqOnPlay.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView_CellBeginEdit);
            this.dataGridViewSeqOnPlay.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSeqOnX_CellEndEdit);
            // 
            // tabPageSeqOnHasLooped
            // 
            this.tabPageSeqOnHasLooped.Controls.Add(this.dataGridViewSeqOnHasLooped);
            this.tabPageSeqOnHasLooped.Location = new System.Drawing.Point(4, 22);
            this.tabPageSeqOnHasLooped.Name = "tabPageSeqOnHasLooped";
            this.tabPageSeqOnHasLooped.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSeqOnHasLooped.Size = new System.Drawing.Size(604, 206);
            this.tabPageSeqOnHasLooped.TabIndex = 4;
            this.tabPageSeqOnHasLooped.Text = "OnHasLooped";
            this.tabPageSeqOnHasLooped.UseVisualStyleBackColor = true;
            // 
            // dataGridViewSeqOnHasLooped
            // 
            this.dataGridViewSeqOnHasLooped.AllowUserToAddRows = false;
            this.dataGridViewSeqOnHasLooped.AllowUserToDeleteRows = false;
            this.dataGridViewSeqOnHasLooped.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSeqOnHasLooped.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSeqOnHasLooped.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSeqOnHasLooped.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewSeqOnHasLooped.Name = "dataGridViewSeqOnHasLooped";
            this.dataGridViewSeqOnHasLooped.Size = new System.Drawing.Size(598, 200);
            this.dataGridViewSeqOnHasLooped.TabIndex = 1;
            this.dataGridViewSeqOnHasLooped.Tag = "OnHasLooped";
            this.dataGridViewSeqOnHasLooped.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView_CellBeginEdit);
            this.dataGridViewSeqOnHasLooped.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSeqOnX_CellEndEdit);
            // 
            // tabPageSeqOnEvent
            // 
            this.tabPageSeqOnEvent.Controls.Add(this.dataGridViewSeqOnEvent);
            this.tabPageSeqOnEvent.Location = new System.Drawing.Point(4, 22);
            this.tabPageSeqOnEvent.Name = "tabPageSeqOnEvent";
            this.tabPageSeqOnEvent.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSeqOnEvent.Size = new System.Drawing.Size(604, 206);
            this.tabPageSeqOnEvent.TabIndex = 5;
            this.tabPageSeqOnEvent.Text = "OnEvent";
            this.tabPageSeqOnEvent.UseVisualStyleBackColor = true;
            // 
            // dataGridViewSeqOnEvent
            // 
            this.dataGridViewSeqOnEvent.AllowUserToAddRows = false;
            this.dataGridViewSeqOnEvent.AllowUserToDeleteRows = false;
            this.dataGridViewSeqOnEvent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSeqOnEvent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSeqOnEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSeqOnEvent.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewSeqOnEvent.Name = "dataGridViewSeqOnEvent";
            this.dataGridViewSeqOnEvent.Size = new System.Drawing.Size(598, 200);
            this.dataGridViewSeqOnEvent.TabIndex = 1;
            this.dataGridViewSeqOnEvent.Tag = "OnEvent";
            this.dataGridViewSeqOnEvent.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView_CellBeginEdit);
            this.dataGridViewSeqOnEvent.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSeqOnX_CellEndEdit);
            // 
            // LevelEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 261);
            this.Controls.Add(this.tabControlMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "LevelEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit level";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LevelEditForm_FormClosing);
            this.Load += new System.EventHandler(this.LevelEditForm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LevelEditForm_KeyPress);
            this.tabControlMain.ResumeLayout(false);
            this.tabPageInteractions.ResumeLayout(false);
            this.tabPagePOI.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPOIs)).EndInit();
            this.tabPageWUI.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWUIs)).EndInit();
            this.tabPageSequences.ResumeLayout(false);
            this.tabControlSequences.ResumeLayout(false);
            this.tabPageSeqStopped.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSeqStopped)).EndInit();
            this.tabPageSeqPlaying.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSeqPlaying)).EndInit();
            this.tabPageSeqOnStop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSeqOnStop)).EndInit();
            this.tabPageSeqOnPlay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSeqOnPlay)).EndInit();
            this.tabPageSeqOnHasLooped.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSeqOnHasLooped)).EndInit();
            this.tabPageSeqOnEvent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSeqOnEvent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageInteractions;
        private System.Windows.Forms.TabPage tabPagePOI;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelInteractions;
        private System.Windows.Forms.DataGridView dataGridViewPOIs;
        private System.Windows.Forms.TabPage tabPageWUI;
        private System.Windows.Forms.DataGridView dataGridViewWUIs;
        private System.Windows.Forms.TabPage tabPageSequences;
        private System.Windows.Forms.TabControl tabControlSequences;
        private System.Windows.Forms.TabPage tabPageSeqStopped;
        private System.Windows.Forms.TabPage tabPageSeqPlaying;
        private System.Windows.Forms.TabPage tabPageSeqOnStop;
        private System.Windows.Forms.TabPage tabPageSeqOnPlay;
        private System.Windows.Forms.TabPage tabPageSeqOnHasLooped;
        private System.Windows.Forms.TabPage tabPageSeqOnEvent;
        private System.Windows.Forms.DataGridView dataGridViewSeqStopped;
        private System.Windows.Forms.DataGridView dataGridViewSeqPlaying;
        private System.Windows.Forms.DataGridView dataGridViewSeqOnStop;
        private System.Windows.Forms.DataGridView dataGridViewSeqOnPlay;
        private System.Windows.Forms.DataGridView dataGridViewSeqOnHasLooped;
        private System.Windows.Forms.DataGridView dataGridViewSeqOnEvent;
    }
}