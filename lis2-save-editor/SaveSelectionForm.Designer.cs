namespace lis2_save_editor
{
    partial class SaveSelectionForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxSteamIds = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButtonCS = new System.Windows.Forms.RadioButton();
            this.radioButtonLIS2 = new System.Windows.Forms.RadioButton();
            this.labelStatus = new System.Windows.Forms.Label();
            this.radioButtonSlot2 = new System.Windows.Forms.RadioButton();
            this.radioButtonSlot1 = new System.Windows.Forms.RadioButton();
            this.radioButtonSlot4 = new System.Windows.Forms.RadioButton();
            this.radioButtonSlot3 = new System.Windows.Forms.RadioButton();
            this.radioButtonSlot5 = new System.Windows.Forms.RadioButton();
            this.groupBoxActiveSlot = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.groupBoxActiveSlot.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Steam ID:";
            // 
            // comboBoxSteamIds
            // 
            this.comboBoxSteamIds.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSteamIds.FormattingEnabled = true;
            this.comboBoxSteamIds.Location = new System.Drawing.Point(15, 26);
            this.comboBoxSteamIds.Name = "comboBoxSteamIds";
            this.comboBoxSteamIds.Size = new System.Drawing.Size(137, 21);
            this.comboBoxSteamIds.TabIndex = 1;
            this.comboBoxSteamIds.SelectedIndexChanged += new System.EventHandler(this.comboBoxSteamIds_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Game:";
            // 
            // radioButtonCS
            // 
            this.radioButtonCS.AutoSize = true;
            this.radioButtonCS.Location = new System.Drawing.Point(51, 52);
            this.radioButtonCS.Name = "radioButtonCS";
            this.radioButtonCS.Size = new System.Drawing.Size(87, 17);
            this.radioButtonCS.TabIndex = 3;
            this.radioButtonCS.TabStop = true;
            this.radioButtonCS.Text = "Captain Spirit";
            this.radioButtonCS.UseVisualStyleBackColor = true;
            this.radioButtonCS.CheckedChanged += new System.EventHandler(this.radioButtonGame_CheckedChanged);
            // 
            // radioButtonLIS2
            // 
            this.radioButtonLIS2.AutoSize = true;
            this.radioButtonLIS2.Location = new System.Drawing.Point(51, 75);
            this.radioButtonLIS2.Name = "radioButtonLIS2";
            this.radioButtonLIS2.Size = new System.Drawing.Size(101, 17);
            this.radioButtonLIS2.TabIndex = 4;
            this.radioButtonLIS2.TabStop = true;
            this.radioButtonLIS2.Text = "Life is Strange 2";
            this.radioButtonLIS2.UseVisualStyleBackColor = true;
            this.radioButtonLIS2.CheckedChanged += new System.EventHandler(this.radioButtonGame_CheckedChanged);
            // 
            // labelStatus
            // 
            this.labelStatus.Location = new System.Drawing.Point(4, 95);
            this.labelStatus.Margin = new System.Windows.Forms.Padding(0);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(150, 60);
            this.labelStatus.TabIndex = 5;
            this.labelStatus.Text = "<status>";
            // 
            // radioButtonSlot2
            // 
            this.radioButtonSlot2.AutoSize = true;
            this.radioButtonSlot2.Location = new System.Drawing.Point(10, 42);
            this.radioButtonSlot2.Name = "radioButtonSlot2";
            this.radioButtonSlot2.Size = new System.Drawing.Size(52, 17);
            this.radioButtonSlot2.TabIndex = 7;
            this.radioButtonSlot2.TabStop = true;
            this.radioButtonSlot2.Text = "Slot 2";
            this.radioButtonSlot2.UseVisualStyleBackColor = true;
            this.radioButtonSlot2.CheckedChanged += new System.EventHandler(this.radioButtonSlot_CheckedChanged);
            // 
            // radioButtonSlot1
            // 
            this.radioButtonSlot1.AutoSize = true;
            this.radioButtonSlot1.Location = new System.Drawing.Point(10, 19);
            this.radioButtonSlot1.Name = "radioButtonSlot1";
            this.radioButtonSlot1.Size = new System.Drawing.Size(52, 17);
            this.radioButtonSlot1.TabIndex = 6;
            this.radioButtonSlot1.TabStop = true;
            this.radioButtonSlot1.Text = "Slot 1";
            this.radioButtonSlot1.UseVisualStyleBackColor = true;
            this.radioButtonSlot1.CheckedChanged += new System.EventHandler(this.radioButtonSlot_CheckedChanged);
            // 
            // radioButtonSlot4
            // 
            this.radioButtonSlot4.AutoSize = true;
            this.radioButtonSlot4.Location = new System.Drawing.Point(10, 88);
            this.radioButtonSlot4.Name = "radioButtonSlot4";
            this.radioButtonSlot4.Size = new System.Drawing.Size(52, 17);
            this.radioButtonSlot4.TabIndex = 9;
            this.radioButtonSlot4.TabStop = true;
            this.radioButtonSlot4.Text = "Slot 4";
            this.radioButtonSlot4.UseVisualStyleBackColor = true;
            this.radioButtonSlot4.CheckedChanged += new System.EventHandler(this.radioButtonSlot_CheckedChanged);
            // 
            // radioButtonSlot3
            // 
            this.radioButtonSlot3.AutoSize = true;
            this.radioButtonSlot3.Location = new System.Drawing.Point(10, 65);
            this.radioButtonSlot3.Name = "radioButtonSlot3";
            this.radioButtonSlot3.Size = new System.Drawing.Size(52, 17);
            this.radioButtonSlot3.TabIndex = 8;
            this.radioButtonSlot3.TabStop = true;
            this.radioButtonSlot3.Text = "Slot 3";
            this.radioButtonSlot3.UseVisualStyleBackColor = true;
            this.radioButtonSlot3.CheckedChanged += new System.EventHandler(this.radioButtonSlot_CheckedChanged);
            // 
            // radioButtonSlot5
            // 
            this.radioButtonSlot5.AutoSize = true;
            this.radioButtonSlot5.Location = new System.Drawing.Point(10, 110);
            this.radioButtonSlot5.Name = "radioButtonSlot5";
            this.radioButtonSlot5.Size = new System.Drawing.Size(52, 17);
            this.radioButtonSlot5.TabIndex = 10;
            this.radioButtonSlot5.TabStop = true;
            this.radioButtonSlot5.Text = "Slot 5";
            this.radioButtonSlot5.UseVisualStyleBackColor = true;
            this.radioButtonSlot5.CheckedChanged += new System.EventHandler(this.radioButtonSlot_CheckedChanged);
            // 
            // groupBoxActiveSlot
            // 
            this.groupBoxActiveSlot.Controls.Add(this.radioButtonSlot1);
            this.groupBoxActiveSlot.Controls.Add(this.radioButtonSlot5);
            this.groupBoxActiveSlot.Controls.Add(this.radioButtonSlot2);
            this.groupBoxActiveSlot.Controls.Add(this.radioButtonSlot4);
            this.groupBoxActiveSlot.Controls.Add(this.radioButtonSlot3);
            this.groupBoxActiveSlot.Location = new System.Drawing.Point(158, 12);
            this.groupBoxActiveSlot.Name = "groupBoxActiveSlot";
            this.groupBoxActiveSlot.Size = new System.Drawing.Size(77, 135);
            this.groupBoxActiveSlot.TabIndex = 11;
            this.groupBoxActiveSlot.TabStop = false;
            this.groupBoxActiveSlot.Text = "Active slot";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(158, 156);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(77, 156);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 12;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // SaveSelectionForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(247, 189);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBoxActiveSlot);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.radioButtonLIS2);
            this.Controls.Add(this.radioButtonCS);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxSteamIds);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "SaveSelectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select save";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SaveSelectionForm_FormClosing);
            this.Load += new System.EventHandler(this.SaveSelectionForm_Load);
            this.groupBoxActiveSlot.ResumeLayout(false);
            this.groupBoxActiveSlot.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxSteamIds;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButtonCS;
        private System.Windows.Forms.RadioButton radioButtonLIS2;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.RadioButton radioButtonSlot2;
        private System.Windows.Forms.RadioButton radioButtonSlot1;
        private System.Windows.Forms.RadioButton radioButtonSlot4;
        private System.Windows.Forms.RadioButton radioButtonSlot3;
        private System.Windows.Forms.RadioButton radioButtonSlot5;
        private System.Windows.Forms.GroupBox groupBoxActiveSlot;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
    }
}