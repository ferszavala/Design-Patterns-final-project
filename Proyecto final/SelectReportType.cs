using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_final
{
    public partial class SelectReportType : Form
    {
        
        public SelectReportType()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            ReportAdmin.GetInstance().flag2 = checkBox2.Checked; 
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            ReportAdmin.GetInstance().flag1 = checkBox1.Checked;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            ReportAdmin.GetInstance().flag3 = checkBox3.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReportAdmin.GetInstance().update();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Principal principal = new Principal();
            principal.ShowDialog();
        }
    }
}
