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
            return Ok(camperData.GetAll());
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
                    ClubId = model.ClubId
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
                    return BadRequest(ModelState);
                }
                else
                {
                    if (model.FirstName is not null)
                    {
                        camper.FirstName = model.FirstName;
                    }

                    if (model.LastName is not null)
                    {
                        camper.LastName = model.LastName;
                    }
                    
                    if (model.Address is not null)
                    {
                        camper.Address = model.Address;
                    }

                    camper.ClubId = model.ClubId;

                    camperData.Update(camper);
                    return NoContent();
                }
            }
        }
    }
}