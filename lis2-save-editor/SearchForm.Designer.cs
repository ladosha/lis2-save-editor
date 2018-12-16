namespace lis2_save_editor
{
    partial class SearchForm
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
            this.checkBoxCase = new System.Windows.Forms.CheckBox();
            this.labelResultCount = new System.Windows.Forms.Label();
            this.buttonFindNext = new System.Windows.Forms.Button();
            this.buttonFindPrev = new System.Windows.Forms.Button();
            this.buttonFind = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxEnds = new System.Windows.Forms.TextBox();
            this.textBoxContains = new System.Windows.Forms.TextBox();
            this.textBoxStarts = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxTarget = new System.Windows.Forms.ComboBox();
            this.checkBoxTransparency = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // checkBoxCase
            // 
            this.checkBoxCase.AutoSize = true;
            this.checkBoxCase.Location = new System.Drawing.Point(11, 115);
            this.checkBoxCase.Name = "checkBoxCase";
            this.checkBoxCase.Size = new System.Drawing.Size(96, 17);
            this.checkBoxCase.TabIndex = 26;
            this.checkBoxCase.Text = "Case Sensitive";
            this.checkBoxCase.UseVisualStyleBackColor = true;
            this.checkBoxCase.CheckedChanged += new System.EventHandler(this.textBoxes_TextChanged);
            // 
            // labelResultCount
            // 
            this.labelResultCount.Location = new System.Drawing.Point(11, 170);
            this.labelResultCount.Name = "labelResultCount";
            this.labelResultCount.Size = new System.Drawing.Size(200, 13);
            this.labelResultCount.TabIndex = 25;
            this.labelResultCount.Text = "Found <x> results";
            this.labelResultCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelResultCount.Visible = false;
            // 
            // buttonFindNext
            // 
            this.buttonFindNext.Enabled = false;
            this.buttonFindNext.Location = new System.Drawing.Point(151, 138);
            this.buttonFindNext.Name = "buttonFindNext";
            this.buttonFindNext.Size = new System.Drawing.Size(60, 25);
            this.buttonFindNext.TabIndex = 24;
            this.buttonFindNext.Text = "Next";
            this.buttonFindNext.UseVisualStyleBackColor = true;
            this.buttonFindNext.Click += new System.EventHandler(this.buttonFindNext_Click);
            // 
            // buttonFindPrev
            // 
            this.buttonFindPrev.Enabled = false;
            this.buttonFindPrev.Location = new System.Drawing.Point(11, 138);
            this.buttonFindPrev.Name = "buttonFindPrev";
            this.buttonFindPrev.Size = new System.Drawing.Size(60, 25);
            this.buttonFindPrev.TabIndex = 23;
            this.buttonFindPrev.Text = "Prev";
            this.buttonFindPrev.UseVisualStyleBackColor = true;
            this.buttonFindPrev.Click += new System.EventHandler(this.buttonFindPrev_Click);
            // 
            // buttonFind
            // 
            this.buttonFind.Enabled = false;
            this.buttonFind.Location = new System.Drawing.Point(81, 138);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(60, 25);
            this.buttonFind.TabIndex = 22;
            this.buttonFind.Text = "First";
            this.buttonFind.UseVisualStyleBackColor = true;
            this.buttonFind.Click += new System.EventHandler(this.buttonFind_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Ends with:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Contains:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Starts with:";
            // 
            // textBoxEnds
            // 
            this.textBoxEnds.Location = new System.Drawing.Point(77, 89);
            this.textBoxEnds.Name = "textBoxEnds";
            this.textBoxEnds.Size = new System.Drawing.Size(134, 20);
            this.textBoxEnds.TabIndex = 18;
            this.textBoxEnds.TextChanged += new System.EventHandler(this.textBoxes_TextChanged);
            // 
            // textBoxContains
            // 
            this.textBoxContains.Location = new System.Drawing.Point(77, 63);
            this.textBoxContains.Name = "textBoxContains";
            this.textBoxContains.Size = new System.Drawing.Size(134, 20);
            this.textBoxContains.TabIndex = 17;
            this.textBoxContains.TextChanged += new System.EventHandler(this.textBoxes_TextChanged);
            // 
            // textBoxStarts
            // 
            this.textBoxStarts.Location = new System.Drawing.Point(77, 37);
            this.textBoxStarts.Name = "textBoxStarts";
            this.textBoxStarts.Size = new System.Drawing.Size(134, 20);
            this.textBoxStarts.TabIndex = 16;
            this.textBoxStarts.TextChanged += new System.EventHandler(this.textBoxes_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Find in:";
            // 
            // comboBoxTarget
            // 
            this.comboBoxTarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTarget.FormattingEnabled = true;
            this.comboBoxTarget.Location = new System.Drawing.Point(77, 10);
            this.comboBoxTarget.Name = "comboBoxTarget";
            this.comboBoxTarget.Size = new System.Drawing.Size(134, 21);
            this.comboBoxTarget.TabIndex = 27;
            this.comboBoxTarget.SelectedIndexChanged += new System.EventHandler(this.comboBoxTarget_SelectedIndexChanged);
            // 
            // checkBoxTransparency
            // 
            this.checkBoxTransparency.AutoSize = true;
            this.checkBoxTransparency.Location = new System.Drawing.Point(113, 115);
            this.checkBoxTransparency.Name = "checkBoxTransparency";
            this.checkBoxTransparency.Size = new System.Drawing.Size(91, 17);
            this.checkBoxTransparency.TabIndex = 28;
            this.checkBoxTransparency.Text = "Transparency";
            this.checkBoxTransparency.UseVisualStyleBackColor = true;
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(221, 190);
            this.Controls.Add(this.checkBoxTransparency);
            this.Controls.Add(this.comboBoxTarget);
            this.Controls.Add(this.checkBoxCase);
            this.Controls.Add(this.labelResultCount);
            this.Controls.Add(this.buttonFindNext);
            this.Controls.Add(this.buttonFindPrev);
            this.Controls.Add(this.buttonFind);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxEnds);
            this.Controls.Add(this.textBoxContains);
            this.Controls.Add(this.textBoxStarts);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "SearchForm";
            this.Text = "Find";
            this.Activated += new System.EventHandler(this.SearchForm_Activated);
            this.Deactivate += new System.EventHandler(this.SearchForm_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SearchForm_FormClosing);
            this.Load += new System.EventHandler(this.SearchForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxCase;
        private System.Windows.Forms.Label labelResultCount;
        private System.Windows.Forms.Button buttonFindNext;
        private System.Windows.Forms.Button buttonFindPrev;
        private System.Windows.Forms.Button buttonFind;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxEnds;
        private System.Windows.Forms.TextBox textBoxContains;
        private System.Windows.Forms.TextBox textBoxStarts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxTarget;
        private System.Windows.Forms.CheckBox checkBoxTransparency;
    }
}