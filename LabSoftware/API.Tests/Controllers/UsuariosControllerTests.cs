using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_Software.DTO;
using System.IO;
using Lab_Software.Helpers;
using Lab_Software.Controllers;

namespace API.Tests.Controllers
{
    public class UsuariosControllerTests
    {
        [Fact]
        public void Get_ReturnsListOfUsuarios()
        {
            //Arrange
            var controller = new UsuariosController();

            //Act
            var result = controller.Get();

            //Assert
            var okResult = Assert.IsType<ActionResult<List<UsuarioDTO>>>(result);
            Assert.NotNull(okResult.Value);
            Assert.IsType<List<UsuarioDTO>>(okResult.Value);
        }

        [Fact]
        public void Delete_ReturnsOk_WhenUsuarioExists()
        {
            //Arrange
            var controller = new UsuariosController();
            var correoExistente = "usuario@example.com";
            controller.Get().Value.Add(new UsuarioDTO(correoExistente, 1));

            //Act
            var result = controller.Delete(correoExistente);

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
