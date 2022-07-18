using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelReader.Presenter
{
    public interface IUserPrompt
    {
        string ShowDialog(string text, string caption);
    }
}
