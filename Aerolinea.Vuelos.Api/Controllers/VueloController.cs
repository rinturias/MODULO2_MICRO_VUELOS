using Aerolinea.Vuelos.Application.Dto;
using Aerolinea.Vuelos.Application.UseCases.Command.Vuelos;
using Aerolinea.Vuelos.Application.UseCases.Queries.Vuelos.SearchVuelos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Aerolinea.Vuelos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VueloController : ControllerBase
    {

        private readonly IMediator _mediator;

        public VueloController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateVuelo")]
        public async Task<IActionResult> CreateVuelo([FromBody] CrearVuelosCommand command)
        {
            try
            {
              return Ok(await _mediator.Send(command));
            }
            catch (Exception ex)
            {
              
            return BadRequest(new ResulService() { success = false, codError = "501", messaje = "Error en la solicitud", error = ex.Message });
            }
        }

        [HttpPost("ListarVuelos")]
        public async Task<IActionResult> ListarVuelos([FromBody] SearchListVuelosQuery query)
        {
            try
            {
                return Ok(await _mediator.Send(query));
            }
            catch (Exception ex)
            {

                return BadRequest(new ResulService() { success = false, codError = "501", messaje = "Error en la solicitud", error = ex.Message });
            }
        }

        [HttpPost("SearchVuelosByDay")]
        public async Task<IActionResult> SearchVuelosByDay([FromBody] SearchVuelosQuery query)
        {
            try
            {
                return Ok(await _mediator.Send(query));
            }
            catch (Exception ex)
            {

                return BadRequest(new ResulService() { success = false, codError = "501", messaje = "Error en la solicitud", error = ex.Message });
            }
        }

        [HttpPut("ModifyVuelos")]
        public async Task<IActionResult> ModifyVuelos([FromBody] CrearVuelosCommand command)
        {
            try
            {
                return Ok(await _mediator.Send(command));
            }
            catch (Exception ex)
            {

                return BadRequest(new ResulService() { success = false, codError = "501", messaje = "Error en la solicitud", error = ex.Message });
            }
        }

        [HttpPost("DeleteVuelos")]
        public async Task<IActionResult> DeleteVuelos([FromBody] CrearVuelosCommand command)
        {
            try
            {
                return Ok(await _mediator.Send(command));
            }
            catch (Exception ex)
            {

                return BadRequest(new ResulService() { success = false, codError = "501", messaje = "Error en la solicitud", error = ex.Message });
            }
        }

    }
}
