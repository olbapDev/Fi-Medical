using CapaConexion;
using CapaDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace CapaNegocio
{
    public class NegocioPaciente
    {
        private ConexionSQL conect;

        public ConexionSQL Conect { get => conect; set => conect = value; }

        public void configurarConexion()
        {
            try
            {
                this.Conect = new ConexionSQL();
                this.Conect.NombreBaseDatos = "Medical";
                this.Conect.NombreTabla = "Paciente";
                this.Conect.CadenaConexion = @"Data Source=DESKTOP-9PT39RR;Initial Catalog=Medical;Integrated Security=True";

            }
            catch(Exception ex)
            {
                MessageBox.Show(" Mensaje Sistema" + ex.Message);
            }
        }//finConfigurarConexion

        public void grabarPaciente(Paciente paciente)
        {
            try 
            {

                this.configurarConexion();
                this.Conect.CadenaSQL = "INSERT INTO " + this.Conect.NombreTabla
                                      + "(rut, dv, nom_paciente, ap_paciente, direccion, id_comuna)"
                                      + " VALUES ('" + paciente.Rut + "','" + paciente.Dv + "','"
                                      + paciente.NomPaciente + "','" + paciente.ApPaciente + "','"
                                      + paciente.Direccion + "','"+ paciente.Comuna + "');";
                this.Conect.EsSelect = false;
                this.Conect.conectar();

            }
            catch(Exception ex)
            {
                MessageBox.Show(" Mensaje Sistema" + ex.Message);
            }

        }//fingrabar

        public void eliminarPaciente(int rut)
        {
            try
            {
                this.configurarConexion();
                this.Conect.CadenaSQL = "DELETE * FROM " + this.Conect.NombreTabla
                                      + " WHERE rut = '" + rut + "';";
                this.Conect.EsSelect = false;
                this.Conect.conectar();
            }
            catch(Exception ex)
            {
                MessageBox.Show(" Mensaje Sistema" + ex.Message);
            }
        }//fin elimiarPaciente

        public void actualizarPaciente(Paciente paciente)
        {
            try
            {
                this.configurarConexion();
                this.Conect.CadenaSQL = "UPDATE " + this.Conect.NombreTabla
                                      + " SET "
                                      + "nom_paciente = '" + paciente.NomPaciente + "','"
                                      + "ap_paciente ='" + paciente.ApPaciente + "','"
                                      + "direccion ='" + paciente.Direccion + "';";
                this.Conect.EsSelect = false;
                this.Conect.conectar();
            }
            catch(Exception ex)
            {
                MessageBox.Show(" Mensaje Sistema" + ex.Message);
            }


        }//fin actualizarPaciente

        public DataTable buscarPaciente(int rut)
        {
            try
            {
                this.configurarConexion();
                this.Conect.CadenaSQL = " SELECT P.rut AS Rut, P.dv AS Digito" +
                    ", P.nom_paciente AS Nombre, P.ap_paciente AS Apellido" +
                    ", P.direccion, C.nom_comuna AS Comuna" +
                    " FROM Paciente AS P," +
                    " Comuna AS C" +
                    " WHERE C.id_comuna = P.id_Comuna AND P.rut = '"+ rut +"';";
                this.Conect.EsSelect = true;
                this.Conect.conectar();
                return this.Conect.DbDataSet.Tables["Paciente"];
            }
            catch(Exception ex)
            {
                MessageBox.Show(" Mensaje Sistema" + ex.Message);
            }
            return null;
        }//fin BuscarCliente



        public DataTable listarPaciente()
        {
            try
            {
                this.configurarConexion();
                this.Conect.CadenaSQL = " SELECT P.rut AS Rut, P.dv AS Digito" +
                    ", P.nom_paciente AS Nombre, P.ap_paciente AS Apellido" +
                    ", P.direccion, C.nom_comuna AS Comuna" +
                    " FROM Paciente AS P," +
                    " Comuna AS C" +
                    " WHERE C.id_comuna = P.id_Comuna;";
                this.Conect.EsSelect = true;
                this.Conect.conectar();
                
                return this.Conect.DbDataSet.Tables["Paciente"];



            }
            catch(Exception ex)
            {
                MessageBox.Show("Mensaje Sistema" + ex.Message);
            }

            return null;

        }//fin ListarPaciente








    }//FinClass
}
