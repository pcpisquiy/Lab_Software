using Microsoft.AspNetCore.Mvc;
using Lab_Software.Controllers;

public class EliminarUsuario_Test
{
    private readonly UsuariosController _controller;

    public EliminarUsuario_Test()
    {
        _controller = new UsuariosController();
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
