using ApiOntwikkelingProject.Entities;
using ApiOntwikkelingProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiOntwikkelingProject.Controllers
{
    [Route("[controller]")]
    public class CamperController : Controller
    {
        private readonly ICamperData camperData;

        public CamperController(ICamperData camperData)
        {
            this.camperData = camperData;
        }

        [Route("")]
        public IActionResult Index()
        {
            return new ObjectResult(camperData.GetAll());
        }

        [Route("{id?}")]
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