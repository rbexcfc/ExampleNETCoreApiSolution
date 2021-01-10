using ClientService.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace ClientService.Models
{
    public class ClientContext : DbContext
    {
        public ClientContext(DbContextOptions<ClientContext> options)
         : base(options)
        {
        }

        public DbSet<ClientDetailsEntity> ClientDetails { get; set; }
    }
}
