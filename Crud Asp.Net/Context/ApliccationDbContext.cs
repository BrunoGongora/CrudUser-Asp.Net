using Crud_Asp.Net.Models;
using Microsoft.EntityFrameworkCore;

namespace Crud_Asp.Net.Context
{
    public class ApliccationDbContext: DbContext
    {
        public ApliccationDbContext(DbContextOptions<ApliccationDbContext> options): base(options)
        {

        }

        public DbSet<Contacto> Contacto { get; set; }
    }
}
