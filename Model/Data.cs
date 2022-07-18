using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelReader.Model
{
    public class Data
    {
        public static int numberOfHeaders { get; set; }
        public static List<String> ColumnName = new List<String>();
        public static Dictionary<string, string> ComponentMap = new Dictionary<string, string>();
    }
}
