using BollywoodHubAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BollywoodHubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritesController : ControllerBase
    {
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult getFavorites(Guid id)
        {
            return NotFound();
        }
    }
}
