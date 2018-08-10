using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace cs_save_editor
{
    public static class BinaryWriterExtension
    {
        public static void WriteUE4String(this BinaryWriter writer, string str)
        {
            byte[] strbytes = Encoding.UTF8.GetBytes(str);
            if (strbytes.Length == 0)
            {
                writer.Write(0);
                return;
            }
            writer.Write(strbytes.Length+1);
            writer.Write(strbytes);
            writer.Write('\0');
            return;
        }

        public static void WriteProperty(this BinaryWriter writer, dynamic property, bool inArray = false, string arrElType = "", string structElType = "")
        {
            if (!inArray)
            {
                WriteUE4String(writer, property.Name);
            }

            string type = "";
            if (!inArray)
            {
                type = property.Type;
                WriteUE4String(writer, type);
            }
            else
            {
                type = arrElType;
            }
            switch (type)
            {
                case "BoolProperty":
                    {
                        if (!inArray)
                        {
                            byte[] value = new byte[10] { 0, 0, 0, 0, 0, 0, 0, 0, Convert.ToByte(property.Value), 0 };
                            writer.Write(value);
                            break;
                        }

                        writer.Write(property.Value);
                        break;
                    }
                case "NameProperty":
                    {
                        if (!inArray)
                        {
                            writer.Write(property.Length);
                            writer.Write(property.UnkBytes);
                            WriteUE4String(writer, property.Value);
                            break;
                        }

                        WriteUE4String(writer, property);
                        break;
                    }
                case "StrProperty":
                    {
                        writer.Write(property.Length);
                        writer.Write(property.UnkBytes);
                        WriteUE4String(writer, property.Value);
                        break;
                    }
                case "ByteProperty":
                    {
                        if (!inArray)
                        {
                            writer.Write(property.Length);
                            writer.Write(property.UnkBytes);
                            writer.Write(property.Value);
                            break;
                        }

                        writer.Write(property);
                        break;
                    }
                case "IntProperty":
                    {
                        if (!inArray)
                        {
                            writer.Write(property.Length);
                            writer.Write(property.UnkBytes);
                            writer.Write(property.Value);
                            break;
                        }

                        writer.Write(property);
                        break;
                    }
                case "UInt32Property":
                    {
                        if (!inArray)
                        {
                            writer.Write(property.Length);
                            writer.Write(property.UnkBytes);
                            writer.Write(property.Value);
                            break;
                        }

                        writer.Write(property);
                        break;
                    }
                case "FloatProperty":
                    {
                        if (!inArray)
                        {
                            writer.Write(property.Length);
                            writer.Write(property.UnkBytes);
                            writer.Write(property.Value);
                            break;
                        }

                        writer.Write(property);
                        break;

                    }
                case "EnumProperty":
                    {
                        if (!inArray)
                        {
                            writer.Write(property.Length);
                            WriteUE4String(writer, property.ElementType);
                            writer.Write(property.UnkByte);
                            WriteUE4String(writer, property.Value);
                            break;

                        }

                        WriteUE4String(writer, property);
                        break;

                    }
                case "StructProperty":
                    {
                        if (!inArray)
                        {
                            writer.Write(property.Length);
                            WriteUE4String(writer, property.ElementType);
                            writer.Write(property.UnkBytes);

                            switch (property.ElementType)
                            {
                                case "Quat":
                                    {
                                        var quat = property.Value["Quat"];
                                        writer.Write(quat.X);
                                        writer.Write(quat.Y);
                                        writer.Write(quat.Z);
                                        writer.Write(quat.W);
                                        break;
                                    }
                                case "Vector":
                                    {
                                        var vec = property.Value["Vector"];
                                        writer.Write(vec.X);
                                        writer.Write(vec.Y);
                                        writer.Write(vec.Z);
                                        break;
                                    }
                                case "Guid":
                                    {
                                        writer.Write(property.Value["Guid"].ToByteArray());
                                        break;
                                    }
                                case "DateTime":
                                    {
                                        writer.Write(property.Value["DateTime"].AddYears(1600).ToFileTime());
                                        WriteUE4String(writer, "None"); //don't know if all datetime props are delimited by this or it's just the end of the file at play
                                        break;
                                    }
                                default:
                                    {
                                        var test = writer.BaseStream.Position;
                                        foreach (var child in property.Value.Values)
                                        {
                                            WriteProperty(writer, child);
                                        }
                                        WriteUE4String(writer, "None"); //None is end of all structs
                                        break;
                                    }
                            }
                            break;
                        }

                        switch (structElType)
                        {
                            case "Quat":
                                {
                                    var quat = property["Quat"];
                                    writer.Write(quat.X);
                                    writer.Write(quat.Y);
                                    writer.Write(quat.Z);
                                    writer.Write(quat.W);
                                    break;
                                }
                            case "Vector":
                                {
                                    var vec = property["Vector"];
                                    writer.Write(vec.X);
                                    writer.Write(vec.Y);
                                    writer.Write(vec.Z);
                                    break;
                                }
                            case "Guid":
                                {
                                    writer.Write(property["Guid"].ToByteArray());
                                    break;
                                }
                            case "DateTime":
                                {
                                    writer.Write(property["DateTime"].AddYears(1600).ToFileTime());
                                    WriteUE4String(writer, "None"); //don't know if all datetime props are delimited by this or it's just the end of the file at play
                                    break;
                                }
                            default:
                                {
                                    foreach (var child in property.Values)
                                    {
                                        WriteProperty(writer, child);
                                    }
                                    WriteUE4String(writer, "None");
                                    break;
                                }
                        }
                        break;
                    }

                case "ArrayProperty":
                    {
                        writer.Write(property.Length);
                        WriteUE4String(writer, property.ElementType);
                        writer.Write(property.UnkByte);
                        writer.Write(property.ElementCount);

                        if (property.ElementType == "StructProperty")
                        {
                            var info = property.Value[0];
                            WriteUE4String(writer, info["struct_name"]);
                            WriteUE4String(writer, info["struct_type"]);
                            writer.Write(info["struct_length"]);
                            WriteUE4String(writer, info["struct_eltype"]);
                            writer.Write(info["struct_unkbytes"]);

                            for (int i = 1; i <= property.ElementCount; i++)
                            {
                                var test = property.Value[i];
                                WriteProperty(writer, property.Value[i], true, property.ElementType, info["struct_eltype"]);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < property.ElementCount; i++)
                            {
                                WriteProperty(writer, property.Value[i], true, property.ElementType);
                            }
                        }
                        break;
                    }
                case "MapProperty":
                    {
                        
                        writer.Write(property.Length);
                        WriteUE4String(writer, property.KeyType);
                        WriteUE4String(writer, property.ValType);
                        writer.Write(property.UnkBytes);
                        writer.Write(property.ElementCount);

                        if (property.KeyType == "StructProperty" && property.ValType == "StructProperty")
                        {
                            foreach (var child in property.Value) //FactAssets. add guid and struct containing entire fact asset
                            {
                                writer.Write(new Guid(child.Key).ToByteArray());
                                var val = child.Value;
                                WriteProperty(writer, val, true, property.ValType);
                            }
                        }
                        else
                        {
                            foreach (var child in property.Value)
                            {
                                WriteProperty(writer, child.Key, true, property.KeyType);
                                WriteProperty(writer, child.Value, true, property.ValType);
                            }
                        }
                        break;
                    }
                //unimplemented yet due to lack of data
                case "TextProperty":
                    {
                        writer.Write(property.Length);
                        writer.Write(property.Value);
                        break;
                    }
                case "SetProperty": //only ONE such property in the file, and it's still empty :D 
                    {
                        writer.Write(property.Length);
                        WriteUE4String(writer, property.ElementType);
                        writer.Write(property.UnkBytes);
                        break;
                    }
                default:
                    {
                        throw new InvalidDataException("Unknown type: " + type);
                    }
            }
        }
    }
}
