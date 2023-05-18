using Microsoft.EntityFrameworkCore;
using ClientDataHarvester.WebApi.Models;

namespace ClientDataHarvester.WebApi.Data
{
    public class ClientDataContext : DbContext
    {

        #nullable disable
        public ClientDataContext(DbContextOptions<ClientDataContext> options) : base(options)
        {
        }
        #nullable restore

        public DbSet<ClientData> ClientData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientData>().HasIndex(p => new { p.ClientName, p.DataType }).IsUnique();
        }
    }
}
