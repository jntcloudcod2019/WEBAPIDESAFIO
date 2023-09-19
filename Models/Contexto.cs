using Microsoft.EntityFrameworkCore;

namespace WebApiDesafio.Models
{
    public class Contexto : DbContext

    {

        public Contexto(DbContextOptions<Contexto> options) : base(options)
        { 

        }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Logradouro> Logradouros { get; set; }  
    }
}
