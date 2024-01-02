using ApiOntwikkelingProject.Entities;
using ApiOntwikkelingProject.Services;
using ApiOntwikkelingProject.ViewModels;
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
            return Ok(campingData.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            Camping camping = campingData.Get(id);

            if (camping is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(camping);
            }
        }

        [HttpPost("")]
        public IActionResult Create([FromBody] CampingCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                Camping newCamping = new Camping
                {
                    Name = model.Name,
                    Address = model.Address
                };

                campingData.Add(newCamping);
                return CreatedAtAction(nameof(Details), new { newCamping.Id }, newCamping);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Camping camping = campingData.Get(id);

            if (camping is null)
            {
                return NotFound();
            }
            else
            {
                campingData.Delete(id);
                return NoContent();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] CampingUpdateViewModel model, int id)
        {
            Camping camping = campingData.Get(id);
            if (camping is null)
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
                    if (model.Name is not null)
                    {
                        camping.Name = model.Name;
                    }

                    if (model.Address is not null)
                    {
                        camping.Address = model.Address;
                    }

                    campingData.Update(camping);
                    return NoContent();
                }
            }
        }
    }
}