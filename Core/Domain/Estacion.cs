using System;
using System.Collections.Generic;

#nullable disable

namespace ECOAPP.Core.Domain
{
    public partial class Estacion
    {
        public Estacion()
        {
            Transacciones = new HashSet<Transaccione>();
        }

        public int IdEstacion { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Ciudad { get; set; }
        public double? Altitud { get; set; }
        public double? Latitud { get; set; }
        public string Direccion { get; set; }

        public virtual ICollection<Transaccione> Transacciones { get; set; }
    }
}
