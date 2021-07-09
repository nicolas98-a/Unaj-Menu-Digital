using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Tp.Restaurante.Application.Services;
using Tp.Restaurante.Domain.DTOs;

namespace Tp.Restaurante.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComandaController : ControllerBase
    {
        private readonly IComandaService _service;
        public ComandaController(IComandaService service)
        {
            _service = service;
        }

        /// <summary>
        /// Agrega una comanda
        /// </summary>
        /// <param name="comanda"></param>
        /// <returns>Retorna el id de la comanda y la entidad a la que pertenece</returns>
        [HttpPost]
        [ProducesResponseType(typeof(GenericCreatedResponseDto), StatusCodes.Status201Created)]
        public IActionResult Post(CreateComandaRequestDto comanda)
        {
            try
            {
                return new JsonResult(_service.CreateComanda(comanda)) { StatusCode = 201 };
            }
            catch (Exception e)
            {
                return new JsonResult(BadRequest(e.Message));
            }
        }

        /// <summary>
        /// Devuelve todas las comadas, permite filtrar por fecha
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns>Retorna la informacion de las comandas</returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<ResponseGetComandaById>), StatusCodes.Status200OK)]
        public IActionResult GetComandas([FromQuery] string fecha)
        {
            try
            {
                return new JsonResult(_service.GetComandas(fecha)) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Devuelve la comada que corresponde al id ingresado
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Retorna la informacion de la comanda</returns>
        [HttpGet("{Id}")]
        [ProducesResponseType(typeof(ResponseGetComandaById), StatusCodes.Status200OK)]
        public IActionResult GetComandaById(string Id)
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
    }
}
