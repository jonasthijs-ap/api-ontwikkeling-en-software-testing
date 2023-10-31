using ApiOntwikkelingProject.Entities;
using ApiOntwikkelingProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiOntwikkelingProject.Controllers
{
    [Route("api/[controller]")]
    public class ClubController : Controller
    {
        private readonly IClubData clubData;

        public ClubController(IClubData clubData)
        {
            this.clubData = clubData;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return new OkObjectResult(clubData.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            Club club = clubData.Get(id);

            if (club == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(club);
            }
        }
    }
}