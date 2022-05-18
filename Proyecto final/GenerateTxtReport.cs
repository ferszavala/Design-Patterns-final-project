using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_final
{
    class GenerateTxtReport
    {
        public GenerateTxtReport()
        {
         
        }
        string path = @"C:\Users\piqui\Downloads\debug.txt";
        public void writeDebug(string message)
        {

            if (!File.Exists(path))
            {
                using (StreamWriter tw = File.CreateText(path))
                {
                    tw.WriteLine(DateTime.Now.ToString() + message);
                }
            }
            else if (File.Exists(path))
            {
                using (var tw = new StreamWriter(path, true))
                {
                    tw.WriteLine(DateTime.Now.ToString() + message);
                }
            }
        }

        public void openWindow()
        {
           
        }
    }
}
