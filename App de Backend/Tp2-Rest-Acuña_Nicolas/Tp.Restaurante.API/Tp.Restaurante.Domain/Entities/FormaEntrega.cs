using System.Collections.Generic;

namespace Tp.Restaurante.Domain.Entities
{
    public class FormaEntrega
    {
        public int FormaEntregaId { get; set; }

        public string Descripcion { get; set; }

        public ICollection<Comanda> ComandasNavigator { get; set; }
    }
}
