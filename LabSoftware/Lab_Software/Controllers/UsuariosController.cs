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
        public UsuariosController() {
            GenerarLista();
        }
       private static  List<UsuarioDTO> ListaUsuarios = new List<UsuarioDTO>();
        protected string FilePath = Directory.GetCurrentDirectory() + "\\bin\\Debug\\net5.0\\MOCK_DATA.csv";
        [HttpGet("ListarUsuarios")]
        public ActionResult<List<UsuarioDTO>> Get() {
            return ListaUsuarios;
        }
        protected void GenerarLista() {
            StreamReader sr = new StreamReader(FilePath);
            
            while (!sr.EndOfStream) {
                ListaUsuarios.Add(new UsuarioDTO(sr.ReadLine()));
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
    }
}
