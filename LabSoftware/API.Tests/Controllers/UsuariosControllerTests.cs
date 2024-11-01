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
using Moq;

namespace API.Tests.Controllers
{
    public class UsuariosControllerTests
    {
        //[Fact]
        //public void Get_ReturnsListOfUsuarios()
        //{
        //    //Arrange
        //    var controller = new UsuariosController(Validador);

        //    //Act
        //    var result = controller.Get();

        //    //Assert
        //    var okResult = Assert.IsType<ActionResult<List<UsuarioDTO>>>(result);
        //    Assert.NotNull(okResult.Value);
        //    Assert.IsType<List<UsuarioDTO>>(okResult.Value);
        //}

        //[Fact]
        //public void Delete_ReturnsOk_WhenUsuarioExists()
        //{
        //    //Arrange
        //    var controller = new UsuariosController(Validador);
        //    var correoExistente = "usuario@example.com";
        //    controller.Get().Value.Add(new UsuarioDTO(correoExistente, 1));

        //    //Act
        //    var result = controller.Delete(correoExistente);

        //    //Assert
        //    Assert.IsType<OkObjectResult>(result);
        //}

        [Fact]
        public void UsuariosController_ActualizarUsuario_IdUsuarioNoExiste()
        {
            int idInvalido = 99999;
            UsuarioDTO usuario = new UsuarioDTO()
            {
                Nombre_Completo = "Justo Rufino Barrios",
                Correo_Electronico = "dabautistac@correo.url.edu.gt",
                Contraseña = "Seguridad123456",
                Edad = 25,
                Pais = "Guatemala",
                Numero_de_Telefono = "55630778",
            };

            Mock<IValidacionesGenerales> validacionesGenerales = new Mock<IValidacionesGenerales>();

            validacionesGenerales.Setup(x => x.UsuarioValido(idInvalido)).Returns(false);
            validacionesGenerales.Setup(x => x.ObtenerIndiceUsuario(idInvalido)).Returns(-1);
            validacionesGenerales.Setup(x => x.ValidarNombre(usuario.Nombre_Completo)).Returns(true);
            validacionesGenerales.Setup(x => x.ValidarCorreo(usuario.Correo_Electronico)).Returns(true);
            validacionesGenerales.Setup(x => x.ValidarContra(usuario.Contraseña)).Returns(true);
            validacionesGenerales.Setup(x => x.ValidarEdad(usuario.Edad)).Returns(true);
            validacionesGenerales.Setup(x => x.ValidarPais(usuario.Pais)).Returns(true);
            validacionesGenerales.Setup(x => x.ValidarTelefono(usuario.Numero_de_Telefono)).Returns(true);

            UsuariosController usuariosController = new UsuariosController(validacionesGenerales.Object);

            var respuesta = usuariosController.ActualizarUsuario(idInvalido, usuario);

            Assert.IsType<NotFoundObjectResult>(respuesta);
        }

        [Fact]
        public void UsuariosController_ActualizarUsuario_ActualizacionNombreCorrecta()
        {
            int idInvalido = 10;
            UsuarioDTO usuario = new UsuarioDTO()
            {
                Nombre_Completo = "Pablo Pisquiy",
            };

            Mock<IValidacionesGenerales> validacionesGenerales = new Mock<IValidacionesGenerales>();

            validacionesGenerales.Setup(x => x.UsuarioValido(idInvalido)).Returns(true);
            validacionesGenerales.Setup(x => x.ObtenerIndiceUsuario(idInvalido)).Returns(10);
            validacionesGenerales.Setup(x => x.ValidarNombre(usuario.Nombre_Completo)).Returns(true);
            validacionesGenerales.Setup(x => x.ValidarCorreo(usuario.Correo_Electronico)).Returns(true);
            validacionesGenerales.Setup(x => x.ValidarContra(usuario.Contraseña)).Returns(true);
            validacionesGenerales.Setup(x => x.ValidarEdad(usuario.Edad)).Returns(true);
            validacionesGenerales.Setup(x => x.ValidarPais(usuario.Pais)).Returns(true);
            validacionesGenerales.Setup(x => x.ValidarTelefono(usuario.Numero_de_Telefono)).Returns(true);

            UsuariosController usuariosController = new UsuariosController(validacionesGenerales.Object);

            var respuesta = usuariosController.ActualizarUsuario(idInvalido, usuario);

            Assert.IsType<OkObjectResult>(respuesta);
        }
    }
}
