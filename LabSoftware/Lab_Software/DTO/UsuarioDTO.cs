using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_Software.DTO
{
    public class UsuarioDTO
    {
        public UsuarioDTO()
        {
            IDUsuario = 0;
            Nombre_Completo = string.Empty;
            Correo_Electronico = string.Empty;
            Contraseña = string.Empty;
            Edad = -1;
            Pais = string.Empty;
            Numero_de_Telefono = string.Empty;
        }

        public UsuarioDTO(string Data, int idUsuario)
        {
            string[] TuplaUsuario = Data.Split(',');

            Nombre_Completo = TuplaUsuario[0];
            Correo_Electronico = TuplaUsuario[1];
            Contraseña = TuplaUsuario[2];
            Edad = !TuplaUsuario[3].Equals(string.Empty) ? int.Parse(TuplaUsuario[3]) : -1;
            Pais = TuplaUsuario[4];
            Numero_de_Telefono = TuplaUsuario[5];
        }

        /// <summary>
        /// Obtiene o establece el identificador del usuario.
        /// </summary>
        public int IDUsuario { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre completo del usuario.
        /// </summary>
        public string Nombre_Completo { get; set; }

        /// <summary>
        /// Obtiene o estblece el correo electrónico del usuario.
        /// </summary>
        public string Correo_Electronico { get; set; }

        /// <summary>
        ///  Obtiene o estblece la contraseña del usuario.
        /// </summary>
        public string Contraseña { get; set; }
        
        /// <summary>
        /// Obtiene o estblece la edad del usuario.
        /// </summary>
        public int Edad { get; set; }
        
        /// <summary>
        /// Obtiene o estblece el Pais del usuario.
        /// </summary>
        public string Pais { get; set; }
        
        /// <summary>
        /// Obtiene o estblece el Numero de Telefono del usuario.
        /// </summary>
        public string Numero_de_Telefono { get; set; }
    }
}
