using Application.IRepositories.Picture;
using Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories.Picture
{
    public class PictureWriteRepository : WriteRepository<Domain.Picture>, IPictureWriteRepository
    {
        public PictureWriteRepository(APIDbContext context) : base(context)
        {
        }
    }
}
