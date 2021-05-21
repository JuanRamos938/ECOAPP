using System;
using System.Collections.Generic;

#nullable disable

namespace ECOAPP.Core.Domain
{
    public partial class PuntosxVehiculo
    {
        public int IdPuntosxVehiculo { get; set; }
        public string MatriculaVehiculo { get; set; }
        public int PuntosAcumulados { get; set; }

        public virtual Vehiculo MatriculaVehiculoNavigation { get; set; }
    }
}
