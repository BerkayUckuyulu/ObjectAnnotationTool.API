using Application.IRepositories.Ticket;
using Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories.Ticket
{
    public class TicketWriteRepository : WriteRepository<Domain.Ticket>, ITicketWriteRepository
    {
        public TicketWriteRepository(APIDbContext context) : base(context)
        {
        }
    }
}
