using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using ExcelReader.Model;
using ExcelReader.Presenter;

namespace ExcelReader.Presenter
{
    public class LoadDefaultHeader : ILoadDefaultHeader
    {
        public static ILoadCustomHeader config = new LoadCustomHeader();
        public static ILoadCSV LoadCSV = new LoadCSV();
        public static DataTable dt = new DataTable();
        public DataTable DefaultHeaderSetter()
        {
            dt = new DataTable();
            try
            {
                var reader = new StreamReader(LoadCSV.LoadUserFile());
                using (var csv = new CsvReader(reader, config.setConfig()))
                using (var dr = new CsvDataReader(csv))
                {
                    Data.numberOfHeaders = dr.FieldCount; //Gets the amount of headers in the CSV file that are required.
                    var DefaultHeaders = csv.HeaderRecord;
                    foreach (var head in DefaultHeaders)
                    {
                        Data.ColumnName.Add(head);//For each header in the DefaultHeaders, we add it into the column.
                    }
                    csv.Read();
                    dt.Load(dr);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            return dt;
        }
    }
}

