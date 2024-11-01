using Lab_Software.DTO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Lab_Software.Helpers
{
    /// <summary>
    /// Clase con métodos de validaciones generales para el control de información de usuarios
    /// </summary>
    public interface IValidacionesGenerales
    {
        /// <summary>
        /// Validación de nombre de usuario
        /// </summary>
        /// <param name="_nombreCompleto">Nombre completo del usuario</param>
        /// <returns></returns>
        bool ValidarNombre(string _nombreCompleto);

        /// <summary>
        /// Valida el correo electrónico del usuario
        /// </summary>
        /// <param name="_correo">Correo electrónico ingresado</param>
        /// <param name="_listaCorreosRegistrados">Lista de correos existentes en el sistema</param>
        /// <returns></returns>
        bool ValidarCorreo(string _correo);

        /// <summary>
        /// Valida contraseña del usuario
        /// </summary>
        /// <param name="_contra">Contraseña ingresada</param>
        /// <returns></returns>
        bool ValidarContra(string _contra);

        /// <summary>
        /// Valida edad del usuario
        /// </summary>
        /// <param name="_edad">Edad ingresada</param>
        /// <returns></returns>
        bool ValidarEdad(int _edad);

        /// <summary>
        /// Valida país del usuario
        /// </summary>
        /// <param name="_pais">País ingresado</param>
        /// <returns></returns>
        bool ValidarPais(string _pais);

        /// <summary>
        /// Valida teléfono del usuario
        /// </summary>
        /// <param name="_telefono">Teléfono ingresado</param>
        /// <returns></returns>
        bool ValidarTelefono(string _telefono);

        /// <summary>
        /// Valida si un usuario existe.
        /// </summary>
        /// <param name="identificadorUsuario">Número identificador del usuario</param>
        /// <returns>Si el usuario existe.</returns>
        bool UsuarioValido(int identificadorUsuario);

        /// <summary>
        /// Obtiene el índice correspondiente del usuario a buscar.
        /// </summary>
        /// <param name="identificadorUsuario">Número de identificador del usuario.</param>
        /// <returns>El índice del usuario.</returns>
        int ObtenerIndiceUsuario(int identificadorUsuario);
    }
}