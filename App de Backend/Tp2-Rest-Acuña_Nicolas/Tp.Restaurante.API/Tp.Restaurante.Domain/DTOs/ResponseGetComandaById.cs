using System;
using System.Collections.Generic;

namespace Tp.Restaurante.Domain.DTOs
{
    public class ResponseGetComandaById
    {
        public Guid ComandaId { get; set; }

        public int PrecioTotal { get; set; }
        public DateTime Fecha { get; set; }

        public string FormaEntrega { get; set; } 
        public List<ResponseGetMercaderiaById> Mercaderia { get; set; }

    }

    public class ResponseGetComandaByIdFormaEntrega
    {
        public int FormaEntregaId { get; set; }

        public string Descripcion { get; set; }
    }


}
