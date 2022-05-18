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
    public partial class Simulation : Form
    {
        Store s = new Store();
        public Simulation()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Principal principal = new Principal();
            principal.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReportAdmin.GetInstance().write("Iniciando simulación");
            int refresco = 0, pan = 0, vegetales = 0;

            foreach(Store i in Stores.GetInstance().stores)
            {
                refresco += i.products[0].quantity;
                pan += i.products[1].quantity;
                vegetales += i.products[2].quantity;
            }

            if(refresco == 0 && pan == 0 && vegetales == 0)
            {
                MessageBox.Show("No se han ingresado pedidos para iniciar una simulación");
            }

            if(numericUpDown1.Value == 0 && refresco > 0)
            {
                MessageBox.Show("No hay suficiente producto para cumplir con la demanda de refresco");
            }

            if(numericUpDown1.Value == 1 && refresco > 120) 
            {
                MessageBox.Show("No hay suficiente producto para cumplir con la demanda de refresco");
            }

            if(numericUpDown1.Value == 2 && refresco > 240)
            {
                MessageBox.Show("No hay suficiente producto para cumplir con la demanda de refresco");
            }

            if (numericUpDown1.Value == 3 && refresco > 360)
            {
                MessageBox.Show("No hay suficiente producto para cumplir con la demanda de refresco");
            }

            if (numericUpDown2.Value == 0 && pan > 0)
            {
                MessageBox.Show("No hay suficiente producto para cumplir con la demanda de pan");
            }

            if (numericUpDown2.Value == 1 && pan > 270)
            {
                MessageBox.Show("No hay suficiente producto para cumplir con la demanda de pan");
            }

            if (numericUpDown2.Value == 2 && pan > 540)
            {
                MessageBox.Show("No hay suficiente producto para cumplir con la demanda de pan");
            }

            if (numericUpDown2.Value == 3 && pan > 810)
            {
                MessageBox.Show("No hay suficiente producto para cumplir con la demanda de pan");
            }

            if (numericUpDown3.Value == 0 && vegetales > 0)
            {
                MessageBox.Show("No hay suficiente producto para cumplir con la demanda de verdura congelada");
            }

            if (numericUpDown3.Value == 1 && vegetales > 95)
            {
                MessageBox.Show("No hay suficiente producto para cumplir con la demanda de verdura congelada");
            }

            if (numericUpDown3.Value == 2 && vegetales > 190)
            {
                MessageBox.Show("No hay suficiente producto para cumplir con la demanda de verdura congelada");
            }

            if (numericUpDown3.Value == 3 && vegetales > 285)
            {
                MessageBox.Show("No hay suficiente producto para cumplir con la demanda de verdura congelada");
            }

            if ((numericUpDown1.Value + numericUpDown2.Value + numericUpDown3.Value) > 5)
            {
                MessageBox.Show("Recuerda que 5 es el máximo número de camiones que puedes tener en circulación al mismo tiempo");
            }

            else
            {
                ReportAdmin.GetInstance().write("Fin de la simulación");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReportAdmin.GetInstance().write("Creando pedido e iniciando la ruta de entrega");
            List<KeyValuePair<float, string>> ganancia = new List<KeyValuePair<float, string>>();

            foreach (Store i in Stores.GetInstance().stores)
            {
                float g = 0;
                foreach (Product j in i.products)
                {
                    g += j.price * j.quantity;
                }
                ganancia.Add(new KeyValuePair<float, string>( g, i.idStore));
            }

            ganancia = ganancia.OrderBy(kvp => kvp.Key).ToList();
            ganancia = Enumerable.Reverse(ganancia).ToList();

            string aux = "";
            foreach (var i in ganancia)
            {
                aux += "ID de la tienda: "+i.Value+" Total:"+i.Key+"\n";
            }
            MessageBox.Show("El orden de la ruta es: \n"+aux);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            ReportAdmin.GetInstance().write("Agregando "+ numericUpDown1.Value + " camiones de refresco a la simulación");
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            ReportAdmin.GetInstance().write("Agregando " + numericUpDown1.Value + " camiones de pan a la simulación");
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            ReportAdmin.GetInstance().write("Agregando " + numericUpDown1.Value + " camiones de verdura congelada a la simulación");
        }

        private void Simulation_Load(object sender, EventArgs e)
        {

        }
    }
}
