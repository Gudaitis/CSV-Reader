using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using ExcelReader.Presenter;
using ExcelReader.Model;

namespace ExcelReader
{
    /// <summary>
    /// Never has used the MVP model before, so I did my best to understand
    /// it from youtube tutorials and tried to implement it myself on this project.
    /// I found filtering by multiple columns to be the hardest because
    /// I tried atleast 3 different approaches, however I found that clicking on the
    /// headers was the best method I can think off that allowed me to successfully add
    /// Data into the componentmap which is used for filtering.
    /// 
    /// The first method I tried was to add combo boxes based on the amount
    /// of headers found in the CSV file, however this would cause issues
    /// with the UI, especially if you have a CSV file with over 20 headers.
    /// 
    /// The method i used was better suited in my opinion, because it makes the
    /// application user friendly if they read the text at the bottom of the screen.
    /// </summary>
    public partial class ExcelReaderApp : Form
    {
        public static ILoadCSV loadCSV = new LoadCSV();
        public static IUserPrompt userPrompt = new UserPrompt();
        
        public static IFilterData filterData = new FilterData();
        DataTable dt = new DataTable();
        public ExcelReaderApp()
        {
            InitializeComponent();
        }

        private void LoadCSVButton(object sender, EventArgs e)
        {
            PopulateGrid(); //Loads Data into the Datagridview
        }

        private void PopulateGrid()
        {
           Data.ColumnName.Clear();
           Data.ComponentMap.Clear();

           dt = new DataTable();
           dt = loadCSV.Load();
           dataGridView1.DataSource = dt; //Loads the CSV into the datagrid
           textBox2.Text = LoadCSV.filePath; //Sets the filepath in the textbox
        }

        private void ResetButton(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dt;
            Data.ComponentMap.Clear(); //Clears the component map for filters.
            label1.Text = "";
        }
        //
        private void header_Click(object sender, EventArgs e)
        {
            ContextMenu contextMenu = new ContextMenu();
            MenuItem menuItem = new MenuItem();
            menuItem.Text = this.dataGridView1.Columns[(sender as DataGridView).CurrentCell.ColumnIndex].Name; //Gets the name of the column header the user clicked.
            MenuItem menuItem1 = new MenuItem();
            contextMenu.MenuItems.Add(menuItem);
            
            try
            {
                dataGridView1.DataSource = filterData.FilterDatagrid(dt, filterData.FilterResultsInDict(menuItem.Text)); //Adds the filterdatagrid function with the componentmap for the user searched values
                label1.Text += "Filtered by: " + menuItem.Text + " - " + FilterData.searchValue + "      "; //Displays the filters to the user.
                if (FilterData.searchValue == "")
                {
                    label1.Text = "";
                }

            }
            catch(ArgumentException)
            {
                MessageBox.Show("Filter by another column");
                label1.Text = "";
            }
            

        }
    }
}
