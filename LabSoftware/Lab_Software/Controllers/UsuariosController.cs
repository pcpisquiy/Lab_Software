using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab_Software.DTO;
using System.IO;
using Lab_Software.AdministracionUsuarios;

namespace Lab_Software.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        private static  List<UsuarioDTO> ListaUsuarios = new List<UsuarioDTO>();

        private static AdministracionUsuario administracion = new AdministracionUsuario();
        
        [HttpGet("ListarUsuarios")]
        public ActionResult<List<UsuarioDTO>> Get() {
            return new List<UsuarioDTO>();
        }

        [HttpGet("ObtenerArchivo")]
        public ActionResult<List<UsuarioDTO>> ObeterArchivo() {
            LecturaArchivo();

            return ListaUsuarios;
        }

        [HttpPut]
        [Route("ActualizacionUsuario/{id}")]
        public ActionResult<IActionResult> ActualizacionUsuario(int id, [FromBody] UsuarioDTO usuario)
        {
            LecturaArchivo();
            bool resultadoActualizacion = administracion.ActualizacionUsuario(usuario, id, ref ListaUsuarios);

            if (resultadoActualizacion)
            {
                return this.Ok("El usuario fue actualizado correctamente.");
            }
            else
            {
                return this.BadRequest("Ocurrió un error, los datos del usuario no puedieron ser actualizados correctamente");
            }
            
        }

        private void LecturaArchivo()
        {
            StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + "\\bin\\Debug\\net5.0\\MOCK_DATA.csv");
            int idUsuario = 1;

            while (!sr.EndOfStream)
            {
                ListaUsuarios.Add(new UsuarioDTO(sr.ReadLine(), idUsuario));
                idUsuario++;
            }
            sr.Close();
        }
    }
}
