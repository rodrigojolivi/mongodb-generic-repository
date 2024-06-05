using Microsoft.AspNetCore.Mvc;
using MongoDBGenericRepository.API.Interfaces;
using MongoDBGenericRepository.API.Models;
using MongoDBGenericRepository.API.Requests;

namespace MongoDBGenericRepository.API.Controllers
{
    [Route("api/persons")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;

        public PersonController(IPersonRepository personRepository)
            => _personRepository = personRepository;

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _personRepository.GetAsync());
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var person = await _personRepository.FindAsync(id);

            if (person == null) return NotFound();

            return Ok(person);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(Person person)
        {
            await _personRepository.CreateAsync(person);

            return Created("", person);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(CreatePersonRequest request)
        {
            var existingPerson = await _personRepository.FindAsync(request.Id);

            if (existingPerson == null) return NotFound();

            existingPerson.Update(request.Name, request.Email, request.Phone);

            await _personRepository.UpdateAsync(existingPerson.Id, existingPerson);

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> PutAsync(Guid id)
        {
            var person = await _personRepository.FindAsync(id);

            if (person == null) return NotFound();

            await _personRepository.RemoveAsync(id);

            return NoContent();
        }
    }
}
