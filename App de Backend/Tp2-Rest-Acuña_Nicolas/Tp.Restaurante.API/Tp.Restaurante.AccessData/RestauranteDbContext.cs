using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Tp.Restaurante.AccessData.Configurations;
using Tp.Restaurante.Domain.Entities;

namespace Tp.Restaurante.AccessData
{
    public class RestauranteDbContext : DbContext
    {

        public RestauranteDbContext(DbContextOptions<RestauranteDbContext> options) : base(options)
        {
        }
        

        public DbSet<Mercaderia> Mercaderias { get; set; }
        public DbSet<Comanda> Comandas { get; set; }
        public DbSet<ComandaMercaderia> ComandaMercaderias { get; set; }
        public DbSet<FormaEntrega> FormaEntregas { get; set; }
        public DbSet<TipoMercaderia> TipoMercaderias { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            ModelConfig(builder);

            builder.Entity<Mercaderia>().HasMany(m => m.ComandasNavigator).WithMany(c => c.MercaderiasNavigator)
                                               .UsingEntity<ComandaMercaderia>(
                                                   cm => cm.HasOne(prop => prop.ComandaNavigator).WithMany().HasForeignKey(prop => prop.ComandaId),
                                                   pg => pg.HasOne(prop => prop.MercaderiaNavigator).WithMany().HasForeignKey(prop => prop.MercaderiaId),
                                                   pg => { pg.HasKey(prop => new { prop.ComandaId, prop.MercaderiaId, prop.ComandaMercaderiaId }); });

            // Llamo al metodo que carga la forma de entrega y los tipos de mercaderia (datos semilla en la base de datos)
            builder.Seed();

        }

        private void ModelConfig(ModelBuilder modelBuilder)
        {
            new ComandaConfiguration(modelBuilder.Entity<Comanda>());
            new ComandaMercaderiaConfiguration(modelBuilder.Entity<ComandaMercaderia>());
            new FormaEntregaConfiguration(modelBuilder.Entity<FormaEntrega>());
            new MercaderiaConfiguration(modelBuilder.Entity<Mercaderia>());
            new TipoMercaderiaConfiguration(modelBuilder.Entity<TipoMercaderia>());
        }
    }

    public class RestauranteDbContextFactory : IDesignTimeDbContextFactory<RestauranteDbContext>
    {
        public RestauranteDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RestauranteDbContext>();
            optionsBuilder.UseSqlServer("Server=.;Database=Restaurante_API_Db;Trusted_Connection=True;Integrated Security=True;;MultipleActiveResultSets=true");

            return new 
                RestauranteDbContext(optionsBuilder.Options);
        }
    }
}
