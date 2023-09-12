using inlock_games_DBFirst_manha.Interfaces;
using inlock_games_DBFirst_manha.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace inlock_games_DBFirst_manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("aplication/json")]

    public class EstudioController : Controller
    {
        private IEstudioRepository _estudiorepository { get; set; } 

        public EstudioController() 
        {
            _estudiorepository = new EstudioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_estudiorepository.Listar());
            }
            catch
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
