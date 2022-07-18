using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelReader.Presenter;
using System.Data;
using ExcelReader.Model;

namespace ExcelReader.Presenter
{
    
    public class LoadCustomHeader : ILoadCustomHeader
    {
        public static DataTable dt = new DataTable();
        public static IUserPrompt prompt = new UserPrompt();
        public static ILoadCSV LoadCSV = new LoadCSV();
        
        public DataTable CustomHeaderSetter()
        {

            var reader = new StreamReader(LoadCSV.LoadUserFile());
            var csv = new CsvReader(reader, setConfig());
            using (var dr = new CsvDataReader(csv))
            {
                var columnLength = dr.FieldCount; //Gets the amount of headers in the CSV file that are required.
                Data.numberOfHeaders = columnLength;
                for (int i = 0; i < columnLength; i++)
                {
                    string newHeaderName = prompt.ShowDialog("Enter your column header name: ", "Input required");
                    dt.Columns.Add(newHeaderName);
                    Data.ColumnName.Add(newHeaderName.ToString());
                }

                while (dr.Read())
                {
                    var row = dt.NewRow();
                    for (int i = 0; i < columnLength; i++)//Skips the default header row
                    {

                        row[i] = csv.GetField(i);//Populates the datarows
                    }
                    dt.Rows.Add(row);//Adds the datarows to the datatable.
                }
                dt.Load(dr);
            }
            return dt;

        }
        public CsvConfiguration setConfig()
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)//Sets the configuaration for our csvreader.
            {
                HasHeaderRecord = true,
                MissingFieldFound = null,
                BadDataFound = null,

            };
            return config;
        }

    }
}
