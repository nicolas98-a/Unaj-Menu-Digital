using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tp.Restaurante.Domain.Entities;

namespace Tp.Restaurante.AccessData.Configurations
{
    public class ComandaMercaderiaConfiguration
    {
        public ComandaMercaderiaConfiguration(EntityTypeBuilder<ComandaMercaderia> entityTypeBuilder)
        {
            entityTypeBuilder.Property(x => x.ComandaMercaderiaId).ValueGeneratedOnAdd();
        }
    }
}
