using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Picture:BaseEntity
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public ICollection<Shape> Shapes { get; set; }
    }
}
