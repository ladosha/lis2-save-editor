using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
//using Newtonsoft.Json;

namespace lis2_save_editor
{

    public enum SaveType
    {
        CaptainSpirit = 8,
        LIS = 11
    }

    public class GameSave
    {
        public Dictionary<string, dynamic> Data;
        public bool SaveChangesSaved { get; set; } = true;

        byte[] saveFileHeader = new byte[70] { 0x47, 0x45, 0x56, 0x41, 0x53, 0x45, 0x4E, 0x44, 0x02, 0x00, 0x00, 0x00, 0x01, 0x02, 0x00, 0x00, 0x04, 0x00, 0x10, 0x00, 0x03, 0x00, 0x00, 0x00, 0x00, 0x00, 0x13, 0x00, 0x00, 0x00, 0x2B, 0x2B, 0x55, 0x45, 0x34, 0x2B, 0x52, 0x65, 0x6C, 0x65, 0x61, 0x73, 0x65, 0x2D, 0x34, 0x2E, 0x31, 0x36, 0x00, 0x11, 0x00, 0x00, 0x00, 0x4C, 0x49, 0x53, 0x32, 0x47, 0x61, 0x6D, 0x65, 0x53, 0x61, 0x76, 0x65, 0x44, 0x61, 0x74, 0x61, 0x00 };
        byte[] gameSpecificHeader;
        public SaveType saveType;
        public bool SaveIsValid { get; set; }

        public void ReadSaveFromFile (string savePath)
        {
            var fileContent = File.ReadAllBytes(savePath);
            MemoryStream file = new MemoryStream(fileContent);
            BinaryReader reader = new BinaryReader(file);

            SaveIsValid = true;

            //check if file starts with header
            for (int i = 0; i < saveFileHeader.Length; i++)
            {
                if (reader.ReadByte() != saveFileHeader[i])
                {
                    SaveIsValid = false;
                    return;
                }
            }

            gameSpecificHeader = reader.ReadBytes(12);

            saveType = (SaveType)gameSpecificHeader[8];

            Data = new Dictionary<string, dynamic>();

            try
            {
                while (reader.BaseStream.Position < reader.BaseStream.Length - 4)
                {
                    dynamic prop = reader.ParseProperty();
                    Data.Add(prop.Name, prop);
                }
            }
            catch (Exception e)
            {
                SaveIsValid = false;
            }

            //string json = JsonConvert.SerializeObject(Data, Formatting.Indented);
            //File.WriteAllText("data_" + Path.GetFileNameWithoutExtension(savePath)+".json", json);
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

            writer.Write(new byte[4] { 0, 0, 0, 0 }); //4 bytes at the end

            var fileContent = new_file.ToArray();

            if (!File.Exists(savePath + @".bkp"))
            {
                File.Copy(savePath, savePath + @".bkp", false);
            }

            File.WriteAllBytes(savePath, fileContent); // Write the new file to disk

            SaveChangesSaved = true;
        }

        public void EditInventoryItem(string invType, string name, int cpIndex, int colIndex, int? val)
        {
            List<dynamic> target;
            if (cpIndex == 0)
            {
                target = Data["CurrentSubContextSaveData"].Value["PlayerSaveData"]
                               .Value["PlayerInventorySaveData"].Value[invType].Value;
            }
            else
            {
                target = Data["CheckpointHistory"].Value[cpIndex]["PlayerSaveData"]
                               .Value["PlayerInventorySaveData"].Value[invType].Value;
            }
            
            int index = target.FindIndex(1, x => x["PickupID"].Value == name);

            if (index == -1) //Add new item
            {
                Dictionary<string, object> new_item = new Dictionary<string, object>();
                new_item["PickupID"] = new NameProperty() { Name = "PickupID", Type = "NameProperty", Value = name };
                new_item["Quantity"] = new IntProperty() { Name = "Quantity", Type = "IntProperty", Value = (colIndex == 1 && val != null) ? (int)val: 0 };
                if(saveType == SaveType.LIS)
                {
                    new_item["bIsNew"] = new BoolProperty() { Name = "bIsNew", Type = "BoolProperty", Value = (colIndex == 2 && val != null) ? Convert.ToBoolean(val) : false };
                }
                
                target.AddUnique(new_item);
            }
            else
            {
                if (val == null) //Remove inventory item
                {
                    target.RemoveAt(index);
                }
                else //Edit existing item
                {
                    if (colIndex == 2)
                    {
                        target[index]["bIsNew"].Value = Convert.ToBoolean(val);
                        return;
                    }
                    target[index]["Quantity"].Value = Convert.ToInt32(val);
                }
            }
        }

        public void EditSeenTutorial(string name, int cpIndex, int? times)
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
                
            if (times == null) //remove item
            {
                target.Remove(name);
            }
            else //edit existing or add new
            {
                target[name] = times;
            }
        }

        public void EditSeenNotification(string name, int cpIndex, bool remove)
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

            if (remove)
            {
                target.Remove(name);
            }
            else
            {
                target.AddUnique(name);
            }
        }

        public void EditDrawing(string name, int cpIndex, int colIndex, object value)
        {
            List<dynamic> target = null;

            if (cpIndex == 0)
            {
                target = Data["CurrentSubContextSaveData"].Value["PlayerSaveData"]
                         .Value["DrawSequenceSaveData"].Value["DrawSequenceItemSaveDatas"].Value;
            }
            else
            {
                target = Data["CheckpointHistory"].Value[cpIndex]["PlayerSaveData"]
                         .Value["DrawSequenceSaveData"].Value["DrawSequenceItemSaveDatas"].Value;
            }

            
            int dr_index = target.FindIndex(1, x => x["DrawSequenceID"].Value["Name"].Value == name);
            List<dynamic> drawing = null;

            if (colIndex == 1 && Convert.ToBoolean(value) == false)
            {
                target.RemoveAt(dr_index);
                return;
            }

            if (dr_index == -1) //Add new DrawSequence
            {
                Guid guid = GameInfo.LIS2_DrawingNames.First(x => x.Value == name).Key;
                Dictionary<string, dynamic> new_seq = new Dictionary<string, dynamic>();
                new_seq["DrawSequenceID"] = new StructProperty()
                {
                    Name = "DrawSequenceID",
                    Type = "StructProperty",
                    ElementType = "DNERefName",
                    Value = new Dictionary<string, dynamic>()
                    {
                        { "Name", new NameProperty()
                            {
                                Name = "Name",
                                Type = "NameProperty",
                                Value = name
                            }
                        },
                        { "NameGuid", new StructProperty
                                {
                                    Name = "NameGuid",
                                    Type = "StructProperty",
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
                    Type = "ArrayProperty",
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
                drawing = new_seq["LandscapeItemSaveDatas"].Value;
            }
            else
            {
                drawing = target[dr_index]["LandscapeItemSaveDatas"].Value;
            }

            switch (colIndex)
            {
                case 2:
                    {
                        dynamic part = null;
                        for (int i = 1; i < drawing.Count; i++)
                        {
                            if (drawing[i]["LandscapeID"].Value == "Zone1_Reveal")
                            {
                                part = drawing[i];
                            }
                        }
                        if (part != null)
                        {
                            part["DrawingPercent"].Value = Convert.ToSingle(value);
                        }
                        else
                        {
                            part = new Dictionary<string, dynamic>()
                            {
                                { "LandscapeID", new NameProperty() {Name = "LandscapeID", Type="NameProperty", Value ="Zone1_Reveal" } },
                                {"DrawingPercent", new FloatProperty() {Name = "DrawingPercent", Type="FloatProperty", Value = Convert.ToSingle(value)} },
                                {"DrawingPhase", new EnumProperty() {Name = "DrawingPhase", Type="EnumProperty", ElementType="ELIS2PencilDrawingPhase", Value = "ELIS2PencilDrawingPhase::Rough" } }
                            };
                            drawing.Add(part);
                        }
                        break;
                    }
                case 3:
                    {
                        dynamic part = null;
                        for (int i = 1; i < drawing.Count; i++)
                        {
                            if (drawing[i]["LandscapeID"].Value == "Zone1_Reveal")
                            {
                                part = drawing[i];
                            }
                        }
                        if (part != null)
                        {
                            if (value.ToString() == "(none)")
                            {
                                drawing.Remove(part);
                                break;
                            }
                            part["DrawingPhase"].Value = "ELIS2PencilDrawingPhase::" + value.ToString();
                        }
                        else
                        {
                            if (value.ToString() == "(none)")
                            {
                                break;
                            }

                            part = new Dictionary<string, dynamic>()
                            {
                                { "LandscapeID", new NameProperty() {Name = "LandscapeID", Type="NameProperty", Value ="Zone1_Reveal" } },
                                {"DrawingPercent", new FloatProperty() {Name = "DrawingPercent", Type="FloatProperty", Value = 0} },
                                {"DrawingPhase", new EnumProperty() {Name = "DrawingPhase", Type="EnumProperty", ElementType="ELIS2PencilDrawingPhase", Value = "ELIS2PencilDrawingPhase::"+value.ToString() } }
                            };
                            drawing.Add(part);
                        }
                        break;
                    }
                case 4:
                    {
                        dynamic part = null;
                        for (int i = 1; i < drawing.Count; i++)
                        {
                            if (drawing[i]["LandscapeID"].Value == "Zone2_Reveal")
                            {
                                part = drawing[i];
                            }
                        }
                        if (part != null)
                        {
                            part["DrawingPercent"].Value = Convert.ToSingle(value);
                        }
                        else
                        {
                            part = new Dictionary<string, dynamic>()
                            {
                                { "LandscapeID", new NameProperty() {Name = "LandscapeID", Type="NameProperty", Value ="Zone2_Reveal" } },
                                {"DrawingPercent", new FloatProperty() {Name = "DrawingPercent", Type="FloatProperty", Value = Convert.ToSingle(value)} },
                                {"DrawingPhase", new EnumProperty() {Name = "DrawingPhase", Type="EnumProperty", ElementType="ELIS2PencilDrawingPhase", Value = "ELIS2PencilDrawingPhase::Rough" } }
                            };
                            drawing.Add(part);
                        }
                        break;
                    }
                case 5:
                    {
                        dynamic part = null;
                        for (int i = 1; i < drawing.Count; i++)
                        {
                            if (drawing[i]["LandscapeID"].Value == "Zone2_Reveal")
                            {
                                part = drawing[i];
                            }
                        }
                        if (part != null)
                        {
                            if (value.ToString() == "(none)")
                            {
                                drawing.Remove(part);
                                break;
                            }
                            part["DrawingPhase"].Value = "ELIS2PencilDrawingPhase::" + value.ToString();
                        }
                        else
                        {
                            if (value.ToString() == "(none)")
                            {
                                break;
                            }
                            part = new Dictionary<string, dynamic>()
                            {
                                { "LandscapeID", new NameProperty() {Name = "LandscapeID", Type="NameProperty", Value ="Zone2_Reveal" } },
                                {"DrawingPercent", new FloatProperty() {Name = "DrawingPercent", Type="FloatProperty", Value = 0} },
                                {"DrawingPhase", new EnumProperty() {Name = "DrawingPhase", Type="EnumProperty", ElementType="ELIS2PencilDrawingPhase", Value = "ELIS2PencilDrawingPhase::"+value.ToString() } }
                            };
                            drawing.Add(part);
                        }
                        break;
                    }
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

            if (saveType == SaveType.CaptainSpirit)
            {
                guid = GameInfo.CS_SeenPicturesNames.First(x => x.Value == name).Key;
                int index = target.FindIndex(1, x => x["Name"].Value == name);

                if (index == -1) //Add new item 
                {
                    Dictionary<string, object> new_item = new Dictionary<string, object>();
                    new_item["Name"] = new NameProperty() { Name = "Name", Type = "NameProperty", Value = name };
                    new_item["NameGuid"] = new StructProperty
                    {
                        Name = "NameGuid",
                        Type = "StructProperty",
                        ElementType = "Guid",
                        Value = new Dictionary<string, dynamic>()
                    {
                        { "Guid", guid }
                    }
                    };
                    target.Add(new_item);
                }
                else
                {
                        target.RemoveAt(index);
                }
            }
            else
            {
                guid = GameInfo.LIS2_SeenPicturesNames.First(x => x.Value == name).Key;
                int index = target.FindIndex(1, x => x["ShowPictureID"].Value["Name"].Value == name);

                if (index == -1) //Add new item 
                {
                    Dictionary<string, object> new_item = new Dictionary<string, object>();
                    new_item["ShowPictureID"] = new StructProperty
                    {
                        Name = "ShowPictureID",
                        Type = "StructProperty",
                        ElementType = "DNERefName",
                        Value = new Dictionary<string, dynamic>()
                        {
                            {"Name", new NameProperty() { Name = "Name", Type = "NameProperty", Value = name } },

                            { "NameGuid", new StructProperty
                                {
                                    Name = "NameGuid",
                                    Type = "StructProperty",
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
                        Type = "BoolProperty",
                        Value = colIndex == 2 ? value : false
                    };
                    new_item["bIsNewForSPMenu"] = new BoolProperty()
                    {
                        Name = "bIsNewForSPMenu",
                        Type = "BoolProperty",
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
            var guid = GameInfo.LIS2_CollectibleNames.First(x => x.Value == name).Key;

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
                        Type = "StructProperty",
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
                            Type = "Int16Property",
                            Value = colIndex == 1 ? Convert.ToInt16(value) : Convert.ToInt16(-1)
                        }
                    },
                    { "bWasCollectedDuringCollectibleMode", new BoolProperty
                        {
                            Name = "bWasCollectedDuringCollectibleMode",
                            Type = "BoolProperty",
                            Value = colIndex == 2 ? Convert.ToBoolean(value) : false
                        }
                    },
                    { "bIsNew", new BoolProperty
                        {
                            Name = "bIsNew",
                            Type = "BoolProperty",
                            Value = colIndex == 3 ? Convert.ToBoolean(value) : false
                        }
                    },
                };
                root.AddUnique(new_item);
            }
            else if (value == String.Empty)
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
            var guid = GameInfo.LIS2_ObjectiveNames.First(x => x.Value == name).Key;

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
                        Type = "StructProperty",
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
                            Type = "EnumProperty",
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
            var guid = GameInfo.LIS2_SMSNames.First(x => x.Value == name).Key;

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
