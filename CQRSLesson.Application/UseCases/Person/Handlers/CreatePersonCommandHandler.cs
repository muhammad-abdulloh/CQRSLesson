using CQRSLesson.Application.Absreactions;
using CQRSLesson.Application.UseCases.Person.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSLesson.Application.UseCases.Person.Handlers
{
    public class CreatePersonCommandHandler : AsyncRequestHandler<CreatePersonCommand>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public CreatePersonCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        protected override async Task Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = new Domain.Entities.Person()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Age = request.Age,
                Email = request.Email,
            };

            await _applicationDbContext.Persons.AddAsync(person);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
