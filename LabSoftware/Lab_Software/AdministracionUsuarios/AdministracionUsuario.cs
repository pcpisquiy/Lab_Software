namespace Lab_Software.AdministracionUsuarios
{
    using System;
    using Lab_Software.DTO;
    using System.Collections.Generic;

    public class AdministracionUsuario
    {
        public bool ActualizacionUsuario(UsuarioDTO usuario, int idUsuario, ref List<UsuarioDTO> usuarios)
        {
            try
            {
                int indiceUsuario = usuarios.FindIndex(usuarioFind => usuarioFind.IDUsuario == idUsuario);

                //// true debe ser reemplazado por validación de nombre
                if (!string.IsNullOrEmpty(usuario.Nombre_Completo) && true)
                {
                    usuarios[indiceUsuario].Nombre_Completo = usuario.Nombre_Completo;
                }
                //// true debe ser reemplazado por validación de correo electrónico
                if (!string.IsNullOrEmpty(usuario.Correo_Electronico) && true)
                {
                    usuarios[indiceUsuario].Correo_Electronico = usuario.Correo_Electronico;
                }
                //// true debe ser reemplazado por validación de contraseña
                if (!string.IsNullOrEmpty(usuario.Contraseña) && true)
                {
                    usuarios[indiceUsuario].Contraseña = usuario.Contraseña;
                }
                //// true debe ser reemplazado por validación de edad
                if (true)
                {
                    usuarios[indiceUsuario].Edad = usuario.Edad;
                }
                //// true debe ser reemplazado por validación de edad
                if (!string.IsNullOrEmpty(usuario.Pais) && true)
                {
                    usuarios[indiceUsuario].Pais = usuario.Pais;
                }
                //// true debe ser reemplazado por validación de número de teléfono
                if (true)
                {
                    usuarios[indiceUsuario].Numero_de_Telefono = usuario.Numero_de_Telefono;
                }

                return true;
            }
            catch (Exception ex)
            {
                // Ocurrió un error, bitácora
                return false;
            }
        }
    }
}
