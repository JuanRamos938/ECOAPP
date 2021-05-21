using System;
using System.Collections.Generic;

#nullable disable

namespace ECOAPP.Core.Domain
{
    public partial class Transaccione
    {
        public int IdTransaccion { get; set; }
        public string MatriculaVehiculo { get; set; }
        public int IdEstacion { get; set; }
        public double CantidadRecargada { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Estacion IdEstacionNavigation { get; set; }
        public virtual Vehiculo MatriculaVehiculoNavigation { get; set; }
    }
}
