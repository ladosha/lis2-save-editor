using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using lis2_save_editor.Properties;

namespace lis2_save_editor
{
    public partial class LevelEditForm : Form
    {
        public LevelEditForm()
        {
            InitializeComponent();
        }

        public Dictionary<string, dynamic> level = null;

        public SaveVersion saveVersion;

        private LevelObject level_info
        {
            get
            {
                var obj = saveVersion == SaveVersion.CaptainSpirit ? GameInfo.CS_Levels.Find(x => x.Name == level["LevelName"].Value) 
                                                             : GameInfo.LIS2_Levels.Find(x => x.Name == level["LevelName"].Value);
                if (obj != null) return obj;
                return LevelObject.Empty;
            }
        }

        public bool changesMade = false;

        private void LevelEditForm_Load(object sender, EventArgs e)
        {
            this.Text = "Edit level " + level_info.Name;
            GenerateInteractions();
            UpdatePOITable();
            UpdateWUITable();
            UpdateStoppedSeqTable();
            UpdatePlayingSeqTable();
            UpdateBindingTables();
            UpdateDelayedEventsTable();
        }

        #region Building

        private void GenerateInteractions()
        {
            flowLayoutPanelInteractions.Controls.Clear();

            List<dynamic> root = level["InteractionsSaveData"].Value["InteractionActors"].Value;

            int lbl_coord = 50, max_lbl_width = 0;

            Regex reg = new Regex(@"(?<=_)C\d+_.*");

            var special_int_icon = saveVersion == SaveVersion.CaptainSpirit ? Resources.CS_icon : Resources.DanielIntIcon;

            foreach (var obj in level_info.Interactions)
            {
                var gbox = new GroupBox();
                gbox.AutoSize = true;
                gbox.AutoSizeMode = AutoSizeMode.GrowOnly;
                gbox.Text = obj.Name;

                //size crutch
                var text_lbl = new Label();
                text_lbl.AutoSize = true;
                text_lbl.Text = gbox.Text;
                text_lbl.Visible = false;
                text_lbl.Enabled = false;
                gbox.Controls.Add(text_lbl);
                gbox.MinimumSize = new Size(text_lbl.Width + 20, gbox.Height);

                var actor_ind = root.FindIndex(1, x => x["InteractionActorName"].Value == obj.Name);

                var cbActive= new CheckBox();
                cbActive.Name = "Active";
                cbActive.Text = "Active";
                cbActive.Location = new Point(6, 20);
                cbActive.AutoSize = true;
                cbActive.Checked = (actor_ind != -1);
                cbActive.CheckedChanged += new EventHandler(checkBoxIntObject_CheckedChanged);
                gbox.Controls.Add(cbActive);

                var cbEnabled = new CheckBox();
                cbEnabled.Text = "Enabled";
                cbEnabled.Location = new Point(70, 20);
                cbEnabled.AutoSize = true;
                cbEnabled.Checked = actor_ind == -1 ? false : root[actor_ind]["bIsEnable"].Value;
                cbEnabled.CheckedChanged += new EventHandler(checkBoxIntObject_CheckedChanged);
                gbox.Controls.Add(cbEnabled);

                var cbDestroyed = new CheckBox();
                cbDestroyed.Text = "Destroyed";
                cbDestroyed.Location = new Point(140, 20);
                cbDestroyed.AutoSize = true;
                cbDestroyed.Checked = actor_ind == -1 ? false : root[actor_ind]["bIsConsideredDestroyed"].Value;
                cbDestroyed.CheckedChanged += new EventHandler(checkBoxIntObject_CheckedChanged);
                gbox.Controls.Add(cbDestroyed);

                foreach (var inter in obj.ClassicInteractions)
                {
                    var lbl = new Label();
                    lbl.AutoSize = true;
                    lbl.Location = new Point(3, lbl_coord);
                    lbl.Text = reg.Match(inter.Value).Value;
                    gbox.Controls.Add(lbl);

                    if (lbl.Width > max_lbl_width)
                    {
                        max_lbl_width = lbl.Width;
                    }

                    var inter_ind = -1;
                    List<dynamic> int_list = null;
                    if (actor_ind != -1)
                    {
                        int_list = root[actor_ind]["ClassicInteractions"].Value;
                        inter_ind = int_list.FindIndex(1, x => x["InteractionGuid"].Value["Guid"] == inter.Key);
                    }

                    var tb = new TextBox();
                    tb.Location = new Point(lbl.Location.X + 3, lbl.Location.Y - 3);
                    tb.Name = "tb" + lbl.Text;
                    tb.Tag = obj.Name + "::" + "Classic" + "::" + inter.Key.ToString();
                    tb.Size = new Size(60, 20);
                    tb.Text = (actor_ind == -1 || inter_ind == -1) ? "" : int_list[inter_ind]["InteractionExecutionCount"].Value.ToString();
                    tb.TextChanged += new EventHandler(textBoxInteraction_CheckedChanged);
                    gbox.Controls.Add(tb);
                    lbl_coord += 26;
                }

                foreach (var inter in obj.DanielInteractions)
                {
                    var pb = new PictureBox();
                    pb.Image = special_int_icon;
                    pb.Location = new Point(3, lbl_coord);
                    pb.Size = new Size(24, 24);
                    pb.SizeMode = PictureBoxSizeMode.Zoom;
                    gbox.Controls.Add(pb);

                    var lbl = new Label();
                    lbl.AutoSize = true;
                    lbl.Location = new Point(26, lbl_coord);
                    lbl.Text = reg.Match(inter.Value).Value;
                    gbox.Controls.Add(lbl);

                    if (lbl.Width > max_lbl_width)
                    {
                        max_lbl_width = lbl.Width;
                    }

                    var inter_ind = -1;
                    List<dynamic> int_list = null;
                    if (actor_ind != -1)
                    {
                        int_list = root[actor_ind]["DanielInteractions"].Value;
                        inter_ind = int_list.FindIndex(1, x => x["InteractionGuid"].Value["Guid"] == inter.Key);
                    }

                    var tb = new TextBox();
                    tb.Location = new Point(lbl.Location.X, lbl.Location.Y - 3);
                    tb.Name = "tb" + lbl.Text;
                    tb.Tag = obj.Name + "::" + "Daniel" + "::" + inter.Key.ToString();
                    tb.Size = new Size(60, 20);
                    tb.Text = (actor_ind == -1 || inter_ind == -1) ? "" : int_list[inter_ind]["InteractionExecutionCount"].Value.ToString();
                    tb.TextChanged += new EventHandler(textBoxInteraction_CheckedChanged);
                    gbox.Controls.Add(tb);
                    lbl_coord += 26;
                }

                lbl_coord = 50;

                foreach (var tb in gbox.Controls.OfType<TextBox>())
                {
                    tb.Location = new Point(tb.Location.X + max_lbl_width, tb.Location.Y);
                }

                flowLayoutPanelInteractions.Controls.Add(gbox);
                
                max_lbl_width = 0;
            }


        }

        private void UpdatePOITable()
        {
            dataGridViewPOIs.Columns.Clear();
            dataGridViewPOIs.DataSource = BuildPOITable().DefaultView;

            dataGridViewPOIs.Columns[1].FillWeight = 20;
            dataGridViewPOIs.Columns[2].FillWeight = 20;
            dataGridViewPOIs.Columns[3].FillWeight = 20;
        }

        private DataTable BuildPOITable()
        {
            DataTable t = new DataTable();
            t.Columns.Add("Name");
            t.Columns.Add("Active", typeof(bool));
            t.Columns.Add("Enabled", typeof(bool));
            t.Columns.Add("Remaining cooldown");

            List<dynamic> target = level["PointsOfInterestSaveData"].Value;

            foreach (var poi in level_info.PointsOfInterest)
            {
                object[] row = new object[t.Columns.Count];
                row[0] = poi;
                
                int index = target.FindIndex(1, x => x["PointOfInterestActorName"].Value == poi);
                if (index != -1)
                {
                    row[1] = true;
                    row[2] = target[index]["bIsPointOfInterestEnabled"].Value;
                    row[3] = target[index]["RemainingCoolDownTime"].Value;
                }
                else
                {
                    row[1] = false;
                    row[2] = false;
                    row[3] = 0;
                }
                t.Rows.Add(row);
            }
            return t;
        }

        private void UpdateWUITable()
        {
            dataGridViewWUIs.Columns.Clear();
            dataGridViewWUIs.DataSource = BuildWUITable().DefaultView;
        }

        private DataTable BuildWUITable()
        {
            DataTable t = new DataTable();
            t.Columns.Add("Name");
            t.Columns.Add("Active", typeof(bool));
            t.Columns.Add("1st vol. radius");
            t.Columns.Add("2nd vol. radius");
            t.Columns.Add("Occlusion speed");
            t.Columns.Add("Minimum occlusion");
            t.Columns.Add("Is disabled", typeof(bool));

            List<dynamic> target = level["WuiVolumeGatesSaveData"].Value;

            foreach (var wui in level_info.WuiVolumes)
            {
                object[] row = new object[t.Columns.Count];
                row[0] = wui;

                int index = target.FindIndex(1, x => x["WuiVolumeGateActorName"].Value == wui);
                if (index != -1)
                {
                    row[1] = true;
                    row[2] = target[index]["FirstVolumeRadius"].Value;
                    row[3] = target[index]["SecondVolumeRadius"].Value;
                    row[4] = target[index]["OcclusionSpeed"].Value;
                    row[5] = target[index]["MinimumOcclusion"].Value;
                    row[6] = target[index]["bDisabled"].Value;
                }
                else
                {
                    row[1] = false;
                    row[2] = 0;
                    row[3] = 0;
                    row[4] = 0;
                    row[5] = 0;
                    row[6] = false;
                }
                t.Rows.Add(row);
            }

            return t;
        }

        private void UpdateStoppedSeqTable()
        {
            dataGridViewSeqStopped.Columns.Clear();
            dataGridViewSeqStopped.DataSource = BuildStoppedSeqTable();
        }

        private DataTable BuildStoppedSeqTable()
        {
            DataTable t = new DataTable();
            
            t.Columns.Add("Name");
            t.Columns.Add("Active", typeof(bool));
            t.Columns.Add("Playback position");
            t.Columns.Add("Is loop", typeof(bool));

            List<dynamic> target = new List<dynamic>();

            if (saveVersion == SaveVersion.CaptainSpirit)
            {
                target = level["LevelChangesSaveData"].Value["PastLevelSequences"].Value;
            }
            else
            {
                target = level["LevelChangesSaveData"].Value["StoppedLevelSequences"].Value;
            }

            foreach (var seq in level_info.LevelSequences)
            {
                object[] row = new object[t.Columns.Count];
                row[0] = seq.ActorName;

                int index = target.FindIndex(1, x => x["LevelSequenceActorName"].Value == seq.ActorName);

                if(index != -1)
                {
                    row[1] = true;
                    row[2] = target[index]["PlaybackPosition"].Value;
                    row[3] = target[index]["bIsLoop"].Value;
                }
                else
                {
                    row[1] = false;
                    row[2] = 0;
                    row[3] = false;
                }
                t.Rows.Add(row);
            }
            return t;
        }

        private void UpdatePlayingSeqTable()
        {
            dataGridViewSeqPlaying.Columns.Clear();
            dataGridViewSeqPlaying.DataSource = BuildPlayingSeqTable();
            dataGridViewSeqPlaying.Columns[1].ReadOnly = true;
        }

        private DataTable BuildPlayingSeqTable()
        {
            DataTable t = new DataTable();

            t.Columns.Add("Name");
            t.Columns.Add("Slot"); //todo: test behavior of multiple sequences in same slot
            t.Columns.Add("Active", typeof(bool));
            t.Columns.Add("Playback position");

            List<dynamic> target = level["LevelChangesSaveData"].Value["PlayingLevelSequences"].Value;

            foreach (var seq in level_info.LevelSequences)
            {
                object[] row = new object[t.Columns.Count];
                row[0] = seq.ActorName;
                

                int index = target.FindIndex(1, x => x["LevelSequenceActorName"].Value == seq.ActorName);

                if (index != -1)
                {
                    row[1] = target[index]["IGESlotName"].Value;
                    row[2] = true;
                    row[3] = target[index]["PlaybackPosition"].Value;
                }
                else
                {
                    row[1] = string.IsNullOrEmpty(seq.SlotName) ? "(unknown)" : seq.SlotName;
                    row[2] = false;
                    row[3] = 0;
                }
                t.Rows.Add(row);
            }
            return t;
        }

        private void UpdateBindingTables()
        {
            DataGridView grid;
            foreach (var type in new string[] {"OnPlay", "OnStop", "OnHasLooped", "OnEvent" })
            {
                grid = (DataGridView)tabControlSequences.TabPages["tabPageSeq" + type].Controls[0];
                grid.Columns.Clear();

                grid.Columns.Add(new DataGridViewTextBoxColumn() {Name = "Name", HeaderText = "Name" });
                var func_list = new List<string>() { "(none)" };
                func_list.AddRange(level_info.LevelFunctions.Where(x => x.Type == type).Select(x => x.Name));
                var comboCol = new DataGridViewComboBoxColumn()
                {
                    Name = "Current function",
                    HeaderText = "Current function",
                    DataSource = func_list
                };

                grid.Columns.Add(comboCol);
                grid.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Default function", HeaderText = "Default function", ReadOnly = true });

                List<dynamic> target = level["LevelChangesSaveData"].Value[$"LevelSequence{type}BindingsSaveData"].Value;

                foreach (var seq in level_info.LevelSequences)
                {
                    object[] row = new object[grid.Columns.Count];
                    row[0] = seq.ActorName;
                    int index = target.FindIndex(1, x => x["LevelSequenceActorName"].Value == seq.ActorName);
                    var cur_func = index == -1 ? "(none)" : target[index]["LevelScriptFunctionName"].Value;
                    if (!func_list.Contains(cur_func)) func_list.Add(cur_func);
                    row[1] = cur_func;
                    string defFunc = seq.GetType().GetProperty(type + "FunctionName").GetValue(seq).ToString();
                    row[2] = string.IsNullOrEmpty(defFunc) ? "(unknown)" : defFunc;
                    grid.Rows.Add(row);
                }
            }
        }

        private void UpdateDelayedEventsTable()
        {
            dataGridViewDelayedEvents.Columns.Clear();
            dataGridViewDelayedEvents.Columns.AddRange(
                new DataGridViewTextBoxColumn() { Name = "Name", HeaderText = "Name", ReadOnly = true, FillWeight = 10 },
                new DataGridViewTextBoxColumn() { Name = "Default function", HeaderText = "Default function", ReadOnly = true, FillWeight = 20 },
                new DataGridViewTextBoxColumn() { Name = "Link ID", HeaderText = "Output link ID", FillWeight = 5 },
                new DataGridViewTextBoxColumn() { Name = "Remaining delay duration", HeaderText = "Remaining delay duration", FillWeight = 5 },
                new DataGridViewCheckBoxColumn() { Name = "Affected by skip", HeaderText = "Affected by skip", FillWeight = 5 }
                );

            var func_list = new List<string>() { "(none)" };
            func_list.AddRange(level_info.LevelFunctions.Where(x => x.Type == "DelayedEvent").Select(x => x.Name));
            var combocol = new DataGridViewComboBoxColumn()
            {
                Name = "Current function",
                HeaderText = "Current function",
                DataSource = func_list,
                FillWeight = 20
            };

            dataGridViewDelayedEvents.Columns.Insert(1, combocol);

            List<dynamic> target = level["DelayedEventsSaveData"].Value["DelayedEvents"].Value;

            foreach (var evt in level_info.DelayedEvents)
            {
                object[] row = new object[dataGridViewDelayedEvents.Columns.Count];
                row[0] = evt.ID;
                row[2] = evt.FunctionName;

                int index = target.FindIndex(1, x => x["DelayedEventID"].Value == evt.ID);
                if (index != -1)
                {
                    var cur_func = target[index]["ExecutionFunction"].Value;
                    if (!func_list.Contains(cur_func)) func_list.Add(cur_func);
                    row[1] = cur_func;
                    row[3] = target[index]["OutputLinkID"].Value;
                    row[4] = target[index]["RemainingDelayDuration"].Value;
                    row[5] = target[index]["bAffectedBySkipTime"].Value;
                }
                else
                {
                    row[1] = "(none)";
                    row[3] = 0;
                    row[4] = 0;
                    row[5] = false;
                }
                dataGridViewDelayedEvents.Rows.Add(row);
            }
        }
        #endregion

        #region Editing

        private void checkBoxIntObject_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            List<dynamic> root = level["InteractionsSaveData"].Value["InteractionActors"].Value;
            var ind = root.FindIndex(1, x => x["InteractionActorName"].Value == cb.Parent.Text);
            bool state = cb.Checked;
            switch (cb.Text)
            {
                case "Active":
                    {
                        if (state == false)
                        {
                            root.RemoveAt(ind);
                        }
                        else
                        {
                            AddInteractionActor(cb.Parent.Text);
                        }
                        break;
                    }
                case "Enabled":
                    {
                        ((CheckBox)cb.Parent.Controls["Active"]).Checked = true;
                        ind = root.FindIndex(1, x => x["InteractionActorName"].Value == cb.Parent.Text);
                        root[ind]["bIsEnable"].Value = state;
                        break;
                    }
                case "Destroyed":
                    {
                        ((CheckBox)cb.Parent.Controls["Active"]).Checked = true;
                        ind = root.FindIndex(1, x => x["InteractionActorName"].Value == cb.Parent.Text);
                        root[ind]["bIsConsideredDestroyed"].Value = state;
                        break;
                    }
                default:
                    {
                        throw new Exception("Unknown checkbox");
                    }
            }
            cb.BackColor = Color.LightGoldenrodYellow;
            changesMade = true;
        }

        private void textBoxInteraction_CheckedChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            string[] info = tb.Tag.ToString().Split(new string[] { "::" }, 3, StringSplitOptions.RemoveEmptyEntries);

            if (string.IsNullOrEmpty(tb.Text))
            {
                List<dynamic> root = level["InteractionsSaveData"].Value["InteractionActors"].Value;
                var ind1 = root.FindIndex(1, x => x["InteractionActorName"].Value == info[0]);
                List<dynamic> int_list = root[ind1][info[1]+"Interactions"].Value;
                var ind2 = int_list.FindIndex(1, x => x["InteractionGuid"].Value["Guid"].ToString() == info[2]);
                int_list.RemoveAt(ind2);
                tb.BackColor = Color.LightGoldenrodYellow;
            }
            else
            {
                int value = 0;
                try
                {
                    value = Convert.ToInt32(tb.Text);
                    tb.BackColor = Color.LightGoldenrodYellow;
                }
                catch
                {
                    tb.BackColor = Color.Red;
                }

                List<dynamic> root = level["InteractionsSaveData"].Value["InteractionActors"].Value;
                var ind1 = root.FindIndex(1, x => x["InteractionActorName"].Value == info[0]);
                if (ind1 == -1)
                {
                    AddInteractionActor(info[0]);
                    ind1 = root.Count - 1;
                }

                List<dynamic> int_list = root[ind1][info[1]+"Interactions"].Value;
                var ind2 = int_list.FindIndex(1, x => x["InteractionGuid"].Value["Guid"].ToString() == info[2]);

                if (ind2 == -1)
                {
                    Guid guid = new Guid(info[2]);
                    string inter_name = info[1] == "Classic" ? level_info.Interactions.Find(x => x.Name == info[0]).ClassicInteractions[guid]
                                                             : level_info.Interactions.Find(x => x.Name == info[0]).DanielInteractions[guid];
                    Dictionary<string, dynamic> new_inter = new Dictionary<string, dynamic>()
                    {
                        {
                            "InteractionNameForDebug", new NameProperty()
                            {
                                Name = "InteractionNameForDebug",
                                Value = inter_name
                            }
                        },
                        {
                            "InteractionGuid", new StructProperty()
                            {
                                Name = "InteractionGuid",
                                ElementType = "Guid",
                                Value = new Dictionary<string, dynamic>()
                                {
                                    { "Guid",  guid}
                                }
                            }
                        },
                        {
                            "InteractionExecutionCount", new IntProperty()
                            {
                                Name = "InteractionExecutionCount",
                                Value = 0
                            }
                        }
                    };
                    int_list.Add(new_inter);
                    ind2 = int_list.Count - 1;
                }

                int_list[ind2]["InteractionExecutionCount"].Value = value;
            }

            changesMade = true;
        }

        private void AddInteractionActor(string name)
        {
            List<dynamic> root = level["InteractionsSaveData"].Value["InteractionActors"].Value;
            Dictionary<string, dynamic> new_actor = new Dictionary<string, dynamic>()
            {
                { "InteractionActorName", new NameProperty
                    {
                        Name = "InteractionActorName",
                        Value = name
                    }
                },
                {
                    "bIsEnable", new BoolProperty
                    {
                        Name = "bIsEnable",
                        Value = true
                    }
                },
                {
                    "bIsConsideredDestroyed", new BoolProperty
                    {
                        Name = "bIsConsideredDestroyed",
                        Value = false
                    }
                },
                {
                    "ClassicInteractions", new ArrayProperty
                    {
                        Name = "ClassicInteractions",
                        ElementType = "StructProperty",
                        Value = new List<dynamic>
                        {
                            new  Dictionary<string, object>()
                            {
                                { "struct_name", "ClassicInteractions" },
                                {"struct_type", "StructProperty" },
                                {"struct_length", 0 },
                                {"struct_eltype", "LIS2InteractionSaveData" },
                                {"struct_unkbytes", new byte[17] }
                            }
                        }
                    }
                },
                {
                    "DanielInteractions", new ArrayProperty
                    {
                        Name = "DanielInteractions",
                        ElementType = "StructProperty",
                        Value = new List<dynamic>
                        {
                            new  Dictionary<string, object>()
                            {
                                { "struct_name", "DanielInteractions" },
                                {"struct_type", "StructProperty" },
                                {"struct_length", 0 },
                                {"struct_eltype", "LIS2InteractionSaveData" },
                                {"struct_unkbytes", new byte[17] }
                            }
                        }
                    }
                }
            };
            root.Add(new_actor);
        }

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

        private void dataGridViewPOIs_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                if (!float.TryParse(dataGridViewPOIs[3, e.RowIndex].Value.ToString(), out float result))
                {
                    MessageBox.Show(Resources.BadValueMessage, "Error");
                    newCellValue = origCellValue;
                    dataGridViewPOIs[e.ColumnIndex, e.RowIndex].Value = origCellValue;
                }
                else
                {
                    newCellValue = result;
                }
            }
            else
            {
                newCellValue = dataGridViewPOIs[e.ColumnIndex, e.RowIndex].Value;
            }

            if (newCellValue.ToString() != origCellValue.ToString())
            {
                var name = dataGridViewPOIs[0, e.RowIndex].Value.ToString();
                EditPOIValue(name, e.ColumnIndex, newCellValue);
                dataGridViewPOIs[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.LightGoldenrodYellow;

                if (e.ColumnIndex != 1)
                {
                    dataGridViewPOIs[1, e.RowIndex].Value = true;
                    dataGridViewPOIs[2, e.RowIndex].Value = true;
                }
                else if (Convert.ToBoolean(newCellValue) == true)
                {
                    EditPOIValue(name, 2, dataGridViewPOIs[2, e.RowIndex].Value);
                    EditPOIValue(name, 3, dataGridViewPOIs[2, e.RowIndex].Value);
                }
            }
        }

        private void dataGridViewWUIs_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int colIndex = e.ColumnIndex;
            if (colIndex > 1 && colIndex < 6)
            {
                if (!float.TryParse(dataGridViewWUIs[colIndex, e.RowIndex].Value.ToString(), out float result))
                {
                    MessageBox.Show(Resources.BadValueMessage, "Error");
                    newCellValue = origCellValue;
                    dataGridViewWUIs[e.ColumnIndex, e.RowIndex].Value = origCellValue;
                }
                else
                {
                    newCellValue = result;
                }
            }
            else
            {
                newCellValue = dataGridViewWUIs[e.ColumnIndex, e.RowIndex].Value;
            }

            if (newCellValue.ToString() != origCellValue.ToString())
            {
                var name = dataGridViewWUIs[0, e.RowIndex].Value.ToString();
                EditWUIValue(name, e.ColumnIndex, newCellValue);
                dataGridViewWUIs[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.LightGoldenrodYellow;

                if (e.ColumnIndex != 1)
                {
                    dataGridViewWUIs[1, e.RowIndex].Value = true;
                }
                else if (Convert.ToBoolean(newCellValue) == true)
                {
                    for (int i=2; i<dataGridViewWUIs.ColumnCount; i++)
                    {
                        EditWUIValue(name, i, dataGridViewWUIs[i, e.RowIndex].Value);
                    }
                }
            }
        }

        private void dataGridViewSeqStopped_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int colIndex = e.ColumnIndex;
            if(colIndex == 2)
            {
                if (!int.TryParse(dataGridViewSeqStopped[colIndex, e.RowIndex].Value.ToString(), out int result))
                {
                    MessageBox.Show(Resources.BadValueMessage, "Error");
                    newCellValue = origCellValue;
                    dataGridViewSeqStopped[colIndex, e.RowIndex].Value = origCellValue;
                }
                else
                {
                    newCellValue = result;
                }
            }
            else
            {
                newCellValue = dataGridViewSeqStopped[colIndex, e.RowIndex].Value;
            }

            if (newCellValue.ToString() != origCellValue.ToString())
            {
                var name = dataGridViewSeqStopped[0, e.RowIndex].Value.ToString();
                EditSeqStoppedValue(name, colIndex, newCellValue);
                dataGridViewSeqStopped[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.LightGoldenrodYellow;

                if (e.ColumnIndex != 1)
                {
                    dataGridViewSeqStopped[1, e.RowIndex].Value = true;
                }
                else if (Convert.ToBoolean(newCellValue) == true)
                {
                    for (int i = 2; i < dataGridViewSeqStopped.ColumnCount; i++)
                    {
                        EditSeqStoppedValue(name, i, dataGridViewSeqStopped[i, e.RowIndex].Value);
                    }
                }
            }
        }

        private void dataGridViewSeqPlaying_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int colIndex = e.ColumnIndex;
            if (colIndex == 3)
            {
                if (!float.TryParse(dataGridViewSeqPlaying[colIndex, e.RowIndex].Value.ToString(), out float result))
                {
                    MessageBox.Show(Resources.BadValueMessage, "Error");
                    newCellValue = origCellValue;
                    dataGridViewSeqPlaying[colIndex, e.RowIndex].Value = origCellValue;
                }
                else
                {
                    newCellValue = result;
                }
            }
            else
            {
                newCellValue = dataGridViewSeqPlaying[colIndex, e.RowIndex].Value;
            }

            if (newCellValue.ToString() != origCellValue.ToString())
            {
                var name = dataGridViewSeqPlaying[0, e.RowIndex].Value.ToString();
                EditSeqPlayingValue(name, colIndex, newCellValue);
                dataGridViewSeqPlaying[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.LightGoldenrodYellow;

                if (e.ColumnIndex != 2)
                {
                    dataGridViewSeqPlaying[2, e.RowIndex].Value = true;
                }
                else if (Convert.ToBoolean(newCellValue) == true)
                {
                    EditSeqPlayingValue(name, 3, dataGridViewSeqPlaying[3, e.RowIndex].Value);
                }
            }
        }

        private void dataGridViewSeqOnX_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            string type = grid.Tag.ToString();

            newCellValue = grid[e.ColumnIndex, e.RowIndex].Value.ToString();

            if (newCellValue.ToString() != origCellValue.ToString())
            {
                var name = grid[0, e.RowIndex].Value.ToString();
                EditBinding(name, type, newCellValue.ToString());
                grid[0, e.RowIndex].Style.BackColor = Color.LightGoldenrodYellow;
            }
        }

        private void dataGridViewDelayedEvents_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int colIndex = e.ColumnIndex;
            switch (colIndex)
            {
                case 3:
                {
                    if (!int.TryParse(dataGridViewDelayedEvents[colIndex, e.RowIndex].Value.ToString(), out int result))
                    {
                        MessageBox.Show(Resources.BadValueMessage, "Error");
                        newCellValue = origCellValue;
                        dataGridViewDelayedEvents[colIndex, e.RowIndex].Value = origCellValue;
                    }
                    else
                    {
                        newCellValue = result;
                    }

                    break;
                }
                case 4:
                {
                    if (!float.TryParse(dataGridViewDelayedEvents[colIndex, e.RowIndex].Value.ToString(), out float result))
                    {
                        MessageBox.Show(Resources.BadValueMessage, "Error");
                        newCellValue = origCellValue;
                        dataGridViewDelayedEvents[colIndex, e.RowIndex].Value = origCellValue;
                    }
                    else
                    {
                        newCellValue = result;
                    }

                    break;
                }
                default:
                    newCellValue = dataGridViewDelayedEvents[colIndex, e.RowIndex].Value;
                    break;
            }

            if (newCellValue.ToString() != origCellValue.ToString())
            {
                var name = dataGridViewDelayedEvents[0, e.RowIndex].Value.ToString();
                EditDelayedEvent(name, colIndex, newCellValue);
                dataGridViewDelayedEvents[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.LightGoldenrodYellow;

                if (e.ColumnIndex != 1)
                {
                    dataGridViewDelayedEvents[1, e.RowIndex].Value = dataGridViewDelayedEvents[2, e.RowIndex].Value;
                }
                else if (newCellValue.ToString() != "(none)")
                {
                    for (int i = 3; i < dataGridViewDelayedEvents.ColumnCount; i++)
                    {
                        EditDelayedEvent(name, i, dataGridViewDelayedEvents[i, e.RowIndex].Value);
                    }
                }
            }
        }

        private void EditPOIValue(string name, int colIndex, object value)
        {
            List<dynamic> target = level["PointsOfInterestSaveData"].Value;
            int index = target.FindIndex(1, x => x["PointOfInterestActorName"].Value == name);

            if (index == -1) //add new item
            {
                Dictionary<string, object> new_item = new Dictionary<string, object>()
                {
                    {
                        "PointOfInterestActorName", new NameProperty()
                        {
                            Name = "PointOfInterestActorName",
                            Value = name
                        }
                    },
                    {
                        "bIsPointOfInterestEnabled", new BoolProperty()
                        {
                            Name = "bIsPointOfInterestEnabled",
                            Value = colIndex == 2 ? Convert.ToBoolean(value) : true 
                        }
                    },
                    {
                        "RemainingCoolDownTime", new FloatProperty()
                        {
                            Name = "RemainingCoolDownTime",
                            Value = colIndex == 3 ? Convert.ToSingle(value) : 0
                        }
                    }
                };
                target.AddUnique(new_item);
            }
            else
            {
                if (colIndex == 1 && Convert.ToBoolean(value) == false) //Remove POI
                {
                    target.RemoveAt(index);
                }
                else
                {
                    switch (colIndex)
                    {
                        case 2:
                            {
                                target[index]["bIsPointOfInterestEnabled"].Value = Convert.ToBoolean(value);
                                break;
                            }
                        case 3:
                            {
                                target[index]["RemainingCoolDownTime"].Value = Convert.ToSingle(value);
                                break;
                            }
                    }
                }
            }
            changesMade = true;
        }

        private void EditWUIValue(string name, int colIndex, object value)
        {
            List<dynamic> target = level["WuiVolumeGatesSaveData"].Value;
            int index = target.FindIndex(1, x => x["WuiVolumeGateActorName"].Value == name);

            if (index == -1) //add new item
            {
                Dictionary<string, object> new_item = new Dictionary<string, object>()
                {
                    {
                        "WuiVolumeGateActorName", new NameProperty()
                        {
                            Name = "WuiVolumeGateActorName",
                            Value = name
                        }
                    },
                    {
                        "FirstVolumeRadius", new FloatProperty()
                        {
                            Name = "FirstVolumeRadius",
                            Value = colIndex == 2 ? Convert.ToSingle(value) : 0
                        }
                    },
                    {
                        "SecondVolumeRadius", new FloatProperty()
                        {
                            Name = "SecondVolumeRadius",
                            Value = colIndex == 3 ? Convert.ToSingle(value) : 0
                        }
                    },
                    {
                        "OcclusionSpeed", new FloatProperty()
                        {
                            Name = "OcclusionSpeed",
                            Value = colIndex == 4 ? Convert.ToSingle(value) : 0
                        }
                    },
                    {
                        "MinimumOcclusion", new FloatProperty()
                        {
                            Name = "MinimumOcclusion",
                            Value = colIndex == 5 ? Convert.ToSingle(value) : 0
                        }
                    },
                    {
                        "bDisabled", new BoolProperty()
                        {
                            Name = "bDisabled",
                            Value = colIndex == 6 ? Convert.ToBoolean(value) : false
                        }
                    },
                };
                target.AddUnique(new_item);
            }
            else
            {
                if (colIndex == 1 && Convert.ToBoolean(value) == false) //Remove WUI volume
                {
                    target.RemoveAt(index);
                }
                else
                {
                    switch (colIndex)
                    {
                        case 2:
                            {
                                target[index]["FirstVolumeRadius"].Value = Convert.ToSingle(value);
                                break;
                            }
                        case 3:
                            {
                                target[index]["SecondVolumeRadius"].Value = Convert.ToSingle(value);
                                break;
                            }
                        case 4:
                            {
                                target[index]["OcclusionSpeed"].Value = Convert.ToSingle(value);
                                break;
                            }
                        case 5:
                            {
                                target[index]["MinimumOcclusion"].Value = Convert.ToSingle(value);
                                break;
                            }
                        case 6:
                            {
                                target[index]["bDisabled"].Value = Convert.ToBoolean(value);
                                break;
                            }
                    }
                }
            }
            changesMade = true;
        }

        private void EditSeqStoppedValue(string name, int colIndex, object value)
        {
            List<dynamic> target = saveVersion == SaveVersion.CaptainSpirit ?
                level["LevelChangesSaveData"].Value["PastLevelSequences"].Value :
            level["LevelChangesSaveData"].Value["StoppedLevelSequences"].Value;
                
            int index = target.FindIndex(1, x => x["LevelSequenceActorName"].Value == name);

            if (index == -1)//Add new item
            {
                Dictionary<string, dynamic> new_item = new Dictionary<string, dynamic>()
                {
                    {
                        "LevelSequenceActorName", new NameProperty
                        {
                                Name = "LevelSequenceActorName",
                                Value = name
                        }
                    },
                    {
                        "PlaybackPosition", new FloatProperty
                        {
                                Name = "PlaybackPosition",
                                Value = colIndex == 2 ? Convert.ToSingle(newCellValue) : 0
                        }
                    },
                    {
                        "bIsLoop", new BoolProperty
                        {
                                Name = "bIsLoop",
                                Value = colIndex == 3 ? Convert.ToBoolean(newCellValue) : false
                        }
                    },
                };
                if (saveVersion >= SaveVersion.LIS_E1)
                {
                    new_item["DebugRequesterName"] = new NameProperty
                    {
                        Name = "DebugRequesterName",
                        Value = level_info.LevelSequences.Find(x => x.ActorName == name)?.DebugRequesterName ?? "None"
                    };
                }
                target.AddUnique(new_item);
                index = target.Count - 1;
                if (saveVersion == SaveVersion.CaptainSpirit)
                {
                    ((List<dynamic>)level["LevelChangesSaveData"].Value["PastLevelChangeTypes"].Value).Add("ELIS2LevelChangeSaveDataType::ELCSDT_SequenceStopped");
                    ((List<dynamic>)level["LevelChangesSaveData"].Value["PastLevelChangeTypedIndices"].Value).Add(index-1);
                }
            }
            else
            {
                if (colIndex == 1 && Convert.ToBoolean(value) == false) //Remove sequence
                {
                    target.RemoveAt(index);

                    if (saveVersion == SaveVersion.CaptainSpirit)
                    {
                        ((List<dynamic>)level["LevelChangesSaveData"].Value["PastLevelChangeTypes"].Value).RemoveAt(index-1);
                        ((List<dynamic>)level["LevelChangesSaveData"].Value["PastLevelChangeTypedIndices"].Value).RemoveAt(index-1);
                    }
                }
                else
                {
                    switch (colIndex)
                    {
                        case 2:
                            {
                                target[index]["PlaybackPosition"].Value = Convert.ToSingle(value);
                                break;
                            }
                        case 3:
                            {
                                target[index]["bIsLoop"].Value = Convert.ToBoolean(value);
                                break;
                            }
                    }
                }
            }
            changesMade = true;
        }

        private void EditSeqPlayingValue(string name, int colIndex, object value)
        {
            List<dynamic> target = level["LevelChangesSaveData"].Value["PlayingLevelSequences"].Value;
            int index = target.FindIndex(1, x => x["LevelSequenceActorName"].Value == name);

            if (index == -1) //Add new item
            {
                Dictionary<string, dynamic> new_item = new Dictionary<string, dynamic>()
                {
                    {
                        "IGESlotName", new NameProperty
                        {
                                Name = "IGESlotName",
                                Value = GetPlayingSeqSlotName(level_info.LevelSequences.Find(x => x.ActorName == name).SlotName)
                        }
                    },
                    {
                        "LevelSequenceActorName", new NameProperty
                        {
                                Name = "LevelSequenceActorName",
                                Value = name
                        }
                    },
                    {
                        "PlaybackPosition", new FloatProperty
                        {
                                Name = "PlaybackPosition",
                                Value = colIndex == 3 ? Convert.ToSingle(newCellValue) : 0
                        }
                    },
                };
                target.AddUnique(new_item);
                index = target.Count - 1;
            }
            else
            {
                if (colIndex == 2 && Convert.ToBoolean(value) == false) //Remove sequence
                {
                    target.RemoveAt(index);
                }
                else
                {
                    target[index]["PlaybackPosition"].Value = Convert.ToSingle(value);
                }
            }
            changesMade = true;
        }
        
        private string GetPlayingSeqSlotName(string initialSlot)
        {
            
            int index;
            string slotPrefix = saveVersion >= SaveVersion.LIS_E1 ? "NoSlot_" : "None_";
            List<dynamic> target = level["LevelChangesSaveData"].Value["PlayingLevelSequences"].Value;
            if (initialSlot.StartsWith(slotPrefix))
            {
                if (!int.TryParse(initialSlot.Remove(0, slotPrefix.Length), out index))
                {
                    index = 0;
                }

                string newSlot = slotPrefix + index.ToString();
                while (target.FindIndex(1, x => x["IGESlotName"].Value == newSlot) != -1)
                {
                    index++;
                    newSlot = slotPrefix + index.ToString();
                }
                return newSlot;
            }
            else if (string.IsNullOrEmpty(initialSlot))
            {
                index = 0;

                string newSlot = slotPrefix + index.ToString();
                while (target.FindIndex(1, x => x["IGESlotName"].Value == newSlot) != -1)
                {
                    index++;
                    newSlot = slotPrefix + index.ToString();
                }
                return newSlot;
            }
            else return initialSlot;
        }

        private void EditBinding(string name, string type, string value)
        {
            List<dynamic> target = level["LevelChangesSaveData"].Value[$"LevelSequence{type}BindingsSaveData"].Value;
            int index = target.FindIndex(1, x => x["LevelSequenceActorName"].Value == name);

            if (index == -1) //add new
            {
                Dictionary<string, dynamic> new_item = new Dictionary<string, dynamic>()
                {
                     {
                        "LevelSequenceActorName", new NameProperty
                        {
                                Name = "LevelSequenceActorName",
                                Value = name
                        }
                    },
                    {
                        "LevelScriptFunctionName", new NameProperty
                        {
                                Name = "LevelScriptFunctionName",
                                Value = value
                        }
                    },
                };
                target.AddUnique(new_item);
                index = target.Count - 1;
            }
            else
            {
                if (value == "(none)") //remove
                {
                    target.RemoveAt(index);
                }
                else
                {
                    target[index]["LevelScriptFunctionName"].Value = value;
                }
            }
            changesMade = true;
        }

        private void EditDelayedEvent(string name, int colIndex, object value)
        {
            List<dynamic> target = level["DelayedEventsSaveData"].Value["DelayedEvents"].Value;
            int id = Convert.ToInt32(name);
            int index = target.FindIndex(1, x => x["DelayedEventID"].Value == id);
            var evt = level_info.DelayedEvents.Find(x => x.ID == id);

            if (index == -1) //add new item
            {
                Dictionary<string, object> new_item = new Dictionary<string, object>()
                {
                    {
                        "DelayedEventID", new IntProperty()
                        {
                            Name = "DelayedEventID",
                            Value = id
                        }
                    },
                    {
                        "LevelScriptActorName", new NameProperty()
                        {
                            Name = "LevelScriptActorName",
                            Value = evt.ActorName
                        }
                    },
                    {
                        "ExecutionFunction", new NameProperty()
                        {
                            Name = "ExecutionFunction",
                            Value = colIndex == 1 ? value.ToString() : evt.FunctionName
                        }
                    },
                    {
                        "OutputLinkID", new IntProperty()
                        {
                            Name = "OutputLinkID",
                            Value = colIndex == 3 ? Convert.ToInt32(value) : 0
                        }
                    },
                    {
                        "RemainingDelayDuration", new FloatProperty()
                        {
                            Name = "RemainingDelayDuration",
                            Value = colIndex == 4 ? Convert.ToSingle(value) : 0
                        }
                    },
                    {
                        "bAffectedBySkipTime", new BoolProperty()
                        {
                            Name = "bAffectedBySkipTime",
                            Value = colIndex == 5 ? Convert.ToBoolean(value) : false
                        }
                    },
                };
                target.AddUnique(new_item);
            }
            else
            {
                if (colIndex == 1 && value.ToString() == "(none)") //Remove POI
                {
                    target.RemoveAt(index);
                }
                else
                {
                    switch (colIndex)
                    {
                        case 1:
                            {
                                target[index]["ExecutionFunction"].Value = value.ToString();
                                break;
                            }
                        case 3:
                            {
                                target[index]["OutputLinkID"].Value = Convert.ToInt32(value);
                                break;
                            }
                        case 4:
                            {
                                target[index]["RemainingDelayDuration"].Value = Convert.ToSingle(value);
                                break;
                            }
                        case 5:
                            {
                                target[index]["bAffectedBySkipTime"].Value = Convert.ToBoolean(value);
                                break;
                            }
                    }
                }
            }
            changesMade = true;
        }

        #endregion

        private void LevelEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            dataGridViewPOIs.EndEdit();
            dataGridViewWUIs.EndEdit();
            dataGridViewSeqStopped.EndEdit();
            dataGridViewSeqPlaying.EndEdit();
            dataGridViewSeqOnStop.EndEdit();
            dataGridViewSeqOnPlay.EndEdit();
            dataGridViewSeqOnHasLooped.EndEdit();
            dataGridViewSeqOnEvent.EndEdit();
        }

        SearchForm searchForm;

        private void LevelEditForm_KeyPress(object sender, KeyPressEventArgs e)
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
            else if (e.KeyChar == 27)
            {
                Close();
            }
        }
    }
}
