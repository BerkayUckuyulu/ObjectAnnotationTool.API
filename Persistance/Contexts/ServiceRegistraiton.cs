using Application.IRepositories.Picture;
using Application.IRepositories.Shape;
using Application.IRepositories.Ticket;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Repositories.Picture;
using Persistance.Repositories.Shape;
using Persistance.Repositories.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Contexts
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<APIDbContext>(options => options.UseMySql(Configuration.ConnectionString,ServerVersion.AutoDetect(Configuration.ConnectionString)));

            services.AddScoped<IPictureReadRepository, PictureReadRepository>();
            services.AddScoped<IPictureWriteRepository, PictureWriteRepository>();

            services.AddScoped<IShapeReadRepository, ShapeReadRepository>();
            services.AddScoped<IShapeWriteRepository, ShapeWriteRepository>();

            services.AddScoped<ITicketReadRepository, TicketReadRepository>();
            services.AddScoped<ITicketWriteRepository, TicketWriteRepository>();

        }
    }
}
