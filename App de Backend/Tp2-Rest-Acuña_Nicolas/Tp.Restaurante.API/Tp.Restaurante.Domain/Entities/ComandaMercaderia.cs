using System;

namespace Tp.Restaurante.Domain.Entities
{
    public class ComandaMercaderia
    {
        public int ComandaMercaderiaId { get; set; }

        public int MercaderiaId { get; set; }
        public Mercaderia MercaderiaNavigator { get; set; }

        public Guid ComandaId { get; set; }
        public Comanda ComandaNavigator { get; set; }
    }
}
