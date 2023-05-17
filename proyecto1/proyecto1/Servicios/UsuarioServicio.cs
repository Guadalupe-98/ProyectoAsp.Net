using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Modelos;
using WebApi.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static WebApi.Controllers.UsuarioController;

namespace WebApi.Servicios
{
    public class UsuarioServicio : IUsuarioService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;

        public UsuarioServicio(IConfiguration configuration, UserManager<Usuario> userManager, SignInManager<Usuario> signInManager)
        {
            _configuration = configuration;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<string> RegistrarUsuario(UsuarioDto usuarioDto)
        {
            var usuario = new Usuario { UserName =usuarioDto.nombreUsuario,nombre=usuarioDto.nombre, apellido=usuarioDto.apellido, };
            var resultado = await _userManager.CreateAsync(usuario, usuarioDto.contraseña);
            if(resultado.Succeeded)
            {
                var token = GenerarJwtToken(usuario);
                return token;
            }

            return null;
        }

        public async Task<string> IniciarSesion(string nombreUsuario, string contraseña)
        {
            var usuario = await _userManager.FindByNameAsync(nombreUsuario);
            if(usuario != null && await _userManager.CheckPasswordAsync(usuario,contraseña))
            {
                var token = GenerarJwtToken(usuario) ;
                return token;
            }
            return null;
        }

        public IEnumerable<Usuario> ObtenerUsuarios()
        {
            var usuarios = _userManager.Users;
            return usuarios;
        }


        private string GenerarJwtToken (Usuario usuario)
        {
            var claims = new List<Claim> {

                new Claim (ClaimTypes.NameIdentifier,usuario.Id),
                new Claim(ClaimTypes.Name,usuario.UserName)

            };

            var key= new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials (key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddHours(Convert.ToDouble(_configuration["Jwt:ExpireHours"]));

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: expires,
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken (token);

        }
    }
}
