using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using cs_save_editor.Properties;

namespace cs_save_editor
{
    public partial class FactEditForm : Form
    {
        public FactEditForm()
        {
            InitializeComponent();
        }

        public dynamic asset = null;

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

            for (int i = 0; i < dataGridViewBool.ColumnCount; i++)
            {
                dataGridViewBool.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private DataTable BuildBoolTable()
        {
            DataTable t = new DataTable();
            t.Columns.Add("Name");
            t.Columns.Add("Value");

            t.Columns[1].DataType = typeof(bool);
            for (int i=1; i<=asset["BoolFacts"].ElementCount; i++)
            {
                var fact = asset["BoolFacts"].Value[i];
                t.Rows.Add(new object[] { fact["FactNameForDebug"].Value, fact["FactValue"].Value });
            }
            return t;
        }

        private void UpdateIntTable()
        {
            dataGridViewInt.Columns.Clear();
            dataGridViewInt.DataSource = BuildIntTable().DefaultView;

            for (int i = 0; i < dataGridViewInt.ColumnCount; i++)
            {
                dataGridViewInt.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private DataTable BuildIntTable()
        {
            DataTable t = new DataTable();
            t.Columns.Add("Name");
            t.Columns.Add("Value");

            t.Columns[1].DataType = typeof(int);
            for (int i = 1; i <= asset["IntFacts"].ElementCount; i++)
            {
                var fact = asset["IntFacts"].Value[i];
                t.Rows.Add(new object[] { fact["FactNameForDebug"].Value, fact["FactValue"].Value });
            }
            return t;
        }

        private void UpdateFloatTable()
        {
            dataGridViewFloat.Columns.Clear();
            dataGridViewFloat.DataSource = BuildFloatTable().DefaultView;

            for (int i = 0; i < dataGridViewFloat.ColumnCount; i++)
            {
                dataGridViewFloat.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private DataTable BuildFloatTable()
        {
            DataTable t = new DataTable();
            t.Columns.Add("Name");
            t.Columns.Add("Value");

            t.Columns[1].DataType = typeof(float);
            for (int i = 1; i <= asset["FloatFacts"].ElementCount; i++)
            {
                var fact = asset["FloatFacts"].Value[i];
                t.Rows.Add(new object[] { fact["FactNameForDebug"].Value, fact["FactValue"].Value });
            }
            return t;
        }

        private void UpdateEnumTable()
        {
            dataGridViewEnum.Columns.Clear();
            dataGridViewEnum.DataSource = BuildEnumTable().DefaultView;

            for (int i = 0; i < dataGridViewEnum.ColumnCount; i++)
            {
                dataGridViewEnum.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private DataTable BuildEnumTable()
        {
            DataTable t = new DataTable();
            t.Columns.Add("Name");
            t.Columns.Add("Value");

            for (int i = 1; i <= asset["EnumFacts"].ElementCount; i++)
            {
                var fact = asset["EnumFacts"].Value[i];
                t.Rows.Add(new object[] { fact["FactNameForDebug"].Value, fact["FactValue"].Value });
            }
            return t;
        }

        #endregion

        #region Edit Functions
        private int newRowIndex = -1;

        private void dataGridView_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            newRowIndex = e.Row.Index - 1;
        }

        private void dataGridView_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex == newRowIndex)
            {
                switch (((DataGridView)sender).Name)
                {
                    case "dataGridViewBool":
                        {
                            var value = dataGridViewBool[1, e.RowIndex].Value;
                            if (value is DBNull) value = false;
                            EditFactValue("BoolFacts", dataGridViewBool[0, e.RowIndex].Value.ToString(), value);
                            dataGridViewBool[1, e.RowIndex].Value = value;
                            break;
                        }
                    case "dataGridViewInt":
                        {
                            var value = dataGridViewInt[1, e.RowIndex].Value;
                            if (value is DBNull) value = 0;
                            EditFactValue("IntFacts", dataGridViewInt[0, e.RowIndex].Value.ToString(), value);
                            dataGridViewInt[1, e.RowIndex].Value = value;
                            break;
                        }
                    case "dataGridViewFloat":
                        {
                            var value = dataGridViewFloat[1, e.RowIndex].Value;
                            if (value is DBNull) value = 0;
                            EditFactValue("FloatFacts", dataGridViewFloat[0, e.RowIndex].Value.ToString(), value);
                            dataGridViewFloat[1, e.RowIndex].Value = value;
                            break;
                        }
                    case "dataGridViewEnum": //todo
                        {
                            var value = dataGridViewEnum[1, e.RowIndex].Value;
                            if (value is DBNull) value = 0;
                            EditFactValue("EnumFacts", dataGridViewEnum[0, e.RowIndex].Value.ToString(), value);
                            dataGridViewEnum[1, e.RowIndex].Value = value;
                            break;
                        }
                    default:
                        {
                            throw new Exception("Unknown data grid");
                            break;
                        }
                }

            }
        }

        private void dataGridView_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            newRowIndex = -1;
        }

        private void dataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var name = e.Row.Cells[0].Value.ToString();
            switch (((DataGridView)sender).Name)
            {
                case "dataGridViewBool":
                    {
                        EditFactValue("BoolFacts", name, null);
                        break;
                    }
                case "dataGridViewInt":
                    {
                        EditFactValue("IntFacts", name, null);
                        break;
                    }
                case "dataGridViewFloat":
                    {
                        EditFactValue("FloatFacts", name, null);
                        break;
                    }
                case "dataGridViewEnum": //todo
                    {
                        EditFactValue("EnumFacts", name, null);
                        break;
                    }
            }
        }

        object origCellValue, newCellValue;

        private void dataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            var grid = ((DataGridView)sender);
            if (grid.Rows[e.RowIndex].IsNewRow)
            {
                if (e.ColumnIndex == 1)
                {
                    e.Cancel = true;
                }
                return;
            }
            if (e.ColumnIndex == 0)
            {
                e.Cancel = true;
                return;
            }
            origCellValue = grid[e.ColumnIndex, e.RowIndex].Value;
        }

        private void dataGridViewBool_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 || dataGridViewBool.Rows[e.RowIndex].IsNewRow) return;
            newCellValue = dataGridViewBool[e.ColumnIndex, e.RowIndex].Value;

            if (newCellValue.ToString() != origCellValue.ToString())
            {
                var name = dataGridViewBool[0, e.RowIndex].Value.ToString();
                EditFactValue("BoolFacts", name, Convert.ToBoolean(newCellValue));
            }
        }

        private void dataGridViewInt_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 || dataGridViewInt.Rows[e.RowIndex].IsNewRow) return;
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

            if (newCellValue.ToString() != origCellValue.ToString())
            {
                var name = dataGridViewInt[0, e.RowIndex].Value.ToString();
                EditFactValue("IntFacts", name, Convert.ToInt32(newCellValue));
            }
        }

        private void dataGridViewFloat_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 || dataGridViewFloat.Rows[e.RowIndex].IsNewRow) return;
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

            if (newCellValue.ToString() != origCellValue.ToString())
            {
                var name = dataGridViewFloat[0, e.RowIndex].Value.ToString();
                EditFactValue("FloatFacts", name, Convert.ToSingle(newCellValue));
            }
        }

        private void dataGridViewEnum_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 || dataGridViewEnum.Rows[e.RowIndex].IsNewRow) return;
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

            if (newCellValue.ToString() != origCellValue.ToString())
            {
                var name = dataGridViewEnum[0, e.RowIndex].Value.ToString();
                EditFactValue("EnumFacts", name, Convert.ToByte(newCellValue));
            }
        }

        private void EditFactValue(string factType, string name, object value)
        {
            List<dynamic> target = asset[factType].Value;
            int index = target.FindIndex(1, x => x["FactNameForDebug"].Value == name);

            if (index == -1) //Add new item
            {
                Dictionary<string, object> new_item = new Dictionary<string, object>();
                switch(factType)
                {
                    case "BoolFacts":
                        {
                            new_item["FactValue"] = new BoolProperty() { Name = "FactValue", Type = "BoolProperty", Value = Convert.ToBoolean(value ?? false) };
                            break;
                        }
                    case "IntFacts":
                        {
                            new_item["FactValue"] = new IntProperty() { Name = "FactValue", Type = "IntProperty", Value = Convert.ToInt32(value ?? 0) };
                            break;
                        }
                    case "FloatFacts":
                        {
                            new_item["FactValue"] = new FloatProperty() { Name = "FactValue", Type = "FloatProperty", Value = Convert.ToSingle(value ?? 0) };
                            break;
                        }
                    case "EnumFacts": //todo
                        {
                            MessageBox.Show("No way!");
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
                        { "Guid", Guid.NewGuid() }
                    }
                };

                target.Add(new_item);
            }
            else
            {
                if (value == null) //Remove fact
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
                                break;
                            }
                    }
                }
            }
            changesMade = true;
        }
        #endregion
    }


}
