using Microsoft.AspNetCore.Mvc;
using TorSub.Application.Contracts;

namespace TorSub.WebUI.Controllers
{

    public class MoviesController : ApiControllerBase
    {
        private readonly IMovieRepository _movieRepository;

        public MoviesController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var entity = await _movieRepository.GetAllAsync();
            return Ok(entity);
        }
    }
}
