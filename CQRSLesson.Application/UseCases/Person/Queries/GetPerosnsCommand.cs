using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSLesson.Application.UseCases.Person.Queries
{
    public class GetPerosnsCommand : IRequest<List<Domain.Entities.Person>>
    {
    }
}
