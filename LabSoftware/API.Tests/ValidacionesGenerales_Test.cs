using Lab_Software.Helpers;
using Lab_Software.DTO;
namespace API.Tests
{
    public class ValidacionesGenerales_Test
    {

        public List<UsuarioDTO> listaUsuarios = new List<UsuarioDTO>();
        public ValidacionesGenerales validaciones;
        
        [Fact]
        public void ValidarNombreCorrecto_Test()
        {
            // Arrange 
            listaUsuarios.Add(new UsuarioDTO
            {
                IdentificadorUsuario = 1,
                Nombre_Completo = "Jose Mario Marroquin",
            });

            validaciones = new ValidacionesGenerales(listaUsuarios);

            // Act
            var resultado = validaciones.ValidarNombre(listaUsuarios[0].Nombre_Completo);

            // Assert
            Assert.True(resultado);

        }

        [Fact]
        public void ValidarNombreIncorrecto_Test()
        {
            // Arrange 
            listaUsuarios.Add(new UsuarioDTO
            {
                IdentificadorUsuario = 1,
                Nombre_Completo = "XLR8",
            });

            validaciones = new ValidacionesGenerales(listaUsuarios);

            // Act
            var resultado = validaciones.ValidarNombre(listaUsuarios[0].Nombre_Completo);

            // Assert
            Assert.False(resultado);

        }

        [Fact]
        public void ValidarCorreoeCorrecto_Test()
        {
            // Arrange 
            string correo = "jmmr114@gmail.com";

            validaciones = new ValidacionesGenerales(listaUsuarios);

            // Act
            var resultado = validaciones.ValidarCorreo(correo);

            // Assert
            Assert.True(resultado);

        }

        [Fact]
        public void ValidarCorreoIncorrecto_Test()
        {
            // Arrange 
            listaUsuarios.Add(new UsuarioDTO
            {
                IdentificadorUsuario = 1,
                Correo_Electronico = "jmmr114#correo.com",
            });

            validaciones = new ValidacionesGenerales(listaUsuarios);

            // Act
            var resultado = validaciones.ValidarCorreo(listaUsuarios[0].Correo_Electronico);

            // Assert
            Assert.False(resultado);

        }

    }
}