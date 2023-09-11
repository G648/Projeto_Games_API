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
    public class StudioController : ControllerBase
    {

        private IStudioRepository _studioRepository { get; set; }

       public StudioController()
        {
            _studioRepository = new StudioRepository();
        }

        /// <summary>
        /// Método de listagem de todos os Studios
        /// </summary>
        /// <returns>Studios listados</returns>
        [HttpGet]
        //[Authorize(Roles = "Administrador, Comum")]
        public IActionResult Get()
        {
            try
            {
               List<StudioDomain> listarStudios =  _studioRepository.ListarTodos();

                return Ok(listarStudios);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Método para realizar o cadastro de um novo estudio de jogos
        /// </summary>
        /// <param name="novoStudio"></param>
        /// <returns>Objeto Criado</returns>
        [HttpPost]
        //[Authorize(Roles ="Administrador")]
        public IActionResult Post(StudioDomain novoStudio)
        {
            try
            {
                _studioRepository.cadastrar(novoStudio);

                return Created("Objeto criado com sucesso!", novoStudio);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
