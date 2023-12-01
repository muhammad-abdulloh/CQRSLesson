using CQRSLesson.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSLesson.Application.Absreactions
{
    public interface IApplicationDbContext
    {
        public DbSet<Person> Persons { get; set; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
