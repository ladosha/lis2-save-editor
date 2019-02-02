using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace lis2_save_editor
{
    #region Properties

    public class GVASProperty
    {
        public string Name { get; set; }
        public string Type { get { return GetType().Name; } }
    }

        //Not actually in the file but might be useful
        public class NoneProperty : GVASProperty
        {
            public new string Name = "None";
            public new string Type = "None";
            public int Length { get; set; }
        }

    public class BoolProperty : GVASProperty
    {
        public bool Value { get; set; }

        public int GetSelfByteLength()
        {
            return Name.GetUE4ByteLength() + Type.GetUE4ByteLength() + 10;
        }

    }

    public class NameProperty : GVASProperty
    {
        public int Length { get { return Value.GetUE4ByteLength(); } }
        public byte[] UnkBytes { get { return new byte[5]; } }
        public string Value { get; set; }

        public int GetSelfByteLength()
        {
            return Name.GetUE4ByteLength() + Type.GetUE4ByteLength() + 4 + UnkBytes.Length + Length;
        }
    }

    public class StrProperty : GVASProperty
    {
        public int Length { get { return Value.GetUE4ByteLength(); } }
        public byte[] UnkBytes { get { return new byte[5]; } }
        public string Value { get; set; }

        public int GetSelfByteLength()
        {
            return Name.GetUE4ByteLength() + Type.GetUE4ByteLength() + 4 + UnkBytes.Length + Length;
        }

    }

    public class ByteProperty : GVASProperty
    {
        public int Length { get { return 1; } }
        public byte[] UnkBytes { get { return new byte[14] { 0x00, 0x00, 0x00, 0x00, 0x05, 0x00, 0x00, 0x00, 0x4E, 0x6F, 0x6E, 0x65, 0x00, 0x00 }; } }
        public byte Value { get; set; }

        public int GetSelfByteLength()
        {
            return Name.GetUE4ByteLength() + Type.GetUE4ByteLength() + 4 + UnkBytes.Length + Length;
        }
    }

    public class IntProperty : GVASProperty
    {
        public int Length { get { return 4; } }
        public byte[] UnkBytes { get { return new byte[5]; } }
        public int Value { get; set; }

        public int GetSelfByteLength()
        {
            return Name.GetUE4ByteLength() + Type.GetUE4ByteLength() + 4 + UnkBytes.Length + Length;
        }

    }

    public class UInt32Property : GVASProperty
    {
        public int Length { get { return 4; } }
        public byte[] UnkBytes { get { return new byte[5]; } }
        public uint Value { get; set; }

        public int GetSelfByteLength()
        {
            return Name.GetUE4ByteLength() + Type.GetUE4ByteLength() + 4 + UnkBytes.Length + Length;
        }
    }

    public class Int16Property : GVASProperty
    {
        public int Length { get { return 2; } }
        public byte[] UnkBytes { get { return new byte[5]; } }
        public short Value { get; set; }

        public int GetSelfByteLength()
        {
            return Name.GetUE4ByteLength() + Type.GetUE4ByteLength() + 4 + UnkBytes.Length + Length;
        }
    }

    public class FloatProperty : GVASProperty
    {
        public int Length { get { return 4; } }
        public byte[] UnkBytes { get { return new byte[5]; } }
        public float Value { get; set; }

        public int GetSelfByteLength()
        {
            return Name.GetUE4ByteLength() + Type.GetUE4ByteLength() + 4 + UnkBytes.Length + Length;
        }
    }

    public class EnumProperty : GVASProperty
    {
        public long Length { get { return Value.GetUE4ByteLength(); } }
        public string ElementType { get; set; }
        public byte UnkByte { get { return 0; } }
        public string Value { get; set; } //for now? maybe will implement later

        public long GetSelfByteLength()
        {
            return Name.GetUE4ByteLength() + Type.GetUE4ByteLength() + 8 + (ElementType.GetUE4ByteLength()) + 1 + Length;
        }
    }

    public class StructProperty : GVASProperty
    {
        public long Length
        {
            get
            {
                switch (ElementType)
                {
                    case "Quat":
                        {
                            return 16;
                        }
                    case "Vector":
                        {
                            return 12;
                        }
                    case "Guid":
                        {
                            return 16;
                        }
                    case "DateTime":
                        {
                            return 8;
                        }
                    default:
                        {
                            long len = 0;
                            foreach (dynamic child in Value.Values)
                            {
                                len += child.GetSelfByteLength();
                            }
                            len += 9; //None string
                            return len;
                        }
                }
            }
        }
        public string ElementType { get; set; }
        public byte[] UnkBytes { get { return new byte[17]; } }
        public Dictionary<string, dynamic> Value { get; set; }

        public long GetSelfByteLength()
        {
            return Name.GetUE4ByteLength() + Type.GetUE4ByteLength() + 8 + ElementType.GetUE4ByteLength() + UnkBytes.Length + Length;
        }
    }

    public class ArrayProperty : GVASProperty
    {
        public long Length
        {
            get
            {
                long len = 4; //ElementCount int is part of length
                if (ElementType == "StructProperty")
                {
                    var struct_info = Value[0];
                    len += struct_info["struct_name"].Length + 5
                        + struct_info["struct_type"].Length + 5
                        + 8
                        + struct_info["struct_eltype"].Length + 5
                        + struct_info["struct_unkbytes"].Length;
                    Value[0]["struct_length"] = GetChildStructByteLength();
                    len += Value[0]["struct_length"];

                    return len;
                }
                else
                {
                    foreach (var element in Value)
                    {
                        switch (ElementType)
                        {
                            case "IntProperty":
                                {
                                    len += 4;
                                    break;
                                }
                            case "FloatProperty":
                                {
                                    len += 4;
                                    break;
                                }
                            case "ByteProperty":
                                {
                                    len += 1;
                                    break;
                                }
                            case "BoolProperty":
                                {
                                    len += 1;
                                    break;
                                }
                            case "StrProperty":
                                {
                                    len += element.Length + 5;
                                    break;
                                }
                            case "NameProperty":
                                {
                                    len += element.Length + 5;
                                    break;
                                }
                            case "UInt32Property":
                                {
                                    len += 4;
                                    break;
                                }
                            case "Int16Property":
                                {
                                    len += 2;
                                    break;
                                }
                            case "EnumProperty":
                                {
                                    len += element.Length + 5;
                                    break;
                                }
                            default:
                                {
                                    throw new System.Exception("Unknown type: " + ElementType);
                                }
                        }
                    }
                    return len;
                }
            }
           
        }
        public string ElementType { get; set; }
        public byte UnkByte { get { return 0; } }
        public int ElementCount { get { return Value.Count - (ElementType == "StructProperty" ? 1 : 0); } }
        public List<dynamic> Value { get; set; }

        public long GetChildStructByteLength()
        {
            long ch_str_len = 0;
            string ch_str_eltype = Value[0]["struct_eltype"];
            for (int i = 1; i <= ElementCount; i++)
            {
                var test = Value[i];
                switch (ch_str_eltype)
                {
                    case "Quat":
                        {
                            ch_str_len += 16;
                            break;
                        }
                    case "Vector":
                        {
                            ch_str_len += 12;
                            break;
                        }
                    case "Guid":
                        {
                            ch_str_len += 16;
                            break;
                        }
                    case "DateTime":
                        {
                            ch_str_len += 8;
                            break;
                        }
                    default:
                        {
                            foreach (var struct_element in Value[i].Values)
                            {
                                ch_str_len += struct_element.GetSelfByteLength();
                            }
                            ch_str_len += 9; //None string
                            break;
                        }
                }
            }
            return ch_str_len;
        }

        public long GetSelfByteLength()
        {
            return Name.GetUE4ByteLength() + Type.GetUE4ByteLength() + 8 + ElementType.GetUE4ByteLength() + 1 + Length;
        }
    }

    public class MapProperty : GVASProperty
    {
        public long Length
        {
            get
            {
                var len = 8; //count int and 4 unknown bytes
                if (KeyType == "StructProperty" && ValType == "StructProperty")
                {
                    foreach (var element in Value)
                    {
                        len += 16;
                        foreach (var child in element.Value.Values)
                        {
                            len += child.GetSelfByteLength();
                        }
                        len += 9; //None string
                    }

                }
                else
                {
                    foreach (var element in Value)
                    {
                        switch (KeyType)
                        {
                            case "IntProperty":
                                {
                                    len += 4;
                                    break;
                                }
                            case "FloatProperty":
                                {
                                    len += 4;
                                    break;
                                }
                            case "ByteProperty":
                                {
                                    len += 1;
                                    break;
                                }
                            case "BoolProperty":
                                {
                                    len += 1;
                                    break;
                                }
                            case "StrProperty":
                                {
                                    len += element.Key.Length + 5;
                                    break;
                                }
                            case "NameProperty":
                                {
                                    len += element.Key.Length + 5;
                                    break;
                                }
                            case "UInt32Property":
                                {
                                    len += 4;
                                    break;
                                }
                            case "Int16Property":
                                {
                                    len += 2;
                                    break;
                                }
                            case "EnumProperty":
                                {
                                    len += element.Key.Length + 5;
                                    break;
                                }
                            default:
                                {
                                    throw new System.Exception("Unknown type: " + KeyType);
                                }
                        }
                        switch (ValType)
                        {
                            case "IntProperty":
                                {
                                    len += 4;
                                    break;
                                }
                            case "FloatProperty":
                                {
                                    len += 4;
                                    break;
                                }
                            case "ByteProperty":
                                {
                                    len += 1;
                                    break;
                                }
                            case "BoolProperty":
                                {
                                    len += 1;
                                    break;
                                }
                            case "StrProperty":
                                {
                                    len += element.Value.Length + 5;
                                    break;
                                }
                            case "NameProperty":
                                {
                                    len += element.Value.Length + 5;
                                    break;
                                }
                            case "UInt32Property":
                                {
                                    len += 4;
                                    break;
                                }
                            case "Int16Property":
                                {
                                    len += 2;
                                    break;
                                }
                            case "EnumProperty":
                                {
                                    len += element.Value.Length + 5;
                                    break;
                                }
                            case "StructProperty":
                                {

                                    foreach (var struct_element in element.Value)
                                    {
                                        len += struct_element.Value.GetSelfByteLength();

                                    }
                                    len += 9; //None string

                                    break;

                                }
                            default:
                                {
                                    throw new System.Exception("Unknown type: " + ValType);
                                }
                        }
                    }
                }
                return len;
            }
           
        }
        public string KeyType { get; set; }
        public string ValType { get; set; }
        public byte[] UnkBytes { get { return new byte[5]; } }
        public int ElementCount { get { return Value.Count; } }
        public Dictionary<dynamic, dynamic> Value { get; set; }

        public long GetSelfByteLength()
        {
            return Name.GetUE4ByteLength() + Type.GetUE4ByteLength() + 8 + KeyType.GetUE4ByteLength() + ValType.GetUE4ByteLength() + 1 + Length;
        }
    }

    public class SetProperty : GVASProperty
    {
        public long Length { get { return 16 * Value.Count + 8; } } //all guids + element count int + 4 unknown bytes
        public string ElementType { get; set; }
        public int ElementCount { get { return Value.Count; } }
        public byte[] UnkBytes { get { return new byte[5]; } } //for now
        public List<dynamic> Value { get; set; }

        public long GetSelfByteLength()
        {
            return Name.GetUE4ByteLength() + Type.GetUE4ByteLength() + 8 + ElementType.GetUE4ByteLength() + 1 + Length;
        }
    }

    public class TextProperty : GVASProperty
    {
        public long Length
        {
            get
            {
                int ValueLength = 0;
                foreach (string s in Value)
                {
                    ValueLength += s.GetUE4ByteLength();
                }
                return ValueLength + 5; //unknown bytes are part of length
            }
        }
        public byte[] UnkBytes { get; set; }
        public string[] Value { get; set; }

        public long GetSelfByteLength()
        {
            int ValueLength = 0;
            foreach (string s in Value)
            {
                ValueLength += s.GetUE4ByteLength();
            }
            return Name.GetUE4ByteLength() + Type.GetUE4ByteLength() + 8 + UnkBytes.Length + ValueLength;
        }


    }
    #endregion

}


