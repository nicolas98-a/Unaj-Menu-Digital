using System.Collections.Generic;
using Tp.Restaurante.Domain.DTOs;

namespace Tp.Restaurante.Domain.Queries
{
    public interface IMercaderiaQuery
    {
        ResponseGetMercaderiaById GetById(string mercaderiaId);
        List<ResponseGetAllMercaderiaDto> GetAllMercaderia(string tipo);
    }
}
