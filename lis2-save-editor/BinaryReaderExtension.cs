using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace lis2_save_editor
{
    public static class BinaryReaderExtension
    {
        public static string ReadUE4String(this BinaryReader reader)
        {
            int length = reader.ReadInt32();
            if (length == 0) return string.Empty;
            return new string(reader.ReadChars(length)).Remove(length - 1);
        }

        public static dynamic ParseProperty(this BinaryReader reader, bool inArray = false, string arrElType="", string structElType = "")
        {
            string name = "";
            if (!inArray)
            {
                name = reader.ReadUE4String();
                if (name == "None") return new NoneProperty();
            }

            string type = "";
            if (!inArray)
            {
                type = reader.ReadUE4String();
            }
            else
            {
                type = arrElType;
            }
            switch(type)
            {
                case "BoolProperty":
                    {
                        if (!inArray)
                        {
                            bool value = Convert.ToBoolean(reader.ReadBytes(10)[8]);
                            return new BoolProperty { Name = name, Value = value };
                        }

                        return reader.ReadByte(); //bool is represented by 1 byte
                        
                    }
                case "NameProperty":
                    {
                        if (!inArray)
                        {
                            int length = reader.ReadInt32();
                            byte[] unkbytes = reader.ReadBytes(5);
                            string value = reader.ReadUE4String();
                            return new NameProperty { Name = name, Value = value };
                        }

                        return reader.ReadUE4String();

                    }
                case "StrProperty":
                    {
                        int length = reader.ReadInt32();
                        byte[] unkbytes = reader.ReadBytes(5);
                        string value = reader.ReadUE4String();
                        return new StrProperty { Name = name, Value = value };
                    }
                case "ByteProperty":
                    {
                        if (!inArray)
                        {
                            int length = reader.ReadInt32(); //it is always 1 bytes, but still
                            byte[] unkbytes = reader.ReadBytes(14); //not knowing what to do. this is 4 bytes, followed by None str, followed by 1 byte
                            byte value = reader.ReadByte();
                            return new ByteProperty { Name = name, Value = value };
                        }

                        return reader.ReadByte();
                    }
                case "IntProperty":
                    {
                        if (!inArray)
                        {
                            int length = reader.ReadInt32(); //it is always 4 bytes, but still
                            byte[] unkbytes = reader.ReadBytes(5);
                            int value = reader.ReadInt32();
                            return new IntProperty { Name = name, Value = value };
                        }

                        return reader.ReadInt32();
                    }
                case "UInt32Property":
                    {
                        if (!inArray)
                        {
                            int length = reader.ReadInt32(); //it is always 4 bytes, but still
                            byte[] unkbytes = reader.ReadBytes(5);
                            uint value = reader.ReadUInt32();
                            return new UInt32Property { Name = name, Value = value };
                        }

                        return reader.ReadUInt32();
                    }
                case "Int16Property":
                    {
                        if (!inArray)
                        {
                            int length = reader.ReadInt32(); //it is always 2 bytes, but still
                            byte[] unkbytes = reader.ReadBytes(5);
                            short value = reader.ReadInt16();
                            return new Int16Property { Name = name, Value = value };
                        }

                        return reader.ReadInt16();
                    }
                case "FloatProperty":
                    {
                        if (!inArray)
                        {
                            int length = reader.ReadInt32(); //it is always 4 bytes, but still
                            byte [] unkbytes = reader.ReadBytes(5);
                            float value = reader.ReadSingle();
                            return new FloatProperty { Name = name, Value = value };
                        }

                        return reader.ReadSingle();
                        
                    }
                case "EnumProperty":
                    {
                        if (!inArray)
                        {
                            long length = reader.ReadInt64();
                            string eltype = reader.ReadUE4String();
                            byte unkbyte = reader.ReadByte();
                            string value = reader.ReadUE4String();
                            return new EnumProperty
                            {
                                ElementType = eltype,
                                Name = name,
                                Value = value
                            };
                        }

                        return reader.ReadUE4String(); //just the value

                    }
                case "StructProperty":
                    {
                        if (!inArray)
                        {
                            long length = reader.ReadInt64();
                            string eltype = reader.ReadUE4String();
                            byte[] unkbytes = reader.ReadBytes(17);
                            long end = reader.BaseStream.Position + length;
                            Dictionary<string, dynamic> value = new Dictionary<string, dynamic>();
                            switch (eltype)
                            {
                                case "Quat":
                                    {
                                        value.Add("Quat", new Quaternion ( reader.ReadSingle(),
                                                                        reader.ReadSingle(),
                                                                        reader.ReadSingle(),
                                                                        reader.ReadSingle() ));
                                        break;
                                    }
                                case "Vector":
                                    {
                                        value.Add("Vector", new Vector3(reader.ReadSingle(), 
                                                                      reader.ReadSingle(), 
                                                                      reader.ReadSingle()));
                                        break;
                                    }
                                case "Guid":
                                    {
                                        value.Add("Guid", new Guid(reader.ReadBytes(16)));
                                        break;
                                    }
                                case "DateTime":
                                    {
                                        try {
                                            value.Add("DateTime", DateTime.FromFileTime(reader.ReadInt64()).AddYears(-1600));
                                        } catch
                                        {
                                            
                                            value.Add("DateTime", new DateTime(1990, 1, 1));
                                        }
                                        ;
                                        break;
                                    }
                                default:
                                    {
                                        while (reader.BaseStream.Position < end)
                                        {
                                            dynamic child = reader.ParseProperty();
                                            if (child.Type != "None")
                                            {
                                                value.Add(child.Name, child);
                                            }
                                        }
                                        break;
                                    }
                            }
           
                            return new StructProperty { Name = name,  ElementType = eltype, Value = value };
                        }

                        Dictionary<string, dynamic> s_value = new Dictionary<string, dynamic>();

                        switch (structElType)
                        {
                            case "Quat":
                                {
                                    s_value.Add("Quat", new Quaternion(reader.ReadSingle(),
                                                                    reader.ReadSingle(),
                                                                    reader.ReadSingle(),
                                                                    reader.ReadSingle()));
                                    break;
                                }
                            case "Vector":
                                {
                                    s_value.Add("Vector", new Vector3(reader.ReadSingle(),
                                                                  reader.ReadSingle(),
                                                                  reader.ReadSingle()));
                                    break;
                                }
                            case "Guid":
                                {
                                    s_value.Add("Guid", new Guid(reader.ReadBytes(16)));
                                    break;
                                }
                            case "DateTime":
                                {
                                    s_value.Add("DateTime", DateTime.FromFileTime(reader.ReadInt64()).AddYears(-1600));
                                    //do we need the None here?
                                    break;
                                }
                            default:
                                {
                                    while (true)
                                    {
                                        dynamic child = reader.ParseProperty();
                                        if (child.Type == "None") break; //"None" i.e reached end of struct 

                                        s_value.Add(child.Name, child);
                                    }
                                    break;
                                }
                        }

                        return s_value;
                    }
                case "ArrayProperty":
                    {
                        long length = reader.ReadInt64();
                        string eltype = reader.ReadUE4String();
                        byte unkbyte = reader.ReadByte();
                        int count = reader.ReadInt32();

                        List<dynamic> value = new List<dynamic> ();

                        if (eltype == "StructProperty")
                        {
                            Dictionary<string, object> struct_info = new Dictionary<string, object>()
                            {
                                { "struct_name", reader.ReadUE4String() },
                                {"struct_type", reader.ReadUE4String() },
                                {"struct_length", reader.ReadInt64() },
                                {"struct_eltype", reader.ReadUE4String() },
                                {"struct_unkbytes", reader.ReadBytes(17) }
                            };

                            value.Add(struct_info);

                            for (int i = 0; i < count; i++)
                            {
                                value.Add(reader.ParseProperty(true, eltype, struct_info["struct_eltype"].ToString()));
                            }
                        }
                        else
                        {
                            for (int i = 0; i < count; i++)
                            {
                                value.Add(reader.ParseProperty(true, eltype));
                            }
                        }
                        
                        return new ArrayProperty { Name = name, ElementType = eltype, Value = value};
                    }
                case "MapProperty":
                    {
                        long length = reader.ReadInt64();
                        string keytype = reader.ReadUE4String();
                        string valtype = reader.ReadUE4String();
                        byte[] unkbytes = reader.ReadBytes(5);
                        int count = reader.ReadInt32();
                        Dictionary<object, object> value = new Dictionary<object, object>();

                        if (keytype == "StructProperty" && valtype == "StructProperty")
                        {
                            for (int i = 0; i < count; i++) //FactAssets. add guid and struct containing entire fact asset
                            {
                                value.Add(new Guid(reader.ReadBytes(16)).ToString(), reader.ParseProperty(true, valtype));
                            }
                        }
                        else
                        {
                            for (int i = 0; i < count; i++)
                            {
                                value.Add(reader.ParseProperty(true, keytype), reader.ParseProperty(true, valtype));
                            }
                        }
                        return new MapProperty { Name = name,  KeyType = keytype, ValType = valtype, Value = value };
                    } 
                case "TextProperty":
                    {
                        long length = reader.ReadInt64();
                        byte[] unkbytes = reader.ReadBytes(6);
                        string[] value;
                        if (length == 5)
                        {
                            value = new string[0];
                        }
                        else
                        {
                            value = new string[2] { reader.ReadUE4String(), reader.ReadUE4String() }; //there are only 2 text properties anyway
                        }
                        return new TextProperty { Name = name, UnkBytes = unkbytes, Value = value };
                    }
                //unimplemented yet due to lack of data
                case "SetProperty": //only GUIDs inside set properties. yay!
                    {
                        long length = reader.ReadInt64();
                        string eltype = reader.ReadUE4String();
                        byte[] unkbytes = reader.ReadBytes(5);
                        int count = reader.ReadInt32();

                        List<dynamic> value = new List<dynamic>();

                        for (int i = 0; i < count; i++)
                        {
                            value.Add(new Guid(reader.ReadBytes(16)));
                        }

                        return new SetProperty { Name = name, ElementType = eltype, Value = value };
                    }
                default:
                    {
                        throw new InvalidDataException("Unknown type: " + type);
                    }
            }
        }

    }
}
