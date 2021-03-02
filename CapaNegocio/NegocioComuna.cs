using CapaConexion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class NegocioComuna
    {
        private ConexionSQL conect;

        public ConexionSQL Conect { get => conect; set => conect = value; }

        public void configurarConexion()
        {
            try
            {
                this.Conect = new ConexionSQL();
                this.Conect.NombreBaseDatos = "Medical";
                this.Conect.NombreTabla = "Comuna";
                this.Conect.CadenaConexion = @"Data Source=DESKTOP-9PT39RR;Initial Catalog=Medical;Integrated Security=True";

            }
            catch (Exception ex)
            {
                MessageBox.Show(" Mensaje Sistema" + ex.Message);
            }
        }//finConfigurarConexion


        public DataTable listarComuna()
        {

            this.configurarConexion();
            this.Conect.CadenaSQL = "SELECT * FROM Comuna;";
            this.Conect.EsSelect = true;
            this.Conect.conectar();

            return this.Conect.DbDataSet.Tables["Comuna"];
           

        }//fin listar comuna






    }
}
