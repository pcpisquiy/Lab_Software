using Microsoft.AspNetCore.Mvc;
using Lab_Software.Controllers;
using Lab_Software.Helpers;

public class EliminarUsuario_Test
{
    private readonly UsuariosController _controller;

    IValidacionesGenerales validaciones;

    public EliminarUsuario_Test()
    {
        _controller = new UsuariosController(validaciones);
    }
    [Fact]
    public void Delete_UsuarioNoExistente_DeberiaRetornarNotFound()
    {
        // Arrange
        var correoElectronico = "nonexistent@example.com";

        // Act
        var result = _controller.Delete(correoElectronico) as NotFoundObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(404, result.StatusCode);
       // Assert.Equal("Usuario no encontrado.", ((dynamic)result.Value).mensaje);
    }
}
