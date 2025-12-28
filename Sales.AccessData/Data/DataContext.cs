using Microsoft.EntityFrameworkCore;
using Sales.Shared.Entities;

namespace Sales.AccessData.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }
    // DbSet por cada entidad
    public DbSet<Country> Countries => Set<Country>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Llamada al metodo base
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Country>()
                    .HasIndex(c => c.Name)
                    .IsUnique();

        //este metodo deshabilita el borrado en cascada en todas las relaciones
        DisableCascadingDelete(modelBuilder);
    }

    private void DisableCascadingDelete(ModelBuilder modelBuilder)
    {
        // Obtener todas las relaciones entre entidades
        var relationShips = modelBuilder.Model.GetEntityTypes()
                                        .SelectMany(e => e.GetForeignKeys());
        foreach (var item in relationShips)
        {
            // Establecer el comportamiento de borrado a Restrict
            item.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}
