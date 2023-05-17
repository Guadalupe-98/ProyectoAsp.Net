using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Modelos;
using static WebApi.Controllers.UsuarioController;

namespace WebApi.Servicios.Interfaces
{
    public interface IUsuarioService
    {
        Task<string> RegistrarUsuario(UsuarioDto usuarioDto);
        Task<string> IniciarSesion(string nombreUsuario, string contraseña);
        IEnumerable<Usuario> ObtenerUsuarios();
        
    }
}
