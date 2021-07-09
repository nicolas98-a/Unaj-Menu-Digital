using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tp.Restaurante.Domain.Entities;

namespace Tp.Restaurante.AccessData.Configurations
{
    public class FormaEntregaConfiguration
    {
        public FormaEntregaConfiguration(EntityTypeBuilder<FormaEntrega> entityTypeBuilder)
        {
            entityTypeBuilder.Property(x => x.Descripcion).IsRequired().HasMaxLength(50);
        }
    }
}
