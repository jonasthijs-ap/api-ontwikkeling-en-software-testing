using ApiOntwikkelingProject.Entities;
using ApiOntwikkelingProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiOntwikkelingProject.Controllers
{
    [Route("[controller]")]
    public class CampingController : Controller
    {
        private readonly ICampingData campingData;

        public CampingController(ICampingData campingData)
        {
            this.campingData = campingData;
        }

        [Route("")]
        public IActionResult Index()
        {
            return new ObjectResult(campingData.GetAll());
        }

        [Route("{id?}")]
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