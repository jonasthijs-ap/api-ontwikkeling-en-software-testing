using ApiOntwikkelingProject.Entities;
using ApiOntwikkelingProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiOntwikkelingProject.Controllers
{
    [Route("[controller]")]
    public class ClubController : Controller
    {
        private readonly IClubData clubData;

        public ClubController(IClubData clubData)
        {
            this.clubData = clubData;
        }

        [Route("")]
        public IActionResult Index()
        {
            return new ObjectResult(clubData.GetAll());
        }

        [Route("{id?}")]
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