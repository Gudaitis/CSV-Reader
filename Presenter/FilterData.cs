using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelReader.Model;

namespace ExcelReader.Presenter
{
    public class FilterData : IFilterData
    {
        public static string searchValue { get; set; }
        public static IUserPrompt userPrompt = new UserPrompt();
        public Dictionary<string, string> FilterResultsInDict(string header)
        {
            searchValue = userPrompt.ShowDialog("Searching by:" + header, "Enter a value");
            Data.ComponentMap.Add(header, searchValue); //Adds the data into the component map which is used for filtering.

            return Data.ComponentMap;
        }
        public DataTable FilterDatagrid(DataTable dt, Dictionary<string, string> ComponentMap)
        {
            try
            { 
                foreach (var filter in ComponentMap)
                {
                    dt = dt.AsEnumerable().Where(x => Convert.ToString(x[Data.ColumnName.IndexOf(filter.Key)]) == filter.Value).CopyToDataTable();//Filters the data using the key and value.
                }
            }
            catch (InvalidOperationException)
            {
              MessageBox.Show("There was no data found with the applied filter");
            }
            return dt;
        }
    }

}
