using System.Collections.Generic;

namespace Tp.Restaurante.Domain.DTOs
{
    public class CreateComandaRequestDto
    {
        public List<int> Mercaderias { get; set; }
        public int FormaEntrega { get; set; }
    }
}
