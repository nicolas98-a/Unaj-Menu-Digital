using System;

namespace Tp.Restaurante.Domain.DTOs
{
    public class ResponseGetAllComandaDto
    {
        public Guid ComandaId { get; set; }

        public int PrecioTotal { get; set; }
        public DateTime Fecha { get; set; }

        public string FormaEntrega { get; set; }
    }

}
