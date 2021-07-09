using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Tp.Restaurante.Application.Services;
using Tp.Restaurante.Domain.DTOs;
using Tp.Restaurante.Domain.Entities;

namespace Tp.Restaurante.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MercaderiaController : ControllerBase
    {
        private readonly IMercaderiaService _service;
        public MercaderiaController (IMercaderiaService service)
        {
            _service = service;
        }

        /// <summary>
        /// Agrega una mercaderia
        /// </summary>
        /// <param name="mercaderia"></param>
        /// <returns>Retorna el id de la mercaderia y la entidad a la que pertenece</returns>
        [HttpPost]
        [ProducesResponseType(typeof(Mercaderia), StatusCodes.Status201Created)]
        public IActionResult Post(MercaderiaDto mercaderia)
        {
            try
            {
                return new JsonResult(_service.CreateMercaderia(mercaderia)) { StatusCode = 201 };

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }
        /// <summary>
        /// Actualiza los datos de una mercaderia 
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="mercaderia"></param>
        /// <returns>No retorna contenido</returns>
        [HttpPut("{Id}")]
        [ProducesResponseType(typeof(Mercaderia), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Mercaderia), StatusCodes.Status404NotFound)]

        public IActionResult PutMercaderia(int Id , MercaderiaDto mercaderia)
        {
            try
            {
                if(_service.UpdateMercaderia(Id, mercaderia))
                {
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }
                             
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        /// <summary>
        /// Borra una mercaderia
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>No retorna contenido</returns>
        [HttpDelete("{Id}")]
        [ProducesResponseType(typeof(Mercaderia), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Mercaderia), StatusCodes.Status404NotFound)]

        public IActionResult DeleteMercaderia(int Id)
        {
            try
            {
                if (_service.DeleteMercaderia(Id))
                {
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        /// <summary>
        /// Devuelve una mercaderia segun su id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Retorna los datos de la mercaderia</returns>
        [HttpGet("{Id}")]
        [ProducesResponseType(typeof(ResponseGetMercaderiaById), StatusCodes.Status200OK)]
        public IActionResult GetMercaderiaById(string Id)
        {
            try
            {   
                return new JsonResult(_service.GetById(Id)) { StatusCode = 200 };
            }
            catch (Exception e)
            {
               return new JsonResult(BadRequest(e.Message)) { StatusCode = 400 };

            }
        }

        /// <summary>
        /// Devuelve toda la mercaderia que hay, permite filtrar por tipo
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns>Retorna los datos de la mercaderia</returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<ResponseGetAllMercaderiaDto>), StatusCodes.Status200OK)]
        public IActionResult GetMercaderias([FromQuery]string tipo)
        {
            try
            {
                return new JsonResult(_service.GetMercaderias(tipo)) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
