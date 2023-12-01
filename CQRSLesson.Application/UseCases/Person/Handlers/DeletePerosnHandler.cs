using CQRSLesson.Application.Absreactions;
using CQRSLesson.Application.UseCases.Person.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSLesson.Application.UseCases.Person.Handlers
{
    public class DeletePerosnHandler : IRequestHandler<DeletePersonCommand, bool>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public DeletePerosnHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public  async Task<bool> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            var user = await _applicationDbContext.Persons.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (user == null)
            {
                return false;
            }
            else
            {
                 _applicationDbContext.Persons.Remove(user);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);

                return true;
            }
        }
    }
}
