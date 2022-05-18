using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_final
{
    class GenerateTextBoxReport
    {
        TextBoxReport form = new TextBoxReport();
        public GenerateTextBoxReport()
        {
            
        }

        public void writeDebug(string message)
        {
            form.textBox1.Text += DateTime.Now.ToString() + message + "\r\n";
        }

        public void openWindow()
        {
            form = new TextBoxReport();
            form.Show();
        }
    }
}
