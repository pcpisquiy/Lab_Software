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
            IdentificadorUsuario = 0;
            Nombre_Completo = string.Empty;
            Correo_Electronico = string.Empty;
            Contraseña = string.Empty;
            Edad = 0;
            Pais = string.Empty;
            Numero_de_Telefono = string.Empty;
        }

        public UsuarioDTO(string Data, int identificadorUsuario)
        {
            string[] TuplaUsuario = Data.Split(',');
            if (TuplaUsuario.Length > 6)
            {
                int Inicio = 0;
                IdentificadorUsuario = identificadorUsuario;
                Nombre_Completo = TuplaUsuario[0];
                Correo_Electronico = TuplaUsuario[1];
                
                for (Inicio = 2; Inicio <= TuplaUsuario.Length - 3; Inicio++) {
                    Contraseña += TuplaUsuario[Inicio];
                }
                Edad = TuplaUsuario[TuplaUsuario.Length - 3] == string.Empty ? 0 : int.Parse(TuplaUsuario[TuplaUsuario.Length - 3]);
                Pais = TuplaUsuario[TuplaUsuario.Length - 2];
                Numero_de_Telefono = TuplaUsuario[TuplaUsuario.Length-1];
            }
            else {
                IdentificadorUsuario = identificadorUsuario;
                Nombre_Completo = TuplaUsuario[0];
                Correo_Electronico = TuplaUsuario[1];
                Contraseña = TuplaUsuario[2];
                Edad = TuplaUsuario[3] == string.Empty ? 0 : int.Parse(TuplaUsuario[3]);
                Pais = TuplaUsuario[4];
                Numero_de_Telefono = TuplaUsuario[5];
            }
        }

        public int IdentificadorUsuario { get; set; }

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
