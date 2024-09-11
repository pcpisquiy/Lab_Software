using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_Software.DTO
{
    public class UsuarioDTO
    {
        public string Nombre_Completo { get; set; }
        public string Correo_Electronico { get; set; }
        public string Contraseña { get; set; }
        public string Edad { get; set; }
        public string Pais { get; set; }
        public string Numero_de_Telefono { get; set; }
    }
}
