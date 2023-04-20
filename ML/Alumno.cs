using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Alumno
    {
        public int IdAlumno { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string FechaNacimiento { get; set; }
        public string UserName { get; set; }

        //Propiedad de Navegación
        public ML.Semestre Semestre { get; set; }
        public ML.Direccion Direccion { get; set; }
    }
}
