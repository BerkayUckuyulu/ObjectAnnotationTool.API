using Application.IRepositories.Ticket;
using Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories.Ticket
{
    public class TicketReadRepository : ReadRepository<Domain.Ticket>, ITicketReadRepository
    {
        public TicketReadRepository(APIDbContext context) : base(context)
        {
        }
    }
}
