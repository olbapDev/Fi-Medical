using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaConexion
{
    public class ConexionSQL
    {
        private String nombreBaseDatos;
        private String nombreTabla;
        private String cadenaConexion;
        private String cadenaSQL;
        private Boolean esSelect;
        private SqlConnection dbConnection;
        private SqlDataAdapter dbDataAdapter;
        private DataSet dbDataSet;

        public string NombreBaseDatos { get => nombreBaseDatos; set => nombreBaseDatos = value; }
        public string NombreTabla { get => nombreTabla; set => nombreTabla = value; }
        public string CadenaConexion { get => cadenaConexion; set => cadenaConexion = value; }
        public string CadenaSQL { get => cadenaSQL; set => cadenaSQL = value; }
        public bool EsSelect { get => esSelect; set => esSelect = value; }
        public SqlConnection DbConnection { get => dbConnection; set => dbConnection = value; }
        public SqlDataAdapter DbDataAdapter { get => dbDataAdapter; set => dbDataAdapter = value; }
        public DataSet DbDataSet { get => dbDataSet; set => dbDataSet = value; }

        public void abrir()
        {
            try
            {
                this.dbConnection.Open();
            }
            catch (Exception ex)
            {

                throw new Exception("Error al abrir conexion " + ex.Message);

            }

        } //Fin abrir

        public void cerrar()
        {
            try
            {
                this.dbConnection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cerrar conexion " + ex.Message);

            }

        } //Fin Cerrar


        public void conectar()
        {
            if (String.IsNullOrEmpty(this.NombreBaseDatos))
            {
                MessageBox.Show("faltanombre bd" + "Mensaje Sistema");
                return;
            }
            if (String.IsNullOrEmpty(this.NombreTabla))
            {
                MessageBox.Show("faltanombre tabla" + "Mensaje Sistema");
                return;
            }
            if (String.IsNullOrEmpty(this.CadenaConexion))
            {
                MessageBox.Show("faltanombre cadena conexion" + "Mensaje Sistema");
                return;
            }
            if (String.IsNullOrEmpty(this.CadenaSQL))
            {
                MessageBox.Show("faltanombre cadena SQL" + "Mensaje Sistema");
                return;
            }


            try
            {
                this.DbConnection = new SqlConnection(this.CadenaConexion);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "Mensaje Sistema");
                return;
            }

            this.abrir();

            //pregunto si es select

            if (this.EsSelect)
            {
                this.DbDataSet = new DataSet();
                try
                {
                    this.DbDataAdapter = new SqlDataAdapter(this.CadenaSQL, this.DbConnection);
                    this.DbDataAdapter.Fill(this.DbDataSet, this.NombreTabla);


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "Mensaje Sistema");
                    return;

                }

            }
            else
            {
                //Se ejecutan las instrucciones INSERT DELETE UPDATE

                try
                {
                    SqlCommand variableSQL = new SqlCommand(this.CadenaSQL, this.DbConnection);
                    variableSQL.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "Mensaje Sistema");
                    return;
                }




            } //fin esSelect






        }// fin conectar

        //public static void Main(String[]args )
        //{
        //    ConexionSQL conect = new ConexionSQL();
        //    conect.NombreBaseDatos = "Prueba2";
        //    conect.NombreTabla = "Producto";
        //    conect.CadenaConexion = "Data Source=DESKTOP-9PT39RR;Initial Catalog=Prueba2;Integrated Security=True";
        //    conect.CadenaSQL = "INSERT INTO Producto (cod_producto, nom_producto, peso_producto) VALUES ('"
        //                    + 


        //}




    } //finclass
}//fin namespace
