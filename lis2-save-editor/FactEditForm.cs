using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using lis2_save_editor.Properties;

namespace lis2_save_editor
{
    public partial class FactEditForm : Form
    {
        public FactEditForm()
        {
            InitializeComponent();
        }

        public Dictionary<string, dynamic> asset = null;

        public SaveVersion saveVersion;

        private FactAsset asset_info
        {
            get
            {
                try
                {
                    if (saveVersion == SaveVersion.CaptainSpirit)
                    {
                        return GameInfo.CS_FactAssets[asset["FactAssetId"].Value["Guid"].ToString()];
                    }
                    else
                    {
                        return GameInfo.LIS2_FactAssets[asset["FactAssetId"].Value["Guid"].ToString()];
                    }
                }
                catch
                {
                    return FactAsset.Empty;
                }
                
            }
        }

        public bool changesMade = false;

        private void FactEditForm_Load(object sender, EventArgs e)
        {
            UpdateBoolTable();
            UpdateIntTable();
            UpdateFloatTable();
            UpdateEnumTable();
        }

        #region Table-building 

        private void UpdateBoolTable()
        {
            dataGridViewBool.Columns.Clear();
            dataGridViewBool.DataSource = BuildBoolTable().DefaultView;

            dataGridViewBool.Columns[1].FillWeight = 20;
            dataGridViewBool.Columns[2].FillWeight = 20;
        }

        private DataTable BuildBoolTable()
        {
            DataTable t = new DataTable();
            t.Columns.Add("Name");
            t.Columns.Add("Active", typeof(bool));
            t.Columns.Add("Value", typeof(bool));

            foreach (var fact in asset_info.BoolFacts)
            {
                object[] row = new object[t.Columns.Count];
                row[0] = fact.Value;
                List<dynamic> target = asset["BoolFacts"].Value;
                int index = target.FindIndex(1, x => x["FactGuid"].Value["Guid"] == fact.Key);
                if (index != -1)
                {
                    row[1] = true;
                    row[2] = target[index]["FactValue"].Value;
                }
                else
                {
                    row[1] = false;
                    row[2] = false;
                }
                t.Rows.Add(row);
            }
            return t;
        }

        private void UpdateIntTable()
        {
            dataGridViewInt.Columns.Clear();
            dataGridViewInt.DataSource = BuildIntTable().DefaultView;

            dataGridViewInt.Columns[1].FillWeight = 20;
            dataGridViewInt.Columns[2].FillWeight = 20;
        }

        private DataTable BuildIntTable()
        {
            DataTable t = new DataTable();
            t.Columns.Add("Name");
            t.Columns.Add("Active", typeof(bool));
            t.Columns.Add("Value");

            foreach (var fact in asset_info.IntFacts)
            {
                object[] row = new object[t.Columns.Count];
                row[0] = fact.Value;
                List<dynamic> target = asset["IntFacts"].Value;
                int index = target.FindIndex(1, x => x["FactGuid"].Value["Guid"] == fact.Key);
                if (index != -1)
                {
                    row[1] = true;
                    row[2] = target[index]["FactValue"].Value;
                }
                else
                {
                    row[1] = false;
                    row[2] = 0;
                }
                t.Rows.Add(row);
            }
            return t;
        }

        private void UpdateFloatTable()
        {
            dataGridViewFloat.Columns.Clear();
            dataGridViewFloat.DataSource = BuildFloatTable().DefaultView;

            dataGridViewFloat.Columns[1].FillWeight = 20;
            dataGridViewFloat.Columns[2].FillWeight = 20;
        }

        private DataTable BuildFloatTable()
        {
            DataTable t = new DataTable();
            t.Columns.Add("Name");
            t.Columns.Add("Active", typeof(bool));
            t.Columns.Add("Value");

            foreach (var fact in asset_info.FloatFacts)
            {
                object[] row = new object[t.Columns.Count];
                row[0] = fact.Value;
                List<dynamic> target = asset["FloatFacts"].Value;
                int index = target.FindIndex(1, x => x["FactGuid"].Value["Guid"] == fact.Key);
                if (index != -1)
                {
                    row[1] = true;
                    row[2] = target[index]["FactValue"].Value;
                }
                else
                {
                    row[1] = false;
                    row[2] = 0;
                }
                t.Rows.Add(row);
            }
            return t;
        }

        private void UpdateEnumTable()
        {
            dataGridViewEnum.Columns.Clear();
            dataGridViewEnum.DataSource = BuildEnumTable().DefaultView;

            dataGridViewEnum.Columns[1].FillWeight = 20;
            dataGridViewEnum.Columns[2].FillWeight = 20;

            tabControl1.SelectedTab = tabPageEnum;
            for (int i=0; i<dataGridViewEnum.RowCount; i++)
            {
                var fact_name = dataGridViewEnum[0, i].Value.ToString();
                if (asset_info.EnumFactChoices.ContainsKey(fact_name))
                {
                    var cbc = new DataGridViewComboBoxCell();
                    cbc.DataSource = asset_info.EnumFactChoices[fact_name];
                    cbc.DropDownWidth = 200;
                    var orig_value = Convert.ToInt32(dataGridViewEnum[2, i].Value);
                    dataGridViewEnum[2, i] = cbc;
                    dataGridViewEnum[2, i].Value = asset_info.EnumFactChoices[fact_name][orig_value];
                }
            }
            tabControl1.SelectedTab = tabPageBool;
        }

        private DataTable BuildEnumTable()
        {
            DataTable t = new DataTable();
            t.Columns.Add("Name");
            t.Columns.Add("Active", typeof(bool));
            t.Columns.Add("Value");

            foreach (var fact in asset_info.EnumFacts)
            {
                object[] row = new object[t.Columns.Count];
                row[0] = fact.Value;
                List<dynamic> target = asset["EnumFacts"].Value;
                int index = target.FindIndex(1, x => x["FactGuid"].Value["Guid"] == fact.Key);
                if (index != -1)
                {
                    row[1] = true;
                    row[2] = target[index]["FactValue"].Value;
                }
                else
                {
                    row[1] = false;
                    row[2] = 0;
                }
                t.Rows.Add(row);
            }
            return t;
        }

        #endregion

        #region Edit Functions

        object origCellValue, newCellValue;

        private void dataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            var grid = ((DataGridView)sender);
            if (e.ColumnIndex == 0)
            {
                e.Cancel = true;
                return;
            }
            origCellValue = grid[e.ColumnIndex, e.RowIndex].Value;
        }

        private void dataGridViewEnum_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                e.Cancel = true;
                return;
            }
            var cell = dataGridViewEnum[e.ColumnIndex, e.RowIndex];
            if (cell is DataGridViewComboBoxCell)
            {
                origCellValue = GetEnumComboBoxSelectedIndex(e.RowIndex);
            }
            else
            {
                origCellValue = cell.Value;
            }
        }

        private void dataGridViewBool_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            newCellValue = dataGridViewBool[e.ColumnIndex, e.RowIndex].Value;

            if (newCellValue.ToString() != origCellValue.ToString())
            {
                var name = dataGridViewBool[0, e.RowIndex].Value.ToString();
                EditFactValue("BoolFacts", name, e.ColumnIndex, newCellValue);
                dataGridViewBool[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.LightGoldenrodYellow;

                if (e.ColumnIndex != 1)
                {
                    dataGridViewBool[1, e.RowIndex].Value = true;
                }
                else if (Convert.ToBoolean(newCellValue) == true)
                {
                    EditFactValue("BoolFacts", name, 2, dataGridViewBool[2, e.RowIndex].Value);
                }
                
            }
        }

        private void dataGridViewInt_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                newCellValue = dataGridViewInt[1, e.RowIndex].Value;
            }
            else
            {
                int result;
                if (!int.TryParse(dataGridViewInt[e.ColumnIndex, e.RowIndex].Value.ToString(), out result))
                {
                    MessageBox.Show(Resources.BadValueMessage, "Error");
                    newCellValue = origCellValue;
                    dataGridViewInt[e.ColumnIndex, e.RowIndex].Value = origCellValue;
                }
                else
                {
                    newCellValue = result;
                }
            }

            if (newCellValue.ToString() != origCellValue.ToString())
            {
                var name = dataGridViewInt[0, e.RowIndex].Value.ToString();
                EditFactValue("IntFacts", name, e.ColumnIndex, newCellValue);
                dataGridViewInt[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.LightGoldenrodYellow;

                if (e.ColumnIndex != 1)
                {
                    dataGridViewInt[1, e.RowIndex].Value = true;
                }
                else if (Convert.ToBoolean(newCellValue) == true)
                {
                    EditFactValue("IntFacts", name, 2, dataGridViewInt[2, e.RowIndex].Value);
                }
            }
        }

        private void dataGridViewFloat_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                newCellValue = dataGridViewFloat[1, e.RowIndex].Value;
            }
            else
            {
                float result;
                if (!float.TryParse(dataGridViewFloat[e.ColumnIndex, e.RowIndex].Value.ToString(), out result))
                {
                    MessageBox.Show(Resources.BadValueMessage, "Error");
                    newCellValue = origCellValue;
                    dataGridViewFloat[e.ColumnIndex, e.RowIndex].Value = origCellValue;
                }
                else
                {
                    newCellValue = result;
                }
            }

            if (newCellValue.ToString() != origCellValue.ToString())
            {
                var name = dataGridViewFloat[0, e.RowIndex].Value.ToString();
                EditFactValue("FloatFacts", name, e.ColumnIndex, newCellValue);
                dataGridViewFloat[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.LightGoldenrodYellow;

                if (e.ColumnIndex != 1)
                {
                    dataGridViewFloat[1, e.RowIndex].Value = true;
                }
                else if (Convert.ToBoolean(newCellValue) == true)
                {
                    EditFactValue("FloatFacts", name, 2, dataGridViewFloat[2, e.RowIndex].Value);
                }
            }
        }

        private void dataGridViewEnum_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                newCellValue = dataGridViewEnum[1, e.RowIndex].Value;
            }
            else
            {
                if(dataGridViewEnum[e.ColumnIndex, e.RowIndex] is DataGridViewComboBoxCell)
                {
                    newCellValue = GetEnumComboBoxSelectedIndex(e.RowIndex);
                }
                else
                {
                    byte result;
                    if (!byte.TryParse(dataGridViewEnum[e.ColumnIndex, e.RowIndex].Value.ToString(), out result))
                    {
                        MessageBox.Show(Resources.BadValueMessage, "Error");
                        newCellValue = origCellValue;
                        dataGridViewEnum[e.ColumnIndex, e.RowIndex].Value = origCellValue;
                    }
                    else
                    {
                        newCellValue = result;
                    }
                }
            }
            
            if (newCellValue.ToString() != origCellValue.ToString())
            {
                var name = dataGridViewEnum[0, e.RowIndex].Value.ToString();
                EditFactValue("EnumFacts", name, e.ColumnIndex, newCellValue);
                dataGridViewEnum[0, e.RowIndex].Style.BackColor = Color.LightGoldenrodYellow;

                if (e.ColumnIndex != 1)
                {
                    dataGridViewEnum[1, e.RowIndex].Value = true;
                }
                else if (Convert.ToBoolean(newCellValue) == true)
                {
                    if (dataGridViewEnum[2, e.RowIndex] is DataGridViewComboBoxCell)
                    {
                        int index = GetEnumComboBoxSelectedIndex(e.RowIndex);
                        EditFactValue("EnumFacts", name, 2, index);
                    }
                    else
                    {
                        EditFactValue("EnumFacts", name, 2, dataGridViewEnum[2, e.RowIndex].Value);
                    }
                }
            }
        }

        private void EditFactValue(string factType, string name, int colIndex, object value)
        {
            List<dynamic> target = asset[factType].Value;
            int index = target.FindIndex(1, x => x["FactNameForDebug"].Value == name);

            if (index == -1) //Add new item
            {
                Dictionary<string, object> new_item = new Dictionary<string, object>();
                var guid = new Guid();
                switch(factType)
                {
                    case "BoolFacts":
                        {
                            new_item["FactValue"] = new BoolProperty() { Name = "FactValue", Type = "BoolProperty", Value = colIndex == 1 ? false : Convert.ToBoolean(value) };
                            guid = asset_info.BoolFacts.First(x => x.Value == name).Key;
                            break;
                        }
                    case "IntFacts":
                        {
                            new_item["FactValue"] = new IntProperty() { Name = "FactValue", Type = "IntProperty", Value = colIndex == 1 ? 0 : Convert.ToInt32(value) };
                            guid = asset_info.IntFacts.First(x => x.Value == name).Key;
                            break;
                        }
                    case "FloatFacts":
                        {
                            new_item["FactValue"] = new FloatProperty() { Name = "FactValue", Type = "FloatProperty", Value = colIndex == 1 ? 0 : Convert.ToSingle(value) };
                            guid = asset_info.FloatFacts.First(x => x.Value == name).Key;
                            break;
                        }
                    case "EnumFacts":
                        {
                            guid = asset_info.EnumFacts.First(x => x.Value == name).Key;
                            new_item["FactValue"] = new ByteProperty()
                            {
                                Name = "FactValue",
                                Type = "ByteProperty",
                                Value = colIndex == 1 ? Convert.ToByte(0) : Convert.ToByte(value)
                            };
                            new_item["History"] = new ArrayProperty()
                            {
                                Name = "History",
                                Type = "ArrayProperty",
                                ElementType = "ByteProperty",
                                Value = new List<dynamic>() { colIndex == 1 ? Convert.ToByte(0) : Convert.ToByte(value) }
                            };
                            break;
                        }
                }
                
                new_item["FactNameForDebug"] = new NameProperty() { Name = "FactNameForDebug", Type = "NameProperty", Value = name };
                new_item["FactGuid"] = new StructProperty
                {
                    Name = "FactGuid",
                    Type = "StructProperty",
                    ElementType = "Guid",
                    Value = new Dictionary<string, dynamic>()
                    {
                        { "Guid",  guid}
                    }
                };

                target.AddUnique(new_item);
            }
            else
            {
                if (colIndex == 1 && Convert.ToBoolean(value) == false) //Remove fact
                {
                    target.RemoveAt(index);
                }
                else //Edit existing fact
                {
                    switch (factType)
                    {
                        case "BoolFacts":
                            {
                                target[index]["FactValue"].Value = Convert.ToBoolean(value);
                                break;
                            }
                        case "IntFacts":
                            {
                                target[index]["FactValue"].Value = Convert.ToInt32(value);
                                break;
                            }
                        case "FloatFacts":
                            {
                                target[index]["FactValue"].Value = Convert.ToSingle(value);
                                break;
                            }
                        case "EnumFacts":
                            {
                                target[index]["FactValue"].Value = Convert.ToByte(value);
                                //((List<dynamic>)target[index]["History"].Value).AddUnique(Convert.ToByte(value));
                                break;
                            }
                    }
                }
            }
            changesMade = true;
        }

        private int GetEnumComboBoxSelectedIndex(int rowIndex)
        {
            string fact_name = dataGridViewEnum[0, rowIndex].Value.ToString();
            string choice = dataGridViewEnum[2, rowIndex].Value.ToString();
            return Array.IndexOf(asset_info.EnumFactChoices[fact_name], choice);
        }
        #endregion

        SearchForm searchForm;
        private void FactEditForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ModifierKeys == Keys.Control && (int)e.KeyChar == 6)
            {
                if (searchForm == null)
                {
                    searchForm = new SearchForm(tabControl1);
                }
                if (searchForm.Visible)
                {
                    searchForm.WindowState = FormWindowState.Normal;
                    searchForm.Activate();
                }
                else
                {
                    searchForm.Show(this);
                    searchForm.UpdateSelectedTab();
                }
            }
            else if (e.KeyChar == 27)
            {
                Close();
            }
        }

        private void FactEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            dataGridViewBool.EndEdit();
            dataGridViewInt.EndEdit();
            dataGridViewFloat.EndEdit();
            dataGridViewEnum.EndEdit();
        }


    }


}
