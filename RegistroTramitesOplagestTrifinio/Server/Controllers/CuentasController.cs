using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RegistroTramitesOplagestTrifinio.Models;
using RegistroTramitesOplagestTrifinio.Shared.DTOs.Usuarios;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RegistroTramitesOplagestTrifinio.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CuentasController : ControllerBase
    {
        private readonly UserManager<UsuarioModel> _userManager;
        private readonly SignInManager<UsuarioModel> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public CuentasController(UserManager<UsuarioModel> userManager, SignInManager<UsuarioModel> signInManager, IConfiguration configuration, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UsuarioFormularioDTO formularioUsuario)
        {
            var usuario = _mapper.Map<UsuarioFormularioDTO, UsuarioModel>(formularioUsuario);
            usuario.Creacion = DateOnly.FromDateTime(DateTime.Today);

            var resultado = await _userManager.CreateAsync(usuario, formularioUsuario.Clave);

            if (resultado.Succeeded)
            {
                return NoContent();
            }
            else
            {
                foreach (var item in resultado.Errors)
                {
                    Console.WriteLine(item.Description);
                }
                return BadRequest();
            }
        }

        [HttpPost("ingresar")]
        [AllowAnonymous]
        public async Task<ActionResult<UsuarioTokenDTO>> Ingresar([FromBody] UsuarioIngresarDTO inicioSesionUsuario)
        {
            var resultado = await _signInManager.PasswordSignInAsync(inicioSesionUsuario.CorreoElectronico, inicioSesionUsuario.Clave, false, false);

            if (resultado.Succeeded)
            {
                return ObtenerToken(inicioSesionUsuario);
            }
            else
            {
                return BadRequest("Usuario o clave incorrectos.");
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioListaDTO>>> Get()
        {
            var usuarios = await _userManager.Users.ToListAsync();

            return _mapper.Map<List<UsuarioModel>, List<UsuarioListaDTO>>(usuarios);
        }

        [HttpPut("{usuarioId}")]
        public async Task<ActionResult> Put(string usuarioId, UsuarioEditarDTO usuarioFormulario)
        {
            var usuario = await _userManager.FindByIdAsync(usuarioId);

            if (usuario != null)
            {
                await _userManager.UpdateAsync(_mapper.Map<UsuarioEditarDTO, UsuarioModel>(usuarioFormulario));
                return NoContent();
            }

            return NotFound();
        }

        [HttpDelete("{usuarioId}")]
        public async Task<ActionResult> Delete(string usuarioId)
        {
            var usuario = await _userManager.FindByIdAsync(usuarioId);

            if (usuario != null)
            {
                await _userManager.DeleteAsync(usuario);
                return NoContent();
            }

            return NotFound();
        }

        [HttpGet("{usuarioId}")]
        public async Task<ActionResult<UsuarioFormularioDTO>> Get(string usuarioId)
        {
            var usuario = await _userManager.FindByIdAsync(usuarioId);

            if (usuario != null)
            {
                return _mapper.Map<UsuarioModel, UsuarioFormularioDTO>(usuario);
            }

            return NotFound();
        }

        private UsuarioTokenDTO ObtenerToken(UsuarioIngresarDTO inicioSesionUsuario)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, inicioSesionUsuario.CorreoElectronico),
                new Claim(ClaimTypes.Name, inicioSesionUsuario.CorreoElectronico),
                new Claim(ClaimTypes.Email, inicioSesionUsuario.CorreoElectronico),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwt:key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddHours(1);
            var token = new JwtSecurityToken(issuer: null, audience: null, claims: claims, expires: expiration, signingCredentials: credentials);

            return new UsuarioTokenDTO { Expiration = expiration, Token = new JwtSecurityTokenHandler().WriteToken(token) };
        }
    }
}
