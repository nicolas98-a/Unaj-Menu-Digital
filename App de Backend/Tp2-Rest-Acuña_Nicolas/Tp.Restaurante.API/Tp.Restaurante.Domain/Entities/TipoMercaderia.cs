using System.Collections.Generic;

namespace Tp.Restaurante.Domain.Entities
{
    public class TipoMercaderia
    {
        public int TipoMercaderiaId { get; set; }

        public string Descripcion { get; set; }

        public ICollection<Mercaderia> MercaderiasNavigator { get; set; }
    }
}
