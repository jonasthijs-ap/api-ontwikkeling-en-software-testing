using ApiOntwikkelingProject.Entities;
using ApiOntwikkelingProject.Services;
using ApiOntwikkelingProject.ViewModels;
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

            if (club is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(club);
            }
        }

        [HttpPost("")]
        public IActionResult Create([FromBody] ClubCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                Club newClub = new Club
                {
                    Name = model.Name,
                    HeadOfficeAddress = model.HeadOfficeAddress,
                    PartnerWithCampingId = model.PartnerWithCampingId
                };

                clubData.Add(newClub);
                return CreatedAtAction(nameof(Details), new { newClub.Id }, newClub);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Club club = clubData.Get(id);

            if (club is null)
            {
                return NotFound();
            }
            else
            {
                clubData.Delete(id);
                return NoContent();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] ClubUpdateViewModel model, int id)
        {
            Club club = clubData.Get(id);
            if (club is null)
            {
                return NotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                else
                {
                    Club newClubData = new Club
                    {
                        Id = id,
                        Name = model.Name,
                        HeadOfficeAddress = model.HeadOfficeAddress
                    };

                    clubData.Update(newClubData);
                    return NoContent();
                }
            }
        }
    }
}