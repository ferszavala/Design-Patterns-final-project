using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_final
{
    class AdapterTextBoxReport : TargetReport
    {
        private readonly GenerateTextBoxReport _generateTextBoxReport;

        public AdapterTextBoxReport(GenerateTextBoxReport generateTextBoxReport)
        {
            this._generateTextBoxReport = generateTextBoxReport;
        }

        public void write(string message)
        {
            this._generateTextBoxReport.writeDebug(message);
        }

        public void openWindow()
        {
            this._generateTextBoxReport.openWindow();
        }
    }
}
