using Aerolinea.Vuelos.Domain.Event;
using Aerolinea.Vuelos.Domain.ValueObjects;
using Sharedkernel.Core;
using Sharedkernel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerolinea.Vuelos.Domain.Entities
{
    public class Vuelo : AggregateRoot<Guid>
    {
  
        public DateTime horaSalida { get; private set; }
        public DateTime horaLLegada { get; private set; }
        public string estado { get; private set; }
        public PrecioValue precio { get; private set; }
        public DateTime fecha { get; private set; }
        public Guid codDestino { get; private set; }
        public Guid codOrigen { get; private set; }
        public Guid codAeronave { get; private set; }
        public int activo { get; private set; }
        public CantidadValue stockAsientos { get; set; }



        private readonly ICollection<TripulacionVuelo> tripulacionVuelos;

        public IReadOnlyCollection<TripulacionVuelo> DetalleTripilacionVuelos
        {
            get
            {
                return new ReadOnlyCollection<TripulacionVuelo>(tripulacionVuelos.ToList());
            }
        }

        private readonly ICollection<PlanillaAsientoVuelo> planillaAsientoVuelos;

        public IReadOnlyCollection<PlanillaAsientoVuelo> DetalleplanillaAsientoVuelos
        {
            get
            {
                return new ReadOnlyCollection<PlanillaAsientoVuelo>(planillaAsientoVuelos.ToList());
            }
        }

        public Vuelo()
        {
             Id = Guid.NewGuid();
            this.tripulacionVuelos = new List<TripulacionVuelo>();
            this.planillaAsientoVuelos = new List<PlanillaAsientoVuelo>();
        }

        public Vuelo(DateTime horaSalida, DateTime horaLLegada, string estado, PrecioValue precio, DateTime fecha, Guid codDestino, Guid codOrigen, Guid codAeronave, int activo, CantidadValue StockAsientos)
        {
            Id = Guid.NewGuid();
            this.tripulacionVuelos = new List<TripulacionVuelo>();
            this.planillaAsientoVuelos = new List<PlanillaAsientoVuelo>();

            this.estado = estado;
            this.precio = precio;

            this.horaSalida = DateTime.UtcNow;
            this.horaLLegada = DateTime.UtcNow;
            this.fecha = DateTime.UtcNow;

            this.codDestino = codDestino;
            this.codOrigen = codOrigen;
            this.codAeronave = codAeronave;
            this.activo = activo;
            this.stockAsientos = StockAsientos;

        }


        public void AgregarItem(  Guid codTripulacion, Guid codEmpleado, string estadoTri, int activoTri)
        {

            //var detalleTripulacion = tripulacionVuelos.FirstOrDefault(x => x.codTripulacion == codTripulacion && x.codVuelo==codVuelo);
            var detalleTripulacion = tripulacionVuelos.FirstOrDefault(x => x.codTripulacion == codTripulacion);
            if (detalleTripulacion is null)
            {
                detalleTripulacion = new TripulacionVuelo(codTripulacion, codEmpleado, estadoTri, activoTri,Id);
                tripulacionVuelos.Add(detalleTripulacion);
            }
            else
            {
                detalleTripulacion.ModificarTripulacionVuelo(estadoTri, activoTri);
            }


         


            AddDomainEvent(new VueloHabilitado(this));
           
        }

        public void GenerarItemPlanillaAsientosVuelo(int stock)
        {
            string estadoDefectoAsientoLibre = "L";
            for (int i = 0; i < stock; i++)
            {
                PlanillaAsientoVuelo objPlanilla = new("ASI" + i.ToString(), estadoDefectoAsientoLibre,0);
                planillaAsientoVuelos.Add(objPlanilla);
            }
            AddDomainEvent(new VueloHabilitado(this));
        }

        public void ConsolidarEventVueloHabilitado()
        {
            var evento = new VueloHabilitado(this);
            AddDomainEvent(evento);
        }
    }
}
