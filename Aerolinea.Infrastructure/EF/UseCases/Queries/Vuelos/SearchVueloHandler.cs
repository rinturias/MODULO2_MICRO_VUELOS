using Aerolinea.Vuelos.Application.Dto;
using Aerolinea.Vuelos.Application.UseCases.Queries.Vuelos.SearchVuelos;
using Aerolinea.Vuelos.Infrastructure.EF.Contexts;
using Aerolinea.Vuelos.Infrastructure.EF.ReadModel;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aerolinea.Vuelos.Infrastructure.EF.UseCases.Queries.Vuelos
{

    public class SearchVueloHandler : 
        IRequestHandler<SearchVuelosQuery, ResulService>,
        IRequestHandler<SearchListVuelosQuery,ResulService>

    {
        private readonly DbSet<VueloReadModel> _vuelos;



    public SearchVueloHandler(ReadDbContext context)
    {
            _vuelos = context.Vuelo;
    }

  

        public async Task<ResulService> Handle(SearchVuelosQuery request, CancellationToken cancellationToken)
        {
        
           var   vueloList= await _vuelos
                     .AsNoTracking()
                     .Include(x => x.DetalleTripulacion)
                     //.ThenInclude(x => x.Id)
                     .Where(x => x.fecha >= request.SearchVuelosDTO.FecInicial && x.fecha <= request.SearchVuelosDTO.FecFinal && x.activo==0)
                     .ToListAsync();

            List<VuelosDto> listNew = new();
            List<TripulacionDto> listNewTripulacion = new();

            foreach (var item in vueloList)
            {
                VuelosDto objVuelo = new();
                objVuelo.codVuelo = item.Id;
                objVuelo.horaSalida = item.horaSalida;
                objVuelo.horaLLegada = item.horaLLegada;
                objVuelo.codOrigen = item.codOrigen;
                objVuelo.codDestino = item.codDestino;
                objVuelo.fecha = item.fecha;
                objVuelo.precio = item.precio;
                objVuelo.estado = item.estado;

                foreach (var itemDetalle in item.DetalleTripulacion)
                {
                    TripulacionDto list = new();
                    list.codTripulacion = itemDetalle.codTripulacion;
                    list.codEmpleado = itemDetalle.codEmpleado;
                    list.estado = itemDetalle.estado;
                    listNewTripulacion.Add(list);

                }
                objVuelo.tripulaciones = listNewTripulacion;
                listNew.Add(objVuelo);

            }


            return new ResulService { data = listNew, messaje = "listado de vuelos por fecha" };
        }

        public async Task<ResulService> Handle(SearchListVuelosQuery request, CancellationToken cancellationToken)
        {
            var vueloList = await _vuelos
                     .AsNoTracking()
                     .Include(x => x.DetalleTripulacion)
                     .Where(x=>x.activo==0)
                      .Take(100)
                     .ToListAsync();


            List <VuelosDto> listNew = new();
            List<TripulacionDto> listNewTripulacion = new();

            foreach (var item in vueloList)
            {
                VuelosDto objVuelo = new();
                objVuelo.codVuelo = item.Id;
                objVuelo.horaSalida = item.horaSalida;
                objVuelo.horaLLegada = item.horaLLegada;
                objVuelo.codOrigen=item.codOrigen;
                objVuelo.codDestino=item.codDestino;
                objVuelo.fecha=item.fecha;
                objVuelo.precio=item.precio;
                objVuelo.estado=item.estado;

                foreach (var itemDetalle in item.DetalleTripulacion)
                {
                    TripulacionDto list = new();
                    list.codTripulacion = itemDetalle.codTripulacion;
                    list.codEmpleado = itemDetalle.codEmpleado;
                    list.estado = itemDetalle.estado;
                    listNewTripulacion.Add(list);

                }
                objVuelo.tripulaciones = listNewTripulacion;
                listNew.Add(objVuelo);

            }


            return new ResulService { data = listNew, messaje = "listado 100  vuelos" };
        }

      
    }
}
