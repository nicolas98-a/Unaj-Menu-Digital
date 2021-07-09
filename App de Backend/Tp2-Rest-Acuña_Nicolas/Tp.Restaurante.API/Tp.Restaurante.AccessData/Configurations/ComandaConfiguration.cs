using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tp.Restaurante.Domain.Entities;

namespace Tp.Restaurante.AccessData.Configurations
{
    public class ComandaConfiguration
    {
        public ComandaConfiguration(EntityTypeBuilder<Comanda> entityTypeBuilder)
        {
            entityTypeBuilder.Property(x => x.ComandaId).IsRequired();
            entityTypeBuilder.Property(x => x.Fecha).HasDefaultValueSql("getdate()");
        }
    }
}
