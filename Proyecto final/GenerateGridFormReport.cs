using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_final
{
    public class GenerateGridFormReport 
    {
        GridFormReport form= new GridFormReport();
        public GenerateGridFormReport() {
            
        }

        public void writeDebug(string message)
        {
            this.form.dataGridView1.Rows.Add(message, DateTime.Now.ToString());
        }

        public void openWindow()
        {
            form = new GridFormReport();
            form.Show();
        }
    }
}
