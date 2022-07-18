using System.Data;


namespace ExcelReader.Presenter
{
    public interface ILoadCSV
    {
       string LoadUserFile();
       DataTable Load();
    }
}
