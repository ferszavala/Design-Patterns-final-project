using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_final
{
    public class ReportAdmin
    {
        TargetReport txt = new AdapterTxtReport(new GenerateTxtReport());
        TargetReport grid = new AdapterGridFormReport(new GenerateGridFormReport());
        TargetReport textbox = new AdapterTextBoxReport(new GenerateTextBoxReport());

        public bool flag1 = false;
        public bool flag2 = false;
        public bool flag3 = false;
        private ReportAdmin()
        {

        }
        private static ReportAdmin _instance;
        public static ReportAdmin GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ReportAdmin();
            }
            return _instance;
        }
        public void write(string message)
        {
            if (flag1)
            {
                grid.write(message); 
            }
            if (flag2)
            {
                textbox.write(message);
            }
            if (flag3)
            {
                txt.write(message);
            }
        }

        public void update()
        {
            if(flag1)
            {
                grid.openWindow();
            }
            if(flag2)
            {
                textbox.openWindow();
            }
            if (flag3)
            {
                txt.openWindow();
            }
        }

       
    }
}
