using System;
using CapaNegocio;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaGUI
{
    public partial class ConsultarFicha : Form
    {
        public ConsultarFicha()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
            System.GC.Collect();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.txtRutPaciente.Text))
                {
                    try
                    {
                        NegocioDetalle auxDetalle = new NegocioDetalle();
                        dataGridView1.DataSource = auxDetalle.listarDetalle();
                        


                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Mensaje Sistema"+ ex.Message);
                    }

                }//FIN IF
               
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + "Mensaje Sistema");
            }
          


           
            

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
