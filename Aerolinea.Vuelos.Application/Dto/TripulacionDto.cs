using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerolinea.Vuelos.Application.Dto
{
    public class TripulacionDto
    {

        public Guid codVuelo { get;  set; }
        public Guid codTripulacion { get; set; }
        public Guid codEmpleado { get;  set; }
        public string estado { get;  set; }
        public int activo { get;  set; }


    }
}
