using CQRSLesson.Application.Absreactions;
using CQRSLesson.Application.UseCases.Person.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSLesson.Application.UseCases.Person.Handlers
{
    public class GetpersonsCommandHandler : IRequestHandler<GetPerosnsCommand, List<Domain.Entities.Person>>
    {
        private readonly IApplicationDbContext _appplicationDbContext;

        public GetpersonsCommandHandler(IApplicationDbContext appplicationDbContext)
        {
            _appplicationDbContext = appplicationDbContext;
        }

        public async Task<List<Domain.Entities.Person>> Handle(GetPerosnsCommand request, CancellationToken cancellationToken)
        {
            return await _appplicationDbContext.Persons.ToListAsync();
        }
    }
}
