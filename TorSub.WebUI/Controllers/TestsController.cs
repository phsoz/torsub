using Microsoft.AspNetCore.Mvc;
using TorSub.Application.Contracts;

namespace TorSub.WebUI.Controllers
{

    public class TestsController : ApiControllerBase
    {
        private readonly ITestsRepository _repo;

        public TestsController(ITestsRepository repo)
        {
            _repo = repo;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var entity = await _repo.GetAllAsync();
            return Ok(entity);
        }
    }
}
