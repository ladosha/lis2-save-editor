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
using System.IO;

namespace lis2_save_editor
{
    public partial class SaveSelectionForm : Form
    {
        public SaveSelectionForm(string[] steamIdFolders)
        {
            InitializeComponent();
            _steamIdFolders = steamIdFolders;
        }

        private GameSave _gameSave;
        private string[] _steamIdFolders;
        public string savePath = null;

        private string SelectedSteamId { get; set; }

        private SaveSlot? SelectedSlot { get; set; }

        private string SelectedGame;

        private readonly Dictionary<SaveSlot, bool> _saveSlotAvailability = new Dictionary<SaveSlot, bool>();

        private void SaveSelectionForm_Load(object sender, EventArgs e)
        {
            if (savePath != null)
            {
                SelectedSteamId = GetSteamIdFromPath(savePath);
                SelectedSlot = GetSlotFromPath(savePath);
                SelectedGame = GetGameNameFromPath(savePath);
            }

            comboBoxSteamIds.Items.Clear();
            foreach(string id in _steamIdFolders)
            {
                comboBoxSteamIds.Items.Add(id.Substring(id.LastIndexOf('\\')+1));
            }

            if (SelectedSteamId != null && comboBoxSteamIds.Items.Contains(SelectedSteamId))
            {
                comboBoxSteamIds.SelectedItem = SelectedSteamId;
            }
            else
            {
                comboBoxSteamIds.SelectedIndex = 0;
            }
        }

        private void SaveSelectionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // If slot is not selected and at least one slot is available
            if (SelectedSlot == null && _saveSlotAvailability.Any(o => o.Value))
            {
                MessageBox.Show("Please select a slot!");
                e.Cancel = true;
            }

            if (SelectedSlot != null)
            {
                savePath = GetSaveFilePath(SelectedGame, SelectedSlot);
            }
        }

        private void comboBoxSteamIds_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedSteamId = comboBoxSteamIds.SelectedItem.ToString();

            radioButtonCS.Enabled = File.Exists(GetSaveFilePath("CaptainSpirit", SaveSlot.First));
            radioButtonLIS2.Enabled = false;

            foreach (SaveSlot slot in Enum.GetValues(typeof(SaveSlot)))
            {
                if (File.Exists(GetSaveFilePath("LIS2", slot)))
                {
                    radioButtonLIS2.Enabled = true;
                    break;
                }
            }

            radioButtonCS.Checked = false;
            radioButtonLIS2.Checked = false;

            if (SelectedGame == "CaptainSpirit")
            {
                radioButtonCS.Checked = true;
            }
            else if (SelectedGame == "LIS2")
            {
                radioButtonLIS2.Checked = true;
            }
        }

        private void radioButtonGame_CheckedChanged(object sender, EventArgs e)
        {
            labelStatus.Visible = false;

            if (radioButtonCS.Checked)
            {
                SelectedGame = "CaptainSpirit";

                radioButtonSlot1.Enabled = true;
                radioButtonSlot2.Enabled = false;
                radioButtonSlot3.Enabled = false;
                radioButtonSlot4.Enabled = false;
                radioButtonSlot5.Enabled = false;

                radioButtonSlot1.Checked = true;
                InterpretHeader();
            }

            else if (radioButtonLIS2.Checked)
            {
                SelectedGame = "LIS2";

                foreach (SaveSlot slot in Enum.GetValues(typeof(SaveSlot)))
                {
                    _saveSlotAvailability[slot] =
                        File.Exists(GetSaveFilePath("LIS2", slot));
                }

                radioButtonSlot1.Enabled = _saveSlotAvailability[SaveSlot.First];
                radioButtonSlot2.Enabled = _saveSlotAvailability[SaveSlot.Second];
                radioButtonSlot3.Enabled = _saveSlotAvailability[SaveSlot.Third];
                radioButtonSlot4.Enabled = _saveSlotAvailability[SaveSlot.Fourth];
                radioButtonSlot5.Enabled = _saveSlotAvailability[SaveSlot.Fifth];

                radioButtonSlot1.Checked = false;
                radioButtonSlot2.Checked = false;
                radioButtonSlot3.Checked = false;
                radioButtonSlot4.Checked = false;
                radioButtonSlot5.Checked = false;

                if (SelectedSlot != null)
                {
                    switch (SelectedSlot)
                    {
                        case SaveSlot.First:
                            radioButtonSlot1.Checked = true;
                            break;
                        case SaveSlot.Second:
                            radioButtonSlot2.Checked = true;
                            break;
                        case SaveSlot.Third:
                            radioButtonSlot3.Checked = true;
                            break;
                        case SaveSlot.Fourth:
                            radioButtonSlot4.Checked = true;
                            break;
                        case SaveSlot.Fifth:
                            radioButtonSlot5.Checked = true;
                            break;
                    }
                }
                else
                {
                    if (_saveSlotAvailability[SaveSlot.First])
                    {
                        radioButtonSlot1.Checked = true;
                    }
                    else if (_saveSlotAvailability[SaveSlot.Second])
                    {
                        radioButtonSlot2.Checked = true;
                    }
                    else if (_saveSlotAvailability[SaveSlot.Third])
                    {
                        radioButtonSlot3.Checked = true;
                    }
                    else if (_saveSlotAvailability[SaveSlot.Fourth])
                    {
                        radioButtonSlot4.Checked = true;
                    }
                    else if (_saveSlotAvailability[SaveSlot.Fifth])
                    {
                        radioButtonSlot5.Checked = true;
                    }
                }
            }
            InterpretHeader();
        }

        private void radioButtonSlot_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonSlot1.Checked)
            {
                SelectedSlot = SaveSlot.First;
            }
            else if (radioButtonSlot2.Checked)
            {
                SelectedSlot = SaveSlot.Second;
            }
            else if (radioButtonSlot3.Checked)
            {
                SelectedSlot = SaveSlot.Third;
            }
            else if (radioButtonSlot4.Checked)
            {
                SelectedSlot = SaveSlot.Fourth;
            }
            else if (radioButtonSlot5.Checked)
            {
                SelectedSlot = SaveSlot.Fifth;
            }

            if(((RadioButton)sender).Checked)
            {
                InterpretHeader();
            }
            
        }

        private void InterpretHeader()
        {
            if (SelectedSlot == null)
            {
                labelStatus.Text = "";
                return;
            }

            var save_path = GetSaveFilePath(SelectedGame, SelectedSlot);

            if (!File.Exists(save_path))
            {
                labelStatus.Text = "";
                return;
            }

            _gameSave = new GameSave();
            _gameSave.ReadSaveFromFile(save_path);

            if (!_gameSave.SaveIsValid)
            {
                labelStatus.Text = "Corrupt save!";
                labelStatus.ForeColor = Color.Red;
                return;
            }

            var text = new StringBuilder();

            if(_gameSave.saveVersion == SaveVersion.LIS_E1)
            {
                var header = _gameSave.Data["HeaderSaveData"].Value;
                var episode = "Episode "+ (header["EpisodeNumber"].Value)+": "
                              + GameInfo.LIS2_EpisodeNames[Convert.ToInt32(header["EpisodeName"].Value[1].Substring(22, 1)) - 1];
                var subcontext = "";
                if (header["SubContextName"].Value.Length > 0)
                {
                    subcontext = GameInfo.LIS2_SubContextNames[header["SubContextName"].Value[1]];
                }
                text.AppendLine(episode);
                text.AppendLine(subcontext);
                text.AppendLine(((DateTime)_gameSave.Data["SaveTime"].Value["DateTime"]).ToLongDateString());
            }
            else
            {
                text.Append("Checkpoint: ");
                var cpName = _gameSave.Data["CheckpointName"].Value.Split('_');
                text.Append(cpName[cpName.Length - 1]);
            }

            labelStatus.Text = text.ToString();
            labelStatus.Visible = true;

        }

        public static string GetSteamIdFromPath(string path)
        {
            var re = new Regex(@".*\\Dontnod\\(?<steamId>\d+).*");
            var result = re.Match(path);
            if (result.Success)
            {
                return result.Groups["steamId"].Value;
            }
            return null;
        }

        public static SaveSlot? GetSlotFromPath(string path)
        {
            var re = new Regex(@".*\\Dontnod\\\d+\\(CaptainSpirit|LIS2)\\Saved\\SaveGames\\GameSave_Slot(?<slotNumber>\d{1}).*");
            var result = re.Match(path);
            if (result.Success)
            {
                int slotNumber;
                if (!int.TryParse(result.Groups["slotNumber"].Value, out slotNumber))
                {
                    return null;
                }
                if (!Enum.IsDefined(typeof(SaveSlot), slotNumber))
                {
                    return null;
                }
                return (SaveSlot)slotNumber;
            }
            return null;
        }

        public static string GetGameNameFromPath(string path)
        {
            var re = new Regex(@".*\\Dontnod\\\d+\\(?<game>\w+).*");
            var result = re.Match(path);
            if (result.Success)
            {
                return result.Groups["game"].Value;
            }
            return null;
        }

        public string GetSaveFilePath(string game, SaveSlot? slot)
        {
            string path = Path.Combine(
                _steamIdFolders[comboBoxSteamIds.SelectedIndex],
                game,
                $"Saved\\SaveGames\\GameSave_Slot{(int)slot}.sav"
                );
            return path;
        }

    }

    public enum SaveSlot
    {
        First,
        Second,
        Third,
        Fourth,
        Fifth
    }
}
