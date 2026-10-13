using Microsoft.EntityFrameworkCore;
using WebEmpresa.Api.Models;

namespace WebEmpresa.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Cliente> Clientes => Set<Cliente>();
}
