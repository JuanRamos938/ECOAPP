using System;
using System.Collections.Generic;

#nullable disable

namespace ECOAPP.Core.Domain
{
    public partial class Vehiculo
    {
        public Vehiculo()
        {
            PuntosxVehiculos = new HashSet<PuntosxVehiculo>();
            Transacciones = new HashSet<Transaccione>();
        }

        public string MatriculaVehiculo { get; set; }
        public string CedulaPropietario { get; set; }
        public string TipoVehiculo { get; set; }

        public virtual Usuario CedulaPropietarioNavigation { get; set; }
        public virtual ICollection<PuntosxVehiculo> PuntosxVehiculos { get; set; }
        public virtual ICollection<Transaccione> Transacciones { get; set; }
    }
}
