using API_FIlmes_Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace API_FIlmes_Entity.Data;

public class FilmeContext : DbContext
{
    public FilmeContext(DbContextOptions<FilmeContext> opts) : base(opts)
    {
               
    }

    public DbSet<Filme> Filmes { get; set; }

}
