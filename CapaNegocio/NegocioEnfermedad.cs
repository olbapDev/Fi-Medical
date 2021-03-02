using CapaConexion;
using CapaDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class NegocioEnfermedad
    {

        private ConexionSQL conect;

        public ConexionSQL Conect { get => conect; set => conect = value; }

        public void configurarConexion()
        {
            try
            {
                this.Conect = new ConexionSQL();
                this.Conect.NombreBaseDatos = "Medical";
                this.Conect.NombreTabla = "Enfermedad";
                this.Conect.CadenaConexion = @"Data Source=DESKTOP-9PT39RR;Initial Catalog=Medical;Integrated Security=True";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " Mensaje Sistema");
            }
        }//finConfigurarConexion

        public void grabarEnfermedad(Enfermedad enfermedad)
        {
            try
            {

                this.configurarConexion();
                this.Conect.CadenaSQL = "INSERT INTO " + this.Conect.NombreTabla
                                      + "(id_enfermedad, detalle_enfermedad)"
                                      + " VALUES ('" + enfermedad.IdEnfermedad + "," + enfermedad.Detalle + "');";
                this.Conect.EsSelect = false;
                this.Conect.conectar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " Mensaje Sistema");
            }

        }//fin grabarEnfermedad

        public void eliminarEnfermedad(int idEnfermedad)
        {
            try
            {
                this.configurarConexion();
                this.Conect.CadenaSQL = "DELETE * FROM " + this.Conect.NombreTabla
                                      + " WHERE id_enfermedad = '" + idEnfermedad + "';";
                this.Conect.EsSelect = false;
                this.Conect.conectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " Mensaje Sistema");

            }
        }//fin eliminarEnfermedad

        public void actualizarEnfermedad(Enfermedad enfermedad)
        {
            try
            {
                this.configurarConexion();
                this.Conect.CadenaSQL = "UPDATE " + this.Conect.NombreTabla
                                      + " SET "
                                      + "detalle_enfermedad = '" + enfermedad.Detalle + "';";
                this.Conect.EsSelect = false;
                this.Conect.conectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " Mensaje Sistema");

            }


        }//fin ActualizarFicha

        public DataTable buscarEnfermedad(int idEnfermedad)
        {
            try
            {
                this.configurarConexion();
                this.Conect.CadenaSQL = " SELECT nom_enfermedad FROM Enfermedad;";
                this.Conect.EsSelect = true;
                this.Conect.conectar();
                return this.Conect.DbDataSet.Tables["Enfermedad"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " Mensaje Sistema");
            }
            return null;
        }//fin buscarEnfermedad




        public DataTable listarEnfermedad()
        {

            try
            {
                this.configurarConexion();
                this.Conect.CadenaSQL = "SELECT nom_enfermedad FROM Enfermedad;";
                this.Conect.EsSelect = true;
                this.Conect.conectar();

                return this.Conect.DbDataSet.Tables["Enfermedad"];



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " Mensaje Sistema");

            }

            return null;

        }//fin ListarEnfermedad





    }//finClass

}
