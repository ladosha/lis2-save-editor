using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace lis2_save_editor
{
    public partial class SearchForm : Form
    {
        TabControl targetTabber;
        public SearchForm(TabControl target)
        {
            InitializeComponent();
            targetTabber = target;
        }

        class Result
        {
            public object Object;
            public Color BackgroundColor;

            public Result(object obj, Color color)
            {
                this.Object = obj;
                this.BackgroundColor = color;
            }
        }

        private List<Result> results = new List<Result>();
        int res_index = 0;

        string find_Starts = "", find_Ends = "", find_Contains = "";

        private void textBoxes_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxStarts.Text) ||
                !string.IsNullOrWhiteSpace(textBoxContains.Text) ||
                !string.IsNullOrWhiteSpace(textBoxEnds.Text))
            {
                buttonFind.Enabled = true;
            }
            else
            {
                buttonFind.Enabled = false;
            }

            ResetSearchState();
        }

        private void checkBoxes_CheckedChanged(object sender, EventArgs e)
        {
            ResetSearchState();
        }

        private void SearchForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //SendKeys.Send("{ESC}"); //fix against the cell's contents being selected
            e.Cancel = true;
            if (results.Count > 0) Unfocus(results[res_index]);
            this.Hide();
            
        }

        public void ResetSearchState()
        {
            if(results.Count > 0) Unfocus(results[res_index]);
            results.Clear();
            buttonFindPrev.Enabled = false;
            buttonFindNext.Enabled = false;
            labelResultCount.Visible = false;
            this.AcceptButton = buttonFind;
            find_Starts = "";
            find_Contains = "";
            find_Ends = "";
            res_index = 0;
        }

        private List<Control> FindControls(Control mainControl, Func<dynamic, bool> func, bool getAllChildren = false, bool firstOnly = false)
        {
            List<Control> lt = new List<Control>();
            for (int i = 0; i < mainControl.Controls.Count; i++)
            {
                if (func(mainControl.Controls[i]))
                {
                    lt.Add(mainControl.Controls[i]);
                    if (firstOnly) return lt;
                }
                if (getAllChildren) lt.AddRange(FindControls(mainControl.Controls[i], func, getAllChildren, firstOnly));
            }
            return lt;
        }

        private void FocusOn(Result res)
        {
            dynamic cont = res.Object;
            if (cont is DataGridViewCell)
            {
                if(cont.DataGridView == null)
                {
                    int index = results.IndexOf(res);
                    results.Clear();
                    Search();
                    cont = results[index].Object;
                }
                res.BackgroundColor = cont.Style.BackColor;
                cont.DataGridView.CurrentCell = cont;
                cont = cont.DataGridView;
            }
            else if (cont is ComboBox)
            {
                res.BackgroundColor = cont.Parent.BackColor;
                cont.Parent.BackColor = Color.PaleGreen;
            }
            else
            {
                res.BackgroundColor = cont.BackColor;
                cont.BackColor = Color.PaleGreen;
            }

            //scroll into view
            Control page = cont;
            while (!(page is Form))
            {
                while (!(page is TabPage))
                {
                    page = page.Parent;
                    if (page is Form) break;
                }
                if (page is Form) break;
                ((TabControl)page.Parent).SelectedTab = (TabPage)page;
                page = page.Parent;
            }
            cont.Focus();
        }

        private void Unfocus(Result res)
        {
            dynamic cont = res.Object;
            if (cont is DataGridViewCell)
            {
                cont.Style.BackColor = res.BackgroundColor;
            }
            else if (cont is ComboBox)
            {
                cont.Parent.BackColor = res.BackgroundColor;
            }
            else
            {
                cont.BackColor = res.BackgroundColor;
            }
        }

        private void SearchForm_Load(object sender, EventArgs e)
        {
            comboBoxTarget.Items.Add("(all)");
            foreach (TabPage p in targetTabber.TabPages)
            {
                comboBoxTarget.Items.Add(p.Text);
            }
            UpdateSelectedTab();
        }

        //hopefully we won't need this
        private void RefreshTabs(TabControl tcl)
        {
            int index = tcl.SelectedIndex;
            foreach (dynamic page in tcl.TabPages)
            {
                tcl.SelectedTab = page;
                if (page.Controls[0] is TabControl)
                {
                    RefreshTabs(page.Controls[0]);
                }
            }
            tcl.SelectedIndex = index;
        }

        public void UpdateSelectedTab()
        {
            comboBoxTarget.SelectedIndex = targetTabber.SelectedIndex+1;
        }

        private void buttonFindPrev_Click(object sender, EventArgs e)
        {
            Unfocus(results[res_index]);
            res_index--;
            if (res_index < 0) res_index = results.Count - 1;
            FocusOn(results[res_index]);
        }

        private void buttonFindNext_Click(object sender, EventArgs e)
        {
            Unfocus(results[res_index]);
            res_index++;
            if (res_index == results.Count) res_index = 0;
            FocusOn(results[res_index]);
        }

        private void comboBoxTarget_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetSearchState();
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            ResetSearchState();
            if (!string.IsNullOrWhiteSpace(textBoxStarts.Text))
            {
                find_Starts = textBoxStarts.Text;
            }
            if (!string.IsNullOrWhiteSpace(textBoxContains.Text))
            {
                find_Contains = textBoxContains.Text;
            }
            if (!string.IsNullOrWhiteSpace(textBoxEnds.Text))
            {
                find_Ends = textBoxEnds.Text;
            }

            Search();
            int res_count = results.Count;

            if (res_count == 0)
            {
                labelResultCount.Visible = false;
                MessageBox.Show("Can not find anything! Try a different target or search terms.");
                return;
            }
            else if (res_count == 1)
            {
                labelResultCount.Visible = true;
                labelResultCount.Text = "Found 1 result.";
            }
            else
            {
                labelResultCount.Visible = true;
                labelResultCount.Text = "Found " + res_count + " results.";
                buttonFindPrev.Enabled = true;
                buttonFindNext.Enabled = true;
                this.AcceptButton = buttonFindNext;
            }
            FocusOn(results[0]);
            res_index = 0;
        }

        private void SearchForm_Activated(object sender, EventArgs e)
        {
            Opacity = 1;
        }

        private void SearchForm_Deactivate(object sender, EventArgs e)
        {
            if(checkBoxTransparency.Checked) Opacity = 0.8;
        }

        private void Search()
        {
            bool CaseSensitive = checkBoxCase.Checked;
            StringComparison strcomp = CaseSensitive ? StringComparison.InvariantCulture 
                                       : StringComparison.InvariantCultureIgnoreCase;

            foreach (dynamic  cnt in FindControls(comboBoxTarget.SelectedIndex == 0 ? (Control)targetTabber : targetTabber.TabPages[comboBoxTarget.SelectedIndex-1], SearchFunc, true, false))
            {
                if(cnt is DataGridView)
                {
                    for (int i = 0; i < cnt.ColumnCount; i++)
                    {
                        for (int j = 0; j < cnt.RowCount; j++)
                        {
                            string value = cnt[i, j].Value.ToString();
                            if (value.StartsWith(find_Starts, !CaseSensitive, CultureInfo.InvariantCulture) &&
                               (value.IndexOf(find_Contains, strcomp) != -1) &&
                               value.EndsWith(find_Ends, !CaseSensitive, CultureInfo.InvariantCulture))
                            {
                                results.Add(new Result(cnt[i, j], cnt[i, j].Style.BackColor));
                            }
                        }
                    }
                    
                }
                else
                {
                    results.Add(new Result(cnt, cnt is ComboBox ? cnt.Parent.BackColor : cnt.BackColor));
                }
                
            }
        }

        private bool SearchFunc(dynamic obj)
        {
            if (!obj.Enabled) return false;
            if (obj is DataGridView) return true;

            string value = "";
            bool CaseSensitive = checkBoxCase.Checked;
            StringComparison strcomp = CaseSensitive ? StringComparison.InvariantCulture
                                       : StringComparison.InvariantCultureIgnoreCase;

            if (obj is Label || obj is TextBox || obj is GroupBox || obj is CheckBox) value = obj.Text;
            else if (obj is ComboBox)
            {
                foreach (var item in ((ComboBox)obj).Items)
                {
                    value += item + "\x00";
                }
            }
            else return false;

            return (value.StartsWith(find_Starts, !CaseSensitive, CultureInfo.InvariantCulture) &&
                    (value.IndexOf(find_Contains, strcomp) != -1) &&
                    value.EndsWith(find_Ends, !CaseSensitive, CultureInfo.InvariantCulture));
        }
    }
}
