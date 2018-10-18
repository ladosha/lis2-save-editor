using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lis2_save_editor
{
    public static class StringExtension
    { 
        public static int GetUE4ByteLength(this string str)
        {
            if (str.Length == 0) return 4; //only length-int
            return str.Length + 5;
        }
    }

}
