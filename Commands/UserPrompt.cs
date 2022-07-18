using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelReader.Presenter
{
    public class UserPrompt : IUserPrompt
    {
        /// <summary>
        /// Shows a dialog for the user to allow them to input custom or default headers.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="caption"></param>
        /// <returns>Returns the values of the headers.</returns>
        public string ShowDialog(string text, string caption)
        {
            {
                Form prompt = new Form()
                {
                    Width = 250,
                    Height = 150,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    Text = caption,
                    StartPosition = FormStartPosition.CenterScreen
                };
                Label textLabel = new Label() { Left = 15, Top = 15, Width = 225, Text = text };
                TextBox textBox = new TextBox() { Left = 15, Top = 50, Width = 200 };
                Button confirmation = new Button() { Text = "Ok", Left = 75, Width = 75, Top = 80, DialogResult = DialogResult.OK };
                confirmation.Click += (sender, e) => { prompt.Close(); };
                prompt.Controls.Add(textBox);
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(textLabel);
                prompt.AcceptButton = confirmation;


                return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : textBox.Text;

            }
        }
        

    }
}
