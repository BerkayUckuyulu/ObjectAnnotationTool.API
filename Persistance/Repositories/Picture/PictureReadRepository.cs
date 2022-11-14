using Application.IRepositories.Picture;
using Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories.Picture
{
    public class PictureReadRepository :ReadRepository<Domain.Picture> ,IPictureReadRepository
    {
        public PictureReadRepository(APIDbContext context) : base(context)
        {
        }
    }
}
