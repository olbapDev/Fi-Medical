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
    public class NegocioDetalle
    {
        private ConexionSQL conect;

        public ConexionSQL Conect { get => conect; set => conect = value; }

        public void configurarConexion()
        {
            try
            {
                this.Conect = new ConexionSQL();
                this.Conect.NombreBaseDatos = "Medical";
                this.Conect.NombreTabla = "Detalle_Ficha";
                this.Conect.CadenaConexion = @"Data Source=DESKTOP-9PT39RR;Initial Catalog=Medical;Integrated Security=True";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Mensaje Sistema" + ex.Message);
            }
        }//finConfigurarConexion

        public void grabarDetalle(DetalleFicha detalle)
        {
            try
            {
                

                this.configurarConexion();
                this.Conect.CadenaSQL = "INSERT INTO " + this.Conect.NombreTabla
                                      + "(id_detalle, id_enfermedad, fecha_cita, descripcion)"
                                      + " VALUES ('" 
                                      + detalle.IdDetalle + "','"
                                      + detalle.IdEnfermedad +"','"
                                      + detalle.FCita +"','" 
                                      + detalle.Descripcion 
                                      + "');";
                this.Conect.EsSelect = false;
                this.Conect.conectar();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Mensaje Sistema" + ex.Message);
            }

        }//fin grabarDetalle

        public void eliminarDetalle(int idDetalle)
        {
            try
            {
                this.configurarConexion();
                this.Conect.CadenaSQL = "DELETE * FROM " + this.Conect.NombreTabla
                                      + " WHERE id_detalle = '" + idDetalle + "';";
                this.Conect.EsSelect = false;
                this.Conect.conectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mensaje Sistema" + ex.Message);
            }
        }//fin eliminarDetalle

        public void actualizarDescripcion(DetalleFicha detalle)
        {
            try
            {
                this.configurarConexion();
                this.Conect.CadenaSQL = "UPDATE " + this.Conect.NombreTabla
                                      + " SET "
                                      + " descripcion = '"
                                      + detalle.IdEnfermedad
                                      + "'"
                                      + "WHERE id_detalle = '" + detalle.IdDetalle + "';";
                this.Conect.EsSelect = false;
                this.Conect.conectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mensaje Sistema" + ex.Message);
            }


        }//fin actualizarDetalle

        public void actualizarFecha(DetalleFicha detalle)
        {
            try
            {
                this.configurarConexion();
                this.Conect.CadenaSQL = "UPDATE " + this.Conect.NombreTabla
                                      + " SET "
                                      + " fecha_cita = '"
                                      + detalle.FCita
                                      + "'"
                                      + "WHERE id_detalle = '" + detalle.IdDetalle + "';";
                this.Conect.EsSelect = false;
                this.Conect.conectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mensaje Sistema" + ex.Message);
            }


        }//fin actualizarfecha


        //public DataTable buscarDetalle(int rut)
        //{
        //    try
        //    {
        //        this.configurarConexion();
        //        this.Conect.CadenaSQL = " SELECT  P.rut , F.id_ficha, D.* "
        //                              + " FROM " 
        //                              + " Paciente AS P , "
        //                              + " Detalle_Ficha AS D , "
        //                              + " Ficha AS F "
        //                              + " WHERE D.id_detalle = F.id_detalle AND F.rut ='" + rut + "';";

        //        this.Conect.EsSelect = true;
        //        this.Conect.conectar();
        //        return this.Conect.DbDataSet.Tables["Detalle"];
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message + " Mensaje Sistema");
        //    }
        //    return null;
        //}//fin BuscarDetalle




        public DataTable listarDetalle()
        {

            try
            {
                this.configurarConexion();
                this.Conect.CadenaSQL = " SELECT * FROM Detalle_Ficha;";
                this.Conect.EsSelect = true;
                this.Conect.conectar();

                return this.Conect.DbDataSet.Tables["Detalle"];



            }
            catch (Exception ex)
            {
                MessageBox.Show("Mensaje Sistema" + ex.Message);
            }

            return null;

        }//fin ListarDetalle







    }
}
