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
    public partial class AgregarFichaMedica : Form
    {
        public AgregarFichaMedica()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
            System.GC.Collect(); 
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            try
            {
                Ficha auxFicha = new Ficha();
                DetalleFicha detalle = new DetalleFicha();
                NegocioFicha auxNegocioFicha = new NegocioFicha();
                NegocioPaciente auxNegocioPaciente = new NegocioPaciente();
                NegocioDetalle auxNegocioDetalle = new NegocioDetalle();

                auxFicha.IdFicha = int.Parse(this.txtIdFicha.Text);
                auxFicha.IdDetalle = int.Parse(this.txtIdDetalle.Text);
                auxFicha.RutPac = int.Parse(this.txtRutPaciente.Text);

                auxNegocioPaciente.buscarPaciente(int.Parse(this.txtRutPaciente.Text));

                detalle.IdDetalle = int.Parse(this.txtIdDetalle.Text);
                detalle.IdEnfermedad =Convert.ToInt32(boxEnfermedad.SelectedIndex);
                detalle.Descripcion = this.txtDescripcion.Text;
                detalle.FCita = monthCalendar1.SelectionStart;

                auxNegocioDetalle.grabarDetalle(detalle);
                auxNegocioFicha.grabarFicha(auxFicha);

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + " Mensaje Sistema");

            }


        }//fin btn guardar

        private void boxEnfermedad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AgregarFichaMedica_Load(object sender, EventArgs e)
        {
            NegocioEnfermedad enfermedad = new NegocioEnfermedad();

            boxEnfermedad.DisplayMember = "nom_enfermedad";
            boxEnfermedad.ValueMember = "id_enfermedad";
            boxEnfermedad.DataSource = enfermedad.listarEnfermedad();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
