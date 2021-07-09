using SqlKata.Compilers;
using SqlKata.Execution;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Tp.Restaurante.Domain.DTOs;
using Tp.Restaurante.Domain.Queries;

namespace Tp.Restaurante.AccessData.Queries
{
    public class MercaderiaQuery : IMercaderiaQuery
    {
        private readonly IDbConnection connection;
        private readonly Compiler sqlKataCompiler;

        public MercaderiaQuery(IDbConnection connection, Compiler sqlKataCompiler)
        {
            this.connection = connection;
            this.sqlKataCompiler = sqlKataCompiler;
        }

        public List<ResponseGetAllMercaderiaDto> GetAllMercaderia(string tipo)
        {
            var db = new QueryFactory(connection, sqlKataCompiler);
      
            if(tipo != null)
            {
                var query = db.Query("Mercaderias")
                    .Select("Mercaderias.Nombre",
                     "TipoMercaderia.Descripcion AS Tipo",
                     "Mercaderias.Precio",
                     "Mercaderias.Ingredientes",
                     "Mercaderias.Preparacion",
                     "Mercaderias.Imagen",
                     "Mercaderias.MercaderiaId")
                     .Join("TipoMercaderia", "TipoMercaderia.TipoMercaderiaId", "Mercaderias.TipoMercaderiaId")
                     .Where("TipoMercaderia.TipoMercaderiaId", "=", tipo);

                var result = query.Get<ResponseGetAllMercaderiaDto>();
                return result.ToList();
            }
            else
            {
                var query = db.Query("Mercaderias")
                    .Select("Mercaderias.Nombre",
                    "TipoMercaderia.Descripcion AS Tipo",
                    "Mercaderias.Precio",
                    "Mercaderias.Ingredientes",
                    "Mercaderias.Preparacion",
                    "Mercaderias.Imagen",
                    "Mercaderias.MercaderiaId")
                    .Join("TipoMercaderia", "TipoMercaderia.TipoMercaderiaId", "Mercaderias.TipoMercaderiaId");
     
                var result = query.Get<ResponseGetAllMercaderiaDto>();
                return result.ToList();
            }

        }

        public ResponseGetMercaderiaById GetById(string mercaderiaId)
        {
            var db = new QueryFactory(connection, sqlKataCompiler);
            var query = db.Query("Mercaderias")
                .Select("Mercaderias.Nombre",
                "TipoMercaderia.Descripcion AS Tipo",
                "Mercaderias.Precio",
                "Mercaderias.Ingredientes",
                "Mercaderias.Preparacion",
                "Mercaderias.Imagen",
                "Mercaderias.MercaderiaId")
                .Join("TipoMercaderia", "TipoMercaderia.TipoMercaderiaId", "Mercaderias.TipoMercaderiaId")
                .Where("MercaderiaId", "=", mercaderiaId)
                .FirstOrDefault<ResponseGetAllMercaderiaDto>();

            if (query != null)
            {
                return new ResponseGetMercaderiaById
                {
                    Nombre = query.Nombre,
                    Tipo = query.Tipo,
                    Precio = query.Precio,
                    Ingredientes = query.Ingredientes,
                    Preparacion = query.Preparacion,
                    Imagen = query.Imagen,
                    MercaderiaId = int.Parse(mercaderiaId)
                };
            }
            else
            {
                return null;
            }
        }
    }
}
