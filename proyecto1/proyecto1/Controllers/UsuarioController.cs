using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Modelos;
using WebApi.Servicios.Interfaces;

namespace WebApi.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UsuarioDto model)
        {
            var token = await _usuarioService.IniciarSesion(model.nombreUsuario, model.contraseña);
            if(token != null) 
            {
                return Ok(new { token });
            }
            return BadRequest(new {message= "Usuario o Constraña incorrecta"});
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Registro(UsuarioDto model)
        {
            var token = await _usuarioService.RegistrarUsuario(model);
            if(token != null)
            {
                return Ok(new { token });
            }
            return BadRequest(new { message = "No se pudo crear el Usuario" });
        }

        public class UsuarioDto
        {
            public string nombreUsuario { get; set; }

            public string nombre { get; set; }

            public string apellido { get; set; }

            public string contraseña { get; set; }
            
        }

    }


}
