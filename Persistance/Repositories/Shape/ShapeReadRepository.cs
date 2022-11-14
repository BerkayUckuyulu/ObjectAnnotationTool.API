using Application.IRepositories.Shape;
using Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories.Shape
{
    public class ShapeReadRepository : ReadRepository<Domain.Shape>, IShapeReadRepository
    {
        public ShapeReadRepository(APIDbContext context) : base(context)
        {
        }
    }
}
