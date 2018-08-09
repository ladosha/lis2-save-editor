using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Windows.Forms;
using cs_save_editor.Properties;
using System.IO;
using System.Drawing;
using System.Linq;

namespace cs_save_editor
{
    public partial class MainForm : Form
    {
        private readonly SettingManager _settingManager = new SettingManager();

        public MainForm()
        {
            InitializeComponent();
            ValidatePaths();
        }

        GameSave gameSave;

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            gameSave = new GameSave();

            gameSave.ReadSaveFromFile(textBoxSavePath.Text);

            //General tab
            comboBoxCPName.SelectedItem = gameSave.Data["CheckpointName"].Value;
            textBoxMapName.Text = gameSave.Data["MapName"].Value;
            textBoxSubContextID.Text = gameSave.Data["CurrentSubContextSaveData"].Value["SubContextId"].Value;
            textBoxSubContextPath.Text = gameSave.Data["CurrentSubContextPathName"].Value;
            dateTimePickerSaveTime.Value = gameSave.Data["SaveTime"].Value["DateTime"];

            UpdateInventoryGrids();
            UpdateSeenNotifsGrid();
            UpdateSeenTutosGrid();
            UpdateAllFactsGrid();
            UpdateWorldGrid();
            GenerateMetrics();
            UpdateSeenPicturesGrid();

            tabControlMain.Enabled = true;
            buttonSaveEdits.Enabled = true;
            labelChangesWarning.Visible = false;
            gameSave.SaveChangesSaved = true;
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            if (ModifierKeys == Keys.Control && File.Exists(textBoxSavePath.Text))
            {
                System.Diagnostics.Process.Start(Directory.GetParent(textBoxSavePath.Text).ToString());
            }
            else
            {
                DialogResult result = openFileDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    _settingManager.Settings.SavePath = openFileDialog1.FileName;
                    textBoxSavePath.Text = openFileDialog1.FileName;
                }
            }
        }

        private void buttonSaveEdits_Click(object sender, EventArgs e)
        {
            gameSave.WriteSaveToFile(textBoxSavePath.Text);
            MessageBox.Show(Resources.EditsSuccessfullySavedMessage, "Savegame Editor", MessageBoxButtons.OK, MessageBoxIcon.Information);
            labelChangesWarning.Visible = false;
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The Awesome Adventures of Captain Spirit"
                + Environment.NewLine + "savegame viewer and editor." +
                  Environment.NewLine + Environment.NewLine + "Version: " + Program.GetApplicationVersionStr(), "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #region Table-building

        private void UpdateInventoryGrids()
        {
            dataGridViewInventory1.Columns.Clear();
            dataGridViewInventory1.DataSource = BuildInventoryTable("InventoryItems").DefaultView;

            for (int i = 0; i < dataGridViewInventory1.ColumnCount; i++)
            {
                dataGridViewInventory1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dataGridViewInventory2.Columns.Clear();
            dataGridViewInventory2.DataSource = BuildInventoryTable("BackPackItems").DefaultView;

            for (int i = 0; i < dataGridViewInventory2.ColumnCount; i++)
            {
                dataGridViewInventory2.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dataGridViewInventory3.Columns.Clear();
            dataGridViewInventory3.DataSource = BuildInventoryTable("PocketsItems").DefaultView;

            for (int i = 0; i < dataGridViewInventory3.ColumnCount; i++)
            {
                dataGridViewInventory3.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }


        }

        private DataTable BuildInventoryTable(string inv_type)
        {
            DataTable t = new DataTable();
            var item_list = gameSave.Data["CurrentSubContextSaveData"].Value["PlayerSaveData"]
                      .Value["PlayerInventorySaveData"].Value[inv_type].Value;

            t.Columns.Add("Name");
            t.Columns.Add("Quantity");

            object[] row = new object[t.Columns.Count];

            for (int i=1; i<item_list.Count; i++)
            {
                row[0] = item_list[i]["PickupID"].Value;
                row[1] = item_list[i]["Quantity"].Value;
                t.Rows.Add(row);
            }
            return t;
        }

        private void UpdateSeenNotifsGrid()
        {
            dataGridViewSeenNotifs.Columns.Clear();
            dataGridViewSeenNotifs.DataSource = BuildSeenNotifsTable().DefaultView;

            for (int i = 0; i < dataGridViewSeenNotifs.ColumnCount; i++)
            {
                dataGridViewSeenNotifs.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private DataTable BuildSeenNotifsTable() //may be incorrect
        {
            DataTable t = new DataTable();
            var notif_list = gameSave.Data["CurrentSubContextSaveData"]
                             .Value["PlayerSaveData"].Value["AlreadySeenNotifications"].Value;

            t.Columns.Add("Name");

            foreach (var element in notif_list)
            {
                t.Rows.Add(new object[] {element});
            }
            t.Rows.Add("N/A"); //temp
            return t;
        }

        private void UpdateSeenTutosGrid()
        {
            dataGridViewSeenTutos.Columns.Clear();
            dataGridViewSeenTutos.DataSource = BuildSeenTutosTable().DefaultView;

            for (int i = 0; i < dataGridViewSeenTutos.ColumnCount; i++)
            {
                dataGridViewSeenTutos.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private DataTable BuildSeenTutosTable()
        {
            DataTable t = new DataTable();
            var tuto_list = gameSave.Data["CurrentSubContextSaveData"]
                             .Value["PlayerSaveData"].Value["AlreadySeenTutorials"].Value;

            t.Columns.Add("Name");
            t.Columns.Add("Times");

            foreach (var element in tuto_list)
            {
                t.Rows.Add(new object[] { element.Key, element.Value });
            }
            return t;
        }

        private void UpdateAllFactsGrid()
        {
            dataGridViewFacts.Columns.Clear();
            dataGridViewFacts.DataSource = BuildAllFactsTable().DefaultView;

            DataGridViewButtonColumn butcol = new DataGridViewButtonColumn();
            butcol.Name = "Value";
            butcol.Text = "View/Edit";
            butcol.UseColumnTextForButtonValue = true;
            dataGridViewFacts.Columns.Insert(1, butcol);

            for (int i = 0; i < dataGridViewFacts.ColumnCount; i++)
            {
                dataGridViewFacts.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dataGridViewFacts.Columns[0].ReadOnly = true;
            dataGridViewFacts.Columns[1].ReadOnly = true;
            dataGridViewFacts.Columns[1].Width = 30;
            dataGridViewFacts.Columns[2].Width = 100;

        }

        private DataTable BuildAllFactsTable()
        {
            DataTable t = new DataTable();
            var asset_list = gameSave.Data["CurrentSubContextSaveData"]
                             .Value["FactsSaveData"].Value;

            t.Columns.Add("Asset ID");
            t.Columns.Add("Keep values on save reset?");
            t.Columns[1].DataType = typeof(bool);
            object[] row = new object[t.Columns.Count];
            foreach (var asset in asset_list)
            {
                row[0] = asset.Key;
                row[1] = asset.Value["bKeepFactValuesOnSaveReset"].Value;
                t.Rows.Add(row);
            }
            return t;
        }

        private void UpdateWorldGrid()
        {
            dataGridViewWorld.Columns.Clear();
            dataGridViewWorld.DataSource = BuildWorldTable().DefaultView;

            for (int i = 0; i < dataGridViewWorld.ColumnCount; i++)
            {
                dataGridViewWorld.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dataGridViewWorld.Columns[0].Width = 220;
        }

        private DataTable BuildWorldTable()
        {
            DataTable t = new DataTable();
            var packages = gameSave.Data["CurrentSubContextSaveData"]
                             .Value["WorldStreamingSaveData"].Value;

            t.Columns.Add("Package name");
            t.Columns.Add("Should be loaded");
            t.Columns.Add("Should be visible");
            t.Columns.Add("Should block on load");
            t.Columns.Add("Has loaded level");
            t.Columns.Add("Is visible");
            t.Columns[1].DataType = typeof(bool);
            t.Columns[2].DataType = typeof(bool);
            t.Columns[3].DataType = typeof(bool);
            t.Columns[4].DataType = typeof(bool);
            t.Columns[5].DataType = typeof(bool);
            object[] row = new object[t.Columns.Count];
            for (int i=1; i<packages.Count; i++)
            {
                row[0] = packages[i]["StreamingLevelPackageName"].Value;
                row[1] = packages[i]["bShouldBeLoaded"].Value;
                row[2] = packages[i]["bShouldBeVisible"].Value;
                row[3] = packages[i]["bShouldBlockOnLoad"].Value;
                row[4] = packages[i]["bHasLoadedLevel"].Value;
                row[5] = packages[i]["bIsVisible"].Value;
                t.Rows.Add(row);
            }
            return t;
        }

        private void GenerateMetrics()
        {
            tabPageMetrics.Controls.Clear();

            var root = gameSave.Data["CurrentSubContextSaveData"].Value["MetricsSaveData"].Value["MetricsBySection"].Value;
            int gbox_coord = 3, lbl_coord = 20, max_lbl_width = 0;
            foreach (var section in root)
            {
                var gbox = new GroupBox();
                gbox.AutoSize = true;
                gbox.Location = new Point(gbox_coord, 3);
                gbox.Text = section.Key;

                foreach (var cnt in section.Value["Counters"].Value)
                {
                    var lbl = new Label();
                    lbl.AutoSize = true;
                    lbl.Location = new Point(3, lbl_coord);
                    lbl.Text = cnt.Key.Split(':')[2];
                    gbox.Controls.Add(lbl);

                    if (lbl.Width > max_lbl_width)
                    {
                        max_lbl_width = lbl.Width;
                    }

                    var tb = new TextBox();
                    tb.Location = new Point(lbl.Location.X + 3, lbl.Location.Y);
                    tb.Name = "tb" + cnt.Key;
                    tb.Tag = section.Key + "::" + cnt.Key;
                    tb.Size = new Size(60, 20);
                    tb.Text = cnt.Value.ToString();
                    tb.TextChanged += new EventHandler(textBoxMetricsCounters_TextChanged);
                    gbox.Controls.Add(tb);
                    lbl_coord += 26;
                }
                foreach(var cnt in section.Value["TimeCounters"].Value)
                {
                    var lbl = new Label();
                    lbl.AutoSize = true;
                    lbl.Location = new Point(3, lbl_coord);
                    lbl.Text = cnt.Key.Split(':')[2] + " time";
                    gbox.Controls.Add(lbl);

                    if (lbl.Width > max_lbl_width)
                    {
                        max_lbl_width = lbl.Width;
                    }

                    var tb = new TextBox();
                    tb.Location = new Point(lbl.Location.X + 3, lbl.Location.Y);
                    tb.Name = "tb" + cnt.Key;
                    tb.Tag = section.Key + "::" + cnt.Key;
                    tb.Size = new Size(60, 20);
                    tb.Text = cnt.Value.ToString();
                    tb.TextChanged += new EventHandler(textBoxMetricsTime_TextChanged);
                    gbox.Controls.Add(tb);
                    lbl_coord += 26;
                }
                foreach (var cnt in section.Value["InteractionCounters"].Value)
                {
                    var lbl = new Label();
                    lbl.AutoSize = true;
                    lbl.Location = new Point(3, lbl_coord);
                    lbl.Text = cnt.Key + " interactions (total/unique)";
                    gbox.Controls.Add(lbl);

                    if (lbl.Width > max_lbl_width)
                    {
                        max_lbl_width = lbl.Width;
                    }

                    var tb1 = new TextBox();
                    tb1.Location = new Point(lbl.Location.X + 3, lbl.Location.Y);
                    tb1.Name = "tb" + cnt.Key + "_Total";
                    tb1.Tag = section.Key + "::Total::" + cnt.Key;
                    tb1.Size = new Size(60, 20);
                    tb1.Text = cnt.Value["Total"].Value.ToString();
                    tb1.TextChanged += new EventHandler(textBoxMetricsInteraction_TextChanged);
                    gbox.Controls.Add(tb1);

                    var tb2 = new TextBox();
                    tb2.Location = new Point(tb1.Location.X + tb1.Width + 10, lbl.Location.Y);
                    tb2.Name = "tb" + cnt.Key + "_Unique";
                    tb2.Tag = section.Key + "::Unique::" + cnt.Key;
                    tb2.Size = new Size(60, 20);
                    tb2.Text = cnt.Value["Unique"].Value.ToString();
                    tb2.TextChanged += new EventHandler(textBoxMetricsInteraction_TextChanged);
                    gbox.Controls.Add(tb2);
                    lbl_coord += 26;
                }

                lbl_coord = 20;

                foreach (var tb in gbox.Controls.OfType<TextBox>())
                {
                    tb.Location = new Point(tb.Location.X + max_lbl_width, tb.Location.Y);
                }

                tabPageMetrics.Controls.Add(gbox);
                
                gbox_coord += gbox.Width + 6;
            }
        }

        private void UpdateSeenPicturesGrid()
        {
            dataGridViewSeenPics.Columns.Clear();
            dataGridViewSeenPics.DataSource = BuildSeenPicturesTable().DefaultView;

            for (int i = 0; i < dataGridViewSeenPics.ColumnCount; i++)
            {
                dataGridViewSeenPics.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private DataTable BuildSeenPicturesTable()
        {
            DataTable t = new DataTable();
            t.Columns.Add("Name");
            var names = gameSave.Data["CurrentSubContextSaveData"]
                             .Value["ShowPicturesSaveData"].Value["AllShowPictureIDSeen"].Value;

            for (int i=1; i<names.Count; i++)
            {
                t.Rows.Add(new object[] { names[i]["Name"].Value });
            }
            return t;
        }

        #endregion

        private void dataGridViewFacts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                var editForm = new FactEditForm();
                string assetId = dataGridViewFacts[0, e.RowIndex].Value.ToString();
                editForm.asset = gameSave.Data["CurrentSubContextSaveData"].Value["FactsSaveData"].Value[assetId];
                editForm.ShowDialog();
                if (editForm.changesMade)
                {
                    ShowChangesWarning();
                }
            }
        }

        #region Edit functions
        private void comboBoxCPName_SelectedValueChanged(object sender, EventArgs e)
        {
            gameSave.Data["CheckpointName"].Value = comboBoxCPName.SelectedItem.ToString();
            ShowChangesWarning();
        }

        private void textBoxMapName_TextChanged(object sender, EventArgs e)
        {
            gameSave.Data["MapName"].Value = textBoxMapName.Text;
            ShowChangesWarning();
        }

        private void textBoxSubContextID_TextChanged(object sender, EventArgs e)
        {
            gameSave.Data["CurrentSubContextSaveData"].Value["SubContextId"].Value = textBoxSubContextID.Text;
            ShowChangesWarning();
        }

        private void textBoxSubContextPath_TextChanged(object sender, EventArgs e)
        {
            gameSave.Data["CurrentSubContextPathName"].Value = textBoxSubContextPath.Text;
            ShowChangesWarning();
        }

        private void dateTimePickerSaveTime_ValueChanged(object sender, EventArgs e)
        {
            gameSave.Data["SaveTime"].Value["DateTime"] = dateTimePickerSaveTime.Value;
            ShowChangesWarning();
        }

        private int newRowIndex = -1;

        private void dataGridView_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            newRowIndex = e.Row.Index-1;
        }

        private void dataGridView_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex == newRowIndex)
            {
                switch (((DataGridView)sender).Name)
                {
                    case "dataGridViewInventory1":
                        {
                            var qty = dataGridViewInventory1[1, e.RowIndex].Value;
                            if (qty is DBNull) qty = 0;
                            gameSave.EditInventoryItem("InventoryItems", dataGridViewInventory1[0, e.RowIndex].Value.ToString(), Convert.ToInt32(qty));
                            dataGridViewInventory1[1, e.RowIndex].Value = qty;
                            break;
                        }
                    case "dataGridViewInventory2":
                        {
                            var qty = dataGridViewInventory2[1, e.RowIndex].Value;
                            if (qty is DBNull) qty = 0;
                            gameSave.EditInventoryItem("BackPackItems", dataGridViewInventory2[0, e.RowIndex].Value.ToString(), Convert.ToInt32(qty));
                            dataGridViewInventory2[1, e.RowIndex].Value = qty;
                            break;
                        }
                    case "dataGridViewInventory3":
                        {
                            var qty = dataGridViewInventory3[1, e.RowIndex].Value;
                            if (qty is DBNull) qty = 0;
                            gameSave.EditInventoryItem("PocketsItems", dataGridViewInventory3[0, e.RowIndex].Value.ToString(), Convert.ToInt32(qty));
                            dataGridViewInventory3[1, e.RowIndex].Value = qty;
                            break;
                        }
                    case "dataGridViewSeenTutos":
                        {
                            var times = dataGridViewSeenTutos[1, e.RowIndex].Value;
                            if (times is DBNull) times = 0;
                            gameSave.EditSeenTutorial(dataGridViewSeenTutos[0, e.RowIndex].Value.ToString(), Convert.ToInt32(times));
                            dataGridViewSeenTutos[1, e.RowIndex].Value = times;
                            break;
                        }
                    case "dataGridViewSeenPics":
                        {
                            gameSave.EditSeenPicture(dataGridViewSeenPics[0, e.RowIndex].Value.ToString(), false);
                            break;
                        }
                    default:
                        {
                            throw new Exception("Unknown data grid");
                            break;
                        }
                }

                ShowChangesWarning();
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
                case "dataGridViewInventory1":
                    {
                        gameSave.EditInventoryItem("InventoryItems", name, null);
                        break;
                    }
                case "dataGridViewInventory2":
                    {
                        gameSave.EditInventoryItem("BackPackItems", name, null);
                        break;
                    }
                case "dataGridViewInventory3":
                    {
                        gameSave.EditInventoryItem("PocketsItems", name, null);
                        break;
                    }
                case "dataGridViewSeenTutos":
                    {
                        gameSave.EditSeenTutorial(name, null);
                        break;
                    }
            }
            ShowChangesWarning();
        }

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

        object origCellValue, newCellValue;

        private void dataGridViewInventory1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 || dataGridViewInventory1.Rows[e.RowIndex].IsNewRow) return;
            int result;
            if (!int.TryParse(dataGridViewInventory1[e.ColumnIndex, e.RowIndex].Value.ToString(), out result))
            {
                MessageBox.Show(Resources.BadValueMessage, "Error");
                newCellValue = origCellValue;
                dataGridViewInventory1[e.ColumnIndex, e.RowIndex].Value = origCellValue;
            }
            else
            {
                newCellValue = result;
            }

            if (newCellValue.ToString() != origCellValue.ToString())
            {
                var item_name = dataGridViewInventory1[0, e.RowIndex].Value.ToString(); 
                gameSave.EditInventoryItem("InventoryItems", item_name, Convert.ToInt32(newCellValue));
                ShowChangesWarning();
            }
        }

        private void dataGridViewInventory2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 || dataGridViewInventory2.Rows[e.RowIndex].IsNewRow) return;
            int result;
            if (!int.TryParse(dataGridViewInventory2[e.ColumnIndex, e.RowIndex].Value.ToString(), out result))
            {
                MessageBox.Show(Resources.BadValueMessage, "Error");
                newCellValue = origCellValue;
                dataGridViewInventory2[e.ColumnIndex, e.RowIndex].Value = origCellValue;
            }
            else
            {
                newCellValue = result;
            }

            if (newCellValue.ToString() != origCellValue.ToString())
            {
                var item_name = dataGridViewInventory2[0, e.RowIndex].Value.ToString();
                gameSave.EditInventoryItem("BackPackItems", item_name, Convert.ToInt32(newCellValue));
                ShowChangesWarning();
            }
        }

        private void dataGridViewInventory3_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 || dataGridViewInventory3.Rows[e.RowIndex].IsNewRow) return;
            int result;
            if (!int.TryParse(dataGridViewInventory3[e.ColumnIndex, e.RowIndex].Value.ToString(), out result))
            {
                MessageBox.Show(Resources.BadValueMessage, "Error");
                newCellValue = origCellValue;
                dataGridViewInventory3[e.ColumnIndex, e.RowIndex].Value = origCellValue;
            }
            else
            {
                newCellValue = result;
            }

            if (newCellValue.ToString() != origCellValue.ToString())
            {
                var item_name = dataGridViewInventory3[0, e.RowIndex].Value.ToString();
                gameSave.EditInventoryItem("PocketsItems", item_name, Convert.ToInt32(newCellValue));
                ShowChangesWarning();
            }
        }

        private void dataGridViewSeenTutos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 || dataGridViewSeenTutos.Rows[e.RowIndex].IsNewRow) return;
            int result;
            if (!int.TryParse(dataGridViewSeenTutos[e.ColumnIndex, e.RowIndex].Value.ToString(), out result))
            {
                MessageBox.Show(Resources.BadValueMessage, "Error");
                newCellValue = origCellValue;
                dataGridViewSeenTutos[e.ColumnIndex, e.RowIndex].Value = origCellValue;
            }
            else
            {
                newCellValue = result;
            }

            if (newCellValue.ToString() != origCellValue.ToString())
            {
                var notif_name = dataGridViewSeenTutos[0, e.RowIndex].Value.ToString();
                gameSave.EditSeenTutorial(notif_name, Convert.ToInt32(newCellValue));
                ShowChangesWarning();
            }
        }

        private void dataGridViewFacts_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var name = dataGridViewFacts[0, e.RowIndex].Value.ToString();
            newCellValue = dataGridViewFacts[e.ColumnIndex, e.RowIndex].Value;
            if (newCellValue.ToString() != origCellValue.ToString())
            {
                gameSave.Data["CurrentSubContextSaveData"].Value["FactsSaveData"]
            .Value[name]["bKeepFactValuesOnSaveReset"].Value = Convert.ToBoolean(newCellValue);
                ShowChangesWarning();
            }
        }

        private void dataGridViewWorld_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string name = dataGridViewWorld[0, e.RowIndex].Value.ToString();

            newCellValue = dataGridViewWorld[e.ColumnIndex, e.RowIndex].Value;

            if (newCellValue.ToString() != origCellValue.ToString())
            {
                string property = "";
                switch (e.ColumnIndex)
                {
                    case 1:
                        {
                            property = "bShouldBeLoaded";
                            break;
                        }
                    case 2:
                        {
                            property = "bShouldBeVisible";
                            break;
                        }
                    case 3:
                        {
                            property = "bShouldBlockOnLoad";
                            break;
                        }
                    case 4:
                        {
                            property = "bHasLoadedLevel";
                            break;
                        }
                    case 5:
                        {
                            property = "bIsVisible";
                            break;
                        }
                }

                gameSave.EditPackageProperty(name, property, Convert.ToBoolean(newCellValue));
                ShowChangesWarning();
            }

        }

        private void textBoxMetricsCounters_TextChanged(object sender, EventArgs e)
        {
            var tb = (TextBox)sender;
            string[] info = tb.Tag.ToString().Split(new string[] { "::" }, 2, StringSplitOptions.RemoveEmptyEntries);
            uint value = 0;
            try
            {
                value = Convert.ToUInt32(tb.Text);
                tb.BackColor = SystemColors.Window;
            }
            catch
            {
                tb.BackColor = Color.Red;
            }

            gameSave.Data["CurrentSubContextSaveData"].Value["MetricsSaveData"].Value["MetricsBySection"].Value[info[0]]["Counters"].Value[info[1]] = value;
            ShowChangesWarning();
        }

        private void textBoxMetricsTime_TextChanged(object sender, EventArgs e)
        {
            var tb = (TextBox)sender;
            string[] info = tb.Tag.ToString().Split(new string[] { "::" }, 2, StringSplitOptions.RemoveEmptyEntries);
            float value = 0;
            try
            {
                value = Convert.ToSingle(tb.Text);
                tb.BackColor = SystemColors.Window;
            }
            catch
            {
                tb.BackColor = Color.Red;
            }

            gameSave.Data["CurrentSubContextSaveData"].Value["MetricsSaveData"].Value["MetricsBySection"].Value[info[0]]["TimeCounters"].Value[info[1]] = value;
            ShowChangesWarning();
        }

        private void textBoxMetricsInteraction_TextChanged(object sender, EventArgs e)
        {
            var tb = (TextBox)sender;
            string[] info = tb.Tag.ToString().Split(new string[] { "::" }, 3, StringSplitOptions.RemoveEmptyEntries);
            uint value = 0;
            try
            {
                value = Convert.ToUInt32(tb.Text);
                tb.BackColor = SystemColors.Window;
            }
            catch
            {
                tb.BackColor = Color.Red;
            }

            gameSave.Data["CurrentSubContextSaveData"].Value["MetricsSaveData"].Value["MetricsBySection"].Value[info[0]]["InteractionCounters"].Value[info[2]][info[1]].Value = value;
            ShowChangesWarning();
        }
        #endregion

        private void textBoxSavePath_TextChanged(object sender, EventArgs e)
        {
            ValidatePaths();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            foreach (TabPage page in tabControlMain.TabPages)
            {
                tabControlMain.SelectedTab = page;
            }
            tabControlMain.SelectedTab = tabPageGeneral;

            textBoxSavePath.Text = _settingManager.Settings.SavePath;

            //double buffering
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, dataGridViewSeenNotifs, new object[] { true });
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, dataGridViewSeenTutos, new object[] { true });
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, dataGridViewFacts, new object[] { true });
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, dataGridViewWorld, new object[] { true });
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, dataGridViewSeenPics, new object[] { true });

            labelChangesWarning.Visible = false;
            
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _settingManager.SaveSettings();

            if (gameSave != null && !gameSave.SaveChangesSaved)
            {
                DialogResult answer = MessageBox.Show(Resources.UnsavedEditsWarningMessage,
                    "Savegame Editor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (answer == DialogResult.Yes)
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else e.Cancel = false;
    }

        private void ValidatePaths()
        {
            bool success = false;
            try
            {
                success = File.Exists(textBoxSavePath.Text) && Path.GetExtension(textBoxSavePath.Text) == ".sav";
            }
            catch
            {

            }
            if (success)
            {
                textBoxSavePath.BackColor = SystemColors.Window;
            }
            else
            {
                textBoxSavePath.BackColor = Color.Red;
            }
            if (success)
            {
                buttonLoad.Enabled = true;
                buttonSaveEdits.Enabled = false;
                tabControlMain.Enabled = false;
                labelChangesWarning.Text = "Save file changed! Press 'Load' to update.";
                labelChangesWarning.Visible = true; //shows warning about save file
            }
            else
            {
                buttonLoad.Enabled = false;
                buttonSaveEdits.Enabled = false;
                tabControlMain.Enabled = false;
            }
        }

        private void ShowChangesWarning()
        {
            gameSave.SaveChangesSaved = false;
            labelChangesWarning.Text = "Press 'Save' to write changes to the save file.";
            labelChangesWarning.Visible = true;
        }
    }
}
