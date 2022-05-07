using Aerolinea.Vuelos.Domain.Entities;
using Sharedkernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerolinea.Vuelos.Domain.Event
{
    public class VueloHabilitado : DomainEvent
    {
       // public Guid vueloId { get; }
        public VueloHabilitado(Vuelo vuelo) : base(DateTime.Now)
        {

            vueloHabilitado = vuelo;


        }

   
        //public VueloHabilitado(Guid _vueloId) : base(DateTime.Now)
        //{

        //    vueloId = _vueloId;


        //}
        public Vuelo vueloHabilitado { get; private set; }
    
    }
}
