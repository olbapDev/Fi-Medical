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
    public partial class AgregarPaciente : Form
    {
        public AgregarPaciente()
        {
            InitializeComponent();
           
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
            System.GC.Collect();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
                try
            {
                Paciente auxPaciente = new Paciente();
                NegocioPaciente auxNegocio = new NegocioPaciente();

                auxPaciente.Rut = int.Parse(this.txtRut.Text);
                auxPaciente.Dv = this.txtDv.Text;
                auxPaciente.NomPaciente = this.txtNombre.Text;
                auxPaciente.ApPaciente = this.txtApellido.Text;
                auxPaciente.Direccion = this.txtDireccion.Text;
                auxPaciente.Comuna = Convert.ToInt32(this.boxComuna.SelectedValue);
                auxNegocio.grabarPaciente(auxPaciente);

                MessageBox.Show("Datos Guardados","Mensaje Sistema");

                limpiar();

            }
            catch(Exception ex)
            {
                MessageBox.Show(" Mensaje Sistema"+ ex.Message );
            }

        }//fin btnAgregar


        private void btnModificar_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void inicio()
        {
            limpiar();
            
            if(btnAgregar.Equals( "Buscar"))
            {
                deshabilitar();
                Paciente auxPaciente = new Paciente();
                NegocioPaciente auxNegocio = new NegocioPaciente();

                auxNegocio.buscarPaciente(int.Parse(this.txtRut.Text));
            }
            
        }

        public void deshabilitar()
        {
            this.txtNombre.Enabled = false;
            this.txtDv.Enabled = false;
            this.txtDireccion.Enabled = false;
            this.txtApellido.Enabled = false;
        }

        public void limpiar()
        {
            try
            {
                if(btnAgregar.Equals("Agregar"))
                {
                    btnAgregar.Text = "Buscar";
                    this.txtRut.Clear();
                    this.txtDv.Clear();
                    this.txtNombre.Clear();
                    this.txtApellido.Clear();
                    this.txtDireccion.Clear();   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "Error al limpiar", "Mensaje Sistema");
            }
        }


        private void AgregarPaciente_Load(object sender, EventArgs e)
        {

            inicio();
            limpiar();
            NegocioComuna comuna = new NegocioComuna();

            boxComuna.DisplayMember = "nom_comuna";
            boxComuna.ValueMember = "id_comuna";
            boxComuna.DataSource = comuna.listarComuna();




        }
    }
}
