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
    public partial class Principal : Form
    {
        GenerateQR qr = GenerateQR.GetInstance();
        public Store s = new Store();


        public Principal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = true;

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                string sFileName = choofdlog.FileName;
            }
            s = qr.LeerQRpng(choofdlog.FileName);
            ReportAdmin.GetInstance().write("Leyendo código QR del explorador de archivos");
            Stores st = Stores.GetInstance();
            st.AddStore(s);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            RegisterStore rs = new RegisterStore();
            rs.s.products = new List<Product> {
            new Product { idProduct = 1, name ="Refresco",price = 15},
            new Product { idProduct = 2, name ="Pan",price = 5},
            new Product { idProduct = 3, name ="Verdura congelada", price = 70}
            };
            rs.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Simulation sim = new Simulation();
            sim.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SelectReportType srt = new SelectReportType();
            srt.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ReportAdmin.GetInstance().write("Borrando todas las tiendas agregadas a la ruta");
            Stores st = Stores.GetInstance();
            st.stores = new List<Store>();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
