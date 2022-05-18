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
    public partial class RegisterStore : Form
    {

        GenerateQR qr = GenerateQR.GetInstance();
        public Store s = new Store();
        



        public RegisterStore()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            s.idStore = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            s.storeName = textBox2.Text;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            s.products[0].quantity = (int)numericUpDown1.Value;
            ReportAdmin.GetInstance().write("Agregando "+numericUpDown1.Value+" refrescos al pedido");
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            s.products[1].quantity = (int)numericUpDown2.Value;
            ReportAdmin.GetInstance().write("Agregando " + numericUpDown1.Value + " panes al pedido");
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            s.products[2].quantity = (int)numericUpDown3.Value;
            ReportAdmin.GetInstance().write("Agregando " + numericUpDown1.Value + " bolsas de vegetales congelados al pedido");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = @"C:\Users\piqui\Downloads\"+s.storeName+".png";
            qr.crearQRpng(s, path);
            qr.LeerQRpng(path);
            Stores st = Stores.GetInstance();
            st.AddStore(s);
           
            ReportAdmin.GetInstance().write("Tienda agregada y pedido añadido " + s.storeName+ " exitosamente");
            ReportAdmin.GetInstance().write("Código QR añadido exitosamente");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Principal principal = new Principal();
            principal.ShowDialog();
        }
    }
}
