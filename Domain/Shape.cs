using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Shape:BaseEntity
    {
        public string Type { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public int w { get; set; }
        public int h { get; set; }

        public Guid? TicketId { get; set; }
        public Ticket? Ticket { get; set; }
        public Guid? PictureId { get; set; }
        public Picture? Picture { get; set; }
    }
}
