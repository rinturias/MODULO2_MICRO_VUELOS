using Aerolinea.Vuelos.Application.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerolinea.Vuelos.Application.UseCases.Queries.Vuelos.SearchVuelos
{
    public class SearchListVuelosQuery : IRequest<ResulService>
    {

        public SearchListVuelosQuery(){}
       
    }
}
