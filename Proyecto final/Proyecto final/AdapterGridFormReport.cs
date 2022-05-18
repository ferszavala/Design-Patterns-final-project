using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_final
{
    class AdapterGridFormReport : TargetReport
    {
        private readonly GenerateGridFormReport _generateGridFormReport;

        public AdapterGridFormReport(GenerateGridFormReport generateGridFormReport)
        {
            this._generateGridFormReport = generateGridFormReport;
        }

        public void write(string message)
        {
            this._generateGridFormReport.writeDebug(message);
        }

        public void openWindow()
        {
            this._generateGridFormReport.openWindow();
        }
    }
}
