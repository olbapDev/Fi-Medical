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
    public class NegocioFicha
    {

        private ConexionSQL conect;

        public ConexionSQL Conect { get => conect; set => conect = value; }

        public void configurarConexion()
        {
            try
            {
                this.Conect = new ConexionSQL();
                this.Conect.NombreBaseDatos = "Medical";
                this.Conect.NombreTabla = "Ficha";
                this.Conect.CadenaConexion = @"Data Source=DESKTOP-9PT39RR;Initial Catalog=Medical;Integrated Security=True";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Mensaje Sistema" + ex.Message);
            }
        }//finConfigurarConexion

        public void grabarFicha(Ficha ficha)
        {
            try
            {

                this.configurarConexion();
                this.Conect.CadenaSQL = "INSERT INTO " + this.Conect.NombreTabla
                                      + "(id_ficha, id_detalle, rut)"
                                      + " VALUES ('" + ficha.IdFicha +"','"
                                      + ficha.IdDetalle +"','" 
                                      + ficha.RutPac +"');";
                this.Conect.EsSelect = false;
                this.Conect.conectar();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Mensaje Sistema" + ex.Message);
            }

        }//fin grabarFicha

        public void eliminarFicha(int idFicha)
        {
            try
            {
                this.configurarConexion();
                this.Conect.CadenaSQL = "DELETE * FROM " + this.Conect.NombreTabla
                                      + " WHERE rut = '" + idFicha + "';";
                this.Conect.EsSelect = false;
                this.Conect.conectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mensaje Sistema" + ex.Message);
            }
        }//fin eliminarFicha

        public DataTable buscarFicha(int idFicha)
        {
            try
            {
                this.configurarConexion();
                this.Conect.CadenaSQL = " SELECT * FROM Ficha WHERE id_ficha = '" + idFicha + "';";
                this.Conect.EsSelect = true;
                this.Conect.conectar();
                return this.Conect.DbDataSet.Tables["Ficha"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mensaje Sistema" + ex.Message);
            }
            return null;
        }//fin BuscarFicha

        //public DataTable buscarDetalle(int idFicha)
        //{
        //    try
        //    {
        //        this.configurarConexion();
        //        this.Conect.CadenaSQL = " SELECT D.fecha_cita FROM " 
        //                              + "Detalle_Ficha AS D"
        //                              + "Ficha AS F"
        //                              + " WHERE D.id_ficha = F.'" + idFicha + "';";
        //        this.Conect.EsSelect = true;
        //        this.Conect.conectar();
        //        return this.Conect.DbDataSet.Tables["Ficha"];
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Mensaje Sistema" + ex.Message);
        //    }
        //    return null;
        //}//fin BuscarFicha


        public DataTable listarFicha()
        {


            try
            {
                this.configurarConexion();
                this.Conect.CadenaSQL = " SELECT * FROM Ficha;";
                this.Conect.EsSelect = true;
                this.Conect.conectar();

                return this.Conect.DbDataSet.Tables["Ficha"];



            }
            catch (Exception ex)
            {
                MessageBox.Show("Mensaje Sistema" + ex.Message);
            }

            return null;

        }//fin ListarFicha



        //public void actualizarFicha(Ficha ficha)
        //{
        //    try
        //    {
        //        this.configurarConexion();
        //        this.Conect.CadenaSQL = "UPDATE " + this.Conect.NombreTabla
        //                              + " SET "
        //                              + "id_ficha = '" + ficha.IdFicha + "';";
        //        this.Conect.EsSelect = false;
        //        this.Conect.conectar();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Mensaje Sistema" + ex.Message);
        //    }


        //}//fin ActualizarFicha





    }//finClass

}
