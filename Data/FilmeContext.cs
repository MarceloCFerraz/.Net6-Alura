using DotNet6.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNet6.Data;

public class FilmeContext : DbContext
{
    public DbSet<Filme> Filmes { get; set; }

    public FilmeContext(DbContextOptions<FilmeContext> opts) : base (opts)
    { }

}