using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelReader.Commands
{
    public class HeaderPrompt : IHeaderPrompt
    {
        public DialogResult UserPromptHeaderSelection()
        {
            var result = MessageBox.Show("Would you like to use custom column headers?", "Required", MessageBoxButtons.YesNo);
            return result;
        }

    }
}
