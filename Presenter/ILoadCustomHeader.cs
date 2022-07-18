
using CsvHelper.Configuration;
using System.Data;


namespace ExcelReader.Presenter
{
    public interface ILoadCustomHeader
    {
        DataTable CustomHeaderSetter();
        CsvConfiguration setConfig();
    }
}
