using ApiOntwikkelingProject.Entities;
using ApiOntwikkelingProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiOntwikkelingProject.Controllers
{
    [Route("api/[controller]")]
    public class CamperController : Controller
    {
        private readonly ICamperData camperData;

        public CamperController(ICamperData camperData)
        {
            this.camperData = camperData;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return new OkObjectResult(camperData.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            Camper camper = camperData.Get(id);

            if (camper == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(camper);
            }
        }
    }
}