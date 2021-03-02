using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDTO
{
    public class Ficha
    {
        private int idFicha;
        private int idDetalle;
        private int rutPac;

        public int IdFicha { get => idFicha; set => idFicha = value; }
        public int IdDetalle { get => idDetalle; set => idDetalle = value; }
        public int RutPac { get => rutPac; set => rutPac = value; }
    }//finclass
}
