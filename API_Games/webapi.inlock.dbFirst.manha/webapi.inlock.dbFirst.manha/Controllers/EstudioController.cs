using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.inlock.dbFirst.manha.Interfaces;
using webapi.inlock.dbFirst.manha.Repositories;

namespace webapi.inlock.dbFirst.manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EstudioController : ControllerBase
    {
        //consegue acessar os métodos criados
        private IEstudioRepository _estudioRepository { get; set; }

        public EstudioController()
        { 
            _estudioRepository = new EstudioRepository();
        }

        [HttpGet]
        public IActionResult Get() 
        {
            try
            {
                return Ok(_estudioRepository.listar());
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpGet("ListarComJogos")]
        public IActionResult ListarComJogos()
        {
            try
            {
                return Ok(_estudioRepository.ListarComJogos());
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
