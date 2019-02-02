using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using lis2_save_editor.Properties;
//using Newtonsoft.Json;

namespace lis2_save_editor
{
    public enum SaveVersion : byte
    {
        CaptainSpirit = 8,
        LIS_E1 = 11,
        LIS_E2 = 13
    }

    public class SaveValidity
    {
        public bool Status { get; set; }
        public string ErrorMessage { get; set; } = "";
    }

    public class GameSave
    {
        public Dictionary<string, dynamic> Data;
        public bool SaveChangesSaved { get; set; } = true;

        readonly byte[] saveFileHeader = new byte[70] { 0x47, 0x45, 0x56, 0x41, 0x53, 0x45, 0x4E, 0x44, 0x02, 0x00, 0x00, 0x00, 0x01, 0x02, 0x00, 0x00, 0x04, 0x00, 0x10, 0x00, 0x03, 0x00, 0x00, 0x00, 0x00, 0x00, 0x13, 0x00, 0x00, 0x00, 0x2B, 0x2B, 0x55, 0x45, 0x34, 0x2B, 0x52, 0x65, 0x6C, 0x65, 0x61, 0x73, 0x65, 0x2D, 0x34, 0x2E, 0x31, 0x36, 0x00, 0x11, 0x00, 0x00, 0x00, 0x4C, 0x49, 0x53, 0x32, 0x47, 0x61, 0x6D, 0x65, 0x53, 0x61, 0x76, 0x65, 0x44, 0x61, 0x74, 0x61, 0x00 };
        byte[] gameSpecificHeader;
        public SaveVersion saveVersion;
        public SaveValidity SaveIsValid { get; set; }

        public void ReadSaveFromFile (string savePath)
        {
            var fileContent = File.ReadAllBytes(savePath);
            MemoryStream file = new MemoryStream(fileContent);
            BinaryReader reader = new BinaryReader(file);

            SaveIsValid = new SaveValidity() { Status = true };

            //check if file starts with header
            for (int i = 0; i < saveFileHeader.Length; i++)
            {
                if (reader.ReadByte() != saveFileHeader[i])
                {
                    SaveIsValid.Status = false;
                    reader.BaseStream.Position = 49;
                    try
                    {
                        if (reader.ReadUE4String() == "LIS2SettingsSaveData")
                        {
                            SaveIsValid.ErrorMessage = Resources.OpenedSettingsFileError;
                        }
                        else
                        {
                            SaveIsValid.ErrorMessage = Resources.SaveHeaderMismatchError;
                        }
                    }
                    catch
                    {
                        SaveIsValid.ErrorMessage = Resources.SaveHeaderMismatchError;
                    }
                    return;
                }
            }

            gameSpecificHeader = reader.ReadBytes(12);

            if (!Enum.IsDefined(typeof(SaveVersion), gameSpecificHeader[8]))
            {
                SaveIsValid.Status = false;
                SaveIsValid.ErrorMessage = Resources.SaveVersionUnknownError;
            }
            saveVersion = (SaveVersion)gameSpecificHeader[8];

            Data = new Dictionary<string, dynamic>();

            try
            {
                while (reader.BaseStream.Position < reader.BaseStream.Length - 13) //Final None string and 4 empty bytes shouldn't be part of the data
                {
                    dynamic prop = reader.ParseProperty();
                    Data.Add(prop.Name, prop);
                }
            }
            catch (Exception e)
            {
                SaveIsValid.Status = false;
                SaveIsValid.ErrorMessage = $"Exception - {e.Message}";
            }

            //string facts = GenerateFactsSQL();

            //string outf = GenerateOutfitSQL();

            //string inv = GenerateInventorySQL();

            //string levsql = GenerateLevelSQL();

            //string cinsql = GenerateCinematicSQL();

            //string drawsql = GenerateDrawingSQL();

            //ReadFacts();

            //var sp = GenerateSeenPicsSQL();

            //File.AppendAllText($"FORDB-{Guid.NewGuid()}.txt", facts + outf + inv + levsql);
            //File.AppendAllText("FORDB.txt", sp);

            //string json = JsonConvert.SerializeObject(Data, Formatting.Indented);
            //File.WriteAllText("data_" + Path.GetFileNameWithoutExtension(savePath)+".json", json);
        }

        public string GenerateFactsSQL()
        {
            StringBuilder sb = new StringBuilder();
            if (saveVersion == SaveVersion.CaptainSpirit)
            {
                sb.AppendLine("insert or ignore into CSFacts (FactGUID, AssetGUID, Name, Type) values");
            }
            else
            {
                sb.AppendLine("insert or ignore into LIS2Facts (FactGUID, AssetGUID, Name, Type) values");
            }

            var assets = Data["CurrentSubContextSaveData"].Value["FactsSaveData"].Value;
            foreach (var asset in assets.Values)
            {
                var id = asset["FactAssetId"].Value["Guid"].ToString();
                foreach (var fact in ((List<dynamic>)asset["BoolFacts"].Value).Skip(1))
                {
                    var fact_guid = fact["FactGuid"].Value["Guid"].ToString();
                    var name = fact["FactNameForDebug"].Value;
                    sb.AppendFormat("(\"{0}\", \"{1}\", \"{2}\", \"{3}\"),\n", fact_guid, id, name, "Bool");
                }
                foreach (var fact in ((List<dynamic>)asset["IntFacts"].Value).Skip(1))
                {
                    var fact_guid = fact["FactGuid"].Value["Guid"].ToString();
                    var name = fact["FactNameForDebug"].Value;
                    sb.AppendFormat("(\"{0}\", \"{1}\", \"{2}\", \"{3}\"),\n", fact_guid, id, name, "Int");
                }
                foreach (var fact in ((List<dynamic>)asset["FloatFacts"].Value).Skip(1))
                {
                    var fact_guid = fact["FactGuid"].Value["Guid"].ToString();
                    var name = fact["FactNameForDebug"].Value;
                    sb.AppendFormat("(\"{0}\", \"{1}\", \"{2}\", \"{3}\"),\n", fact_guid, id, name, "Float");
                }
                foreach (var fact in ((List<dynamic>)asset["EnumFacts"].Value).Skip(1))
                {
                    var fact_guid = fact["FactGuid"].Value["Guid"].ToString();
                    var name = fact["FactNameForDebug"].Value;
                    sb.AppendFormat("(\"{0}\", \"{1}\", \"{2}\", \"{3}\"),\n", fact_guid, id, name, "Enum");
                }
            }

            if (saveVersion >= SaveVersion.LIS_E1)
            {
                for (int i = 1; i <= Data["CheckpointHistory"].ElementCount; i++)
                {
                    assets = Data["CheckpointHistory"].Value[i]["FactsSaveData"].Value;
                    foreach (var asset in assets.Values)
                    {
                        var id = asset["FactAssetId"].Value["Guid"].ToString();
                        foreach (var fact in ((List<dynamic>)asset["BoolFacts"].Value).Skip(1))
                        {
                            var fact_guid = fact["FactGuid"].Value["Guid"].ToString();
                            var name = fact["FactNameForDebug"].Value;
                            sb.AppendFormat("(\"{0}\", \"{1}\", \"{2}\", \"{3}\"),\n", fact_guid, id, name, "Bool");
                        }
                        foreach (var fact in ((List<dynamic>)asset["IntFacts"].Value).Skip(1))
                        {
                            var fact_guid = fact["FactGuid"].Value["Guid"].ToString();
                            var name = fact["FactNameForDebug"].Value;
                            sb.AppendFormat("(\"{0}\", \"{1}\", \"{2}\", \"{3}\"),\n", fact_guid, id, name, "Int");
                        }
                        foreach (var fact in ((List<dynamic>)asset["FloatFacts"].Value).Skip(1))
                        {
                            var fact_guid = fact["FactGuid"].Value["Guid"].ToString();
                            var name = fact["FactNameForDebug"].Value;
                            sb.AppendFormat("(\"{0}\", \"{1}\", \"{2}\", \"{3}\"),\n", fact_guid, id, name, "Float");
                        }
                        foreach (var fact in ((List<dynamic>)asset["EnumFacts"].Value).Skip(1))
                        {
                            var fact_guid = fact["FactGuid"].Value["Guid"].ToString();
                            var name = fact["FactNameForDebug"].Value;
                            sb.AppendFormat("(\"{0}\", \"{1}\", \"{2}\", \"{3}\"),\n", fact_guid, id, name, "Enum");
                        }
                    }
                }
            }
            sb = sb.Replace(",\n", ";\n", sb.Length - 3, 3);
            return sb.ToString();
            
        }

        public string GenerateInventorySQL()
        {
            StringBuilder sb = new StringBuilder();
            if (saveVersion == SaveVersion.CaptainSpirit)
            {
                return "";
            }
            else
            {
                sb.AppendLine("insert or ignore into LIS2Inventory (ID, Type, Owner) values");
            }

            foreach (var owner in new string[] {"Player", "BrotherAI" })
            {
                string ownerPrefix = owner == "Player" ? "Player" : "AI";

                var items = Data["CurrentSubContextSaveData"].Value[$"{owner}SaveData"].Value[$"{ownerPrefix}InventorySaveData"].Value;

                foreach(var type in new string[] { "Inventory", "BackPack", "Pockets" })
                {
                    foreach (var item in ((List<dynamic>)items[$"{type}Items"].Value).Skip(1))
                    {
                        var id = item["PickupID"].Value.ToString();
                        sb.AppendFormat("(\"{0}\", \"{1}\", \"{2}\"),\n", id, type, owner);
                    }
                }
            }

            if (saveVersion >= SaveVersion.LIS_E1)
            {
                for (int i = 1; i <= Data["CheckpointHistory"].ElementCount; i++)
                {
                    foreach (var owner in new string[] { "Player", "BrotherAI" })
                    {
                        string ownerPrefix = owner == "Player" ? "Player" : "AI";

                        var items = Data["CheckpointHistory"].Value[i][$"{owner}SaveData"].Value[$"{ownerPrefix}InventorySaveData"].Value;

                        foreach (var type in new string[] { "Inventory", "BackPack", "Pockets" })
                        {
                            foreach (var item in ((List<dynamic>)items[$"{type}Items"].Value).Skip(1))
                            {
                                var id = item["PickupID"].Value.ToString();
                                sb.AppendFormat("(\"{0}\", \"{1}\", \"{2}\"),\n", id, type, owner);
                            }
                        }
                    }
                }
            }
            sb = sb.Replace(",\n", ";\n", sb.Length - 3, 3);
            return sb.ToString();
        }

        public string GenerateDrawingSQL()
        {
            StringBuilder sb = new StringBuilder();
            if (saveVersion == SaveVersion.CaptainSpirit)
            {
                return "";
            }
            else
            {
                sb.AppendLine("insert or ignore into LIS2Drawings (Name, GUID, ZoneCount) values");
            }

            List<dynamic> items = Data["CurrentSubContextSaveData"].Value["PlayerSaveData"].Value["DrawSequenceSaveData"].Value["DrawSequenceItemSaveDatas"].Value;
            foreach (var item in items.Skip(1))
            {
                var name = item["DrawSequenceID"].Value["Name"].Value;
                var guid = item["DrawSequenceID"].Value["NameGuid"].Value["Guid"].ToString();
                var zone_cnt = item["LandscapeItemSaveDatas"].ElementCount;
                sb.AppendFormat("('{0}', '{1}', '{2}'),\n", name, guid, zone_cnt);
            }

            for (int i = 1; i <= Data["CheckpointHistory"].ElementCount; i++)
            {
                items = Data["CurrentSubContextSaveData"].Value["PlayerSaveData"].Value["DrawSequenceSaveData"].Value["DrawSequenceItemSaveDatas"].Value;
                foreach (var item in items.Skip(1))
                {
                    var name = item["DrawSequenceID"].Value["Name"].Value;
                    var guid = item["DrawSequenceID"].Value["NameGuid"].Value["Guid"].ToString();
                    var zone_cnt = item["LandscapeItemSaveDatas"].ElementCount;
                    sb.AppendFormat("('{0}', '{1}', '{2}'),\n", name, guid, zone_cnt);
                }
            }

            sb = sb.Replace(",\n", ";\n", sb.Length - 3, 3);
            return sb.ToString();
        }

        public string GenerateOutfitSQL()
        {
            if (saveVersion == SaveVersion.CaptainSpirit)
            {
                return "";
            }

            StringBuilder sb = new StringBuilder();
            StringBuilder sb2 = new StringBuilder();

            sb.AppendLine("insert or ignore into LIS2Outfits (GUID, Slot, Owner) values");
            foreach (var person in Data["CurrentSubContextSaveData"].Value["Outfits"].Value)
            {
                List<dynamic> outf_list = person.Value["Items"].Value;
                foreach (var of in outf_list.Skip(1))
                {
                    var guid = of["Guid"].Value["Guid"].ToString();
                    if (guid == Guid.Empty.ToString()) break;
                    string slot = of["Slot"].Value;
                    if (slot.Contains("Collectible_Badge"))
                    {
                        slot = "Collectible_Badge";
                    }
                    if (of["Flags"].ElementCount != 0)
                    {
                        throw new Exception("Found flags!");
                    }
                    sb.AppendFormat("(\"{0}\", \"{1}\", \"{2}\"),\n", guid, slot, person.Key);
                    sb2.AppendFormat("update LIS2Outfits set Slot = '{1}', Owner = '{2}' where GUID = '{0}';\n", guid, slot, person.Key);
                }
            }

            for (int i = 1; i <= Data["CheckpointHistory"].ElementCount; i++)
            {
                foreach (var person in Data["CheckpointHistory"].Value[i]["Outfits"].Value)
                {
                    List<dynamic> outf_list = person.Value["Items"].Value;
                    foreach (var of in outf_list.Skip(1))
                    {
                        var guid = of["Guid"].Value["Guid"].ToString();
                        if (guid == Guid.Empty.ToString()) break;
                        string slot = of["Slot"].Value;
                        if (slot.Contains("Collectible_Badge"))
                        {
                            slot = "Collectible_Badge";
                        }
                        if (of["Flags"].ElementCount != 0)
                        {
                            throw new Exception("Found flags!");
                        }
                        sb.AppendFormat("(\"{0}\", \"{1}\", \"{2}\"),\n", guid, slot, person.Key);
                        sb2.AppendFormat("update LIS2Outfits set Slot = '{1}', Owner = '{2}' where GUID = '{0}';\n", guid, slot, person.Key);
                    }
                }
            }

            sb = sb.Replace(",\n", ";\n", sb.Length-3, 3);
            return sb2.ToString() + sb.ToString();
        }

        public string GenerateLevelSQL()
        {
            StringBuilder sb = new StringBuilder();

            string table = saveVersion >= SaveVersion.LIS_E1 ? "LIS2" : "CS";

            foreach (var level in ((List<dynamic>)Data["CurrentSubContextSaveData"].Value["LevelsSaveData"].Value).Skip(1))
            {
                var lvl_name = level["LevelName"].Value;
                sb.AppendFormat("insert or ignore into {1}Levels (Name) values (\"{0}\");\n", lvl_name, table);

                //interactions
                List<dynamic> actor_list = level["InteractionsSaveData"].Value["InteractionActors"].Value;
                foreach (var actor in actor_list.Skip(1))
                {
                    var actor_name = actor["InteractionActorName"].Value;
                    sb.AppendFormat("insert or ignore into {2}InteractionActors (Name, LevelName) values (\"{0}\", \"{1}\");\n", actor_name, lvl_name, table);

                    sb.AppendFormat("insert or ignore into {0}Interactions (GUID, Name, Type, ActorName, LevelName) values\n", table);
                    foreach (var inter in ((List<dynamic>)actor["ClassicInteractions"].Value).Skip(1))
                    {
                        var int_name = inter["InteractionNameForDebug"].Value;
                        var guid = inter["InteractionGuid"].Value["Guid"].ToString();
                        sb.AppendFormat("(\"{0}\", \"{1}\", \"{2}\", \"{3}\", \"{4}\"),\n", guid, int_name, "Classic", actor_name, lvl_name);
                    }
                    foreach (var inter in ((List<dynamic>)actor["DanielInteractions"].Value).Skip(1))
                    {
                        var int_name = inter["InteractionNameForDebug"].Value;
                        var guid = inter["InteractionGuid"].Value["Guid"].ToString();
                        sb.AppendFormat("(\"{0}\", \"{1}\", \"{2}\", \"{3}\", \"{4}\"),\n", guid, int_name, "Daniel", actor_name, lvl_name);
                    }
                    sb = sb.Replace(",\n", ";\n", sb.Length - 3, 3);
                }

                //POIs
                List<dynamic> poi_list = level["PointsOfInterestSaveData"].Value;
                if (poi_list.Count > 1)
                {
                    sb.AppendFormat("insert or ignore into {0}POIs (Name, LevelName) values\n", table);
                    foreach (var poi in poi_list.Skip(1))
                    {
                        sb.AppendFormat("(\"{0}\", \"{1}\"),\n", poi["PointOfInterestActorName"].Value, lvl_name);
                    }
                    sb = sb.Replace(",\n", ";\n", sb.Length - 3, 3);
                }

                //WuiVolumes
                List<dynamic> wui_list = level["WuiVolumeGatesSaveData"].Value;
                if (wui_list.Count > 1)
                {
                    sb.AppendFormat("insert or ignore into {0}WUIs (Name, LevelName) values\n", table);
                    foreach (var wui in wui_list.Skip(1))
                    {
                        sb.AppendFormat("(\"{0}\", \"{1}\"),\n", wui["WuiVolumeGateActorName"].Value, lvl_name);
                    }
                    sb = sb.Replace(",\n", ";\n", sb.Length - 3, 3);
                }

                //LevelChanges
                Dictionary<string, dynamic> lvl_changes = level["LevelChangesSaveData"].Value;

                if (saveVersion >= SaveVersion.LIS_E1)
                {
                    foreach (var seq in ((List<dynamic>)lvl_changes["StoppedLevelSequences"].Value).Skip(1))
                    {
                        string seq_name = seq["LevelSequenceActorName"].Value;
                        string dbg_name = seq["DebugRequesterName"].Value;
                        sb.AppendFormat("insert or ignore into {0}LevelSequences (ActorName, LevelName, DebugRequesterName) values" +
                            "('{1}', '{2}', '{3}');\n", table, seq_name, lvl_name, dbg_name);
                        sb.AppendFormat("UPDATE {0}LevelSequences SET DebugRequesterName = '{1}' WHERE ActorName='{2}' AND LevelName='{3}';\n", table, dbg_name, seq_name, lvl_name);
                    }
                    //no values so far
                    //foreach (var mesh in ((List<dynamic>)lvl_changes["SpawnedStaticMeshes"].Value).Skip(1))
                    //{
                    //    throw new Exception();
                    //}

                    //foreach (var act in lvl_changes["ChangedActors"].Value)
                    //{
                    //    throw new Exception();
                    //}
                }
                else
                {
                    foreach (var seq in ((List<dynamic>)lvl_changes["PastLevelSequences"].Value).Skip(1))
                    {
                        string seq_name = seq["LevelSequenceActorName"].Value;
                        sb.AppendFormat("insert or ignore into {0}LevelSequences (ActorName, LevelName) values" +
                            "('{1}', '{2}');\n", table, seq_name, lvl_name);
                    }
                }
                foreach (var seq in ((List<dynamic>)lvl_changes["PlayingLevelSequences"].Value).Skip(1))
                {
                    string seq_name = seq["LevelSequenceActorName"].Value;
                    string slot_name = seq["IGESlotName"].Value;
                    //TEMP
                    //string stored_slot = GameInfo.LIS2_Levels.Find(x => x.Name == lvl_name).LevelSequences.Find(y => y.ActorName == seq_name).SlotName;
                    //if (stored_slot != slot_name) System.Windows.Forms.MessageBox.Show(slot_name + " != " + stored_slot);
                    //END TEMP
                    sb.AppendFormat("insert or ignore into {0}LevelSequences (ActorName, LevelName, SlotName) values" +
                        "('{1}', '{2}', '{3}');\n", table, seq_name, lvl_name, slot_name);
                    sb.AppendFormat("UPDATE {0}LevelSequences SET SlotName = '{1}' WHERE ActorName='{2}' AND LevelName='{3}';\n", table, slot_name, seq_name, lvl_name);
                }

                foreach (var t in new string[] { "Play", "Stop", "HasLooped", "Event" })
                {
                    foreach (var seq in ((List<dynamic>)lvl_changes[$"LevelSequenceOn{t}BindingsSaveData"].Value).Skip(1))
                    {
                        string seq_name = seq["LevelSequenceActorName"].Value;
                        string func_name = seq["LevelScriptFunctionName"].Value;
                        sb.AppendFormat("insert or ignore into {0}LevelSequences (ActorName, LevelName, On{4}FunctionName) values" +
                            "('{1}', '{2}', '{3}');\n", table, seq_name, lvl_name, func_name, t);
                        sb.AppendFormat("UPDATE {0}LevelSequences SET On{4}FunctionName = '{1}' WHERE ActorName='{2}' AND LevelName='{3}';\n", table, func_name, seq_name, lvl_name, t);
                        sb.AppendFormat("insert or ignore into {0}LevelFunctions (Name, LevelName, Type) values ('{1}', '{2}', '{3}');\n", table, func_name, lvl_name, $"On{t}");
                    }
                }
            }

            if (saveVersion >= SaveVersion.LIS_E1)
            {
                for (int i = 1; i <= Data["CheckpointHistory"].ElementCount; i++)
                {
                    foreach (var level in ((List<dynamic>)Data["CheckpointHistory"].Value[i]["LevelsSaveData"].Value).Skip(1))
                    {
                        var lvl_name = level["LevelName"].Value;
                        sb.AppendFormat("insert or ignore into LIS2Levels (Name) values (\"{0}\");\n", lvl_name);
                        List<dynamic> actor_list = level["InteractionsSaveData"].Value["InteractionActors"].Value;
                        foreach (var actor in actor_list.Skip(1))
                        {
                            var actor_name = actor["InteractionActorName"].Value;
                            sb.AppendFormat("insert or ignore into LIS2InteractionActors (Name, LevelName) values (\"{0}\", \"{1}\");\n", actor_name, lvl_name);

                            sb.AppendLine("insert or ignore into LIS2Interactions (GUID, Name, Type, ActorName, LevelName) values");
                            foreach (var inter in ((List<dynamic>)actor["ClassicInteractions"].Value).Skip(1))
                            {
                                var int_name = inter["InteractionNameForDebug"].Value;
                                var guid = inter["InteractionGuid"].Value["Guid"].ToString();
                                sb.AppendFormat("(\"{0}\", \"{1}\", \"{2}\", \"{3}\", \"{4}\"),\n", guid, int_name, "Classic", actor_name, lvl_name);
                            }
                            foreach (var inter in ((List<dynamic>)actor["DanielInteractions"].Value).Skip(1))
                            {
                                var int_name = inter["InteractionNameForDebug"].Value;
                                var guid = inter["InteractionGuid"].Value["Guid"].ToString();
                                sb.AppendFormat("(\"{0}\", \"{1}\", \"{2}\", \"{3}\", \"{4}\"),\n", guid, int_name, "Daniel", actor_name, lvl_name);
                            }
                            sb = sb.Replace(",\n", ";\n", sb.Length - 3, 3);
                        }
                        List<dynamic> poi_list = level["PointsOfInterestSaveData"].Value;
                        if (poi_list.Count > 1)
                        {
                            sb.AppendLine("insert or ignore into LIS2POIs (Name, LevelName) values");
                            foreach (var poi in poi_list.Skip(1))
                            {
                                sb.AppendFormat("(\"{0}\", \"{1}\"),\n", poi["PointOfInterestActorName"].Value, lvl_name);
                            }
                            sb = sb.Replace(",\n", ";\n", sb.Length - 3, 3);
                        }

                        //WuiVolumes
                        List<dynamic> wui_list = level["WuiVolumeGatesSaveData"].Value;
                        if (wui_list.Count > 1)
                        {
                            sb.AppendFormat("insert or ignore into {0}WUIs (Name, LevelName) values\n", table);
                            foreach (var wui in wui_list.Skip(1))
                            {
                                sb.AppendFormat("(\"{0}\", \"{1}\"),\n", wui["WuiVolumeGateActorName"].Value, lvl_name);
                            }
                            sb = sb.Replace(",\n", ";\n", sb.Length - 3, 3);
                        }

                        //LevelChanges
                        Dictionary<string, dynamic> lvl_changes = level["LevelChangesSaveData"].Value;
                        foreach (var seq in ((List<dynamic>)lvl_changes["StoppedLevelSequences"].Value).Skip(1))
                        {
                            string seq_name = seq["LevelSequenceActorName"].Value;
                            string dbg_name = seq["DebugRequesterName"].Value;
                            sb.AppendFormat("insert or ignore into {0}LevelSequences (ActorName, LevelName, DebugRequesterName) values" +
                                "('{1}', '{2}', '{3}');\n", table, seq_name, lvl_name, dbg_name);
                            sb.AppendFormat("UPDATE {0}LevelSequences SET DebugRequesterName = '{1}' WHERE ActorName='{2}' AND LevelName='{3}';\n", table, dbg_name, seq_name, lvl_name);
                        }
                        foreach (var seq in ((List<dynamic>)lvl_changes["PlayingLevelSequences"].Value).Skip(1))
                        {
                            string seq_name = seq["LevelSequenceActorName"].Value;
                            string slot_name = seq["IGESlotName"].Value;
                            sb.AppendFormat("insert or ignore into {0}LevelSequences (ActorName, LevelName, SlotName) values" +
                                "('{1}', '{2}', '{3}');\n", table, seq_name, lvl_name, slot_name);
                            sb.AppendFormat("UPDATE {0}LevelSequences SET SlotName = '{1}' WHERE ActorName='{2}' AND LevelName='{3}';\n", table, slot_name, seq_name, lvl_name);
                        }

                        foreach (var t in new string[] { "Play", "Stop", "HasLooped", "Event" })
                        {
                            foreach (var seq in ((List<dynamic>)lvl_changes[$"LevelSequenceOn{t}BindingsSaveData"].Value).Skip(1))
                            {
                                string seq_name = seq["LevelSequenceActorName"].Value;
                                string func_name = seq["LevelScriptFunctionName"].Value;
                                sb.AppendFormat("insert or ignore into {0}LevelSequences (ActorName, LevelName, On{4}FunctionName) values" +
                                    "('{1}', '{2}', '{3}');\n", table, seq_name, lvl_name, func_name, t);
                                sb.AppendFormat("UPDATE {0}LevelSequences SET On{4}FunctionName = '{1}' WHERE ActorName='{2}' AND LevelName='{3}';\n", table, func_name, seq_name, lvl_name, t);
                                sb.AppendFormat("insert or ignore into {0}LevelFunctions (Name, LevelName, Type) values ('{1}', '{2}', '{3}');\n", table, func_name, lvl_name, $"On{t}");
                            }
                        }

                        //foreach (var mesh in ((List<dynamic>)lvl_changes["SpawnedStaticMeshes"].Value).Skip(1))
                        //{
                        //    throw new Exception();
                        //}

                        //foreach (var act in lvl_changes["ChangedActors"].Value)
                        //{
                        //    throw new Exception();
                        //}
                    }
                }
            }

            return sb.ToString();
        }

        public string GenerateCinematicSQL()
        {
            StringBuilder sb = new StringBuilder();
            string table = saveVersion >= SaveVersion.LIS_E1 ? "LIS2" : "CS";

            if (saveVersion == SaveVersion.CaptainSpirit)
            {
                List<dynamic> cin_list = Data["CinematicHistorySaveData"].Value["SubcontextCinematicHistorySaveData"].Value["PT"]["PlayedCinematics"].Value;
                foreach (var cin in cin_list.Skip(1))
                {
                    string cin_guid = cin["Guid"].ToString();
                    sb.AppendFormat("insert or ignore into CSCinematics (GUID) values (\"{1}\");\n", table, cin_guid);
                }
            }
            else
            {
                foreach (var context in Data["CinematicHistorySaveData"].Value["SubcontextCinematicHistorySaveData"].Value)
                {
                    string context_id = context.Key;
                    foreach (var cin in ((List<dynamic>)context.Value["PlayedCinematics"].Value).Skip(1))
                    {
                        string cin_guid = cin["Key"].Value["Guid"].ToString();
                        sb.AppendFormat("insert or ignore into {0}Cinematics (GUID, SubcontextID) values (\"{1}\", \"{2}\");\n", table, cin_guid, context_id);

                        List<dynamic> cond_list = cin["Value"].Value["Conditions"].Value;
                        if (cond_list.Count > 1)
                        {
                            sb.AppendFormat("insert or ignore into {0}CinematicConditions (GUID, CinematicGUID, SubcontextID) values\n", table);
                            foreach (var cond in cond_list.Skip(1))
                            {
                                string cond_guid = cond["Key"].Value["Guid"].ToString();
                                sb.AppendFormat("(\"{0}\", \"{1}\", \"{2}\"),\n", cond_guid, cin_guid, context_id);
                            }
                            sb = sb.Replace(",\n", ";\n", sb.Length - 3, 3);
                        }
                    }
                }
            }

            return sb.ToString();
        }

        public string GenerateSeenPicsSQL()
        {
            StringBuilder sb = new StringBuilder();

            List<dynamic> root = Data["CurrentSubContextSaveData"].Value["ShowPicturesSaveData"].Value["AllShowPictureIDSeen"].Value;

            if (saveVersion == SaveVersion.CaptainSpirit)
            {
                if (root.Count > 1)
                {
                    sb.AppendLine("insert or ignore into CSSeenPictures (Name, GUID) values");
                }

                foreach (var pic in root.Skip(1))
                {
                    sb.AppendFormat("('{0}', '{1}'),\n", pic["Name"].Value, pic["NameGuid"].Value["Guid"].ToString());
                }
            }
            else
            {
                if (root.Count > 1)
                {
                    sb.AppendLine("insert or ignore into LIS2SeenPictures (Name, GUID) values");
                }

                foreach (var pic in root.Skip(1))
                {
                    sb.AppendFormat("('{0}', '{1}'),\n", pic["ShowPictureID"].Value["Name"].Value, pic["ShowPictureID"].Value["NameGuid"].Value["Guid"].ToString());
                }

                for (int i = 1; i <= Data["CheckpointHistory"].ElementCount; i++)
                {
                    root = Data["CheckpointHistory"].Value[i]["ShowPicturesSaveData"].Value["AllShowPictureIDSeen"].Value;

                    foreach (var pic in root.Skip(1))
                    {
                        sb.AppendFormat("('{0}', '{1}'),\n", pic["ShowPictureID"].Value["Name"].Value, pic["ShowPictureID"].Value["NameGuid"].Value["Guid"].ToString());
                    }
                }
            }

            if (sb.Length > 4)
            {
                sb = sb.Replace(",\n", ";\n", sb.Length - 3, 3);
            }

            return sb.ToString();
        }

        public static void ReadFacts()
        {
            var file = File.OpenRead(@"D:\exported\LIS_2\root\E1-Cooked\LevelDesign\Fact\PROM\Episode1\FD_E1_1A.uexp");
            BinaryReader br = new BinaryReader(file);
            StringBuilder sb = new StringBuilder();
            List<Guid> guids = new List<Guid>();
            br.ReadBytes(49); //change
            Guid assetguid = new Guid(br.ReadBytes(16));
            br.ReadBytes(510); //change
            while (file.Position < file.Length - 23) /*change*/
            {
                while (true)
                {
                    if (br.ReadByte() == 111) break; /*change*/
                }
                br.BaseStream.Position -= 17;
                var testBytes = br.ReadBytes(16);
                var zeroCnt = 0;
                foreach (var b in testBytes)
                {
                    if (b == 0) zeroCnt++;
                }
                if (zeroCnt < 5)
                {
                    Guid guid = new Guid(testBytes);
                    guids.Add(guid);
                }
                br.ReadByte();
            }

            var asset = GameInfo.LIS2_FactAssets[assetguid.ToString()];

            Dictionary<Guid, string> gs = new Dictionary<Guid, string>();

            foreach(var g in guids)
            {
                string name = "";
                if(asset.BoolFacts.TryGetValue(g, out name) ||
                   asset.IntFacts.TryGetValue(g, out name) ||
                   asset.FloatFacts.TryGetValue(g, out name) ||
                   asset.EnumFacts.TryGetValue(g, out name))
                {
                    try
                    {
                        gs.Add(g, name);
                    }
                    catch (ArgumentException)
                    {
                        if (gs[g] == "UNKNOWN")
                        {
                            gs[g] = name;
                        }
                        else
                        {
                            System.Windows.Forms.MessageBox.Show($"Duplicate key, old name:{gs[g]}, new name:{name}");
                        }
                    }
                }
                else
                {
                    try
                    {
                        gs.Add(g, "UNKNOWN");
                    }
                    catch (ArgumentException)
                    {
                        System.Windows.Forms.MessageBox.Show("Duplicate key");
                    }
                }
            }

            string ts = string.Join("\n", gs.Values);
        }

        public void WriteSaveToFile(string savePath)
        {
            var new_file = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(new_file);
            writer.Write(saveFileHeader);
            writer.Write(gameSpecificHeader);

            foreach (var pr in Data.Values)
            {
                BinaryWriterExtension.WriteProperty(writer, pr);
            }

            writer.WriteUE4String("None");
            writer.Write(new byte[4] { 0, 0, 0, 0 }); //4 bytes at the end

            var fileContent = new_file.ToArray();

            if (!File.Exists(savePath + @".bkp"))
            {
                File.Copy(savePath, savePath + @".bkp", false);
            }

            File.WriteAllBytes(savePath, fileContent); // Write the new file to disk

            SaveChangesSaved = true;
        }

        public void EditInventoryItem(string invType, string name, string owner, int cpIndex, int colIndex, int val)
        {
            List<dynamic> target;
            string ownerPrefix = owner == "Player" ? "Player" : "AI";

            if (cpIndex == 0)
            {
                target = Data["CurrentSubContextSaveData"].Value[$"{owner}SaveData"]
                               .Value[$"{ownerPrefix}InventorySaveData"].Value[$"{invType}Items"].Value;
            }
            else
            {
                target = Data["CheckpointHistory"].Value[cpIndex][$"{owner}SaveData"]
                               .Value[$"{ownerPrefix}InventorySaveData"].Value[$"{invType}Items"].Value;
            }
            
            int index = target.FindIndex(1, x => x["PickupID"].Value == name);

            if (index == -1) //Add new item
            {
                Dictionary<string, object> new_item = new Dictionary<string, object>
                {
                    ["PickupID"] = new NameProperty() {Name = "PickupID", Value = name},
                    ["Quantity"] = new IntProperty() {Name = "Quantity", Value = colIndex == 2 ? val : 0}
                };
                if(saveVersion >= SaveVersion.LIS_E1)
                {
                    new_item["bIsNew"] = new BoolProperty() { Name = "bIsNew", Value = colIndex == 3 ? Convert.ToBoolean(val) : false };
                }
                
                target.AddUnique(new_item);
            }
            else
            {
                switch(colIndex)
                {
                    case 1:
                        {
                            if(Convert.ToBoolean(val) == false)
                            {
                                target.RemoveAt(index);
                            }
                            break;
                        }
                    case 2:
                        {
                            target[index]["Quantity"].Value = val;
                            break;
                        }
                    case 3:
                        {
                            target[index]["bIsNew"].Value = Convert.ToBoolean(val);
                            break;
                        }
                }
            }
        }

        public void EditSeenTutorial(string name, int cpIndex, int colIndex, int value)
        {
            Dictionary<object, object> target;
            if (cpIndex == 0)
            {
                target = Data["CurrentSubContextSaveData"].Value["PlayerSaveData"]
                         .Value["AlreadySeenTutorials"].Value;
            }
            else
            {
                target = Data["CheckpointHistory"].Value[cpIndex]["PlayerSaveData"]
                         .Value["AlreadySeenTutorials"].Value;
            }
                
            if (colIndex == 1 && Convert.ToBoolean(value) == false) //remove item
            {
                target.Remove(name);
            }
            else //edit existing or add new
            {
                target[name] = value;
            }
        }

        public void EditSeenNotification(string name, int cpIndex, bool seen)
        {
            List<dynamic> target;
            if (cpIndex == 0)
            {
                target = Data["CurrentSubContextSaveData"].Value["PlayerSaveData"]
                         .Value["AlreadySeenNotifications"].Value;
            }
            else
            {
                target = Data["CheckpointHistory"].Value[cpIndex]["PlayerSaveData"]
                         .Value["AlreadySeenNotifications"].Value;
            }

            if (!seen)
            {
                target.Remove(name);
            }
            else
            {
                target.AddUnique(name);
            }
        }

        public void EditPackageProperty(string name, int cpIndex, string property, bool value)
        {
            List<dynamic> target;
            if (cpIndex == 0)
            {
                target = Data["CurrentSubContextSaveData"].Value["WorldStreamingSaveData"].Value;
            }
            else
            {
                target = Data["CheckpointHistory"].Value[cpIndex]["WorldStreamingSaveData"].Value;
            }
            int index = target.FindIndex(1, x => x["StreamingLevelPackageName"].Value == name);

            target[index][property].Value = value;
        }

        public void EditSeenPicture(string name, int cpIndex, int colIndex, bool value)
        {
            Guid guid = new Guid();
            List<dynamic> target;
            if (cpIndex == 0)
            {
                target = Data["CurrentSubContextSaveData"].Value["ShowPicturesSaveData"].Value["AllShowPictureIDSeen"].Value;
            }
            else
            {
                target = Data["CheckpointHistory"].Value[cpIndex]["ShowPicturesSaveData"].Value["AllShowPictureIDSeen"].Value;
            }

            if (saveVersion == SaveVersion.CaptainSpirit)
            {
                guid = GameInfo.CS_SeenPicturesNames[name];
                int index = target.FindIndex(1, x => x["NameGuid"].Value["Guid"] == guid);

                if (index == -1) //Add new item 
                {
                    Dictionary<string, object> new_item = new Dictionary<string, object>();
                    new_item["Name"] = new NameProperty() { Name = "Name", Value = name };
                    new_item["NameGuid"] = new StructProperty
                    {
                        Name = "NameGuid",
                        ElementType = "Guid",
                        Value = new Dictionary<string, dynamic>()
                        {
                            { "Guid", guid }
                        }
                    };
                    target.AddUnique(new_item);
                }
                else
                {
                        target.RemoveAt(index);
                }
            }
            else
            {
                guid = GameInfo.LIS2_SeenPicturesNames[name];
                int index = target.FindIndex(1, x => x["ShowPictureID"].Value["NameGuid"].Value["Guid"] == guid);

                if (index == -1) //Add new item 
                {
                    Dictionary<string, object> new_item = new Dictionary<string, object>();
                    new_item["ShowPictureID"] = new StructProperty
                    {
                        Name = "ShowPictureID",
                        ElementType = "DNERefName",
                        Value = new Dictionary<string, dynamic>()
                        {
                            {"Name", new NameProperty() { Name = "Name", Value = name } },

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
                    new_item["bWasCollectedDuringCollectibleMode"] = new BoolProperty()
                    {
                        Name = "bWasCollectedDuringCollectibleMode",
                        Value = colIndex == 2 ? value : false
                    };
                    new_item["bIsNewForSPMenu"] = new BoolProperty()
                    {
                        Name = "bIsNewForSPMenu",
                        Value = colIndex == 3 ? value : false
                    };

                    target.AddUnique(new_item);
                }
                else
                {
                    if (colIndex == 1 && value == false) //Remove item
                    {
                        target.RemoveAt(index);
                    }
                    else //Edit existing
                    {
                        switch(colIndex)
                        {
                            case 2:
                                {
                                    target[index]["bWasCollectedDuringCollectibleMode"].Value = value;
                                    break;
                                }
                            case 3:
                                {
                                    target[index]["bIsNewForSPMenu"].Value = value;
                                    break;
                                }
                        }
                       
                    }
                }
            }
        }

        public void EditCollectible(string name, int cpIndex, int colIndex, object value)
        {
            var guid = GameInfo.LIS2_CollectibleNames[name];

            List<dynamic> root;

            if (cpIndex == 0)
            {
                root = Data["CurrentSubContextSaveData"].Value["CollectiblesSaveData"].Value["Items"].Value;
            }
            else
            {
                root = Data["CheckpointHistory"].Value[cpIndex]["CollectiblesSaveData"].Value["Items"].Value;
            }

            var target_ind = root.FindIndex(1, x => x["CollectibleGUID"].Value["Guid"] == guid);
            if(target_ind == -1) //Add new item
            {
                Dictionary<string, dynamic> new_item = new Dictionary<string, dynamic>()
                {
                    { "CollectibleGUID", new StructProperty()
                        {
                        Name = "CollectibleGUID",
                        ElementType = "Guid",
                        Value = new Dictionary<string, dynamic>()
                            {
                                { "Guid", guid }
                            }
                        }
                    },
                    { "EquipedSlotIndex", new Int16Property()
                        {
                            Name = "EquipedSlotIndex",
                            Value = colIndex == 1 ? Convert.ToInt16(value) : Convert.ToInt16(-1)
                        }
                    },
                    { "bWasCollectedDuringCollectibleMode", new BoolProperty
                        {
                            Name = "bWasCollectedDuringCollectibleMode",
                            Value = colIndex == 2 ? Convert.ToBoolean(value) : false
                        }
                    },
                    { "bIsNew", new BoolProperty
                        {
                            Name = "bIsNew",
                            Value = colIndex == 3 ? Convert.ToBoolean(value) : false
                        }
                    },
                };
                root.AddUnique(new_item);
            }
            else if (value == string.Empty)
            {
                root.RemoveAt(target_ind);
            }
            else
            {
                var item = root[target_ind];
                switch (colIndex)
                {
                    case 1:
                        {
                            item["EquipedSlotIndex"].Value = Convert.ToInt16(value);
                            break;
                        }
                    case 2:
                        {
                            item["bWasCollectedDuringCollectibleMode"].Value = Convert.ToBoolean(value);
                            break;
                        }
                    case 3:
                        {
                            item["bIsNew"].Value = Convert.ToBoolean(value);
                            break;
                        }
                }
            }
        }

        public void EditObjective(string name, int cpIndex, string value)
        {
            var guid = GameInfo.LIS2_ObjectiveNames[name];

            List<dynamic> root;

            if (cpIndex == 0)
            {
                root = Data["CurrentSubContextSaveData"].Value["ObjectiveSaveData"].Value["ObjectiveSaveDataItems"].Value;
            }
            else
            {
                root = Data["CheckpointHistory"].Value[cpIndex]["ObjectiveSaveData"].Value["ObjectiveSaveDataItems"].Value;
            }

            var target_ind = root.FindIndex(1, x => x["ObjectiveGUID"].Value["Guid"] == guid);
            if (target_ind == -1) //add
            {
                Dictionary<string, dynamic> new_item = new Dictionary<string, dynamic>()
                {
                    { "ObjectiveGUID", new StructProperty()
                        {
                        Name = "ObjectiveGUID",
                        ElementType = "Guid",
                        Value = new Dictionary<string, dynamic>()
                            {
                                { "Guid", guid }
                            }
                        }
                    },
                    {
                        "ObjectiveState", new EnumProperty()
                        {
                            Name = "ObjectiveState",
                            ElementType = "ELIS2ObjectiveState",
                            Value = "ELIS2ObjectiveState::" + value
                        }
                    },
                };
                root.AddUnique(new_item);
            }
            else if (value == "(none)") //remove
            {
                root.RemoveAt(target_ind);
            }
            else //edit
            {
                root[target_ind]["ObjectiveState"].Value = "ELIS2ObjectiveState::" + value;
            }
        }

        public void EditSeenMessage(string name, int cpIndex, bool value)
        {
            var guid = GameInfo.LIS2_SMSNames[name];

            List<dynamic> root;

            if (cpIndex == 0)
            {
                root = Data["CurrentSubContextSaveData"].Value["PhoneSaveData"].Value["ReadedMessages"].Value;
            }
            else
            {
                root = Data["CheckpointHistory"].Value[cpIndex]["PhoneSaveData"].Value["ReadedMessages"].Value;
            }

            var target_ind = root.FindIndex(x => x == guid);

            if (target_ind == -1)
            {
                root.AddUnique(guid);
            }
            else
            {
                root.RemoveAt(target_ind);
            }
        }
    }
}
