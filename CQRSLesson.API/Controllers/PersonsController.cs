using CQRSLesson.API.ViewModels;
using CQRSLesson.Application.UseCases.Person.Commands;
using CQRSLesson.Application.UseCases.Person.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRSLesson.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PersonsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreatePerson(PersonDTO model)
        {
            var command = new CreatePersonCommand
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Age = model.Age,
                Email = model.Email,
            };

            await _mediator.Send(command);

            return Ok("yaratildi");
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllPersons()
        {
           var persons = await _mediator.Send(new GetPerosnsCommand());

            return Ok(persons);
        }

        [HttpDelete]
        public async ValueTask<ActionResult<bool>> DeletePersonAsync(int id)
        {
            var command = new DeletePersonCommand()
            {
                Id = id
            };

            bool result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
