using Aerolinea.Vuelos.Application.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerolinea.Vuelos.Application.UseCases.Command.Vuelos
{
    public class CrearVuelosCommand : IRequest<ResulService>
    {
        private CrearVuelosCommand() { }

        public CrearVuelosCommand(RequestVueloDto detalle)
        {
            Detalle = detalle;
        }

        public RequestVueloDto Detalle { get; set; }

        
    
    }
}
