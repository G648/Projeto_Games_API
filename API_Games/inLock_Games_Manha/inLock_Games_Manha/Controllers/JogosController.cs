using inLock_Games_Manha.Domains;
using inLock_Games_Manha.Interfaces;
using inLock_Games_Manha.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace inLock_Games_Manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class JogosController : ControllerBase
    {

        /// <summary>
        /// objeto _jogosRepository que iirá receber todos os métodos definidos na interface IJogosRepository
        /// </summary>

        private IJogosRepository _jogosRepository { get; set; }

        public JogosController()
        {
            _jogosRepository = new JogosRepository();
        }

        /// <summary>
        /// Método para realizar o cadastro de um novo Jogo
        /// </summary>
        /// <param name="novoJogo"></param>
        /// <returns>Jogo Cadastrado</returns>
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public IActionResult Post(JogosDomain novoJogo)
        {
            try
            {
                _jogosRepository.cadastrar(novoJogo);

                return Created("Objeto cadastrado com sucesso!", novoJogo);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Método para realizar a listagem de um determinado jogo
        /// </summary>
        /// <returns>jogo listado</returns>
        [HttpGet]
        [Authorize(Roles ="Administrador, Comum")]
        public IActionResult Get()
        {
            try
            {
                List<JogosDomain> ListaFilmes = _jogosRepository.ListarTodos();

                return Ok(ListaFilmes);
            }
            catch (Exception error)
            {
                return  BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Método para realizar o delete de um studio específico
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Ok, Objeto deletado</returns>
        [HttpDelete]
        [Authorize(Roles ="Administrador")]
        public IActionResult Delete (int id)
        {
            try
            {
                _jogosRepository.deletar(id);

                return StatusCode(204);
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }
    }
}
