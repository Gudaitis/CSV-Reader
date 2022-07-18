
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelReader.Presenter;
using ExcelReader.Commands;
using System.IO;

namespace ExcelReader.Presenter
{
    public class LoadCSV : ILoadCSV
    {
        
        public static IHeaderPrompt HeaderPrompt = new HeaderPrompt();
        public static ILoadCustomHeader CustomHeader = new LoadCustomHeader();
        public static ILoadDefaultHeader DefaultHeader = new LoadDefaultHeader();
        public static string filePath;
        DataTable dt = new DataTable();
        public string LoadUserFile()
        {
            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                openFile.InitialDirectory = "c:\\"; //Opens the file dialog on the default directory of C:
                openFile.Filter = "CSV files (*.csv)|*.csv";
                openFile.FilterIndex = 2;
                openFile.RestoreDirectory = true;


                if (openFile.ShowDialog() == DialogResult.OK)
                {

                    //Get the path of specified file
                    filePath = openFile.FileName;
                    
                }
                Console.WriteLine(filePath);
                return filePath;
                
            } 
            
        }
        public DataTable Load()
        {
            if (HeaderPrompt.UserPromptHeaderSelection() == DialogResult.Yes)
            {
                dt = CustomHeader.CustomHeaderSetter();
            }
            else
            {
                dt =  DefaultHeader.DefaultHeaderSetter();
            }
            return dt;

        }
    }
}

