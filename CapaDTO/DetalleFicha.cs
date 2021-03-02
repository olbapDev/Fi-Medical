using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDTO
{
    public class DetalleFicha
    {
        private int idDetalle;
        private string descripcion;
        private DateTime fCita;
        private int idEnfermedad;

        public int IdDetalle { get => idDetalle; set => idDetalle = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public DateTime FCita { get => fCita; set => fCita = value; }
        public int IdEnfermedad { get => idEnfermedad; set => idEnfermedad = value; }
    }//finclass

}
