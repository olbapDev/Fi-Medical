using CapaDTO;
using CapaNegocio;
using System;
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
    public partial class ConsultarPaciente : Form
    {
        public ConsultarPaciente()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
            System.GC.Collect();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            
            if(string.IsNullOrEmpty(this.txtRut.Text))
            {
                try
                {

                    NegocioPaciente auxNegocio = new NegocioPaciente();

                    dataGridView1.DataSource = auxNegocio.listarPaciente();
                  
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "Mensaje Sistema");
                }
            }
            else
            {
                try
                {

                    NegocioPaciente auxNegocio = new NegocioPaciente();

                    dataGridView1.DataSource = auxNegocio.buscarPaciente(int.Parse(this.txtRut.Text));
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "Mensaje Sistema");
                }
            }
            
           
          
            
        }
    }
}
