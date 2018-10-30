namespace lis2_save_editor
{
    partial class FactEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FactEditForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageBool = new System.Windows.Forms.TabPage();
            this.dataGridViewBool = new System.Windows.Forms.DataGridView();
            this.tabPageInt = new System.Windows.Forms.TabPage();
            this.dataGridViewInt = new System.Windows.Forms.DataGridView();
            this.tabPageFloat = new System.Windows.Forms.TabPage();
            this.dataGridViewFloat = new System.Windows.Forms.DataGridView();
            this.tabPageEnum = new System.Windows.Forms.TabPage();
            this.dataGridViewEnum = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabPageBool.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBool)).BeginInit();
            this.tabPageInt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInt)).BeginInit();
            this.tabPageFloat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFloat)).BeginInit();
            this.tabPageEnum.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEnum)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageBool);
            this.tabControl1.Controls.Add(this.tabPageInt);
            this.tabControl1.Controls.Add(this.tabPageFloat);
            this.tabControl1.Controls.Add(this.tabPageEnum);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(748, 261);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageBool
            // 
            this.tabPageBool.Controls.Add(this.dataGridViewBool);
            this.tabPageBool.Location = new System.Drawing.Point(4, 22);
            this.tabPageBool.Name = "tabPageBool";
            this.tabPageBool.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBool.Size = new System.Drawing.Size(740, 235);
            this.tabPageBool.TabIndex = 0;
            this.tabPageBool.Text = "Boolean";
            this.tabPageBool.UseVisualStyleBackColor = true;
            // 
            // dataGridViewBool
            // 
            this.dataGridViewBool.AllowUserToAddRows = false;
            this.dataGridViewBool.AllowUserToDeleteRows = false;
            this.dataGridViewBool.AllowUserToResizeRows = false;
            this.dataGridViewBool.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewBool.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBool.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewBool.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewBool.Name = "dataGridViewBool";
            this.dataGridViewBool.Size = new System.Drawing.Size(734, 229);
            this.dataGridViewBool.TabIndex = 0;
            this.dataGridViewBool.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView_CellBeginEdit);
            this.dataGridViewBool.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewBool_CellEndEdit);
            // 
            // tabPageInt
            // 
            this.tabPageInt.Controls.Add(this.dataGridViewInt);
            this.tabPageInt.Location = new System.Drawing.Point(4, 22);
            this.tabPageInt.Name = "tabPageInt";
            this.tabPageInt.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInt.Size = new System.Drawing.Size(740, 235);
            this.tabPageInt.TabIndex = 1;
            this.tabPageInt.Text = "Integer";
            this.tabPageInt.UseVisualStyleBackColor = true;
            // 
            // dataGridViewInt
            // 
            this.dataGridViewInt.AllowUserToAddRows = false;
            this.dataGridViewInt.AllowUserToDeleteRows = false;
            this.dataGridViewInt.AllowUserToResizeRows = false;
            this.dataGridViewInt.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewInt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewInt.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewInt.Name = "dataGridViewInt";
            this.dataGridViewInt.Size = new System.Drawing.Size(734, 229);
            this.dataGridViewInt.TabIndex = 1;
            this.dataGridViewInt.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView_CellBeginEdit);
            this.dataGridViewInt.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewInt_CellEndEdit);
            // 
            // tabPageFloat
            // 
            this.tabPageFloat.Controls.Add(this.dataGridViewFloat);
            this.tabPageFloat.Location = new System.Drawing.Point(4, 22);
            this.tabPageFloat.Name = "tabPageFloat";
            this.tabPageFloat.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFloat.Size = new System.Drawing.Size(740, 235);
            this.tabPageFloat.TabIndex = 2;
            this.tabPageFloat.Text = "Float";
            this.tabPageFloat.UseVisualStyleBackColor = true;
            // 
            // dataGridViewFloat
            // 
            this.dataGridViewFloat.AllowUserToAddRows = false;
            this.dataGridViewFloat.AllowUserToDeleteRows = false;
            this.dataGridViewFloat.AllowUserToResizeRows = false;
            this.dataGridViewFloat.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewFloat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFloat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewFloat.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewFloat.Name = "dataGridViewFloat";
            this.dataGridViewFloat.Size = new System.Drawing.Size(734, 229);
            this.dataGridViewFloat.TabIndex = 1;
            this.dataGridViewFloat.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView_CellBeginEdit);
            this.dataGridViewFloat.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewFloat_CellEndEdit);
            // 
            // tabPageEnum
            // 
            this.tabPageEnum.Controls.Add(this.dataGridViewEnum);
            this.tabPageEnum.Location = new System.Drawing.Point(4, 22);
            this.tabPageEnum.Name = "tabPageEnum";
            this.tabPageEnum.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEnum.Size = new System.Drawing.Size(740, 235);
            this.tabPageEnum.TabIndex = 3;
            this.tabPageEnum.Text = "Enum";
            this.tabPageEnum.UseVisualStyleBackColor = true;
            // 
            // dataGridViewEnum
            // 
            this.dataGridViewEnum.AllowUserToAddRows = false;
            this.dataGridViewEnum.AllowUserToDeleteRows = false;
            this.dataGridViewEnum.AllowUserToResizeRows = false;
            this.dataGridViewEnum.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewEnum.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEnum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewEnum.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewEnum.Name = "dataGridViewEnum";
            this.dataGridViewEnum.Size = new System.Drawing.Size(734, 229);
            this.dataGridViewEnum.TabIndex = 1;
            this.dataGridViewEnum.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView_CellBeginEdit);
            this.dataGridViewEnum.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewEnum_CellEndEdit);
            // 
            // FactEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 261);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FactEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit fact asset";
            this.Load += new System.EventHandler(this.FactEditForm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FactEditForm_KeyPress);
            this.tabControl1.ResumeLayout(false);
            this.tabPageBool.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBool)).EndInit();
            this.tabPageInt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInt)).EndInit();
            this.tabPageFloat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFloat)).EndInit();
            this.tabPageEnum.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEnum)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageBool;
        private System.Windows.Forms.DataGridView dataGridViewBool;
        private System.Windows.Forms.TabPage tabPageInt;
        private System.Windows.Forms.TabPage tabPageFloat;
        private System.Windows.Forms.TabPage tabPageEnum;
        private System.Windows.Forms.DataGridView dataGridViewInt;
        private System.Windows.Forms.DataGridView dataGridViewFloat;
        private System.Windows.Forms.DataGridView dataGridViewEnum;
    }
}