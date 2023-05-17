using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Modelos;
using WebApi.Modelos;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WebApi.Servicios.Context
{
    public class ApplicationDBContext: IdentityDbContext<Usuario>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options)
        {
          
        }

        public DbSet<Producto>Producto { get; set; }


    }
}
