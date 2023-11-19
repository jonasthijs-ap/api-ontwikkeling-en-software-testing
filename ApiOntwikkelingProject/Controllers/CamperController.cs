using ApiOntwikkelingProject.Entities;
using ApiOntwikkelingProject.Services;
using ApiOntwikkelingProject.ViewModels;
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

            if (camper is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(camper);
            }
        }

        [HttpPost("")]
        public IActionResult Create([FromBody] CamperCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                Camper newCamper = new Camper
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Address = model.Address,
                    MemberFromClubId = model.MemberFromClubId
                };

                camperData.Add(newCamper);
                return CreatedAtAction(nameof(Details), new { newCamper.Id }, newCamper);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Camper camper = camperData.Get(id);

            if (camper is null)
            {
                return NotFound();
            }
            else
            {
                camperData.Delete(id);
                return NoContent();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] CamperUpdateViewModel model, int id)
        {
            Camper camper = camperData.Get(id);
            if (camper is null)
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
                    Camper newCamperData = new Camper
                    {
                        Id = id,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Address = model.Address
                    };

                    camperData.Update(newCamperData);
                    return NoContent();
                }
            }
        }
    }
}