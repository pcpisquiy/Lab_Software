using Lab_Software.DTO;
using System.Collections.Generic;
using System.Security.Permissions;
using System.Text.RegularExpressions;

namespace Lab_Software.Helpers
{
    /// <summary>
    /// Clase con métodos de validaciones generales para el control de información de usuarios
    /// </summary>
    public class ValidacionesGenerales
    {
        #region Atributos privados

        /// <summary>
        /// Lista de usuario para realizar la validación
        /// </summary>
        private static List<UsuarioDTO> ListaUsuarios = new List<UsuarioDTO>();

        // Lista de países válidos en el sistema
        private List<string> ListaPaises = new List<string> { "Guatemala", "El Salvador", "Nicaragua", "Panamá", "México", "Canadá", "Estados Unidos", "Japón" };

        // Expresiones regulares para las validaciones de datos
        private static Regex nombreRegex = new Regex(@"^[A-Za-z]+(?:\s[A-Za-z]+)+$");
        private static Regex correoRegex = new Regex(@"^[\w\.-]+@[a-zA-Z\d\.-]+\.[a-zA-Z]{2,}$");
        private static Regex contraRegex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&#])[A-Za-z\d@$!%*?&#]{8,}$");
        private static Regex telefonoRegex = new Regex(@"^\+\d{1,3}-\d{1,4}-\d{1,4}-\d{1,4}$");

        public ValidacionesGenerales(List<UsuarioDTO> usuarios)
        {
            ListaUsuarios = usuarios;
        }

        #endregion

        #region Métodos públicos

        /// <summary>
        /// Validación de nombre de usuario
        /// </summary>
        /// <param name="_nombreCompleto">Nombre completo del usuario</param>
        /// <returns></returns>
        public bool ValidarNombre(string _nombreCompleto)
        {
            return nombreRegex.IsMatch(_nombreCompleto);
        }

        /// <summary>
        /// Valida el correo electrónico del usuario
        /// </summary>
        /// <param name="_correo">Correo electrónico ingresado</param>
        /// <param name="_listaCorreosRegistrados">Lista de correos existentes en el sistema</param>
        /// <returns></returns>
        public bool ValidarCorreo(string _correo)
        {
            return correoRegex.IsMatch(_correo) && !ListaUsuarios.Exists(usuario => usuario.Correo_Electronico == _correo);
        }

        /// <summary>
        /// Valida contraseña del usuario
        /// </summary>
        /// <param name="_contra">Contraseña ingresada</param>
        /// <returns></returns>
        public bool ValidarContra(string _contra)
        {
            return contraRegex.IsMatch(_contra);
        }

        /// <summary>
        /// Valida edad del usuario
        /// </summary>
        /// <param name="_edad">Edad ingresada</param>
        /// <returns></returns>
        public bool ValidarEdad(int _edad)
        {
            return (_edad >= 18 && _edad <= 120);
        }

        /// <summary>
        /// Valida país del usuario
        /// </summary>
        /// <param name="_pais">País ingresado</param>
        /// <returns></returns>
        public bool ValidarPais(string _pais)
        {
            return ListaPaises.Contains(_pais);
        }

        /// <summary>
        /// Valida teléfono del usuario
        /// </summary>
        /// <param name="_telefono">Teléfono ingresado</param>
        /// <returns></returns>
        public bool ValidarTelefono(string _telefono)
        {
            return telefonoRegex.IsMatch(_telefono);
        }

        #endregion

    }
}