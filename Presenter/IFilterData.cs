using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelReader.Presenter
{
    public interface IFilterData
    {
        Dictionary<string, string> FilterResultsInDict(string header);

        DataTable FilterDatagrid(DataTable dt, Dictionary<string, string> ComponentMap);
    }
}
