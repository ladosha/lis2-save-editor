using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
//using Newtonsoft.Json;

namespace cs_save_editor
{
    public class GameSave
    {
        public Dictionary<string, dynamic> Data;
        public bool SaveChangesSaved { get; set; } = true;

        byte[] saveFileHeader = new byte[82] { 0x47, 0x45, 0x56, 0x41, 0x53, 0x45, 0x4E, 0x44, 0x02, 0x00, 0x00, 0x00, 0x01, 0x02, 0x00, 0x00, 0x04, 0x00, 0x10, 0x00, 0x03, 0x00, 0x00, 0x00, 0x00, 0x00, 0x13, 0x00, 0x00, 0x00, 0x2B, 0x2B, 0x55, 0x45, 0x34, 0x2B, 0x52, 0x65, 0x6C, 0x65, 0x61, 0x73, 0x65, 0x2D, 0x34, 0x2E, 0x31, 0x36, 0x00, 0x11, 0x00, 0x00, 0x00, 0x4C, 0x49, 0x53, 0x32, 0x47, 0x61, 0x6D, 0x65, 0x53, 0x61, 0x76, 0x65, 0x44, 0x61, 0x74, 0x61, 0x00, 0x5F, 0x32, 0x53, 0x5F, 0x53, 0x49, 0x4C, 0x5F, 0x08, 0x00, 0x00, 0x00 };
        public bool SaveIsValid { get; set; }

        public void ReadSaveFromFile (string savePath)
        {
            var fileContent = File.ReadAllBytes(savePath);
            MemoryStream file = new MemoryStream(fileContent);
            BinaryReader reader = new BinaryReader(file);

            SaveIsValid = true;

            //check if file starts with header
            for (int i=0; i<saveFileHeader.Length; i++)
            {
                if (reader.ReadByte() != saveFileHeader[i])
                {
                    SaveIsValid = false;
                    return;
                }
            }

            Data = new Dictionary<string, dynamic>();

            try
            {
                while (reader.BaseStream.Position < reader.BaseStream.Length - 4)
                {
                    dynamic prop = reader.ParseProperty();
                    Data.Add(prop.Name, prop);
                }
            }
            catch
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

            foreach (var pr in Data.Values)
            {
                BinaryWriterExtension.WriteProperty(writer, pr);
            }

            string str = "";

            str.GetUE4ByteLength();

            writer.Write(new byte[4] { 0, 0, 0, 0 }); //4 bytes at the end

            var fileContent = new_file.ToArray();

            if (!File.Exists(savePath + @".bkp"))
            {
                File.Copy(savePath, savePath + @".bkp", false);
            }

            File.WriteAllBytes(savePath, fileContent); // Write changes the file on disk

            SaveChangesSaved = true;
        }

        public void EditInventoryItem(string invType, string name, int? qty)
        {
            List<dynamic> target = Data["CurrentSubContextSaveData"].Value["PlayerSaveData"]
                               .Value["PlayerInventorySaveData"].Value[invType].Value;
            int index = target.FindIndex(1, x => x["PickupID"].Value == name);

            if (index == -1) //Add new item
            {
                Dictionary<string, object> new_item = new Dictionary<string, object>();
                new_item["PickupID"] = new NameProperty() { Name = "PickupID", Type = "NameProperty", Value = name };
                new_item["Quantity"] = new IntProperty() { Name = "Quantity", Type = "IntProperty", Value = qty ?? 0 };
                target.Add(new_item);
            }
            else
            {
                if (qty == null) //Remove inventory item
                {
                    target.RemoveAt(index);
                }
                else //Edit existing item
                {
                    target[index]["Quantity"].Value = Convert.ToInt32(qty);
                }
            }
            
        }

        public void EditSeenTutorial(string name, int? times)
        {
             Dictionary<object, object> target = Data["CurrentSubContextSaveData"].Value["PlayerSaveData"]
                                                 .Value["AlreadySeenTutorials"].Value;
            if (times == null) //remove item
            {
                target.Remove(name);
            }
            else //edit existing or add new
            {
                target[name] = times;
            }
        }

        public void EditPackageProperty(string name, string property, bool value)
        {
            List<dynamic> target = Data["CurrentSubContextSaveData"].Value["WorldStreamingSaveData"].Value;
            int index = target.FindIndex(1, x => x["StreamingLevelPackageName"].Value == name);

            target[index][property].Value = value;
        }

        public void EditSeenPicture(string name, bool remove)
        {
            List<dynamic> target = Data["CurrentSubContextSaveData"].Value["ShowPicturesSaveData"].Value["AllShowPictureIDSeen"].Value;
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
                        { "Guid", Guid.NewGuid() }
                    }
                };
                target.Add(new_item);
            }
            else
            {
                if (remove) //Remove item
                {
                    target.RemoveAt(index);
                }
                else //Edit existing
                {
                    target[index]["Name"].Value = name;
                }
            }
        }
    }
}
