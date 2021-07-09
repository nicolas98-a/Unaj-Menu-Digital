using System.Collections.Generic;
using Tp.Restaurante.Domain.DTOs;

namespace Tp.Restaurante.Domain.Queries
{
    public interface IComandaQuery
    {
        List<ResponseGetComandaById> GetAllComanda(string fecha);
        ResponseGetComandaById GetById(string comandaId);
    }
}
