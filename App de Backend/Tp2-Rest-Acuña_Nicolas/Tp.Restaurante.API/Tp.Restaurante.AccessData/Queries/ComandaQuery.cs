using SqlKata.Compilers;
using SqlKata.Execution;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Tp.Restaurante.Application.Services;
using Tp.Restaurante.Domain.DTOs;
using Tp.Restaurante.Domain.Queries;

namespace Tp.Restaurante.AccessData.Queries
{
    public class ComandaQuery : IComandaQuery
    {
        private readonly IDbConnection connection;
        private readonly Compiler sqlKataCompiler;
        private readonly IMercaderiaService _mercaderiaservice;

        public ComandaQuery(IDbConnection connection, Compiler sqlKataCompiler, IMercaderiaService service)
        {
            this.connection = connection;
            this.sqlKataCompiler = sqlKataCompiler;
            _mercaderiaservice = service;
        }

        public List<ResponseGetComandaById> GetAllComanda(string fecha)
        {
            List<ResponseGetComandaById> allComandaDtos = new List<ResponseGetComandaById>();
            var db = new QueryFactory(connection, sqlKataCompiler);
            
            var query = db.Query("Comandas")
                .Select("Comandas.ComandaId",
                "Comandas.PrecioTotal",
                "Comandas.Fecha",
                "FormaEntrega.Descripcion AS FormaEntrega")
                .Join("FormaEntrega", "FormaEntrega.FormaEntregaId", "Comandas.FormaEntregaId")
                .When(!string.IsNullOrWhiteSpace(fecha), q => q.WhereLike("Comandas.Fecha", $"%{fecha}%"));

            var allComandas = query.Get<ResponseGetAllComandaDto>().ToList();
            foreach (var comanda in allComandas)
            {
                ResponseGetComandaById comandaById = GetById(comanda.ComandaId.ToString());
                allComandaDtos.Add(comandaById);
            }

            return allComandaDtos;

        }

        public ResponseGetComandaById GetById(string comandaId)
        {
            var db = new QueryFactory(connection, sqlKataCompiler);

            var comanda = db.Query("Comandas")
                .Select("ComandaId", "PrecioTotal", "Fecha", "FormaEntregaId")
                .Where("ComandaId", "=", comandaId)
                .FirstOrDefault<ComandaDto>();

            if (comanda != null)
            {
                var entrega = db.Query("FormaEntrega")
                    .Select("FormaEntregaId", "Descripcion")
                    .Where("FormaEntregaId", "=", comanda.FormaEntregaId)
                    .FirstOrDefault<ResponseGetComandaByIdFormaEntrega>();

                var idsMercaderia = db.Query("ComandaMercaderias")
                    .Select("MercaderiaId", "ComandaId")
                    .Where("ComandaId", "=", comandaId)
                    .Get<int>().ToList();

                List<ResponseGetMercaderiaById> listaMercaderias = new List<ResponseGetMercaderiaById>();
                foreach (var item in idsMercaderia)
                {
                    ResponseGetMercaderiaById mercaderia = _mercaderiaservice.GetById(item.ToString());
                    listaMercaderias.Add(mercaderia);
                }

                return new ResponseGetComandaById
                {
                    ComandaId = comanda.ComandaId,
                    PrecioTotal = comanda.PrecioTotal,
                    Fecha = comanda.Fecha,
                    FormaEntrega = entrega.Descripcion,
                    Mercaderia = listaMercaderias
                };
            }
            else 
            {
                return null;
            }
        }
    }
}
