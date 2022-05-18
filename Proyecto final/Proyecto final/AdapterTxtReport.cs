using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_final
{
    class AdapterTxtReport : TargetReport
    {
        private readonly GenerateTxtReport _generateTxtReport;

        public AdapterTxtReport(GenerateTxtReport generateTxtReport)
        {
            this._generateTxtReport = generateTxtReport;
        }

        public void write(string message)
        {
            this._generateTxtReport.writeDebug(message);
        }

        public void openWindow()
        {
            this._generateTxtReport.openWindow();
        }
    }
}
