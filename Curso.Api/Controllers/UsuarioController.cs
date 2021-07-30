using Curso.Api.Filters;
using Curso.Api.Models;
using Curso.Api.Models.Usuarios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Curso.Api.Controllers
{
    [Route("api/v1/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        /// <summary>
        /// Este serviço permite autenticar um usuário cadastrado
        /// </summary>
        /// <param name="loginViewModelInput">View model do login</param>
        /// <returns>Retorna status ok, dados do usuario e o token</returns>
        [SwaggerResponse(statusCode:200, description: "Sucesso ao autenticar", Type = typeof(LoginViewModelInput))]
        [SwaggerResponse(statusCode:400, description: "Campos obrigatórios", Type = typeof(ValidaCampoViewModelOutput))]
        [SwaggerResponse(statusCode:500, description: "Erro interno", Type = typeof(ErroGenericoViwModel))]
        [HttpPost]
        [Route("logar")]
        [ValidacaoModelStateCustomizado]
        public IActionResult Logar(LoginViewModelInput loginViewModelInput)
        {
            //var key = new byte[32];
            //RNGCryptoServiceProvider.Create().GetBytes(key);
            //var base64Secret = Convert.ToBase64String(key);
            //// make safe for url
            //var urlEncoded = base64Secret.TrimEnd('=').Replace('+', '-').Replace('/', '_');

            var usuarioViewModelOutput = new UsuarioViewModelOutput()
            {
                Codigo = 1,
                Login = "rpcajr",
                Email = "rpcajr@gmail.com"
            };

            var secret = Encoding.ASCII.GetBytes("sSs2hDUU0XTQ2wqA6A8YeSM76GV1eQjT0oa5NEk675E");
            var symmetricSecurityKey = new SymmetricSecurityKey(secret);
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, usuarioViewModelOutput.Codigo.ToString()),
                    new Claim(ClaimTypes.Name, usuarioViewModelOutput.Login.ToString()),
                    new Claim(ClaimTypes.Email, usuarioViewModelOutput.Email.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature)

            };

            return Ok(loginViewModelInput);
        }

        [HttpPost]
        [Route("registrar")]
        public IActionResult Registrar(RegistroViewModelInput registroViewModelInput)
        {
            return Created("", registroViewModelInput);
        }
    }
}
