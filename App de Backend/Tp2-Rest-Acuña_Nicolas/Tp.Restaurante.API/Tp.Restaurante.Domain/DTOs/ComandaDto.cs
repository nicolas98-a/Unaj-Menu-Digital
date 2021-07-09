using System;

namespace Tp.Restaurante.Domain.DTOs
{
    public class ComandaDto
    {
        public Guid ComandaId { get; set; }

        public int PrecioTotal { get; set; }
        public DateTime Fecha { get; set; }

        public int FormaEntregaId { get; set; }
    }
}
