using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace CapaDTO
{
    public class Paciente
    {
        private int rut;
        private string dv;
        private string nomPaciente;
        private string apPaciente;
        private string direccion;
        private int comuna;

        public int Rut { get => rut; set => rut = value; }
        public string Dv { get => dv; set => dv = value; }
        public string NomPaciente { get => nomPaciente; set => nomPaciente = value; }
        public string ApPaciente { get => apPaciente; set => apPaciente = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public int Comuna { get => comuna; set => comuna = value; }
    }//finClass
}
