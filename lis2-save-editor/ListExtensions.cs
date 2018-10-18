using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lis2_save_editor
{
    public static class ListExtensions
    {
        public static List<T> AddUnique<T>(this List<T> list, T item)
        {
            if (!list.Contains(item))
            {
                list.Add(item);
            }
            return list;
        }
    }
}
