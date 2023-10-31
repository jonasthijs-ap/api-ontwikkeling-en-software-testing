using ApiOntwikkelingProject.Entities;
using ApiOntwikkelingProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiOntwikkelingProject.Controllers
{
    [Route("api/[controller]")]
    public class CampingController : Controller
    {
        private readonly ICampingData campingData;

        public CampingController(ICampingData campingData)
        {
            this.campingData = campingData;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return new OkObjectResult(campingData.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            Camping camping = campingData.Get(id);

            if (camping == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(camping);
            }
        }
    }
}