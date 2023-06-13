using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isk.GeneralAPI.DAL
{
    public static class ServiceExtensions
    {
        public static void ConfigurMsSqlContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<IskContext>(o => o.UseSqlServer(connectionString));
        }
    }
}
