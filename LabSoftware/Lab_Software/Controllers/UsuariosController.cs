using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab_Software.DTO;
using System.IO;
namespace Lab_Software.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
       private static  List<UsuarioDTO> ListaUsuarios = new List<UsuarioDTO>();
        [HttpGet("ListarUsuarios")]
        public ActionResult<List<UsuarioDTO>> Get() {
            return new List<UsuarioDTO>();
        }
        [HttpGet("ObtenerArchivo")]
        public ActionResult<List<UsuarioDTO>> ObeterArchivo() {
            StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + "\\bin\\Debug\\net5.0\\MOCK_DATA.csv");
            
            while (!sr.EndOfStream) {
                ListaUsuarios.Add(new UsuarioDTO(sr.ReadLine()));
            }
            sr.Close();
            return ListaUsuarios;
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
            var lineas = System.IO.File.ReadAllLines(archivoRuta).ToList();
            var lineasFiltradas = lineas.Where(l => !l.Contains(correoElectronico)).ToList();
            System.IO.File.WriteAllLines(archivoRuta, lineasFiltradas);

            return Ok(new { mensaje = "Usuario eliminado con éxito." });
        }
    }
}
