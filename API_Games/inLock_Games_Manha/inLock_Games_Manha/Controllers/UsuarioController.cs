using inLock_Games_Manha.Domains;
using inLock_Games_Manha.Interfaces;
using inLock_Games_Manha.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace inLock_Games_Manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {

        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Post (UsuarioDomain usuario)
        {
            try
            {
                UsuarioDomain usuarioBuscado = _usuarioRepository.Login(usuario.Email, usuario.Senha);  

                if (usuarioBuscado == null)
                {
                    return NotFound("usuario não encontrado");
                }

                //caso encontre o usuario, prossegue para a criação do token

                //1º -> definir as informações (Claims) que serão fornecidos no token (PAYLOAD)

                //realizar instalação dos pacotes no nuget :
                //System.IdentityModel.Tokens.Jwt
                //Microsoft.AspNetCore.Authentication.JwtBearer

                var claims = new[]
                {
                    //formatação da claim 
                    //jti realiza a validação do ID que estamos procurando
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                    new Claim(ClaimTypes.Role, usuarioBuscado.Titulo.Titulo)
                };

                //2º -> difinir a chave de acesso ao token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("projeto-chave-autenticacao-inLock-Games"));

                //3º -> definir as credenciais do token(HEADER)
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //4º -> gerar o token
                //preparando o token
                var token = new JwtSecurityToken
                (
                    //emissor do token
                    issuer: "inLock_Games_Manha",

                    //destinatário do token
                    audience: "inLock_Games_Manha",

                    //dados definidos nas claims(informações)
                    claims: claims,

                    //tempo de expiração do token 
                    expires: DateTime.Now.AddMinutes(5),

                    //por fim, informaremos nossas credenciais do token, definidas como creds
                    signingCredentials: creds
                );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);   
            }
        }

    }
}
