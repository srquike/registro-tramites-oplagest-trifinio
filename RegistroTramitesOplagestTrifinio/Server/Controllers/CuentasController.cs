using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RegistroTramitesOplagestTrifinio.Models;
using RegistroTramitesOplagestTrifinio.Shared.DTOs.Roles;
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
        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public CuentasController(UserManager<UsuarioModel> userManager, SignInManager<UsuarioModel> signInManager, IConfiguration configuration, IMapper mapper, IPasswordHasher<UsuarioModel> passwordHasher, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _mapper = mapper;
            _roleManager = roleManager;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UsuarioFormularioDTO formularioUsuario)
        {
            var usuario = _mapper.Map<UsuarioFormularioDTO, UsuarioModel>(formularioUsuario);
            usuario.Creacion = DateOnly.FromDateTime(DateTime.Today);
            usuario.UserName = usuario.Email;

             var resultado = await _userManager.CreateAsync(usuario);

            if (resultado.Succeeded)
            {
                return NoContent();
            }

            foreach (var item in resultado.Errors)
            {
                Console.WriteLine(item.Description);
            }

            return BadRequest();
        }

        [HttpPost("ingresar")]
        [AllowAnonymous]
        public async Task<ActionResult<UsuarioTokenDTO>> Ingresar([FromBody] UsuarioIngresarDTO inicioSesionUsuario)
        {
            var resultado = await _signInManager.PasswordSignInAsync(inicioSesionUsuario.CorreoElectronico, inicioSesionUsuario.Clave, false, false);

            if (resultado.Succeeded)
            {
                var usuario = await _userManager.FindByEmailAsync(inicioSesionUsuario.CorreoElectronico);

                if (usuario.Activo)
                {
                    var roles = await _userManager.GetRolesAsync(usuario);

                    return ObtenerToken(usuario, roles);
                }

                return BadRequest("El usuario no esta activado");
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

        [HttpGet("roles")]
        public async Task<ActionResult<List<RolDTO>>> GetRoles()
        {
            return await _roleManager.Roles.Select(x => new RolDTO { Nombre = x.Name, RolId = x.Id }).ToListAsync();
        }

        [HttpPut("{usuarioId}")]
        public async Task<ActionResult> Put(string usuarioId, UsuarioFormularioDTO usuarioFormulario)
        {
            var usuario = await _userManager.FindByIdAsync(usuarioId);

            if (usuario != null)
            {
                usuario.Email = usuarioFormulario.CorreoElectronico;
                usuario.Nombre = usuarioFormulario.Nombre;
                usuario.Activo = usuarioFormulario.Activo;

                await _userManager.UpdateAsync(usuario);

                return NoContent();
            }

            return NotFound();
        }

        [HttpPut("CambiarClave")]
        public async Task<ActionResult> CambiarClave([FromBody] UsuarioCambiarClaveDTO usuarioCambiarClave)
        {
            var usuario = await _userManager.FindByIdAsync(usuarioCambiarClave.UsuarioId);

            if (usuario != null)
            {
                await _userManager.RemovePasswordAsync(usuario);
                await _userManager.AddPasswordAsync(usuario, usuarioCambiarClave.Clave);

                return NoContent();
            }

            return NotFound();
        }
        
        [HttpPut("CambiarRol")]
        public async Task<ActionResult> CambiarRol([FromBody] UsuarioCambiarRol usuarioCambiarRol)
        {
            var usuario = await _userManager.FindByIdAsync(usuarioCambiarRol.UsuarioId);

            if (usuario != null)
            {
                if (!await _userManager.IsInRoleAsync(usuario, usuarioCambiarRol.Rol))
                {
                    await _userManager.AddToRoleAsync(usuario, usuarioCambiarRol.Rol);
                    return NoContent();
                }

                return BadRequest("El usuario ya tiene este rol asignado");
            }

            return NotFound("El usuario no fue encontrado");
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

        private UsuarioTokenDTO ObtenerToken(UsuarioModel usuario, IList<string> roles)
        {
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, usuario.Email),
                new Claim(ClaimTypes.Name, usuario.Nombre),
                new Claim(ClaimTypes.Email, usuario.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            foreach (var rol in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, rol));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwt:key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddHours(1);
            var token = new JwtSecurityToken(issuer: null, audience: null, claims: claims, expires: expiration, signingCredentials: credentials);

            return new UsuarioTokenDTO { Expiration = expiration, Token = new JwtSecurityTokenHandler().WriteToken(token) };
        }
    }
}
