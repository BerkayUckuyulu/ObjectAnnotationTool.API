using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepositories.Ticket
{
    public interface ITicketWriteRepository :IWriteRepository<Domain.Ticket>
    {
    }
}
