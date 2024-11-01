using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab_Software.DTO;
using System.IO;
using Lab_Software.Helpers;
using System.Windows;
namespace Lab_Software.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        public UsuariosController() {
            GenerarLista();
            Validador = new ValidacionesGenerales(ListaUsuarios);
        }
        
        private static List<UsuarioDTO> ListaUsuarios = new List<UsuarioDTO>();
        
        protected string FilePath = AppDomain.CurrentDomain.BaseDirectory +"/MOCK_DATA.csv";

        private static ValidacionesGenerales Validador;

        [HttpGet("ListarUsuarios")]
        public ActionResult<List<UsuarioDTO>> Get() {
            return ListaUsuarios;
        }
        protected void GenerarLista() {
            StreamReader sr = new StreamReader(FilePath);

            int identificadorUsuario = 1;
            while (!sr.EndOfStream) {
                ListaUsuarios.Add(new UsuarioDTO(sr.ReadLine(), identificadorUsuario));
                identificadorUsuario++;
            }
            sr.Close();
        }
        [HttpDelete("EliminarUsuario/{correoElectronico}")]
        public ActionResult Delete(string correoElectronico)
        {
            var usuario = ListaUsuarios.FirstOrDefault(u => u.Correo_Electronico == correoElectronico);
            if (usuario == null)
            {
                return NotFound(new { mensaje = "Usuario no encontrado." });
            }
            ListaUsuarios.Remove(usuario);
            var lineas = System.IO.File.ReadAllLines(FilePath).ToList();
            var lineasFiltradas = lineas.Where(l => !l.Contains(correoElectronico)).ToList();
            System.IO.File.WriteAllLines(FilePath, lineasFiltradas);

            return Ok(new { mensaje = "Usuario eliminado con éxito." });
        }

        [HttpPut("AcualizarUsurio/{id}")]
        public ActionResult ActualizarUsuario(int id, [FromBody] UsuarioDTO usuarioActualizar)
        {
            bool usuarioValido = ListaUsuarios.Exists(usuario => usuario.IdentificadorUsuario == id);
            if (!usuarioValido)
            {
                return NotFound(new { mensaje = "Usuario no encontrado." });
            }

            int indiceUsuario = ListaUsuarios.FindIndex(usuario => usuario.IdentificadorUsuario == id);

            if (!string.IsNullOrEmpty(usuarioActualizar.Nombre_Completo) && Validador.ValidarNombre(usuarioActualizar.Nombre_Completo))
            {
                ListaUsuarios[indiceUsuario].Nombre_Completo = usuarioActualizar.Nombre_Completo;
            }

            if (!string.IsNullOrEmpty(usuarioActualizar.Correo_Electronico) && Validador.ValidarCorreo(usuarioActualizar.Correo_Electronico))
            {
                ListaUsuarios[indiceUsuario].Correo_Electronico = usuarioActualizar.Correo_Electronico;
            }

            if (!string.IsNullOrEmpty(usuarioActualizar.Contraseña) && Validador.ValidarContra(usuarioActualizar.Contraseña))
            {
                ListaUsuarios[indiceUsuario].Contraseña = usuarioActualizar.Contraseña;
            }

            if (Validador.ValidarEdad(usuarioActualizar.Edad))
            {
                ListaUsuarios[indiceUsuario].Edad = usuarioActualizar.Edad;
            }

            if (!string.IsNullOrEmpty(usuarioActualizar.Pais) && Validador.ValidarPais(usuarioActualizar.Pais))
            {
                ListaUsuarios[indiceUsuario].Pais = usuarioActualizar.Pais;
            }

            if (Validador.ValidarTelefono(usuarioActualizar.Numero_de_Telefono))
            {
                ListaUsuarios[indiceUsuario].Edad = usuarioActualizar.Edad;
            }

            return Ok(new { mensaje = "Usuario actualizado con éxito.", usario = ListaUsuarios[indiceUsuario] });
        }
    }
}
