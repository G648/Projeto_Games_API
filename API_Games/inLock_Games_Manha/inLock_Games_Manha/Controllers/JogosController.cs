using inLock_Games_Manha.Domains;
using inLock_Games_Manha.Interfaces;
using inLock_Games_Manha.Repositories;
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

        [HttpPost]
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

        [HttpGet]
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
    }
}
