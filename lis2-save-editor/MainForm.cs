using lis2_save_editor.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace lis2_save_editor
{
    public partial class MainForm : Form
    {
        private readonly SettingManager _settingManager = new SettingManager();

        public MainForm()
        {
            InitializeComponent();
            ValidatePaths();
        }

        private GameSave _gameSave;
        private string[] _steamIdFolders = new string[0];

        private List<dynamic> _editedControls = new List<object>();

        private bool SaveLoading = false;

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            _gameSave = new GameSave();
            _gameSave.ReadSaveFromFile(textBoxSavePath.Text);

            #region BATCH READ
            /*
            string[] paths = new string[]
            {
                ...
            };
            
            foreach (var p in paths)
            {
                _gameSave.ReadSaveFromFile(p);
            }
            //*/
            #endregion

            if (!_gameSave.SaveIsValid.Status)
            {
                MessageBox.Show(string.Format(Resources.CorruptSaveMessage, _gameSave.SaveIsValid.ErrorMessage), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveLoading = true;

            comboBoxCPName.Items.Clear();
            
            if (_gameSave.saveVersion != SaveVersion.CaptainSpirit)
            {
                comboBoxCPName.Items.AddRange(GameInfo.LIS2_CheckpointNames);

                groupBoxDanielPos.Enabled = true;
                groupBoxAICall.Enabled = true;
                groupBoxMetaInv_SeenSubContexts.Enabled = true;
                groupBoxMetaInv_TutoStatus.Enabled = true;
                groupBoxOutfitsSean.Enabled = true;
                groupBoxOutfitsDaniel.Enabled = true;
                groupBoxOutfitsCharles.Enabled = true;
            }
            else
            {
                comboBoxCPName.Items.AddRange(GameInfo.CS_CheckpointNames);

                groupBoxDanielPos.Enabled = false;
                groupBoxAICall.Enabled = false;
                groupBoxMetaInv_SeenSubContexts.Enabled = false;
                groupBoxMetaInv_TutoStatus.Enabled = false;
                groupBoxOutfitsSean.Enabled = false;
                groupBoxOutfitsDaniel.Enabled = false;
                groupBoxOutfitsCharles.Enabled = false;
            }

            textBoxMapName.Text = _gameSave.Data["MapName"].Value;
            textBoxSubContextPath.Text = _gameSave.Data["CurrentSubContextPathName"].Value;
            dateTimePickerSaveTime.Value = _gameSave.Data["SaveTime"].Value["DateTime"];

            UpdateCheckpointList();
            UpdateHeaderData();
            UpdateStats();
            UpdateCSImportData();
            GenerateCinematics();

            comboBoxSelectCP.SelectedIndex = 0;

            tabControlMain.Enabled = true;
            comboBoxSelectCP.Enabled = true;
            buttonSaveEdits.Enabled = true;
            labelChangesWarning.Visible = false;
            _gameSave.SaveChangesSaved = true;

            //datagridview scrollbars dirty fix
            if (this.Width % 2 == 0)
            {
                Size = new Size(this.Width + 1, this.Height + 1);
            }
            else
            {
                Size = new Size(this.Width - 1, this.Height - 1);
            }
            

            if (searchForm != null)
            {
                searchForm.ResetSearchState();
            }
        }

        private void UpdateCheckpointList()
        {
            comboBoxSelectCP.Items.Clear();
            string[] cpName;
            string subID = _gameSave.Data["CurrentSubContextSaveData"].Value["SubContextId"].Value;
            if (_gameSave.saveVersion == SaveVersion.CaptainSpirit)
            {
                cpName = _gameSave.Data["CheckpointName"].Value.Split('_');
                comboBoxSelectCP.Items.Add($"Current - {subID}_{cpName.Last()}");
            }
            else
            {
                cpName = _gameSave.Data["CurrentSubContextSaveData"].Value["CheckpointName"].Value.Split('_');
                comboBoxSelectCP.Items.Add($"Current - {subID}_{cpName.Last()}");

                for (int i = 1; i <= _gameSave.Data["CheckpointHistory"].ElementCount; i++)
                {
                    comboBoxSelectCP.Items.Add(string.Format("{0} - {1}",
                        i, _gameSave.Data["CheckpointHistory"].Value[i]["SubContextId"].Value));
                }
            }

        }

        private void UpdateHeaderData()
        {
            comboBoxHeader_EPName.Items.Clear();
            comboBoxHeader_SubContextName.Items.Clear();
            comboBoxHeader_CheckpointName.Items.Clear();
            ClearGroupBox(groupBoxLISHeader);

            var header = _gameSave.Data["HeaderSaveData"].Value;
            checkBoxGameStarted.Checked = header["bGameStarted"].Value;

            if (_gameSave.saveVersion == SaveVersion.CaptainSpirit)
            {
                comboBoxHeader_EPName.Enabled = false;
                comboBoxHeader_EPNumber.Enabled = false;
                comboBoxHeader_SubContextName.Enabled = false;
                comboBoxHeader_CheckpointName.Enabled = false;
            }
            else
            {
                comboBoxHeader_EPName.Enabled = true;
                comboBoxHeader_EPNumber.Enabled = true;
                comboBoxHeader_SubContextName.Enabled = true;

                comboBoxHeader_EPName.Items.AddRange(GameInfo.LIS2_EpisodeNames);
                comboBoxHeader_SubContextName.Items.AddRange(GameInfo.LIS2_SubContextNames.Values.ToArray());
                comboBoxHeader_EPName.SelectedIndex = Convert.ToInt32(header["EpisodeName"].Value[1].Substring(22, 1)) - 1;
                comboBoxHeader_EPNumber.SelectedIndex = header["EpisodeNumber"].Value - 1;
                if (header["SubContextName"].Value.Length > 0)
                {
                    comboBoxHeader_SubContextName.SelectedItem = GameInfo.LIS2_SubContextNames[header["SubContextName"].Value[1]];
                }
                else
                {
                    comboBoxHeader_SubContextName.SelectedItem = GameInfo.LIS2_SubContextNames["NONE"];
                }

                if (_gameSave.saveVersion >= SaveVersion.LIS_E2)
                {
                    comboBoxHeader_CheckpointName.Enabled = true;
                    comboBoxHeader_CheckpointName.Items.AddRange(GameInfo.LIS2_CheckpointNames);
                    comboBoxHeader_CheckpointName.SelectedItem = header["CheckpointName"].Value;
                }
                else
                {
                    comboBoxHeader_CheckpointName.Enabled = false;
                }
            }
        }

        private void UpdateCSImportData()
        {
            if (_gameSave.saveVersion < SaveVersion.LIS_E2)
            {
                dateTimePickerCSSaveTime.Enabled = false;
                dateTimePickerCSLastPopup.Enabled = false;
                return;
            }
            else
            {
                dateTimePickerCSSaveTime.Enabled = true;
                dateTimePickerCSLastPopup.Enabled = true;
            }

            var root = _gameSave.Data["CaptainSpiritImportSaveData"].Value;

            foreach (Panel pan in groupBoxCSImport.Controls.OfType<Panel>())
            {
                DateTimePicker dtp = (DateTimePicker)pan.Controls[0];
                var date = root[$"{dtp.Tag}CaptainSpiritSaveTime"].Value["DateTime"];
                if (date < dtp.MinDate)
                {
                    dtp.Enabled = false;
                }
                else
                {
                    dtp.Enabled = true;
                    dtp.Value = date;
                }
            }
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
            _gameSave.WriteSaveToFile(textBoxSavePath.Text);
            MessageBox.Show(Resources.EditsSuccessfullySavedMessage, "Savegame Editor", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ResetEditedControls();
            labelChangesWarning.Visible = false;
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show(string.Format(Resources.AboutMessage, Program.GetApplicationVersionStr()), 
                            "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #region Read functions

        private void UpdatePlayerInfo(int cpIndex)
        {
            ClearGroupBox(groupBoxPlayerPos);
            dynamic root;
            if (cpIndex == 0)
            {
                root = _gameSave.Data["CurrentSubContextSaveData"].Value["PlayerSaveData"].Value;
            }
            else
            {
                root = _gameSave.Data["CheckpointHistory"].Value[cpIndex]["PlayerSaveData"].Value;
            }

            dynamic pos = root["RespawnTransform"].Value;
            textBoxPlayerRotationX.Text = pos["Rotation"].Value["Quat"].X.ToString();
            textBoxPlayerRotationY.Text = pos["Rotation"].Value["Quat"].Y.ToString();
            textBoxPlayerRotationZ.Text = pos["Rotation"].Value["Quat"].Z.ToString();
            textBoxPlayerRotationW.Text = pos["Rotation"].Value["Quat"].W.ToString();
            textBoxPlayerTranslationX.Text = pos["Translation"].Value["Vector"].X.ToString();
            textBoxPlayerTranslationY.Text = pos["Translation"].Value["Vector"].Y.ToString();
            textBoxPlayerTranslationZ.Text = pos["Translation"].Value["Vector"].Z.ToString();
            textBoxPlayerScaleX.Text = pos["Scale3D"].Value["Vector"].X.ToString();
            textBoxPlayerScaleY.Text = pos["Scale3D"].Value["Vector"].Y.ToString();
            textBoxPlayerScaleZ.Text = pos["Scale3D"].Value["Vector"].Z.ToString();

            if (_gameSave.saveVersion >= SaveVersion.LIS_E2)
            {
                checkBoxPlayerTransformValid.Enabled = true;
                checkBoxPlayerTransformValid.Checked = root["bRespawnTransformValid"].Value;
                checkBoxPlayerDistanceCuesPaused.Enabled = true;
                checkBoxPlayerDistanceCuesPaused.Checked = root["bDistanceCuesPaused"].Value;
            }
            else
            {
                checkBoxPlayerTransformValid.Enabled = false;
                checkBoxPlayerDistanceCuesPaused.Enabled = false;
            }
            

            if (root["PlayerControllerDisplacementMode"].Value == "ELIS2DisplacementMode::CustomMode")
            {
                comboBoxPlayerDisplacementMode.SelectedItem = root["PlayerControllerCustomDisplacementModeId"].Value;
            }
            else
            {
                comboBoxPlayerDisplacementMode.SelectedItem = root["PlayerControllerDisplacementMode"].Value.Replace("ELIS2DisplacementMode::", "");
            }

            checkBoxLockedDiary.Checked = root["bPlayerControllerLockedDiary"].Value;
            checkBoxVoicePaused.Checked = root["bInnerVoiceComponentPaused"].Value;
        }

        private void UpdateDanielInfo(int cpIndex)
        {
            ClearGroupBox(groupBoxDanielPos);
            if (_gameSave.saveVersion == SaveVersion.CaptainSpirit)
            {
                return;
            }

            dynamic root;
            string subContextId;
            if (cpIndex == 0)
            {
                root = _gameSave.Data["CurrentSubContextSaveData"].Value["BrotherAISaveData"].Value;
                subContextId = _gameSave.Data["CurrentSubContextSaveData"].Value["SubContextId"].Value;
            }
            else
            {
                root = _gameSave.Data["CheckpointHistory"].Value[cpIndex]["BrotherAISaveData"].Value;
                subContextId = _gameSave.Data["CheckpointHistory"].Value[cpIndex]["SubContextId"].Value;
            }

            dynamic pos = root["RespawnTransform"].Value;
            textBoxDanielRotationX.Text = pos["Rotation"].Value["Quat"].X.ToString();
            textBoxDanielRotationY.Text = pos["Rotation"].Value["Quat"].Y.ToString();
            textBoxDanielRotationZ.Text = pos["Rotation"].Value["Quat"].Z.ToString();
            textBoxDanielRotationW.Text = pos["Rotation"].Value["Quat"].W.ToString();
            textBoxDanielTranslationX.Text = pos["Translation"].Value["Vector"].X.ToString();
            textBoxDanielTranslationY.Text = pos["Translation"].Value["Vector"].Y.ToString();
            textBoxDanielTranslationZ.Text = pos["Translation"].Value["Vector"].Z.ToString();
            textBoxDanielScaleX.Text = pos["Scale3D"].Value["Vector"].X.ToString();
            textBoxDanielScaleY.Text = pos["Scale3D"].Value["Vector"].Y.ToString();
            textBoxDanielScaleZ.Text = pos["Scale3D"].Value["Vector"].Z.ToString();

            comboBoxDanielAIState.SelectedItem = root["AIState"].Value.Replace("ELIS2AIState::", "");

            List<string> pois = new List<string>();
            foreach (var level in GameInfo.LIS2_Levels.Where(x => x.Name.Contains(subContextId)))
            {
                foreach (var poi in level.PointsOfInterest)
                {
                    pois.AddUnique(poi);
                }
            }

            //Dontnod messed up?
            if (subContextId == "E2_1A")
            {
                foreach (var level in GameInfo.LIS2_Levels.Where(x => x.Name.Contains("E2_2A")))
                {
                    foreach (var poi in level.PointsOfInterest)
                    {
                        pois.AddUnique(poi);
                    }
                }
            }

            comboBoxDanielPOI.Items.Clear();
            comboBoxDanielPOI.Items.Add("None");
            pois.Sort();
            comboBoxDanielPOI.Items.AddRange(pois.ToArray());
            comboBoxDanielPOI.SelectedItem = root["PointOfInterestInProgress"].Value;

            comboBoxDanielAIPreset.SelectedItem = root["AIDataPresetName"].Value;

            if (_gameSave.saveVersion >= SaveVersion.LIS_E2)
            {
                checkBoxDanielTransformValid.Enabled = true;
                checkBoxDanielTransformValid.Checked = root["bRespawnTransformValid"].Value;
            }
            else
            {
                checkBoxDanielTransformValid.Enabled = false;
            }
        }

        private void UpdateAICallInfo(int cpIndex)
        {
            ClearGroupBox(groupBoxAICall);
            if (_gameSave.saveVersion == SaveVersion.CaptainSpirit)
            {
                return;
            }

            dynamic root;
            if (cpIndex == 0)
            {
                root = _gameSave.Data["CurrentSubContextSaveData"].Value["CallAISaveData"].Value;
            }
            else
            {
                root = _gameSave.Data["CheckpointHistory"].Value[cpIndex]["CallAISaveData"].Value;
            }

            checkBoxAICallGlobalEnable.Checked = root["bIsCallAIBehaviourEnable"].Value;
            checkBoxAICallFocusFail.Checked = root["bIsFocusFailNecessaryToCall"].Value;
            textBoxAICallDelay.Text = root["DelayBetweenCalls"].Value.ToString();

            List<dynamic> ai_items = root["CallAIItems"].Value;
            ai_items = ai_items.Skip(1).ToList();

            foreach (CheckBox cb in groupBoxAICallEnable.Controls.OfType<CheckBox>())
            {
                var item = ai_items.Find(x => x["AIToCall"].Value.EndsWith(cb.Tag.ToString()));
                cb.CheckState = item == null
                    ? CheckState.Unchecked
                    : (item["bEnable"].Value ? CheckState.Checked : CheckState.Indeterminate);
            }
        }

        private void UpdateStats()
        {
            ClearGroupBox(groupBoxEpisodeCompletion);
            ClearGroupBox(groupBoxSendChoiceSuccess);
            if (_gameSave.saveVersion == SaveVersion.CaptainSpirit)
            {
                groupBoxEpisodeCompletion.Enabled = false;
                groupBoxSendChoiceSuccess.Enabled = false;
                return;
            }
            groupBoxEpisodeCompletion.Enabled = true;
            Dictionary<string, dynamic> root = _gameSave.Data["StatsSaveData"].Value;

            List<dynamic> epCompletion = root["EpisodeCompletion"].Value;

            for (int i = 0; i < epCompletion.Count; i++)
            {
                ((CheckBox)groupBoxEpisodeCompletion.Controls.Find("checkBoxEpComplete" + (i + 1), false)[0]).Checked = Convert.ToBoolean(epCompletion[i]);
            }

            if (_gameSave.saveVersion >= SaveVersion.LIS_E2)
            {
                groupBoxSendChoiceSuccess.Enabled = true;
                Dictionary<dynamic, dynamic> sendChoiceSuccess = root["SendChoiceSuccess"].Value;
                foreach (var item in sendChoiceSuccess)
                {
                    ((CheckBox) groupBoxSendChoiceSuccess.Controls.Find($"checkBoxChoiceSent{item.Key}", false)[0])
                        .CheckState = Convert.ToBoolean(item.Value) ? CheckState.Checked : CheckState.Indeterminate;
                }
            }
            else
            {
                groupBoxSendChoiceSuccess.Enabled = false;
            }
        }

        private void UpdateMetaInvSubContexts(int cpIndex)
        {
            ClearGroupBox(groupBoxMetaInv_SeenSubContexts);
            if (_gameSave.saveVersion == SaveVersion.CaptainSpirit)
            {
                return;
            }

            List<dynamic> root;

            if (cpIndex == 0)
            {
                root = _gameSave.Data["CurrentSubContextSaveData"].Value["MetaInventoryMapSaveData"].Value["SeenSubcontexts"].Value;
            }
            else
            {
                root = _gameSave.Data["CheckpointHistory"].Value[cpIndex]["MetaInventoryMapSaveData"].Value["SeenSubcontexts"].Value;
            }

            foreach (CheckBox cb in groupBoxMetaInv_SeenSubContexts.Controls.OfType<CheckBox>())
            {
                cb.Checked = root.Contains(cb.Tag.ToString());
            }
        }

        private void UpdateMetaInvTutoStatus(int cpIndex)
        {
            ClearGroupBox(groupBoxMetaInv_TutoStatus);
            if (_gameSave.saveVersion == SaveVersion.CaptainSpirit)
            {
                return;
            }

            Dictionary<dynamic, dynamic> root;

            if (cpIndex == 0)
            {
                root = _gameSave.Data["CurrentSubContextSaveData"].Value["PlayerSaveData"]
                       .Value["MetaInventoryTutorialSaveData"].Value["PageTutorialStatusMap"].Value;
            }
            else
            {
                root = _gameSave.Data["CheckpointHistory"].Value[cpIndex]["PlayerSaveData"]
                       .Value["MetaInventoryTutorialSaveData"].Value["PageTutorialStatusMap"].Value;
            }

            foreach (CheckBox cb in groupBoxMetaInv_TutoStatus.Controls.OfType<CheckBox>())
            {
                var key = "ELIS2MetaInventoryPageType::" + cb.Text;
                cb.Checked = root.ContainsKey(key) ? Convert.ToBoolean(root[key]) : false;
            }
        }

        private void UpdateInventoryGrids(int cpIndex)
        {
            dataGridViewInventory1.Columns.Clear();
            dataGridViewInventory2.Columns.Clear();
            dataGridViewInventory3.Columns.Clear();
            dataGridViewInventoryDaniel1.Columns.Clear();
            dataGridViewInventoryDaniel2.Columns.Clear();
            dataGridViewInventoryDaniel3.Columns.Clear();

            List<DataGridView> grids = new List<DataGridView>()
            {
                dataGridViewInventory1
            };

            if (_gameSave.saveVersion >= SaveVersion.LIS_E1)
            {
                grids.Add(dataGridViewInventory2);
                grids.Add(dataGridViewInventory3);
            }

            if (_gameSave.saveVersion >= SaveVersion.LIS_E2)
            {
                grids.Add(dataGridViewInventoryDaniel1);
                grids.Add(dataGridViewInventoryDaniel2);
                grids.Add(dataGridViewInventoryDaniel3);
            }

            foreach (var g in grids)
            {
                string[] info = g.Tag.ToString().Split(new string[] { "::" }, 2, StringSplitOptions.None);

                g.DataSource = BuildInventoryTable(cpIndex, info[0], info[1]).DefaultView;
                for (int i=1; i<g.ColumnCount; i++)
                {
                    g.Columns[i].FillWeight = 10;
                }
            }
        }

        private DataTable BuildInventoryTable(int cpIndex, string inv_type, string owner)
        {
            DataTable t = new DataTable();
            List<dynamic> item_list;

            string ownerPrefix = owner == "Player" ? "Player" : "AI";

            if(cpIndex == 0)
            {
                item_list = _gameSave.Data["CurrentSubContextSaveData"].Value[$"{owner}SaveData"]
                      .Value[$"{ownerPrefix}InventorySaveData"].Value[$"{inv_type}Items"].Value;
            }
            else
            {
                item_list = _gameSave.Data["CheckpointHistory"].Value[cpIndex][$"{owner}SaveData"]
                      .Value[$"{ownerPrefix}InventorySaveData"].Value[$"{inv_type}Items"].Value;
            }

            object[] row = new object[t.Columns.Count];

            if (_gameSave.saveVersion == SaveVersion.CaptainSpirit)
            {
                t.Columns.Add("Name");
                t.Columns.Add("Active", typeof(bool));
                t.Columns.Add("Quantity");

                row = new object[t.Columns.Count];

                foreach (var item in GameInfo.CS_InventoryItems)
                {
                    row[0] = item;
                    int index = item_list.FindIndex(1, x => x["PickupID"].Value == item);
                    if (index == -1)
                    {
                        row[1] = false;
                        row[2] = 0;
                    }
                    else
                    {
                        row[1] = true;
                        row[2] = item_list[index]["Quantity"].Value;
                    }
                    
                    t.Rows.Add(row);
                }
            }
            else
            {
                t.Columns.Add("Name");
                t.Columns.Add("Active", typeof(bool));
                t.Columns.Add("Quantity");
                t.Columns.Add("Is new", typeof(bool));

                row = new object[t.Columns.Count];

                foreach (var item in GameInfo.LIS2_InventoryItems.Where(x => x.Owner == owner && x.Type == inv_type))
                {
                    row[0] = item.ID;
                    int index = item_list.FindIndex(1, x => x["PickupID"].Value == item.ID);
                    if (index == -1)
                    {
                        row[1] = false;
                        row[2] = 0;
                        row[3] = false;
                    }
                    else
                    {
                        row[1] = true;
                        row[2] = item_list[index]["Quantity"].Value;
                        row[3] = item_list[index]["bIsNew"].Value;
                    }

                    t.Rows.Add(row);
                }
            }
            
            return t;
        }

        private void UpdateSeenNotifsGrid(int cpIndex)
        {
            dataGridViewSeenNotifs.Columns.Clear();
            dataGridViewSeenNotifs.DataSource = BuildSeenNotifsTable(cpIndex).DefaultView;

            if(_gameSave.saveVersion >= SaveVersion.LIS_E1)
            {
                dataGridViewSeenNotifs.Columns[1].FillWeight = 10;
            }
        }

        private DataTable BuildSeenNotifsTable(int cpIndex)
        {
            DataTable t = new DataTable();
            if (_gameSave.saveVersion == SaveVersion.CaptainSpirit)
            {
                return t;
            }

            List<dynamic> notif_list;
            if (cpIndex == 0)
            {
                notif_list = _gameSave.Data["CurrentSubContextSaveData"]
                             .Value["PlayerSaveData"].Value["AlreadySeenNotifications"].Value;
            }
            else
            {
                notif_list = _gameSave.Data["CheckpointHistory"].Value[cpIndex]
                             ["PlayerSaveData"].Value["AlreadySeenNotifications"].Value;
            }
            
            t.Columns.Add("Name");
            t.Columns.Add("Seen", typeof(bool));

            foreach (var element in GameInfo.LIS2_SeenNotifsNames)
            {
                t.Rows.Add(new object[] {element, notif_list.Contains(element)});
            }

            return t;
        }

        private void UpdateSeenTutosGrid(int cpIndex)
        {
            dataGridViewSeenTutos.Columns.Clear();
            dataGridViewSeenTutos.DataSource = BuildSeenTutosTable(cpIndex).DefaultView;

            dataGridViewSeenTutos.Columns[1].FillWeight = 10;
            dataGridViewSeenTutos.Columns[2].FillWeight = 10;
        }

        private DataTable BuildSeenTutosTable(int cpIndex)
        {
            DataTable t = new DataTable();
            Dictionary<dynamic, dynamic> tuto_list;

            if (cpIndex == 0)
            {
                tuto_list = _gameSave.Data["CurrentSubContextSaveData"]
                             .Value["PlayerSaveData"].Value["AlreadySeenTutorials"].Value;
            }
            else
            {
                tuto_list = _gameSave.Data["CheckpointHistory"].Value[cpIndex]
                            ["PlayerSaveData"].Value["AlreadySeenTutorials"].Value;
            }

            t.Columns.Add("Name");
            t.Columns.Add("Seen", typeof(bool));
            t.Columns.Add("Times");

            string[] namelist = _gameSave.saveVersion == SaveVersion.CaptainSpirit 
                              ? GameInfo.CS_SeenTutosNames : GameInfo.LIS2_SeenTutosNames;

            foreach (var name in namelist)
            {
                object[] row = new object[t.Columns.Count];
                row[0] = name;
                var times = tuto_list.FirstOrDefault(x => x.Key == name).Value;
                if (times == null)
                {
                    row[1] = false;
                    row[2] = 0;
                }
                else
                {
                    row[1] = true;
                    row[2] = times;
                }
                t.Rows.Add(row);
            }
            return t;
        }

        private void GenerateDrawings(int cpIndex)
        {
            flowLayoutPanelDrawings.Controls.Clear();

            if (_gameSave.saveVersion == SaveVersion.CaptainSpirit)
            {
                return;
            }

            List<dynamic> root;

            if (cpIndex == 0)
            {
                root = _gameSave.Data["CurrentSubContextSaveData"].Value["PlayerSaveData"]
                    .Value["DrawSequenceSaveData"].Value["DrawSequenceItemSaveDatas"].Value;
            }
            else
            {
                root = _gameSave.Data["CheckpointHistory"].Value[cpIndex]["PlayerSaveData"]
                    .Value["DrawSequenceSaveData"].Value["DrawSequenceItemSaveDatas"].Value;
            }

            root = root.Skip(1).ToList();

            var phases = new string[] { "Rough", "Detail", "Finished" };

            int lbl_y = 20, gbox_x = 3, max_lbl_width = 0;

            foreach (var drawing in GameInfo.LIS2_DrawingNames)
            {
                var gbox = new GroupBox();
                gbox.AutoSize = true;
                gbox.Text = drawing.Name;

                var cb_dr_active = new CheckBox();
                cb_dr_active.AutoSize = true;
                cb_dr_active.Name = "DrawingActive";
                cb_dr_active.Text = "Active";
                cb_dr_active.Location = new Point(10, lbl_y);
                dynamic save_drawing = root.Find(x => x["DrawSequenceID"].Value["Name"].Value == drawing.Name);
                cb_dr_active.Checked = save_drawing != null;
                cb_dr_active.Tag = drawing.Name;
                cb_dr_active.CheckedChanged += new EventHandler(checkBoxDrawingActive_CheckedChanged);
                gbox.Controls.Add(cb_dr_active);

                List<dynamic> save_drawingzone_list = save_drawing?["LandscapeItemSaveDatas"].Value ?? new List<dynamic>();
                if (save_drawingzone_list.Count > 0) save_drawingzone_list = save_drawingzone_list.Skip(1).ToList();
                for (int i=1; i<=drawing.ZoneCount; i++)
                {
                    var gbox_zone = new GroupBox();
                    gbox_zone.AutoSize = true;
                    gbox_zone.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                    gbox_zone.Location = new Point(gbox_x, 40);
                    gbox_zone.Text = $"Zone {i}";

                    var cb_zone_active = new CheckBox();
                    cb_zone_active.AutoSize = true;
                    cb_zone_active.Name = "ZoneActive";
                    cb_zone_active.Text = "Active";
                    cb_zone_active.Location = new Point(10, lbl_y);
                    dynamic save_zone = save_drawingzone_list.Find(x => x["LandscapeID"].Value == $"Zone{i}_Reveal");
                    cb_zone_active.Checked = save_zone != null;
                    cb_zone_active.Tag = drawing.Name + "::" + i;
                    cb_zone_active.CheckedChanged += new EventHandler(checkBoxDrawingZoneActive_CheckedChanged);
                    gbox_zone.Controls.Add(cb_zone_active);
                    lbl_y += 26;

                    var lbl_percent = new Label() { AutoSize = true, Text = "Percent", Location = new Point(3, lbl_y) };

                    gbox_zone.Controls.Add(lbl_percent);

                    if (lbl_percent.Width > max_lbl_width)
                    {
                        max_lbl_width = lbl_percent.Width;
                    }

                    var tb_percent = new TextBox();
                    tb_percent.Location = new Point(lbl_percent.Location.X + 3, lbl_percent.Location.Y);
                    tb_percent.Name = "tbPercent";
                    tb_percent.Tag = drawing.Name + "::" + i;
                    tb_percent.Size = new Size(80, 20);
                    tb_percent.Text = save_zone == null ? "" : save_zone["DrawingPercent"].Value.ToString();
                    tb_percent.TextChanged += new EventHandler(textBoxDrawingPercent_TextChanged);
                    gbox_zone.Controls.Add(tb_percent);
                    lbl_y += 26;

                    if (_gameSave.saveVersion == SaveVersion.LIS_E1)
                    {
                        var lbl_phase = new Label() { AutoSize = true, Text = "Phase", Location = new Point(3, lbl_y) };
                        gbox_zone.Controls.Add(lbl_phase);

                        if (lbl_phase.Width > max_lbl_width)
                        {
                            max_lbl_width = lbl_phase.Width;
                        }

                        var panel_phase = new Panel() { Location = new Point(lbl_phase.Location.X + 3, lbl_phase.Location.Y), Size = new Size(85, 27) };

                        var combo_phase = new ComboBox();
                        combo_phase.Name = "comboBoxPhase";
                        combo_phase.Location = new Point(3, 3);
                        combo_phase.Width = 80;
                        combo_phase.Items.AddRange(phases);
                        combo_phase.DropDownStyle = ComboBoxStyle.DropDownList;
                        combo_phase.SelectedItem = save_zone == null ? "" : save_zone["DrawingPhase"].Value.Split(new string[] { "::" }, StringSplitOptions.None)[1];
                        combo_phase.Tag = drawing.Name + "::" + i;
                        combo_phase.SelectedIndexChanged += new EventHandler(comboBoxDrawingPhase_Old_SelectedIndexChanged);
                        panel_phase.Controls.Add(combo_phase);
                        gbox_zone.Controls.Add(panel_phase);
                        
                    }
                    else
                    {
                        foreach(var type in new string[] {"Start", "Current", "End" })
                        {
                            var lbl_phase = new Label() { AutoSize = true, Text = type+" phase", Location = new Point(3, lbl_y) };
                            gbox_zone.Controls.Add(lbl_phase);
                            lbl_y += 26;

                            if (lbl_phase.Width > max_lbl_width)
                            {
                                max_lbl_width = lbl_phase.Width;
                            }

                            /* 
                            var panel_phase  = new Panel() { Location = new Point(lbl_phase.Location.X + 3, lbl_phase.Location.Y), Size = new Size(85, 27) };
                            var combo_phase = new ComboBox();
                            combo_phase.Location = new Point(lbl_phase.Location.X + 3, lbl_phase.Location.Y);
                            combo_phase.Width = 80;
                            combo_phase.Items.AddRange(phases);
                            combo_phase.DropDownStyle = ComboBoxStyle.DropDownList;
                            combo_phase.SelectedIndex = save_zone == null ? 0 : save_zone[$"Drawing{type}Phase"].Value + 1;
                            combo_phase.Tag = drawing.Name + "::" + i + "::" + type;
                            //combo_phase.SelectedIndexChanged += new EventHandler(comboBoxDrawingPhase_SelectedIndexChanged);
                            panel_phase.Controls.Add(combo_phase);
                            gbox_zone.Controls.Add(panel_phase);
                            */

                            var tb_phase = new TextBox();
                            tb_phase.Name = $"tb{type}Phase";
                            tb_phase.Location = new Point(lbl_phase.Location.X + 3, lbl_phase.Location.Y);
                            tb_phase.Width = 80;
                            tb_phase.Text = save_zone == null ? "-1" : save_zone[$"Drawing{type}Phase"].Value.ToString();
                            tb_phase.Tag = drawing.Name + "::" + i + "::" + type;
                            tb_phase.TextChanged += new EventHandler(textBoxDrawingPhase_TextChanged);
                            gbox_zone.Controls.Add(tb_phase);
                        }

                        var cb_zone_finish = new CheckBox();
                        cb_zone_finish.AutoSize = false;
                        cb_zone_finish.Name = "cbFinishWhenComplete";
                        cb_zone_finish.Size = new Size(130, 30);
                        cb_zone_finish.Text = "Finish draw sequence when complete";
                        cb_zone_finish.Location = new Point(cb_zone_active.Location.X + 60, 14);
                        cb_zone_finish.Checked = save_zone == null ? false : save_zone["bFinishDrawSequenceWhenComplete"].Value;
                        cb_zone_finish.Tag = drawing.Name + "::" + i;
                        cb_zone_finish.CheckedChanged += new EventHandler(checkBoxDrawingZoneFinishWhenComplete_CheckedChanged);
                        gbox_zone.Controls.Add(cb_zone_finish);
                    }
                    foreach (var tb in gbox_zone.Controls.OfType<TextBox>())
                    {
                        tb.Location = new Point(tb.Location.X + max_lbl_width, tb.Location.Y - 3);
                    }

                    foreach (var pan in gbox_zone.Controls.OfType<Panel>())
                    {
                        pan.Location = new Point(pan.Location.X + max_lbl_width - 3, pan.Location.Y - 6);
                    }

                    lbl_y = 20;
                    max_lbl_width = 0;

                    gbox.Controls.Add(gbox_zone);

                    gbox_x += gbox_zone.Width + 5;
                }

                gbox_x = 3;
                lbl_y = 20;
                flowLayoutPanelDrawings.Controls.Add(gbox);
                
            }
        }

        private void UpdateAllFactsGrid(int cpIndex)
        {
            dataGridViewFacts.Columns.Clear();
            dataGridViewFacts.DataSource = BuildAllFactsTable(cpIndex).DefaultView;

            DataGridViewButtonColumn butcol = new DataGridViewButtonColumn();
            butcol.Name = "Value";
            butcol.Text = "View/Edit";
            butcol.UseColumnTextForButtonValue = true;
            dataGridViewFacts.Columns.Insert(1, butcol);

            dataGridViewFacts.Columns[0].ReadOnly = true;
            dataGridViewFacts.Columns[1].ReadOnly = true;
            dataGridViewFacts.Columns[1].FillWeight = 20;
            dataGridViewFacts.Columns[2].FillWeight = 20;
        }

        private DataTable BuildAllFactsTable(int cpIndex)
        {
            DataTable t = new DataTable();
            dynamic asset_list;

            if (cpIndex == 0)
            {
                asset_list = _gameSave.Data["CurrentSubContextSaveData"]
                             .Value["FactsSaveData"].Value;
            }
            else
            {
                asset_list = _gameSave.Data["CheckpointHistory"].Value[cpIndex]["FactsSaveData"].Value;
            }
            
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

        private void UpdateWorldGrid(int cpIndex)
        {
            dataGridViewWorld.Columns.Clear();
            dataGridViewWorld.DataSource = BuildWorldTable(cpIndex).DefaultView;

            dataGridViewWorld.Columns[0].Width = 220;
        }

        private DataTable BuildWorldTable(int cpIndex)
        {
            DataTable t = new DataTable();
            List<dynamic> packages;
            if (cpIndex == 0)
            {
                packages = _gameSave.Data["CurrentSubContextSaveData"]
                             .Value["WorldStreamingSaveData"].Value;
            }
            else
            {
                packages = _gameSave.Data["CheckpointHistory"].Value[cpIndex]["WorldStreamingSaveData"].Value;
            }
            
            if (_gameSave.saveVersion == SaveVersion.CaptainSpirit)
            {
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
                foreach (var pack in packages.Skip(1))
                {
                    row[0] = pack["StreamingLevelPackageName"].Value;
                    row[1] = pack["bShouldBeLoaded"].Value;
                    row[2] = pack["bShouldBeVisible"].Value;
                    row[3] = pack["bShouldBlockOnLoad"].Value;
                    row[4] = pack["bHasLoadedLevel"].Value;
                    row[5] = pack["bIsVisible"].Value;
                    t.Rows.Add(row);
                }
            }
            else
            {
                t.Columns.Add("Package name");
                t.Columns.Add("Should be loaded");
                t.Columns.Add("Should be visible");
                t.Columns.Add("Has loaded level");
                t.Columns.Add("Is visible");
                t.Columns.Add("Is requesting unload");
                t.Columns[1].DataType = typeof(bool);
                t.Columns[2].DataType = typeof(bool);
                t.Columns[3].DataType = typeof(bool);
                t.Columns[4].DataType = typeof(bool);
                t.Columns[5].DataType = typeof(bool);
                object[] row = new object[t.Columns.Count];
                foreach (var pack in packages.Skip(1))
                {
                    row[0] = pack["StreamingLevelPackageName"].Value;
                    row[1] = pack["bShouldBeLoaded"].Value;
                    row[2] = pack["bShouldBeVisible"].Value;
                    row[3] = pack["bHasLoadedLevel"].Value;
                    row[4] = pack["bIsVisible"].Value;
                    row[5] = pack["bIsRequestingUnloadAndRemoval"].Value;
                    t.Rows.Add(row);
                }
            }
            
            return t;
        }

        private void UpdateAllLevelsGrid(int cpIndex)
        {
            dataGridViewLevels.Columns.Clear();
            dataGridViewLevels.DataSource = BuildAllLevelsTable(cpIndex).DefaultView;

            DataGridViewButtonColumn butcol = new DataGridViewButtonColumn();
            butcol.Name = "Value";
            butcol.Text = "View/Edit";
            butcol.UseColumnTextForButtonValue = true;
            dataGridViewLevels.Columns.Insert(1, butcol);

            dataGridViewLevels.Columns[1].FillWeight = 20;
            dataGridViewLevels.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewLevels.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private DataTable BuildAllLevelsTable(int cpIndex)
        {
            DataTable t = new DataTable();
            List<dynamic> level_list;

            if (cpIndex == 0)
            {
                level_list = _gameSave.Data["CurrentSubContextSaveData"]
                             .Value["LevelsSaveData"].Value;
            }
            else
            {
                level_list = _gameSave.Data["CheckpointHistory"].Value[cpIndex]["LevelsSaveData"].Value;
            }

            t.Columns.Add("Level ID");
            foreach (var lvl in level_list.Skip(1))
            {
                t.Rows.Add(new object[] { lvl["LevelName"].Value });
            }
            return t;
        }

        private void GenerateMetrics(int cpIndex)
        {
            flowLayoutPanelMetrics.Controls.Clear();

            dynamic root;
            if (cpIndex == 0)
            {
                root = _gameSave.Data["CurrentSubContextSaveData"].Value["MetricsSaveData"].Value;
            }
            else
            {
                root = _gameSave.Data["CheckpointHistory"].Value[cpIndex]["MetricsSaveData"].Value;
            }

            #region Playthrough box
            var gbox_p = new GroupBox();
            gbox_p.AutoSize = true;
            gbox_p.Text = "Playthrough";

            var lbl_p = new Label();
            lbl_p.AutoSize = true;
            lbl_p.Location = new Point(3, 20);
            lbl_p.Text = "GUID";
            gbox_p.Controls.Add(lbl_p);

            var tb_p = new TextBox();
            tb_p.Location = new Point(lbl_p.Location.X + 50, lbl_p.Location.Y - 3);
            tb_p.Name = "tbPlaythroughGuid";
            tb_p.Size = new Size(220, 20);
            tb_p.Text = root["PlaythroughId"].Value["Guid"].ToString();
            tb_p.TextChanged += new EventHandler(textBoxMetricsPlaythroughGuid_TextChnaged);
            gbox_p.Controls.Add(tb_p);

            if (_gameSave.saveVersion >= SaveVersion.LIS_E1)
            {
                lbl_p = new Label();
                lbl_p.AutoSize = true;
                lbl_p.Location = new Point(3, 46);
                lbl_p.Text = "Counter";
                gbox_p.Controls.Add(lbl_p);

                tb_p = new TextBox();
                tb_p.Location = new Point(lbl_p.Location.X + 50, lbl_p.Location.Y - 3);
                tb_p.Name = "tbPlaythroughCounter";
                tb_p.Size = new Size(60, 20);
                tb_p.Text = root["PlaythroughCounter"].Value.ToString();
                tb_p.TextChanged += new EventHandler(textBoxMetricsPlaythroughCounter_TextChnaged);
                gbox_p.Controls.Add(tb_p);
            }

            flowLayoutPanelMetrics.Controls.Add(gbox_p);
            #endregion

            root = root["MetricsBySection"].Value;
            int lbl_coord = 20, max_lbl_width = 0;
            foreach (var section in root)
            {
                var gbox = new GroupBox();
                gbox.AutoSize = true;
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

                foreach (var tb in gbox.Controls.OfType<TextBox>())
                {
                    tb.Location = new Point(tb.Location.X + max_lbl_width, tb.Location.Y - 3);
                }

                lbl_coord = 20;
                max_lbl_width = 0;

                flowLayoutPanelMetrics.Controls.Add(gbox);
            }
        }

        private void UpdateSeenPicturesGrid(int cpIndex)
        {
            dataGridViewSeenPics.Columns.Clear();
            dataGridViewSeenPics.DataSource = BuildSeenPicturesTable(cpIndex).DefaultView;

            if (_gameSave.saveVersion >= SaveVersion.LIS_E1)
            {
                dataGridViewSeenPics.Columns[1].FillWeight = 20;
                dataGridViewSeenPics.Columns[2].FillWeight = 20;
                dataGridViewSeenPics.Columns[3].FillWeight = 20;
            }
        }

        private DataTable BuildSeenPicturesTable(int cpIndex)
        {
            DataTable t = new DataTable();
            t.Columns.Add("Name");
            t.Columns.Add("Seen", typeof(bool));
            List<dynamic> names;
            if (cpIndex == 0)
            {
                names = _gameSave.Data["CurrentSubContextSaveData"]
                             .Value["ShowPicturesSaveData"].Value["AllShowPictureIDSeen"].Value;
            }
            else
            {
                names = _gameSave.Data["CheckpointHistory"].Value[cpIndex]
                    ["ShowPicturesSaveData"].Value["AllShowPictureIDSeen"].Value;
            }

            if (_gameSave.saveVersion == SaveVersion.CaptainSpirit)
            {
                foreach (var item in GameInfo.CS_SeenPicturesNames)
                {
                    object[] row = new object[t.Columns.Count];
                    row[0] = item.Key;
                    int index = names.FindIndex(1, x => x["NameGuid"].Value["Guid"] == item.Value);
                    row[1] = (index != -1);
                    t.Rows.Add(row);
                }
            }
            else
            {
                t.Columns.Add("Obtained in CollectibleMode", typeof(bool));
                t.Columns.Add("Is new for SPMenu", typeof(bool));
                object[] row = new object[t.Columns.Count];

                foreach (var item in GameInfo.LIS2_SeenPicturesNames)
                {
                    row[0] = item.Key;
                    int index = names.FindIndex(1, x => x["ShowPictureID"].Value["NameGuid"].Value["Guid"] == item.Value);
                    if (index != -1)
                    {
                        row[1] = true;
                        row[2] = names[index]["bWasCollectedDuringCollectibleMode"].Value;
                        row[3] = names[index]["bIsNewForSPMenu"].Value;
                    }
                    else
                    {
                        row[1] = false;
                        row[2] = false;
                        row[3] = false;
                    }
                    t.Rows.Add(row);
                }
            }
            
            return t;
        }

        private void UpdateCollectiblesGrid(int cpIndex)
        {
            dataGridViewCollectibles.Columns.Clear();
            dataGridViewCollectibles.DataSource = BuildCollectiblesTable(cpIndex).DefaultView;

            if(_gameSave.saveVersion >= SaveVersion.LIS_E1)
            {
                dataGridViewCollectibles.Columns[1].FillWeight = 20;
                dataGridViewCollectibles.Columns[2].FillWeight = 20;
                dataGridViewCollectibles.Columns[3].FillWeight = 20;
            }
        }

        private DataTable BuildCollectiblesTable(int cpIndex)
        {
            DataTable t = new DataTable();
            if (_gameSave.saveVersion == SaveVersion.CaptainSpirit)
            {
                return t;
            }
            t.Columns.Add("Name");
            t.Columns.Add("Slot index");
            t.Columns.Add("Obtained in CollectibleMode", typeof(bool));
            t.Columns.Add("Is new", typeof(bool));

            List<dynamic> collectibles;
            if (cpIndex == 0)
            {
                collectibles = _gameSave.Data["CurrentSubContextSaveData"]
                             .Value["CollectiblesSaveData"].Value["Items"].Value;
            }
            else
            {
                collectibles = _gameSave.Data["CheckpointHistory"].Value[cpIndex]
                    ["CollectiblesSaveData"].Value["Items"].Value;
            }

            collectibles = collectibles.Skip(1).ToList();

            foreach (var item in GameInfo.LIS2_CollectibleNames)
            {
                object[] row = new object[t.Columns.Count];
                row[0] = item.Key;
                var coll = collectibles.Find(x => x["CollectibleGUID"].Value["Guid"] == item.Value);
                if (coll != null)
                {
                    row[1] = coll["EquipedSlotIndex"].Value;
                    row[2] = coll["bWasCollectedDuringCollectibleMode"].Value;
                    row[3] = coll["bIsNew"].Value;
                }
                else
                {
                    row[1] = "";
                    row[2] = false;
                    row[3] = false;
                }
                t.Rows.Add(row);
            }

            return t;
        }

        private void UpdateObjectivesGrid(int cpIndex)
        {
            dataGridViewObjectives.Columns.Clear();
            if (_gameSave.saveVersion == SaveVersion.CaptainSpirit)
            {
                return;
            }

            dataGridViewObjectives.Columns.Add("Name", "Name");

            DataGridViewComboBoxColumn combocol = new DataGridViewComboBoxColumn();
            combocol.Items.AddRange("(none)", "Active", "Done", "Aborted", "Inactive");
            combocol.Name = "State";
            combocol.HeaderText = "State";

            dataGridViewObjectives.Columns.Add(combocol);

            List<dynamic> objectives;
            if (cpIndex == 0)
            {
                objectives = _gameSave.Data["CurrentSubContextSaveData"]
                             .Value["ObjectiveSaveData"].Value["ObjectiveSaveDataItems"].Value;
            }
            else
            {
                objectives = _gameSave.Data["CheckpointHistory"].Value[cpIndex]
                    ["ObjectiveSaveData"].Value["ObjectiveSaveDataItems"].Value;
            }

            objectives = objectives.Skip(1).ToList();

            foreach (var item in GameInfo.LIS2_ObjectiveNames)
            {
                object[] row = new object[dataGridViewObjectives.Columns.Count];
                row[0] = item.Key;
                var obj = objectives.Find(x => x["ObjectiveGUID"].Value["Guid"] == item.Value);
                if (obj != null)
                {
                    row[1] = obj["ObjectiveState"].Value.Replace("ELIS2ObjectiveState::", "");
                }
                else
                {
                    row[1] = "(none)";
                }
                dataGridViewObjectives.Rows.Add(row);
            }

            dataGridViewObjectives.Columns["State"].Width = 120;
        }

        private void UpdateSeenMessagesGrid(int cpIndex)
        {
            dataGridViewSeenMessages.Columns.Clear();
            dataGridViewSeenMessages.DataSource = BuildSeenMessagesTable(cpIndex).DefaultView;

            if(_gameSave.saveVersion >= SaveVersion.LIS_E1)
            {
                dataGridViewSeenMessages.Columns[1].FillWeight = 20;
            }
            
        }

        private DataTable BuildSeenMessagesTable(int cpIndex)
        {
            DataTable t = new DataTable();
            if (_gameSave.saveVersion == SaveVersion.CaptainSpirit)
            {
                return t;
            }
            t.Columns.Add("Name");
            t.Columns.Add("Seen", typeof(bool));

            List<dynamic> messages;
            if (cpIndex == 0)
            {
                messages = _gameSave.Data["CurrentSubContextSaveData"]
                             .Value["PhoneSaveData"].Value["ReadedMessages"].Value;
            }
            else
            {
                messages = _gameSave.Data["CheckpointHistory"].Value[cpIndex]
                    ["PhoneSaveData"].Value["ReadedMessages"].Value;
            }

            foreach (var item in GameInfo.LIS2_SMSNames)
            {
                object[] row = new object[t.Columns.Count];
                row[0] = item.Key;
                var msg = messages.Find(x => x == item.Value);
                if (msg != null)
                {
                    row[1] = true;
                }
                else
                {
                    row[1] = false;
                }
                t.Rows.Add(row);
            }

            return t;
        }

        private void UpdateOutfits(int cpIndex)
        {
            if (_gameSave.saveVersion == SaveVersion.CaptainSpirit)
            {
                return;
            }

            Dictionary<dynamic, dynamic> root;

            if (cpIndex == 0)
            {
                root = _gameSave.Data["CurrentSubContextSaveData"].Value["Outfits"].Value;
            }
            else
            {
                root = _gameSave.Data["CheckpointHistory"].Value[cpIndex]["Outfits"].Value;
            }

            foreach (GroupBox gb in tabPageOutfits.Controls.OfType<GroupBox>())
            {
                ClearGroupBox(gb);
                string owner = gb.Tag.ToString();
                List<dynamic> target;
                if (root.ContainsKey(owner))
                {
                    target = root[owner]["Items"].Value;
                }
                else
                {
                    gb.Enabled = false;
                    continue;
                }

                foreach (Panel pan in gb.Controls.OfType<Panel>())
                {
                    ComboBox cb = (ComboBox)pan.Controls[0];
                    cb.Items.Clear();
                    string[] info = cb.Tag.ToString().Split(new string[] { "::" }, StringSplitOptions.None);
                    cb.Items.Add("(none)");
                    foreach (var obj in GameInfo.LIS2_Outfits.Where(x => x.Owner == info[0]
                                        && (info[1].StartsWith("Collectible_Badge") ? x.Slot == "Collectible_Badge" : x.Slot == info[1])))
                    {
                        cb.Items.Add(obj.Name);
                    }
                    int index = target.FindIndex(1, x => x["Slot"].Value == info[1]);
                    cb.SelectedItem = index == -1 ? "(none)"
                                                  : GameInfo.LIS2_Outfits.Find(x => x.GUID == target[index]["Guid"].Value["Guid"])?.Name
                                                  ?? "(none)";
                }
            }
        }

        private void GenerateCinematics()
        {
            tabPageCinematics.Controls.Clear();

            Dictionary<dynamic, dynamic> root = _gameSave.Data["CinematicHistorySaveData"].Value["SubcontextCinematicHistorySaveData"].Value;

            if (_gameSave.saveVersion == SaveVersion.CaptainSpirit)
            {
                int cb_x = 3, cb_y = 3, i = 0;
                List<dynamic> save_cin_list = ((List<dynamic>)root["PT"]["PlayedCinematics"].Value).Skip(1).ToList();
                int max_length = 0;
                
                foreach (var l in GameInfo.CS_Cinematics.Select(x => x.Name))
                {
                    if (l.Length > max_length) max_length = l.Length;
                }

                max_length *= 6;
                
                foreach (var cin in GameInfo.CS_Cinematics)
                {
                    var cb_active = new CheckBox();
                    cb_active.AutoSize = false;
                    cb_active.Size = new Size(max_length, 17);
                    cb_active.Location = new Point(cb_x, cb_y);
                    cb_active.Text = string.IsNullOrEmpty(cin.Name) ? cin.GUID.ToString() : cin.Name;
                    dynamic save_cin = save_cin_list.Find(x => x["Guid"] == cin.GUID);
                    cb_active.Checked = save_cin != null;
                    cb_active.Tag = "PT::" + cin.GUID.ToString();
                    cb_active.CheckedChanged += new EventHandler(checkBoxCinematicActive_CheckedChanged);
                    tabPageCinematics.Controls.Add(cb_active);

                    i++;

                    if (i % 3 == 0)
                    {
                        cb_x = 0;
                        cb_y += 20;
                    }
                    else
                    {
                        cb_x += max_length;
                    }
                    
                }
            }
            else
            {
                int cb_y = 20, gbox_y = 20, subc_gbox_x = 3;
                List<string> subs = GameInfo.LIS2_Cinematics.Select(c => c.SubcontextID).Distinct().ToList();
                foreach (var sub_id in subs)
                {
                    var gbox = new GroupBox();
                    gbox.AutoSize = true;
                    gbox.AutoSizeMode = AutoSizeMode.GrowOnly;
                    gbox.Text = sub_id;
                    gbox.Location = new Point(subc_gbox_x, 3);

                    //size crutch
                    var text_lbl = new Label();
                    text_lbl.AutoSize = true;
                    text_lbl.Text = gbox.Text;
                    text_lbl.Visible = false;
                    text_lbl.Enabled = false;
                    gbox.Controls.Add(text_lbl);
                    gbox.MinimumSize = new Size(text_lbl.Width + 20, 20);

                    List<dynamic> save_cin_list = root.ContainsKey(sub_id) ? ((List<dynamic>)root[sub_id]["PlayedCinematics"].Value).Skip(1).ToList() : new List<dynamic>();
                    foreach (var cin in GameInfo.LIS2_Cinematics.Where(x => x.SubcontextID == sub_id))
                    {
                        var gbox_cin = new GroupBox();
                        gbox_cin.AutoSize = true;
                        gbox_cin.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                        gbox_cin.Location = new Point(3, gbox_y);
                        gbox_cin.Text = string.IsNullOrEmpty(cin.Name) ? cin.GUID.ToString() : cin.Name;

                        //size crutch
                        var text_lbl_cin = new Label();
                        text_lbl_cin.AutoSize = true;
                        text_lbl_cin.Text = gbox_cin.Text;
                        text_lbl_cin.Visible = false;
                        text_lbl_cin.Enabled = false;
                        gbox_cin.Controls.Add(text_lbl_cin);
                        gbox_cin.MinimumSize = new Size(text_lbl_cin.Width + 20, 20);

                        var cb_active = new CheckBox();
                        cb_active.AutoSize = true;
                        cb_active.Name = "Active";
                        cb_active.Text = "Active";
                        cb_active.Location = new Point(10, cb_y);
                        dynamic save_cin = save_cin_list.Find(x => x["Key"].Value["Guid"] == cin.GUID);
                        cb_active.Checked = save_cin != null;
                        cb_active.Tag = sub_id + "::" + cin.GUID.ToString();
                        cb_active.CheckedChanged += new EventHandler(checkBoxCinematicActive_CheckedChanged);
                        gbox_cin.Controls.Add(cb_active);
                        cb_y += 26;

                        List<dynamic> save_cond_list = save_cin != null ? ((List<dynamic>)save_cin["Value"].Value["Conditions"].Value).Skip(1).ToList() : new List<dynamic>();
                        foreach (var cond in cin.Conditions)
                        {
                            var cb = new CheckBox();
                            cb.AutoSize = true;
                            cb.Text = cond;
                            cb.Location = new Point(10, cb_y);
                            cb.ThreeState = true;
                            dynamic save_cond = save_cond_list.Find(x => x["Key"].Value["Guid"].ToString() == cond);
                            cb.CheckState = save_cond != null ? save_cond["Value"].Value == true ? CheckState.Checked : CheckState.Indeterminate : CheckState.Unchecked;
                            cb.Tag = sub_id + "::" + cin.GUID.ToString() + "::" + cond;
                            cb.CheckStateChanged += new EventHandler(checkBoxCinematicCondition_CheckStateChanged);
                            gbox_cin.Controls.Add(cb);
                            cb_y += 26;
                        }
                        gbox.Controls.Add(gbox_cin);
                        gbox_y += gbox_cin.Height + 10;
                        cb_y = 20;
                    }
                    tabPageCinematics.Controls.Add(gbox);
                    gbox_y = 20;

                    subc_gbox_x += gbox.Width + 20;
                }
            }
        }

        #endregion

        private void dataGridViewFacts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if (e.ColumnIndex == 1)
            {
                var editForm = new FactEditForm();
                var cpIndex = comboBoxSelectCP.SelectedIndex;
                string assetId = dataGridViewFacts[0, e.RowIndex].Value.ToString();
                if (cpIndex == 0)
                {
                    editForm.asset = _gameSave.Data["CurrentSubContextSaveData"].Value["FactsSaveData"].Value[assetId];
                }
                else
                {
                    editForm.asset = _gameSave.Data["CheckpointHistory"].Value[cpIndex]["FactsSaveData"].Value[assetId];
                }
                editForm.saveVersion = _gameSave.saveVersion;
                editForm.ShowDialog();
                if (editForm.changesMade)
                {
                    _editedControls.AddUnique(dataGridViewFacts[0, e.RowIndex]);
                    dataGridViewFacts[0, e.RowIndex].Style.BackColor = Color.LightGoldenrodYellow;
                    ShowChangesWarning();
                }
            }
        }

        private void dataGridViewLevels_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if (e.ColumnIndex == 1)
            {
                var levelForm = new LevelEditForm();
                var cpIndex = comboBoxSelectCP.SelectedIndex;
                if (cpIndex == 0)
                {
                    levelForm.level = _gameSave.Data["CurrentSubContextSaveData"].Value["LevelsSaveData"].Value[e.RowIndex + 1];
                }
                else
                {
                    levelForm.level = _gameSave.Data["CheckpointHistory"].Value[cpIndex]["LevelsSaveData"].Value[e.RowIndex + 1];
                }
                levelForm.saveVersion = _gameSave.saveVersion;
                levelForm.ShowDialog();
                if (levelForm.changesMade)
                {
                    _editedControls.AddUnique(dataGridViewLevels[0, e.RowIndex]);
                    dataGridViewLevels[0, e.RowIndex].Style.BackColor = Color.LightGoldenrodYellow;
                    ShowChangesWarning();
                }
            }
        }

        #region Edit functions
        private void comboBoxCPName_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!SaveLoading)
            {
                int cpIndex = comboBoxSelectCP.SelectedIndex;
                if (_gameSave.saveVersion == SaveVersion.CaptainSpirit)
                {
                    _gameSave.Data["CheckpointName"].Value = comboBoxCPName.SelectedItem.ToString();
                }
                else if (cpIndex == 0)
                {
                    _gameSave.Data["CurrentSubContextSaveData"].Value["CheckpointName"].Value = comboBoxCPName.SelectedItem.ToString();
                }
                else
                {
                    _gameSave.Data["CheckpointHistory"].Value[cpIndex]["CheckpointName"].Value = comboBoxCPName.SelectedItem.ToString();
                }

                _editedControls.AddUnique(panelCPName);
                panelCPName.BackColor = Color.LightGoldenrodYellow;
                ShowChangesWarning();
            } 
        }

        private void comboBoxEPName_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!SaveLoading)
            {
                _gameSave.Data["HeaderSaveData"].Value["EpisodeName"].Value[1] = _gameSave.Data["HeaderSaveData"]
                .Value["EpisodeName"].Value[1].Substring(0, 22) + (comboBoxHeader_EPName.SelectedIndex + 1).ToString();

                _editedControls.AddUnique(panelEpName);
                panelEpName.BackColor = Color.LightGoldenrodYellow;
                ShowChangesWarning();
            }
        }

        private void comboBoxEPNumber_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!SaveLoading)
            {
                _gameSave.Data["HeaderSaveData"].Value["EpisodeNumber"].Value = comboBoxHeader_EPNumber.SelectedIndex + 1;

                _editedControls.AddUnique(panelEpNumber);
                panelEpNumber.BackColor = Color.LightGoldenrodYellow;
                ShowChangesWarning();
            }
        }

        private void comboBoxSubContextName_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!SaveLoading)
            {
                if (comboBoxHeader_SubContextName.SelectedIndex == 0)
                {
                    _gameSave.Data["HeaderSaveData"].Value["SubContextName"].Value = new string[0];
                    if (_gameSave.saveVersion >= SaveVersion.LIS_E2)
                    {
                        _gameSave.Data["HeaderSaveData"].Value["SubContextId"].Value = "None";
                    }
                    
                }
                else
                {
                    var subname = GameInfo.LIS2_SubContextNames.ElementAt(comboBoxHeader_SubContextName.SelectedIndex).Key;
                    var epnum = subname[1];
                    _gameSave.Data["HeaderSaveData"].Value["SubContextName"].Value = new string[2]
                    {
                    string.Format("/Game/Localization/LocalizationAssets/E{0}/E{0}_Subcontexts.E{0}_Subcontexts", epnum),
                    subname
                    };
                    if (_gameSave.saveVersion >= SaveVersion.LIS_E2)
                    {
                        string subID = subname.Remove(0, 19);
                        if (subID == "E2_2A") subID = "E2_1A";
                        else if (subID == "E2_5C_01") subID = "E2_5C";
                        _gameSave.Data["HeaderSaveData"].Value["SubContextId"].Value = subID;
                    }
                }

                _editedControls.AddUnique(panelSubContextName);
                panelSubContextName.BackColor = Color.LightGoldenrodYellow;
                ShowChangesWarning();
            }
        }

        private void checkBoxGameStarted_CheckedChanged(object sender, EventArgs e)
        {
            if (!SaveLoading)
            {
                _gameSave.Data["HeaderSaveData"].Value["bGameStarted"].Value = checkBoxGameStarted.Checked;

                _editedControls.AddUnique(checkBoxGameStarted);
                checkBoxGameStarted.BackColor = Color.LightGoldenrodYellow;
                ShowChangesWarning();
            }
        }

        private void comboBoxHeader_CheckpointName_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!SaveLoading)
            {
                int cpIndex = comboBoxSelectCP.SelectedIndex;
                if (_gameSave.saveVersion < SaveVersion.LIS_E2)
                {
                    throw new Exception("This should not happen");
                }

                _gameSave.Data["HeaderSaveData"].Value["CheckpointName"].Value = comboBoxHeader_CheckpointName.SelectedItem.ToString();

                _editedControls.AddUnique(panelHeaderCheckpointName);
                panelHeaderCheckpointName.BackColor = Color.LightGoldenrodYellow;
                ShowChangesWarning();
            }
        }

        private void textBoxMapName_TextChanged(object sender, EventArgs e)
        {
            if (!SaveLoading)
            {
                _gameSave.Data["MapName"].Value = textBoxMapName.Text;

                _editedControls.AddUnique(textBoxMapName);
                textBoxMapName.BackColor = Color.LightGoldenrodYellow;
                ShowChangesWarning();
            }
        }

        private void textBoxSubContextID_TextChanged(object sender, EventArgs e)
        {    
            if (!SaveLoading)
            {
                int cpIndex = comboBoxSelectCP.SelectedIndex;
                if (cpIndex == 0)
                {
                    _gameSave.Data["CurrentSubContextSaveData"].Value["SubContextId"].Value = textBoxSubContextID.Text;
                }
                else
                {
                    _gameSave.Data["CheckpointHistory"].Value[cpIndex]["SubContextId"].Value = textBoxSubContextID.Text;
                }

                _editedControls.AddUnique(textBoxSubContextID);
                textBoxSubContextID.BackColor = Color.LightGoldenrodYellow;
                ShowChangesWarning();
            }
        }

        private void textBoxSubContextPath_TextChanged(object sender, EventArgs e)
        {
            if (!SaveLoading)
            {
                _gameSave.Data["CurrentSubContextPathName"].Value = textBoxSubContextPath.Text;

                _editedControls.AddUnique(textBoxSubContextPath);
                textBoxSubContextPath.BackColor = Color.LightGoldenrodYellow;
                ShowChangesWarning();
            }
        }

        private void dateTimePickerSaveTime_ValueChanged(object sender, EventArgs e)
        {
            if (!SaveLoading)
            {
                _gameSave.Data["SaveTime"].Value["DateTime"] = dateTimePickerSaveTime.Value;

                _editedControls.AddUnique(panelSaveTime);
                panelSaveTime.BackColor = Color.LightGoldenrodYellow;
                ShowChangesWarning();
            }
        }

        private void dateTimePickerCSSaveTime_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker dtp = (DateTimePicker)sender;
            if (!SaveLoading)
            {
                _gameSave.Data["CaptainSpiritImportSaveData"].Value[$"{dtp.Tag.ToString()}CaptainSpiritSaveTime"].Value["DateTime"] = dtp.Value;

                _editedControls.AddUnique(dtp.Parent);
                dtp.Parent.BackColor = Color.LightGoldenrodYellow;
                ShowChangesWarning();
            }
        }

        private void textBoxPosition_TextChanged(object sender, EventArgs e)
        {
            if (!SaveLoading)
            {
                var tb = (TextBox)sender;
                //e.g Player::Rotation::X
                string[] info = tb.Tag.ToString().Split(new string[] { "::" }, 3, StringSplitOptions.RemoveEmptyEntries);
                float value = 0;
                try
                {
                    value = Convert.ToSingle(tb.Text);
                    tb.BackColor = Color.LightGoldenrodYellow;
                    _editedControls.AddUnique(tb);
                }
                catch
                {
                    tb.BackColor = Color.Red;
                }

                string dataType = (info[1] == "Rotation") ? "Quat" : "Vector";
                int cpIndex = comboBoxSelectCP.SelectedIndex;
                if (cpIndex == 0)
                {
                    switch (info[2])
                    {
                        case "X":
                            {
                                _gameSave.Data["CurrentSubContextSaveData"].Value[info[0] + "SaveData"]
                                .Value["RespawnTransform"].Value[info[1]].Value[dataType].X = value;
                                break;
                            }
                        case "Y":
                            {
                                _gameSave.Data["CurrentSubContextSaveData"].Value[info[0] + "SaveData"]
                                .Value["RespawnTransform"].Value[info[1]].Value[dataType].Y = value;
                                break;
                            }
                        case "Z":
                            {
                                _gameSave.Data["CurrentSubContextSaveData"].Value[info[0] + "SaveData"]
                                .Value["RespawnTransform"].Value[info[1]].Value[dataType].Z = value;
                                break;
                            }
                        case "W":
                            {
                                _gameSave.Data["CurrentSubContextSaveData"].Value[info[0] + "SaveData"]
                                .Value["RespawnTransform"].Value[info[1]].Value[dataType].W = value;
                                break;
                            }
                    }
                }
                else
                {
                    switch (info[2])
                    {
                        case "X":
                            {
                                _gameSave.Data["CheckpointHistory"].Value[cpIndex][info[0] + "SaveData"]
                                .Value["RespawnTransform"].Value[info[1]].Value[dataType].X = value;
                                break;
                            }
                        case "Y":
                            {
                                _gameSave.Data["CheckpointHistory"].Value[cpIndex][info[0] + "SaveData"]
                                .Value["RespawnTransform"].Value[info[1]].Value[dataType].Y = value;
                                break;
                            }
                        case "Z":
                            {
                                _gameSave.Data["CheckpointHistory"].Value[cpIndex][info[0] + "SaveData"]
                                .Value["RespawnTransform"].Value[info[1]].Value[dataType].Z = value;
                                break;
                            }
                        case "W":
                            {
                                _gameSave.Data["CheckpointHistory"].Value[cpIndex][info[0] + "SaveData"]
                                .Value["RespawnTransform"].Value[info[1]].Value[dataType].W = value;
                                break;
                            }
                    }
                }

                ShowChangesWarning();
            }
        }

        private void comboBoxPlayerDisplacementMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!SaveLoading)
            {
                dynamic root;
                var value = comboBoxPlayerDisplacementMode.SelectedItem.ToString();
                if (comboBoxSelectCP.SelectedIndex == 0)
                {
                    root = _gameSave.Data["CurrentSubContextSaveData"].Value["PlayerSaveData"].Value;
                }
                else
                {
                    root = _gameSave.Data["CheckpointHistory"].Value[comboBoxSelectCP.SelectedIndex]["PlayerSaveData"].Value;
                }

                if (comboBoxPlayerDisplacementMode.SelectedIndex > 2)
                {
                    root["PlayerControllerCustomDisplacementModeId"].Value = value;
                    root["PlayerControllerDisplacementMode"].Value = "ELIS2DisplacementMode::CustomMode";
                }
                else
                {
                    root["PlayerControllerCustomDisplacementModeId"].Value = "None";
                    root["PlayerControllerDisplacementMode"].Value = "ELIS2DisplacementMode::" + value;
                }

                _editedControls.AddUnique(panelPlayerDisplacementMode);
                panelPlayerDisplacementMode.BackColor = Color.LightGoldenrodYellow;
                ShowChangesWarning();
            }
        }

        private void checkBoxPlayerTransformValid_CheckedChanged(object sender, EventArgs e)
        {
            if (!SaveLoading)
            {
                bool value = checkBoxPlayerTransformValid.Checked;
                if (comboBoxSelectCP.SelectedIndex == 0)
                {
                    _gameSave.Data["CurrentSubContextSaveData"].Value["PlayerSaveData"].Value["bRespawnTransformValid"].Value = value;
                }
                else
                {
                    _gameSave.Data["CheckpointHistory"].Value[comboBoxSelectCP.SelectedIndex]["PlayerSaveData"].Value["bRespawnTransformValid"].Value = value;
                }

                _editedControls.AddUnique(checkBoxPlayerTransformValid);
                checkBoxPlayerTransformValid.BackColor = Color.LightGoldenrodYellow;
                ShowChangesWarning();
            }
        }

        private void checkBoxPlayerDistanceCuesPaused_CheckedChanged(object sender, EventArgs e)
        {
            if (!SaveLoading)
            {
                bool value = checkBoxPlayerDistanceCuesPaused.Checked;
                if (comboBoxSelectCP.SelectedIndex == 0)
                {
                    _gameSave.Data["CurrentSubContextSaveData"].Value["PlayerSaveData"].Value["bDistanceCuesPaused"].Value = value;
                }
                else
                {
                    _gameSave.Data["CheckpointHistory"].Value[comboBoxSelectCP.SelectedIndex]["PlayerSaveData"].Value["bDistanceCuesPaused"].Value = value;
                }

                _editedControls.AddUnique(checkBoxPlayerDistanceCuesPaused);
                checkBoxPlayerDistanceCuesPaused.BackColor = Color.LightGoldenrodYellow;
                ShowChangesWarning();
            }
        }

        private void checkBoxDanielTransformValid_CheckedChanged(object sender, EventArgs e)
        {
            if (!SaveLoading)
            {
                bool value = checkBoxDanielTransformValid.Checked;
                if (comboBoxSelectCP.SelectedIndex == 0)
                {
                    _gameSave.Data["CurrentSubContextSaveData"].Value["BrotherAISaveData"].Value["bRespawnTransformValid"].Value = value;
                }
                else
                {
                    _gameSave.Data["CheckpointHistory"].Value[comboBoxSelectCP.SelectedIndex]["BrotherAISaveData"].Value["bRespawnTransformValid"].Value = value;
                }

                _editedControls.AddUnique(checkBoxDanielTransformValid);
                checkBoxDanielTransformValid.BackColor = Color.LightGoldenrodYellow;
                ShowChangesWarning();
            }
        }

        private void checkBoxLockedDiary_CheckedChanged(object sender, EventArgs e)
        {
            if (!SaveLoading)
            {
                bool value = checkBoxLockedDiary.Checked;
                if (comboBoxSelectCP.SelectedIndex == 0)
                {
                    _gameSave.Data["CurrentSubContextSaveData"].Value["PlayerSaveData"].Value["bPlayerControllerLockedDiary"].Value = value;
                }
                else
                {
                    _gameSave.Data["CheckpointHistory"].Value[comboBoxSelectCP.SelectedIndex]["PlayerSaveData"].Value["bPlayerControllerLockedDiary"].Value = value;
                }

                _editedControls.AddUnique(checkBoxLockedDiary);
                checkBoxLockedDiary.BackColor = Color.LightGoldenrodYellow;
                ShowChangesWarning();
            }

        }

        private void checkBoxVoicePaused_CheckedChanged(object sender, EventArgs e)
        {
            if (!SaveLoading)
            {
                bool value = checkBoxVoicePaused.Checked;
                if (comboBoxSelectCP.SelectedIndex == 0)
                {
                    _gameSave.Data["CurrentSubContextSaveData"].Value["PlayerSaveData"].Value["bInnerVoiceComponentPaused"].Value = value;
                }
                else
                {
                    _gameSave.Data["CheckpointHistory"].Value[comboBoxSelectCP.SelectedIndex]["PlayerSaveData"].Value["bInnerVoiceComponentPaused"].Value = value;
                }

                _editedControls.AddUnique(checkBoxVoicePaused);
                checkBoxVoicePaused.BackColor = Color.LightGoldenrodYellow;
                ShowChangesWarning();
            }
        }

        private void comboBoxDanielAIState_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!SaveLoading)
            {
                var value = comboBoxDanielAIState.SelectedItem.ToString();
                if (comboBoxSelectCP.SelectedIndex == 0)
                {
                    _gameSave.Data["CurrentSubContextSaveData"].Value["BrotherAISaveData"]
                             .Value["AIState"].Value = "ELIS2AIState::" + value;
                }
                else
                {
                    _gameSave.Data["CheckpointHistory"].Value[comboBoxSelectCP.SelectedIndex]["BrotherAISaveData"]
                             .Value["AIState"].Value = "ELIS2AIState::" + value;
                }

                _editedControls.AddUnique(panelDanielAIState);
                panelDanielAIState.BackColor = Color.LightGoldenrodYellow;
                ShowChangesWarning();
            }
        }

        private void comboBoxDanielPOI_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!SaveLoading)
            {
                var value = comboBoxDanielPOI.SelectedItem.ToString();
                if (comboBoxSelectCP.SelectedIndex == 0)
                {
                    _gameSave.Data["CurrentSubContextSaveData"].Value["BrotherAISaveData"]
                             .Value["PointOfInterestInProgress"].Value = value;
                }
                else
                {
                    _gameSave.Data["CheckpointHistory"].Value[comboBoxSelectCP.SelectedIndex]["BrotherAISaveData"]
                             .Value["PointOfInterestInProgress"].Value = value;
                }

                _editedControls.AddUnique(panelDanielPOI);
                panelDanielPOI.BackColor = Color.LightGoldenrodYellow;
                ShowChangesWarning();
            }
        }

        private void comboBoxDanielAIPreset_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!SaveLoading)
            {
                var value = comboBoxDanielAIPreset.SelectedItem.ToString();
                if (comboBoxSelectCP.SelectedIndex == 0)
                {
                    _gameSave.Data["CurrentSubContextSaveData"].Value["BrotherAISaveData"]
                             .Value["AIDataPresetName"].Value = value;
                }
                else
                {
                    _gameSave.Data["CheckpointHistory"].Value[comboBoxSelectCP.SelectedIndex]["BrotherAISaveData"]
                             .Value["AIDataPresetName"].Value = value;
                }

                _editedControls.AddUnique(panelDanielAIPreset);
                panelDanielAIPreset.BackColor = Color.LightGoldenrodYellow;
                ShowChangesWarning();
            }
        }

        private void textBoxAICallDelay_TextChanged(object sender, EventArgs e)
        {
            if (!SaveLoading)
            {
                float value;
                if (!float.TryParse(textBoxAICallDelay.Text, out value))
                {
                    value = 0;
                    textBoxAICallDelay.BackColor = Color.Red;
                }
                else
                {
                    textBoxAICallDelay.BackColor = Color.LightGoldenrodYellow;
                    _editedControls.AddUnique(textBoxAICallDelay);
                }

                if (comboBoxSelectCP.SelectedIndex == 0)
                {
                    _gameSave.Data["CurrentSubContextSaveData"].Value["CallAISaveData"].Value["DelayBetweenCalls"].Value = value;
                }
                else
                {
                    _gameSave.Data["CheckpointHistory"].Value[comboBoxSelectCP.SelectedIndex]["CallAISaveData"].Value["DelayBetweenCalls"].Value = value;
                }

                ShowChangesWarning();
            }
        }

        private void checkBoxAICallGlobalEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (!SaveLoading)
            {
                bool value = checkBoxAICallGlobalEnable.Checked;
                if (comboBoxSelectCP.SelectedIndex == 0)
                {
                    _gameSave.Data["CurrentSubContextSaveData"].Value["CallAISaveData"].Value["bIsCallAIBehaviourEnable"].Value = value;
                }
                else
                {
                    _gameSave.Data["CheckpointHistory"].Value[comboBoxSelectCP.SelectedIndex]["CallAISaveData"].Value["bIsCallAIBehaviourEnable"].Value = value;
                }

                checkBoxAICallGlobalEnable.BackColor = Color.LightGoldenrodYellow;
                _editedControls.AddUnique(checkBoxAICallGlobalEnable);
                ShowChangesWarning();
            }
        }

        private void checkBoxAICallFocusFail_CheckedChanged(object sender, EventArgs e)
        {
            if (!SaveLoading)
            {
                bool value = checkBoxAICallFocusFail.Checked;
                if (comboBoxSelectCP.SelectedIndex == 0)
                {
                    _gameSave.Data["CurrentSubContextSaveData"].Value["CallAISaveData"].Value["bIsFocusFailNecessaryToCall"].Value = value;
                }
                else
                {
                    _gameSave.Data["CheckpointHistory"].Value[comboBoxSelectCP.SelectedIndex]["CallAISaveData"].Value["bIsFocusFailNecessaryToCall"].Value = value;
                }

                checkBoxAICallFocusFail.BackColor = Color.LightGoldenrodYellow;
                _editedControls.AddUnique(checkBoxAICallFocusFail);
                ShowChangesWarning();
            }
        }

        private void checkBoxAICall_CheckStateChanged(object sender, EventArgs e)
        {
            if (!SaveLoading)
            {
                CheckBox cb = (CheckBox)sender;
                List<dynamic> root;
                var name = cb.Tag.ToString();
                if (comboBoxSelectCP.SelectedIndex == 0)
                {
                    root = _gameSave.Data["CurrentSubContextSaveData"].Value["CallAISaveData"].Value["CallAIItems"].Value;
                }
                else
                {
                    root = _gameSave.Data["CheckpointHistory"].Value[comboBoxSelectCP.SelectedIndex]["CallAISaveData"].Value["CallAIItems"].Value;
                }
                int index = root.FindIndex(1, x => x["AIToCall"].Value == "ELIS2AIBuddy::" + name);

                if (cb.CheckState == CheckState.Unchecked) //remove
                {
                    root.RemoveAt(index);
                }
                else //edit existing
                {
                    if (index == -1) //Add new
                    {
                        Dictionary<string, dynamic> new_item = new Dictionary<string, dynamic>()
                        {
                            { "AIToCall", new EnumProperty()
                                {
                                    Name = "AIToCall",
                                    ElementType = "ELIS2AIBuddy",
                                    Value = "ELIS2AIBuddy::" + name
                                }
                            },
                            { "bEnable", new BoolProperty()
                                {
                                    Name = "bEnable",
                                    Value = false
                                }
                            }
                        };
                        root.AddUnique(new_item);
                        index = root.Count - 1;
                    }

                    root[index]["bEnable"].Value = cb.CheckState == CheckState.Checked;
                }

                cb.BackColor = Color.LightGoldenrodYellow;
                _editedControls.AddUnique(cb);
                ShowChangesWarning();
            }
        }

        private void checkBoxEpComplete_CheckedChanged(object sender, EventArgs e)
        {
            if (!SaveLoading)
            {
                CheckBox cb = (CheckBox)sender;
                int index = Convert.ToInt32(cb.Tag);
                _gameSave.Data["StatsSaveData"].Value["EpisodeCompletion"].Value[index] = cb.Checked;

                cb.BackColor = Color.LightGoldenrodYellow;
                _editedControls.AddUnique(cb);
                ShowChangesWarning();
            }
        }

        private void checkBoxMetaInvSeenSubcontexts_CheckedChanged(object sender, EventArgs e)
        {
            if (!SaveLoading)
            {
                CheckBox cb = (CheckBox)sender;
                int cpIndex = comboBoxSelectCP.SelectedIndex;

                List<dynamic> root;

                if (cpIndex == 0)
                {
                    root = _gameSave.Data["CurrentSubContextSaveData"].Value["MetaInventoryMapSaveData"].Value["SeenSubcontexts"].Value;
                }
                else
                {
                    root = _gameSave.Data["CheckpointHistory"].Value[cpIndex]["MetaInventoryMapSaveData"].Value["SeenSubcontexts"].Value;
                }

                if (cb.Checked)
                {
                    root.AddUnique(cb.Tag.ToString());
                }
                else
                {
                    root.Remove(cb.Tag.ToString());
                }

                cb.BackColor = Color.LightGoldenrodYellow;
                _editedControls.AddUnique(cb);
                ShowChangesWarning();
            }
        }

        private void checkBoxMetaInvTutoStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (!SaveLoading)
            {
                CheckBox cb = (CheckBox)sender;
                int cpIndex = comboBoxSelectCP.SelectedIndex;

                Dictionary<dynamic, dynamic> root;

                if (cpIndex == 0)
                {
                    root = _gameSave.Data["CurrentSubContextSaveData"].Value["PlayerSaveData"]
                           .Value["MetaInventoryTutorialSaveData"].Value["PageTutorialStatusMap"].Value;
                }
                else
                {
                    root = _gameSave.Data["CheckpointHistory"].Value[cpIndex]["PlayerSaveData"]
                           .Value["MetaInventoryTutorialSaveData"].Value["PageTutorialStatusMap"].Value;
                }

                root["ELIS2MetaInventoryPageType::" + cb.Text] = cb.Checked;

                cb.BackColor = Color.LightGoldenrodYellow;
                _editedControls.AddUnique(cb);
                ShowChangesWarning();
            }
        }

        private void dataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            var grid = ((DataGridView)sender);
            if (grid.Rows[e.RowIndex].IsNewRow ^ e.ColumnIndex == 0)
            {
                e.Cancel = true;
                return;
            }
            origCellValue = grid[e.ColumnIndex, e.RowIndex].Value;
        }

        object origCellValue, newCellValue;

        private void dataGridViewInventory_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            string[] info = grid.Tag.ToString().Split(new string[] { "::" }, 2, StringSplitOptions.None);

            switch (e.ColumnIndex)
            {
                case 0: return;
                case 1:
                case 3:
                    {
                        newCellValue = grid[e.ColumnIndex, e.RowIndex].Value;
                        break;
                    }
                case 2:
                    {
                        int result;
                        if (!int.TryParse(grid[2, e.RowIndex].Value.ToString(), out result))
                        {
                            MessageBox.Show(Resources.BadValueMessage, "Error");
                            newCellValue = origCellValue;
                            grid[e.ColumnIndex, e.RowIndex].Value = origCellValue;
                        }
                        else
                        {
                            newCellValue = result;
                        }
                        break;
                    }
            }

            if (newCellValue.ToString() != origCellValue.ToString())
            {
                var item_name = grid[0, e.RowIndex].Value.ToString();
                _gameSave.EditInventoryItem(info[0], item_name, info[1], comboBoxSelectCP.SelectedIndex, e.ColumnIndex, Convert.ToInt32(newCellValue));

                if (e.ColumnIndex == 1 ^ Convert.ToBoolean(grid[1, e.RowIndex].Value) == false)
                {
                    grid[1, e.RowIndex].Value = true;
                    _gameSave.EditInventoryItem(info[0], item_name, info[1], comboBoxSelectCP.SelectedIndex, 2, Convert.ToInt32(grid[2, e.RowIndex].Value));
                    if (_gameSave.saveVersion >= SaveVersion.LIS_E1)
                    {
                        _gameSave.EditInventoryItem(info[0], item_name, info[1], comboBoxSelectCP.SelectedIndex, 3, Convert.ToInt32(grid[3, e.RowIndex].Value));
                    }
                }
                _editedControls.AddUnique(grid[e.ColumnIndex, e.RowIndex]);
                grid[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.LightGoldenrodYellow;
                ShowChangesWarning();
            }
        }

        private void dataGridViewSeenNotifs_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            newCellValue = dataGridViewSeenNotifs[e.ColumnIndex, e.RowIndex].Value;

            if (newCellValue.ToString() != origCellValue.ToString())
            {
                var name = dataGridViewSeenNotifs[0, e.RowIndex].Value.ToString();
                _gameSave.EditSeenNotification(name, comboBoxSelectCP.SelectedIndex, Convert.ToBoolean(newCellValue));
                _editedControls.AddUnique(dataGridViewSeenNotifs[e.ColumnIndex, e.RowIndex]);
                dataGridViewSeenNotifs[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.LightGoldenrodYellow;
                ShowChangesWarning();
            }
        }

        private void dataGridViewSeenTutos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var value = dataGridViewSeenTutos[e.ColumnIndex, e.RowIndex].Value;
            int result;
            if (e.ColumnIndex == 1)
            {
                newCellValue = value;
            }
            else
            {
                if (!int.TryParse(value.ToString(), out result))
                {
                    MessageBox.Show(Resources.BadValueMessage, "Error");
                    newCellValue = origCellValue;
                    dataGridViewSeenTutos[e.ColumnIndex, e.RowIndex].Value = origCellValue;
                }
                else
                {
                    newCellValue = result;
                }
            }

            if (newCellValue.ToString() != origCellValue.ToString())
            {
                var name = dataGridViewSeenTutos[0, e.RowIndex].Value.ToString();
                _gameSave.EditSeenTutorial(name, comboBoxSelectCP.SelectedIndex, e.ColumnIndex, Convert.ToInt32(newCellValue));

                if (e.ColumnIndex == 1 ^ Convert.ToBoolean(dataGridViewSeenTutos[1, e.RowIndex].Value) == false)
                {
                    dataGridViewSeenTutos[1, e.RowIndex].Value = true;
                    _gameSave.EditSeenTutorial(name, comboBoxSelectCP.SelectedIndex, 2, Convert.ToInt32(dataGridViewSeenTutos[2, e.RowIndex].Value));
                }

                _editedControls.AddUnique(dataGridViewSeenTutos[e.ColumnIndex, e.RowIndex]);
                dataGridViewSeenTutos[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.LightGoldenrodYellow;
                ShowChangesWarning();
            }
        }

        private void dataGridViewFacts_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var name = dataGridViewFacts[0, e.RowIndex].Value.ToString();
            newCellValue = dataGridViewFacts[e.ColumnIndex, e.RowIndex].Value;
            if (newCellValue.ToString() != origCellValue.ToString())
            {
                int cpIndex = comboBoxSelectCP.SelectedIndex;
                if (cpIndex == 0)
                {
                    _gameSave.Data["CurrentSubContextSaveData"].Value["FactsSaveData"]
                             .Value[name]["bKeepFactValuesOnSaveReset"].Value = Convert.ToBoolean(newCellValue);
                }
                else
                {
                    _gameSave.Data["CheckpointHistory"].Value[cpIndex]["FactsSaveData"]
                             .Value[name]["bKeepFactValuesOnSaveReset"].Value = Convert.ToBoolean(newCellValue);
                }
                
                _editedControls.AddUnique(dataGridViewFacts[e.ColumnIndex, e.RowIndex]);
                dataGridViewFacts[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.LightGoldenrodYellow;
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
                if (_gameSave.saveVersion == SaveVersion.CaptainSpirit)
                {
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
                }
                else
                {
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
                                property = "bHasLoadedLevel";
                                break;
                            }
                        case 4:
                            {
                                property = "bIsVisible";
                                break;
                            }
                        case 5:
                            {
                                property = "bIsRequestingUnloadAndRemoval";
                                break;
                            }
                    }
                }

                _gameSave.EditPackageProperty(name, comboBoxSelectCP.SelectedIndex, property, Convert.ToBoolean(newCellValue));
                _editedControls.AddUnique(dataGridViewWorld[e.ColumnIndex, e.RowIndex]);
                dataGridViewWorld[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.LightGoldenrodYellow;
                ShowChangesWarning();
            }
        }

        private void dataGridViewSeenPics_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            newCellValue = dataGridViewSeenPics[e.ColumnIndex, e.RowIndex].Value;

            if (newCellValue.ToString() != origCellValue.ToString())
            {
                var name = dataGridViewSeenPics[0, e.RowIndex].Value.ToString();
                _gameSave.EditSeenPicture(name, comboBoxSelectCP.SelectedIndex, e.ColumnIndex, Convert.ToBoolean(newCellValue));

                if (_gameSave.saveVersion >= SaveVersion.LIS_E1)
                {
                    if (e.ColumnIndex == 1 ^ Convert.ToBoolean(dataGridViewSeenPics[1, e.RowIndex].Value) == false)
                    {
                        dataGridViewSeenPics[1, e.RowIndex].Value = true;
                        _gameSave.EditSeenPicture(name, comboBoxSelectCP.SelectedIndex, 2, Convert.ToBoolean(dataGridViewSeenPics[2, e.RowIndex].Value));
                        _gameSave.EditSeenPicture(name, comboBoxSelectCP.SelectedIndex, 3, Convert.ToBoolean(dataGridViewSeenPics[3, e.RowIndex].Value));
                    }
                }
                _editedControls.AddUnique(dataGridViewSeenPics[e.ColumnIndex, e.RowIndex]);
                dataGridViewSeenPics[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.LightGoldenrodYellow;
                ShowChangesWarning();
            }
        }

        private void dataGridViewCollectibles_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var value = dataGridViewCollectibles[e.ColumnIndex, e.RowIndex].Value;

            if (e.ColumnIndex == 1)
            {
                if (string.IsNullOrWhiteSpace(value.ToString()))
                {
                    newCellValue = "";
                    dataGridViewCollectibles[e.ColumnIndex, e.RowIndex].Value = "";
                }
                else
                {
                    int result;
                    if (!int.TryParse(value.ToString(), out result))
                    {
                        MessageBox.Show(Resources.BadValueMessage, "Error");
                        newCellValue = origCellValue;
                        dataGridViewCollectibles[e.ColumnIndex, e.RowIndex].Value = origCellValue;
                    }
                    else
                    {
                        newCellValue = result;
                    }
                } 
            }
            else
            {
                newCellValue = value;
            }

            if (newCellValue.ToString() != origCellValue.ToString())
            {
                var name = dataGridViewCollectibles[0, e.RowIndex].Value.ToString();
                _gameSave.EditCollectible(name, comboBoxSelectCP.SelectedIndex, e.ColumnIndex, newCellValue);

                if (e.ColumnIndex == 1 ^ string.IsNullOrWhiteSpace(dataGridViewCollectibles[1, e.RowIndex].Value.ToString()))
                {
                    if (e.ColumnIndex != 1)
                    {
                        dataGridViewCollectibles[1, e.RowIndex].Value = -1;
                    }
                    _gameSave.EditCollectible(name, comboBoxSelectCP.SelectedIndex, 2, dataGridViewCollectibles[2, e.RowIndex].Value);
                    _gameSave.EditCollectible(name, comboBoxSelectCP.SelectedIndex, 3, dataGridViewCollectibles[3, e.RowIndex].Value);
                }
                
                _editedControls.AddUnique(dataGridViewCollectibles[e.ColumnIndex, e.RowIndex]);
                dataGridViewCollectibles[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.LightGoldenrodYellow;
                ShowChangesWarning();
            }
        }

        private void dataGridViewObjectives_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            newCellValue = dataGridViewObjectives[e.ColumnIndex, e.RowIndex].Value.ToString();

            if (newCellValue.ToString() != origCellValue.ToString())
            {
                var name = dataGridViewObjectives[0, e.RowIndex].Value.ToString();
                _gameSave.EditObjective(name, comboBoxSelectCP.SelectedIndex, newCellValue.ToString());
                _editedControls.AddUnique(dataGridViewObjectives[0, e.RowIndex]);
                dataGridViewObjectives[0, e.RowIndex].Style.BackColor = Color.LightGoldenrodYellow;
                ShowChangesWarning();
            }
        }

        private void dataGridViewSeenMessages_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            newCellValue = dataGridViewSeenMessages[e.ColumnIndex, e.RowIndex].Value;

            if (newCellValue.ToString() != origCellValue.ToString())
            {
                var name = dataGridViewSeenMessages[0, e.RowIndex].Value.ToString();
                _gameSave.EditSeenMessage(name, comboBoxSelectCP.SelectedIndex, Convert.ToBoolean(newCellValue));
                _editedControls.AddUnique(dataGridViewSeenMessages[e.ColumnIndex, e.RowIndex]);
                dataGridViewSeenMessages[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.LightGoldenrodYellow;
                ShowChangesWarning();
            }
        }

        private void textBoxMetricsPlaythroughGuid_TextChnaged(object sender, EventArgs e)
        {
            var tb = (TextBox)sender;
            Guid value;
            try
            {
                value = new Guid(tb.Text);
                if (comboBoxSelectCP.SelectedIndex == 0)
                {
                    _gameSave.Data["CurrentSubContextSaveData"].Value["MetricsSaveData"].Value["PlaythroughId"].Value["Guid"] = value;
                }
                else
                {
                    _gameSave.Data["CheckpointHistory"].Value[comboBoxSelectCP.SelectedIndex]["MetricsSaveData"].Value["PlaythroughId"].Value["Guid"] = value;
                }
                tb.BackColor = Color.LightGoldenrodYellow;
                _editedControls.AddUnique(tb);
                ShowChangesWarning();
            }
            catch
            {
                tb.BackColor = Color.Red;
            }
        }

        private void textBoxMetricsPlaythroughCounter_TextChnaged(object sender, EventArgs e)
        {
            var tb = (TextBox)sender;
            int value;
            try
            {
                value = Convert.ToInt32(tb.Text);
                if (comboBoxSelectCP.SelectedIndex == 0)
                {
                    _gameSave.Data["CurrentSubContextSaveData"].Value["MetricsSaveData"].Value["PlaythroughCounter"].Value = value;
                }
                else
                {
                    _gameSave.Data["CheckpointHistory"].Value[comboBoxSelectCP.SelectedIndex]["MetricsSaveData"].Value["PlaythroughCounter"].Value = value;
                }
                tb.BackColor = Color.LightGoldenrodYellow;
                _editedControls.AddUnique(tb);
                ShowChangesWarning();
            }
            catch
            {
                tb.BackColor = Color.Red;
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
                tb.BackColor = Color.LightGoldenrodYellow;
                _editedControls.AddUnique(tb);
            }
            catch
            {
                tb.BackColor = Color.Red;
            }

            if (comboBoxSelectCP.SelectedIndex == 0)
            {
                _gameSave.Data["CurrentSubContextSaveData"].Value["MetricsSaveData"].Value["MetricsBySection"].Value[info[0]]["Counters"].Value[info[1]] = value;
            }
            else
            {
                _gameSave.Data["CheckpointHistory"].Value[comboBoxSelectCP.SelectedIndex]["MetricsSaveData"].Value["MetricsBySection"].Value[info[0]]["Counters"].Value[info[1]] = value;
            }
            
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
                tb.BackColor = Color.LightGoldenrodYellow;
                _editedControls.AddUnique(tb);
            }
            catch
            {
                tb.BackColor = Color.Red;
            }

            if (comboBoxSelectCP.SelectedIndex == 0)
            {
                _gameSave.Data["CurrentSubContextSaveData"].Value["MetricsSaveData"].Value["MetricsBySection"].Value[info[0]]["TimeCounters"].Value[info[1]] = value;
            }
            else
            {
                _gameSave.Data["CheckpointHistory"].Value[comboBoxSelectCP.SelectedIndex]["MetricsSaveData"].Value["MetricsBySection"].Value[info[0]]["TimeCounters"].Value[info[1]] = value;
            }

            
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
                tb.BackColor = Color.LightGoldenrodYellow;
                _editedControls.AddUnique(tb);
            }
            catch
            {
                tb.BackColor = Color.Red;
            }

            if (comboBoxSelectCP.SelectedIndex == 0)
            {
                _gameSave.Data["CurrentSubContextSaveData"].Value["MetricsSaveData"].Value["MetricsBySection"].Value[info[0]]["InteractionCounters"].Value[info[2]][info[1]].Value = value;
            }
            else
            {
                _gameSave.Data["CheckpointHistory"].Value[comboBoxSelectCP.SelectedIndex]["MetricsSaveData"].Value["MetricsBySection"].Value[info[0]]["InteractionCounters"].Value[info[2]][info[1]].Value = value;

            }
            ShowChangesWarning();
        }

        private void comboBoxOutfit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!SaveLoading)
            {
                ComboBox cb = (ComboBox)sender;
                string[] info = cb.Tag.ToString().Split(new string[] { "::" }, StringSplitOptions.None);
                var value = cb.SelectedItem.ToString();
                List<dynamic> target;

                if (comboBoxSelectCP.SelectedIndex == 0)
                {
                    target = _gameSave.Data["CurrentSubContextSaveData"].Value["Outfits"].Value[info[0]]["Items"].Value;
                }
                else
                {
                    target = _gameSave.Data["CheckpointHistory"].Value[comboBoxSelectCP.SelectedIndex]["Outfits"].Value[info[0]]["Items"].Value;
                }

                int index = target.FindIndex(1, x => x["Slot"].Value == info[1]);
                Guid guid = GameInfo.LIS2_Outfits.Find(x => x.Name == value).GUID;

                if (index == -1)
                {
                    Dictionary<string, dynamic> new_item = new Dictionary<string, dynamic>()
                    {
                        { "Guid", new StructProperty
                            {
                                Name = "Guid",
                                ElementType = "Guid",
                                Value = new Dictionary<string, dynamic>()
                                {
                                    { "Guid", guid }
                                }
                            }
                        },
                        {
                            "Slot", new NameProperty
                            {
                                Name = "Slot",
                                Value = info[1]
                            }
                        },
                        {
                            "Flags", new ArrayProperty
                            {
                                Name = "Flags",
                                ElementType = "NameProperty",
                                Value = new List<dynamic>()
                            }
                        }
                    };
                    target.AddUnique(new_item);
                    index = target.Count - 1;
                }
                if (value == "(none)")
                {
                    target.RemoveAt(index);
                }
                else
                {
                    target[index]["Guid"].Value["Guid"] = guid;
                }

                _editedControls.AddUnique(cb.Parent);
                cb.Parent.BackColor = Color.LightGoldenrodYellow;
                ShowChangesWarning();
            }
        }

        private void checkBoxCinematicActive_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;

            Dictionary<dynamic, dynamic> root = _gameSave.Data["CinematicHistorySaveData"].Value["SubcontextCinematicHistorySaveData"].Value;
            string[] info = cb.Tag.ToString().Split(new string[] { "::" }, 2, StringSplitOptions.RemoveEmptyEntries);

            List<dynamic> cin_list;
            if (!root.ContainsKey(info[0])) //Add new subcontext
            {
                Dictionary<string, dynamic> new_cont = new Dictionary<string, dynamic>()
                {
                    {
                        "PlayedCinematics", new ArrayProperty()
                        {
                            Name = "PlayedCinematics",
                            ElementType = "StructProperty",
                            Value = new List<dynamic>
                            {
                                new  Dictionary<string, object>()
                                {
                                    { "struct_name", "PlayedCinematics" },
                                    {"struct_type", "StructProperty" },
                                    {"struct_length", 0 },
                                    {"struct_eltype", "LIS2SequencePlayConditions" },
                                    {"struct_unkbytes", new byte[17] }
                                }
                            }
                        }
                    }
                };
                root[info[0]] = new_cont;
            }
            cin_list = root[info[0]]["PlayedCinematics"].Value;

            if (_gameSave.saveVersion == SaveVersion.CaptainSpirit)
            {
                if(cb.Checked) //Add cinematic
                {
                    Dictionary<string, dynamic> new_cin = new Dictionary<string, dynamic>()
                    {
                        {
                            "Guid", new Guid(info[1])
                        }
                    };
                    cin_list.AddUnique(new_cin);
                }
                else //Remove
                {
                    cin_list.RemoveAt(cin_list.FindIndex(1, x => x["Guid"].ToString() == info[1]));
                }
            }
            else
            {
                if (cb.Checked) //Add cinematic
                {
                    Dictionary<string, dynamic> new_cin = new Dictionary<string, dynamic>()
                    {
                        {
                            "Key", new StructProperty()
                            {
                                Name = "Key",
                                ElementType = "Guid",
                                Value = new Dictionary<string, dynamic>()
                                {
                                    { "Guid",  new Guid(info[1])}
                                }
                            }
                        },
                        {
                            "Value", new StructProperty()
                            {
                                Name = "Value",
                                ElementType = "LIS2PlayConditions",
                                Value = new Dictionary<string, dynamic>()
                                {
                                    {
                                        "Conditions", new ArrayProperty()
                                        {
                                            Name = "Conditions",
                                            ElementType = "StructProperty",
                                            Value = new List<dynamic>
                                            {
                                                new  Dictionary<string, object>()
                                                {
                                                    { "struct_name", "Conditions" },
                                                    {"struct_type", "StructProperty" },
                                                    {"struct_length", 0 },
                                                    {"struct_eltype", "LIS2PlayConditionsFactResult" },
                                                    {"struct_unkbytes", new byte[17] }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    };
                    cin_list.AddUnique(new_cin);
                }
                else //Remove cinematic
                {
                    cin_list.RemoveAt(cin_list.FindIndex(1, x => x["Key"].Value["Guid"].ToString() == info[1]));
                }
            }
            _editedControls.AddUnique(cb);
            cb.BackColor = Color.LightGoldenrodYellow;
            ShowChangesWarning();

        }

        private void checkBoxCinematicCondition_CheckStateChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            string[] info = cb.Tag.ToString().Split(new string[] { "::" }, 3, StringSplitOptions.RemoveEmptyEntries);

            ((CheckBox)cb.Parent.Controls["Active"]).Checked = true;
            List<dynamic> root = _gameSave.Data["CinematicHistorySaveData"].Value["SubcontextCinematicHistorySaveData"].Value[info[0]]["PlayedCinematics"].Value;
            List<dynamic> cond_list = root[root.FindIndex(1, x => x["Key"].Value["Guid"].ToString() == info[1])]["Value"].Value["Conditions"].Value;

            int index = cond_list.FindIndex(1, x => x["Key"].Value["Guid"].ToString() == info[2]);
            if (cb.CheckState == CheckState.Unchecked)
            {
                cond_list.RemoveAt(index);
            }
            else
            {
                if (index == -1) //add new condition
                {
                    Dictionary<string, dynamic> new_cond = new Dictionary<string, dynamic>()
                    {
                        {
                            "Key", new StructProperty()
                            {
                                Name = "Key",
                                ElementType = "Guid",
                                Value = new Dictionary<string, dynamic>()
                                {
                                    { "Guid",  new Guid(info[2])}
                                }
                            }
                        },
                        {
                            "Value", new BoolProperty()
                            {
                                Name = "Value",
                                Value = false
                            }
                        }
                    };
                    cond_list.AddUnique(new_cond);
                    index = cond_list.Count - 1;
                }
                cond_list[index]["Value"].Value = cb.CheckState == CheckState.Checked;
            }

            _editedControls.AddUnique(cb);
            cb.BackColor = Color.LightGoldenrodYellow;
            ShowChangesWarning();
        }

        private void checkBoxDrawingZoneFinishWhenComplete_CheckedChanged(object sender, EventArgs e)
        {
            if(!SaveLoading)
            {
                var cb = (CheckBox)sender;
                string[] info = cb.Tag.ToString().Split(new string[] { "::" }, 2, StringSplitOptions.RemoveEmptyEntries);

                bool value = cb.Checked;

                List<dynamic> target = null;

                if (comboBoxSelectCP.SelectedIndex == 0)
                {
                    target = _gameSave.Data["CurrentSubContextSaveData"].Value["PlayerSaveData"]
                        .Value["DrawSequenceSaveData"].Value["DrawSequenceItemSaveDatas"].Value;
                }
                else
                {
                    target = _gameSave.Data["CheckpointHistory"].Value[comboBoxSelectCP.SelectedIndex]["PlayerSaveData"]
                        .Value["DrawSequenceSaveData"].Value["DrawSequenceItemSaveDatas"].Value;
                }

                ((CheckBox)cb.Parent.Controls.Find("ZoneActive", false)[0]).Checked = true;

                int dr_index = target.FindIndex(1, x => x["DrawSequenceID"].Value["Name"].Value == info[0]);
                List<dynamic> drawing = target[dr_index]["LandscapeItemSaveDatas"].Value;
                int index = drawing.FindIndex(1, x => x["LandscapeID"].Value == $"Zone{info[1]}_Reveal");

                drawing[index]["bFinishDrawSequenceWhenComplete"].Value = value;

                _editedControls.AddUnique(cb);
                cb.BackColor = Color.LightGoldenrodYellow;
                ShowChangesWarning();
            }
        }

        private void textBoxDrawingPhase_TextChanged(object sender, EventArgs e)
        {
            if (!SaveLoading)
            {
                var tb = (TextBox)sender;
                string[] info = tb.Tag.ToString().Split(new string[] { "::" }, 3, StringSplitOptions.RemoveEmptyEntries);

                int value = -1;
                try
                {
                    value = Convert.ToInt32(tb.Text);
                    tb.BackColor = Color.LightGoldenrodYellow;
                    _editedControls.AddUnique(tb);
                }
                catch
                {
                    tb.BackColor = Color.Red;
                }

                List<dynamic> target = null;

                if (comboBoxSelectCP.SelectedIndex == 0)
                {
                    target = _gameSave.Data["CurrentSubContextSaveData"].Value["PlayerSaveData"]
                        .Value["DrawSequenceSaveData"].Value["DrawSequenceItemSaveDatas"].Value;
                }
                else
                {
                    target = _gameSave.Data["CheckpointHistory"].Value[comboBoxSelectCP.SelectedIndex]["PlayerSaveData"]
                        .Value["DrawSequenceSaveData"].Value["DrawSequenceItemSaveDatas"].Value;
                }

                ((CheckBox)tb.Parent.Controls.Find("ZoneActive", false)[0]).Checked = true;

                int dr_index = target.FindIndex(1, x => x["DrawSequenceID"].Value["Name"].Value == info[0]);
                List<dynamic> drawing = target[dr_index]["LandscapeItemSaveDatas"].Value;
                int index = drawing.FindIndex(1, x => x["LandscapeID"].Value == $"Zone{info[1]}_Reveal");

                drawing[index][$"Drawing{info[2]}Phase"].Value = value;

                ShowChangesWarning();
            }
        }

        private void comboBoxDrawingPhase_Old_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!SaveLoading)
            {
                var cb = (ComboBox)sender;
                string[] info = cb.Tag.ToString().Split(new string[] { "::" }, 2, StringSplitOptions.RemoveEmptyEntries);

                List<dynamic> target = null;

                if (comboBoxSelectCP.SelectedIndex == 0)
                {
                    target = _gameSave.Data["CurrentSubContextSaveData"].Value["PlayerSaveData"]
                        .Value["DrawSequenceSaveData"].Value["DrawSequenceItemSaveDatas"].Value;
                }
                else
                {
                    target = _gameSave.Data["CheckpointHistory"].Value[comboBoxSelectCP.SelectedIndex]["PlayerSaveData"]
                        .Value["DrawSequenceSaveData"].Value["DrawSequenceItemSaveDatas"].Value;
                }

                ((CheckBox)cb.Parent.Parent.Controls.Find("ZoneActive", false)[0]).Checked = true;

                int dr_index = target.FindIndex(1, x => x["DrawSequenceID"].Value["Name"].Value == info[0]);
                List<dynamic> drawing = target[dr_index]["LandscapeItemSaveDatas"].Value;
                int index = drawing.FindIndex(1, x => x["LandscapeID"].Value == $"Zone{info[1]}_Reveal");

                drawing[index]["DrawingPhase"].Value = "ELIS2PencilDrawingPhase::" + cb.SelectedItem.ToString();

                cb.Parent.BackColor = Color.LightGoldenrodYellow;
                _editedControls.AddUnique(cb.Parent);
                ShowChangesWarning();
            }
        }

        private void textBoxDrawingPercent_TextChanged(object sender, EventArgs e)
        {
            if (!SaveLoading)
            {
                var tb = (TextBox)sender;
                string[] info = tb.Tag.ToString().Split(new string[] { "::" }, 2, StringSplitOptions.RemoveEmptyEntries);

                float value = 0;
                try
                {
                    value = Convert.ToSingle(tb.Text);
                    tb.BackColor = Color.LightGoldenrodYellow;
                    _editedControls.AddUnique(tb);
                }
                catch
                {
                    tb.BackColor = Color.Red;
                }

                List<dynamic> target = null;

                if (comboBoxSelectCP.SelectedIndex == 0)
                {
                    target = _gameSave.Data["CurrentSubContextSaveData"].Value["PlayerSaveData"]
                        .Value["DrawSequenceSaveData"].Value["DrawSequenceItemSaveDatas"].Value;
                }
                else
                {
                    target = _gameSave.Data["CheckpointHistory"].Value[comboBoxSelectCP.SelectedIndex]["PlayerSaveData"]
                        .Value["DrawSequenceSaveData"].Value["DrawSequenceItemSaveDatas"].Value;
                }

                ((CheckBox)tb.Parent.Controls.Find("ZoneActive", false)[0]).Checked = true;

                int dr_index = target.FindIndex(1, x => x["DrawSequenceID"].Value["Name"].Value == info[0]);
                List<dynamic> drawing = target[dr_index]["LandscapeItemSaveDatas"].Value;
                int index = drawing.FindIndex(1, x => x["LandscapeID"].Value == $"Zone{info[1]}_Reveal");

                drawing[index]["DrawingPercent"].Value = value;

                ShowChangesWarning();
            }
        }

        private void checkBoxDrawingZoneActive_CheckedChanged(object sender, EventArgs e)
        {
            var cb = (CheckBox)sender;
            string[] info = cb.Tag.ToString().Split(new string[] { "::" }, 2, StringSplitOptions.RemoveEmptyEntries);


            List<dynamic> target = null;

            if (comboBoxSelectCP.SelectedIndex == 0)
            {
                target = _gameSave.Data["CurrentSubContextSaveData"].Value["PlayerSaveData"]
                         .Value["DrawSequenceSaveData"].Value["DrawSequenceItemSaveDatas"].Value;
            }
            else
            {
                target = _gameSave.Data["CheckpointHistory"].Value[comboBoxSelectCP.SelectedIndex]["PlayerSaveData"]
                         .Value["DrawSequenceSaveData"].Value["DrawSequenceItemSaveDatas"].Value;
            }

            ((CheckBox)cb.Parent.Parent.Controls.Find("DrawingActive", false)[0]).Checked = true;

            int dr_index = target.FindIndex(1, x => x["DrawSequenceID"].Value["Name"].Value == info[0]);

            List<dynamic> drawing = target[dr_index]["LandscapeItemSaveDatas"].Value;

            if (cb.Checked) //Add new zone 
            {
                //todo: implement updating of form fields after adding new zone
                SaveLoading = true;
                var tbPercent = (TextBox)cb.Parent.Controls.Find("tbPercent", false)[0];
                var part = new Dictionary<string, dynamic>()
                {
                    { "LandscapeID", new NameProperty() {Name = "LandscapeID", Value = $"Zone{info[1]}_Reveal"} }
                };
                if (float.TryParse(tbPercent.Text, out float percent))
                {
                    part["DrawingPercent"] = new FloatProperty() {Name = "DrawingPercent", Value = percent};
                }
                else
                {
                    part["DrawingPercent"] = new FloatProperty() { Name = "DrawingPercent", Value = 0 };
                    tbPercent.Text = "0";
                }

                if (_gameSave.saveVersion == SaveVersion.LIS_E1)
                {
                    var cbPhase = (ComboBox)cb.Parent.Controls.Find("comboBoxPhase", true)[0];
                    string phase = cbPhase.SelectedItem?.ToString() ?? "Rough";
                    part["DrawingPhase"] = new EnumProperty() { Name = "DrawingPhase", ElementType = "ELIS2PencilDrawingPhase", Value = "ELIS2PencilDrawingPhase::" + phase };
                    cbPhase.SelectedItem = phase;
                }
                else
                {
                    foreach (var type in new string[] { "Start", "Current", "End" })
                    {
                        var tb = (TextBox)cb.Parent.Controls.Find($"tb{type}Phase", false)[0];
                        if (int.TryParse(tb.Text, out int result))
                        {
                            part[$"Drawing{type}Phase"] = new IntProperty() { Name = $"Drawing{type}Phase", Value = result };
                        }
                        else
                        {
                            part[$"Drawing{type}Phase"] = new IntProperty() { Name = $"Drawing{type}Phase", Value = -1 };
                            tb.Text = "-1";
                        }
                    }
                    bool fwc = ((CheckBox)cb.Parent.Controls.Find("cbFinishWhenComplete", false)[0]).Checked;
                    part["bFinishDrawSequenceWhenComplete"] = new BoolProperty() { Name = "bFinishDrawSequenceWhenComplete", Value = fwc };
                }
                drawing.AddUnique(part);
                SaveLoading = false;
            }
            else
            {
                int index = drawing.FindIndex(1, x => x["LandscapeID"].Value == $"Zone{info[1]}_Reveal");
                drawing.RemoveAt(index);
            }

            _editedControls.AddUnique(cb);
            cb.BackColor = Color.LightGoldenrodYellow;
            ShowChangesWarning();
        }

        private void checkBoxDrawingActive_CheckedChanged(object sender, EventArgs e)
        {
            var cb = (CheckBox)sender;

            List<dynamic> target = null;

            if (comboBoxSelectCP.SelectedIndex == 0)
            {
                target = _gameSave.Data["CurrentSubContextSaveData"].Value["PlayerSaveData"]
                         .Value["DrawSequenceSaveData"].Value["DrawSequenceItemSaveDatas"].Value;
            }
            else
            {
                target = _gameSave.Data["CheckpointHistory"].Value[comboBoxSelectCP.SelectedIndex]["PlayerSaveData"]
                         .Value["DrawSequenceSaveData"].Value["DrawSequenceItemSaveDatas"].Value;
            }

            int dr_index = target.FindIndex(1, x => x["DrawSequenceID"].Value["Name"].Value == cb.Tag.ToString());

            if (cb.Checked) //Add new DrawSequence
            {
                if (dr_index != -1) throw new Exception("something's off");
                var name = cb.Tag.ToString();
                Guid guid = GameInfo.LIS2_DrawingNames.Find(x => x.Name == name).GUID;
                Dictionary<string, dynamic> new_seq = new Dictionary<string, dynamic>();
                new_seq["DrawSequenceID"] = new StructProperty()
                {
                    Name = "DrawSequenceID",
                    ElementType = "DNERefName",
                    Value = new Dictionary<string, dynamic>()
                    {
                        { "Name", new NameProperty()
                            {
                                Name = "Name",
                                Value = name
                            }
                        },
                        { "NameGuid", new StructProperty
                            {
                                Name = "NameGuid",
                                ElementType = "Guid",
                                Value = new Dictionary<string, dynamic>()
                                {
                                    { "Guid", guid }
                                }
                            }
                        }
                    }
                };
                new_seq["LandscapeItemSaveDatas"] = new ArrayProperty()
                {
                    Name = "LandscapeItemSaveDatas",
                    ElementType = "StructProperty",
                    Value = new List<dynamic>
                    {
                        new  Dictionary<string, object>()
                        {
                            { "struct_name", "LandscapeItemSaveDatas" },
                            {"struct_type", "StructProperty" },
                            {"struct_length", 0 },
                            {"struct_eltype", "LIS2LandscapeItemSaveData" },
                            {"struct_unkbytes", new byte[17] }
                        }
                    }
                };
                target.AddUnique(new_seq);
            }
            else
            {
                if (dr_index == -1) throw new Exception("something's off");
                target.RemoveAt(dr_index);
            }

            _editedControls.AddUnique(cb);
            cb.BackColor = Color.LightGoldenrodYellow;
            ShowChangesWarning();
        }
        #endregion

        private void textBoxSavePath_TextChanged(object sender, EventArgs e)
        {
            ValidatePaths();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Text = $"Life is Strange 2 Savegame Editor v{Program.GetApplicationVersionStr()}";
            foreach (TabPage page in tabControlMain.TabPages)
            {
                tabControlMain.SelectedTab = page;
            }
            tabControlMain.SelectedTab = tabPageGeneral;

            DetectSavePath();
            textBoxSavePath.Text = _settingManager.Settings.SavePath;

            labelChangesWarning.Visible = false; 
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _settingManager.SaveSettings();

            if (_gameSave != null && !_gameSave.SaveChangesSaved)
            {
                DialogResult answer = MessageBox.Show(string.Format(Resources.UnsavedEditsWarningMessage, _editedControls.Count),
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

        private void comboBoxSelectCP_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveLoading = true;

            int index = comboBoxSelectCP.SelectedIndex;

            //General tab
            if (_gameSave.saveVersion == SaveVersion.CaptainSpirit)
            {
                comboBoxCPName.SelectedItem = _gameSave.Data["CheckpointName"].Value;
                textBoxSubContextID.Text = _gameSave.Data["CurrentSubContextSaveData"].Value["SubContextId"].Value;
            }
            else if (index == 0)
            {
                comboBoxCPName.SelectedItem = _gameSave.Data["CurrentSubContextSaveData"].Value["CheckpointName"].Value;
                textBoxSubContextID.Text = _gameSave.Data["CurrentSubContextSaveData"].Value["SubContextId"].Value;
            }
            else
            {
                comboBoxCPName.SelectedItem = _gameSave.Data["CheckpointHistory"].Value[index]["CheckpointName"].Value;
                textBoxSubContextID.Text = _gameSave.Data["CheckpointHistory"].Value[index]["SubContextId"].Value;

            }

            UpdatePlayerInfo(index);
            UpdateDanielInfo(index);
            UpdateAICallInfo(index);
            UpdateCamActorInfo(index);
            UpdateMetaInvSubContexts(index);
            UpdateMetaInvTutoStatus(index);
            UpdateInventoryGrids(index);
            UpdateSeenNotifsGrid(index);
            UpdateSeenTutosGrid(index);
            GenerateDrawings(index);
            UpdateAllFactsGrid(index);
            UpdateWorldGrid(index);
            UpdateAllLevelsGrid(index);
            GenerateMetrics(index);
            UpdateSeenPicturesGrid(index);
            UpdateCollectiblesGrid(index);
            UpdateObjectivesGrid(index);
            GenerateActiveObjectiveCueGroups(index);
            UpdateSeenMessagesGrid(index);
            UpdateOutfits(index);

            SaveLoading = false;
            ResetEditedControls();

            if (searchForm != null)
            {
                searchForm.ResetSearchState();
            }
        }

        private void GenerateActiveObjectiveCueGroups(int cpIndex)
        {
            flowLayoutPanelActiveObjectiveCueGroups.Controls.Clear();

            List<dynamic> root;
            string[] source = _gameSave.saveVersion == SaveVersion.CaptainSpirit
                ? GameInfo.CS_ActiveObjectiveCueGroups
                : GameInfo.LIS2_ActiveObjectiveCueGroups;
            if (cpIndex == 0)
            {
                root = _gameSave.Data["CurrentSubContextSaveData"].Value["PlayerSaveData"]
                    .Value["ActiveObjectiveCueGroups"].Value;
            }
            else
            {
                root = _gameSave.Data["CheckpointHistory"].Value[cpIndex]["PlayerSaveData"]
                    .Value["ActiveObjectiveCueGroups"].Value;
            }

            root = root.Skip(1).ToList();
            int lbl_y = 20;

            foreach (var cuegroup in source)
            {
                var gbox = new GroupBox();
                gbox.AutoSize = true;
                gbox.Text = cuegroup;

                //size crutch
                var text_lbl = new Label();
                text_lbl.AutoSize = true;
                text_lbl.Text = gbox.Text;
                text_lbl.Visible = false;
                text_lbl.Enabled = false;
                gbox.Controls.Add(text_lbl);
                gbox.MinimumSize = new Size(text_lbl.Width + 20, 20);

                var cb_active = new CheckBox();
                cb_active.AutoSize = true;
                cb_active.Name = "Active";
                cb_active.Text = "Active";
                cb_active.Location = new Point(10, lbl_y);
                dynamic save_group = root.Find(x => x["GroupName"].Value == cuegroup);
                cb_active.Checked = save_group != null;
                cb_active.Tag = cuegroup;
                cb_active.CheckedChanged += new EventHandler(checkBoxObjectiveCueGroup_CheckedChanged);
                gbox.Controls.Add(cb_active);

                var cb_paused = new CheckBox();
                cb_paused.AutoSize = true;
                cb_paused.Name = "Paused";
                cb_paused.Text = "Paused";
                cb_paused.Location = new Point(70, lbl_y);
                cb_paused.Checked = save_group?["bPaused"].Value ?? false;
                cb_paused.Tag = cuegroup;
                cb_paused.CheckedChanged += new EventHandler(checkBoxObjectiveCueGroup_CheckedChanged);
                gbox.Controls.Add(cb_paused);

                lbl_y += 20;

                Label lbl_indexes = new Label()
                {
                    Location = new Point(8, lbl_y),
                    Text = "Cue indexes:",
                    AutoSize = true
                };
                gbox.Controls.Add(lbl_indexes);

                lbl_y += 15;

                ListBox lbox = new ListBox();
                lbox.Name = "CueIndexes";
                lbox.Location = new Point(10, lbl_y);
                lbox.Size = new Size(120, 70);
                lbox.SelectionMode = SelectionMode.MultiExtended;
                lbox.Tag = cuegroup;
                gbox.Controls.Add(lbox);
                lbl_y += 75;

                if (save_group != null)
                {
                    foreach (var item in save_group["CurrentCuesIndexes"].Value)
                    {
                        lbox.Items.Add(item);
                    }
                }

                lbox.KeyUp += new KeyEventHandler(listBoxObjectiveCueGroupIndexes_KeyPress);

                TextBox tb = new TextBox();
                tb.Name = "tbNewCueIndex";
                tb.Location = new Point(10, lbl_y);
                tb.Width = 65;
                tb.Tag = cuegroup;
                tb.TextChanged += new EventHandler(textBoxObjectiveCueGroupNewIndex_TextChanged);
                gbox.Controls.Add(tb);

                Button but = new Button();
                but.Name = "btnAddNewIndex";
                but.Location = new Point(85, lbl_y - 1);
                but.Width = 45;
                but.Text = "Add";
                but.Tag = cuegroup;
                but.Enabled = false;
                but.Click += new EventHandler(buttonObjectiveCueGroupNewIndex_Click);
                gbox.Controls.Add(but);

                flowLayoutPanelActiveObjectiveCueGroups.Controls.Add(gbox);
                lbl_y = 20;
            }
        }

        private void listBoxObjectiveCueGroupIndexes_KeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                ListBox lb = (ListBox) sender;
                var selectedItems = lb.SelectedItems.OfType<int>().ToArray();
                var name = lb.Tag.ToString();
                List<dynamic> root;
                var cpIndex = comboBoxSelectCP.SelectedIndex;
                if (cpIndex == 0)
                {
                    root = _gameSave.Data["CurrentSubContextSaveData"].Value["PlayerSaveData"]
                        .Value["ActiveObjectiveCueGroups"].Value;
                }
                else
                {
                    root = _gameSave.Data["CheckpointHistory"].Value[cpIndex]["PlayerSaveData"]
                        .Value["ActiveObjectiveCueGroups"].Value;
                }
                int index = root.FindIndex(1, x => x["GroupName"].Value == name);
                List<dynamic> cues = root[index]["CurrentCuesIndexes"].Value;
                foreach (var item in selectedItems)
                {
                    cues.Remove(item);
                    lb.Items.Remove(item);
                    _editedControls.Add(item);
                }

                if (selectedItems.Length > 0)
                {
                    ShowChangesWarning();
                }
            }
        }

        private void buttonObjectiveCueGroupNewIndex_Click(object sender, EventArgs e)
        {
            Control par = ((Button)sender).Parent;
            ListBox lb = (ListBox)par.Controls.Find("CueIndexes", false)[0];
            int value = Convert.ToInt32(par.Controls.Find("tbNewCueIndex", false)[0].Text);
            if (!lb.Items.Contains(value))
            {
                lb.Items.Add(value);
                ((CheckBox) par.Controls.Find("Active", false)[0]).Checked = true;
                var name = lb.Tag.ToString();
                List<dynamic> root;
                var cpIndex = comboBoxSelectCP.SelectedIndex;
                if (cpIndex == 0)
                {
                    root = _gameSave.Data["CurrentSubContextSaveData"].Value["PlayerSaveData"]
                        .Value["ActiveObjectiveCueGroups"].Value;
                }
                else
                {
                    root = _gameSave.Data["CheckpointHistory"].Value[cpIndex]["PlayerSaveData"]
                        .Value["ActiveObjectiveCueGroups"].Value;
                }
                int index = root.FindIndex(1, x => x["GroupName"].Value == name);
                List<dynamic> cues = root[index]["CurrentCuesIndexes"].Value;
                cues.AddUnique(value);
                _editedControls.Add(value);
                ShowChangesWarning();
            }
        }

        private void textBoxObjectiveCueGroupNewIndex_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox) sender;
            Button btn = (Button) tb.Parent.Controls.Find("btnAddNewIndex", false)[0];
            if (int.TryParse(tb.Text, out int result))
            {
                btn.Enabled = true;
                tb.BackColor = SystemColors.Window;
            }
            else
            {
                btn.Enabled = false;
                tb.BackColor = Color.Red;
            }
        }

        private void checkBoxObjectiveCueGroup_CheckedChanged(object sender, EventArgs e)
        {
            List<dynamic> root;
            var cb = (CheckBox) sender;
            string name = cb.Tag.ToString();
            var cpIndex = comboBoxSelectCP.SelectedIndex;
            if (cpIndex == 0)
            {
                root = _gameSave.Data["CurrentSubContextSaveData"].Value["PlayerSaveData"]
                    .Value["ActiveObjectiveCueGroups"].Value;
            }
            else
            {
                root = _gameSave.Data["CheckpointHistory"].Value[cpIndex]["PlayerSaveData"]
                    .Value["ActiveObjectiveCueGroups"].Value;
            }

            int index = root.FindIndex(1, x => x["GroupName"].Value == name);
            if (cb.Name == "Active" && !cb.Checked)
            {
                root.RemoveAt(index);
            }
            else
            {
                if (index == -1)
                {
                    List<dynamic> values = ((ListBox)cb.Parent.Controls.Find("CueIndexes", false)[0]).Items.OfType<int>().Cast<dynamic>().ToList();
                    bool isPaused = ((CheckBox)cb.Parent.Controls.Find("Paused", false)[0]).Checked;
                    Dictionary<string, dynamic> new_item = new Dictionary<string, dynamic>()
                    {
                        {"GroupName", new NameProperty() {Name = "GroupName", Value = name}},
                        {
                            "CurrentCuesIndexes",
                            new ArrayProperty() {Name = "CurrentCuesIndexes", ElementType = "IntProperty", Value = values}
                        },
                        {
                            "bPaused", new BoolProperty() {Name = "bPaused", Value = isPaused}
                        }
                    };
                    root.AddUnique(new_item);
                    index = root.Count - 1;
                }

                if (cb.Name == "Paused")
                {
                    root[index]["bPaused"].Value = cb.Checked;
                }
            }

            cb.BackColor = Color.LightGoldenrodYellow;
            _editedControls.AddUnique(cb);
            ShowChangesWarning();
        }

        private void UpdateCamActorInfo(int cpIndex)
        {
            if (_gameSave.saveVersion == SaveVersion.CaptainSpirit)
            {
                checkBoxUseCameraDetection.Enabled = false;
                return;
            }

            dynamic root;
            if (cpIndex == 0)
            {
                root = _gameSave.Data["CurrentSubContextSaveData"].Value["CamFocusActorComponentSaveData"].Value;
            }
            else
            {
                root = _gameSave.Data["CheckpointHistory"].Value[cpIndex]["CamFocusActorComponentSaveData"].Value;
            }

            checkBoxUseCameraDetection.Enabled = true;
            checkBoxUseCameraDetection.Checked = root["bUseDetection"].Value;
        }

        private void DetectSavePath()
        {
            try
            {
                _steamIdFolders = Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\AppData\Local\Dontnod\");
            }
            catch
            {

            }

            if (string.IsNullOrEmpty(_settingManager.Settings.SavePath))
            {
                if (_steamIdFolders.Length == 1)
                {
                    bool found = false;

                    //search for LIS2 saves
                    for (int i = 0; i < 5; i++)
                    {
                        if (File.Exists(_steamIdFolders[0].ToString() + @"\LIS2\Saved\SaveGames\GameSave_Slot" + i + ".sav"))
                        {
                            textBoxSavePath.Text = _steamIdFolders[0].ToString() + @"\LIS2\Saved\SaveGames\GameSave_Slot" + i + ".sav";
                            _settingManager.Settings.SavePath = textBoxSavePath.Text;
                            found = true;
                            break;
                        }
                    }

                    //search for CS save
                    if (!found && File.Exists(_steamIdFolders[0].ToString() + @"\CaptainSpirit\Saved\SaveGames\GameSave_Slot0.sav"))
                    {
                        textBoxSavePath.Text = _steamIdFolders[0].ToString() + @"\CaptainSpirit\Saved\SaveGames\GameSave_Slot0.sav";
                        _settingManager.Settings.SavePath = textBoxSavePath.Text;
                        found = true;
                    }

                    if (!found)
                    {
                        textBoxSavePath.Text = "Auto-detection failed! Please select the path manually.";
                    } 
                }
                else if (_steamIdFolders.Length > 1)
                {
                    using (var saveSelectionForm = new SaveSelectionForm(_steamIdFolders))
                    {
                        if (saveSelectionForm.ShowDialog() == DialogResult.OK)
                        {
                            textBoxSavePath.Text = saveSelectionForm.savePath;
                            _settingManager.Settings.SavePath = textBoxSavePath.Text;
                        }
                    }
                }
                else
                {
                    textBoxSavePath.Text = "Auto-detection failed! Please select the path manually.";
                }
            }
            else
            {
                textBoxSavePath.Text = _settingManager.Settings.SavePath;
            }
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
                _settingManager.Settings.SavePath = textBoxSavePath.Text;
                buttonLoad.Enabled = true;
                buttonSaveEdits.Enabled = false;
                tabControlMain.Enabled = false;
                comboBoxSelectCP.Enabled = false;

                try
                {
                    string saveRoot = Path.GetFullPath(Path.Combine(textBoxSavePath.Text, @"..\..\..\..\..\")).ToLowerInvariant();
                    string testRoot = (Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\AppData\Local\Dontnod\").ToLowerInvariant();
                    if (saveRoot == testRoot && 
                       (textBoxSavePath.Text.Contains("CaptainSpirit") || textBoxSavePath.Text.Contains("LIS2")))
                    {
                        buttonSaveSelector.Enabled = true;
                    }
                    else
                    {
                        buttonSaveSelector.Enabled = false;
                    }
                }
                catch
                {
                    buttonSaveSelector.Enabled = false;
                }

                labelChangesWarning.Text = "Save file changed! Press 'Load' to update.";
                labelChangesWarning.Visible = true;
            }
            else
            {
                textBoxSavePath.BackColor = Color.Red;
                buttonLoad.Enabled = false;
                buttonSaveEdits.Enabled = false;
                tabControlMain.Enabled = false;
                comboBoxSelectCP.Enabled = false;
                labelChangesWarning.Visible = false;
            }
        }

        private void ShowChangesWarning()
        {
            _gameSave.SaveChangesSaved = false;
            labelChangesWarning.Text = "Press 'Save' to write changes to the save file.";
            labelChangesWarning.Visible = true;
        }
        
        private void ResetEditedControls()
        {
            foreach (var cnt in _editedControls)
            {
                if (cnt is DataGridViewCell)
                {
                    cnt.Style.BackColor = Color.White;
                }
                else if (cnt is TextBox)
                {
                    cnt.BackColor = SystemColors.Window;
                }
                else if (cnt is Panel || cnt is GroupBox || cnt is CheckBox)
                {
                    cnt.BackColor = Color.Transparent;
                }
                else if (cnt is Control)
                {
                    cnt.BackColor = Color.White;
                }
            }
            _editedControls.Clear();
        }

        private void buttonSaveSelector_Click(object sender, EventArgs e)
        {
            using (var saveSelectionForm = new SaveSelectionForm(_steamIdFolders))
            {
                saveSelectionForm.savePath = textBoxSavePath.Text;
                if (saveSelectionForm.ShowDialog() == DialogResult.OK)
                {
                    textBoxSavePath.Text = saveSelectionForm.savePath;
                    _settingManager.Settings.SavePath = textBoxSavePath.Text;
                }
            }
        }

        SearchForm searchForm;
        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ModifierKeys == Keys.Control && (int)e.KeyChar == 6)
            {
                if (searchForm == null)
                {
                    searchForm = new SearchForm(tabControlMain);
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
        }

        private void checkBoxUseCameraDetection_CheckedChanged(object sender, EventArgs e)
        {
            if (!SaveLoading)
            {
                dynamic root;
                var cpIndex = comboBoxSelectCP.SelectedIndex;
                if (cpIndex == 0)
                {
                    root = _gameSave.Data["CurrentSubContextSaveData"].Value["CamFocusActorComponentSaveData"].Value;
                }
                else
                {
                    root = _gameSave.Data["CheckpointHistory"].Value[cpIndex]["CamFocusActorComponentSaveData"].Value;
                }

                root["bUseDetection"].Value = checkBoxUseCameraDetection.Checked;

                _editedControls.AddUnique(checkBoxUseCameraDetection);
                checkBoxUseCameraDetection.BackColor = Color.LightGoldenrodYellow;
                ShowChangesWarning();
            }
        }

        private void checkBoxChoiceSent_CheckStateChanged(object sender, EventArgs e)
        {
            if (!SaveLoading)
            {
                CheckBox cb = (CheckBox)sender;
                int index = Convert.ToInt32(cb.Tag);
                Dictionary<dynamic, dynamic> target = _gameSave.Data["StatsSaveData"].Value["SendChoiceSuccess"].Value;
                if (cb.CheckState == CheckState.Unchecked)
                {
                    target.Remove(index);
                }
                else
                {
                    target[index] = cb.CheckState == CheckState.Checked;
                }
                
                cb.BackColor = Color.LightGoldenrodYellow;
                _editedControls.AddUnique(cb);
                ShowChangesWarning();
            }
        }

        private void ClearGroupBox(GroupBox gb)
        {
            foreach (Control cnt in gb.Controls)
            {
                if (cnt is TextBox)
                {
                    cnt.Text = "";
                }
                else if (cnt is Panel)
                {
                    ((ComboBox)cnt.Controls[0]).SelectedIndex = -1;
                }
                else if (cnt is CheckBox)
                {
                    ((CheckBox)cnt).Checked = false;
                }
                else if (cnt is GroupBox)
                {
                    ClearGroupBox((GroupBox)cnt);
                }
            }
        }
    }
}
