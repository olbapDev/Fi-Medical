using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaGUI
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fichaMedicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultarFicha auxConFi = new ConsultarFicha();
            auxConFi.ShowDialog();
        }

        private void pacienteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AgregarPaciente auxAgregar = new AgregarPaciente();
            auxAgregar.ShowDialog();

        }

        private void fichaMedicaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AgregarFichaMedica auxFicha = new AgregarFichaMedica();
            auxFicha.ShowDialog();
        }

        private void horaMedicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModificarFecha pFecha = new ModificarFecha();
            pFecha.ShowDialog();
        }

        private void pacienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultarPaciente auxConsultarP = new ConsultarPaciente();
            auxConsultarP.ShowDialog();
        }

        private void mantenedorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
