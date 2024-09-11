using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab_Software.DTO;
namespace Lab_Software.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        [HttpGet("ListarUsuarios")]
        public ActionResult<List<UsuarioDTO>> Get() {
            return new List<UsuarioDTO>();
        }
    }
}
