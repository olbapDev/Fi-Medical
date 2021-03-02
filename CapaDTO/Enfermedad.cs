using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDTO
{
    public class Enfermedad
    {
        private int idEnfermedad;
        private string detalle;

        public int IdEnfermedad { get => idEnfermedad; set => idEnfermedad = value; }
        public string Detalle { get => detalle; set => detalle = value; }
    }//finClass

}
