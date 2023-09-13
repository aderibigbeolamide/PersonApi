using Microsoft.AspNetCore.Mvc;
using PersonApi.DTOs.RequestModel;
using PersonApi.Interface.Services;

namespace PersonApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService ?? throw new ArgumentNullException(nameof(personService));
        }

         [HttpPost("Create")]
        public async Task<IActionResult> Create([FromForm] CreatePersonRequestModel model)
        {
            var person = await _personService.Create(model);
            if (person.Success == false)
            {
                return BadRequest(person);
            }
            return Ok(person);
        }

         [HttpGet("GetByName/{name}")]
        public async Task<IActionResult> GetByName([FromRoute] string name)
        {
            var person = await _personService.GetByName(name);
            if (person.Success == false)
            {
                return BadRequest(person);
            }
            return Ok(person);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var person = await _personService.GetById(id);
            if (person.Success == false)
            {
                return BadRequest(person);
            }
            return Ok(person);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(
            [FromForm] UpdatePersonRequestModel model)
        {
            var person = await _personService.UpdatePerson(model);
            if (person.Success == false)
            {
                return BadRequest(person);
            }
            return Ok(person);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var person = await _personService.DeletePerson(id);
            if (person.Success == false)
            {
                return BadRequest(person);
            }
            return Ok(person);
        }
    }
}