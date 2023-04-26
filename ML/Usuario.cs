using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string ApellidoMaterno { get; set; }
        public string ApellidoPaterno { get; set; }
        public string FechaNacimineto { get; set; }
        public char Sexo { get; set; }
        public string EstadoCivil { get; set; }
        public string Curp { get; set; }
        public ML.Direccion Direccion  { get; set; }
        public List<object> Usuarios { get; set; }
    }
}
