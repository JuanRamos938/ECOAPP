using System;
using System.Collections.Generic;

#nullable disable

namespace ECOAPP.Core.Domain
{
    public partial class Usuario
    {
        public Usuario()
        {
            Vehiculos = new HashSet<Vehiculo>();
        }

        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Vehiculo> Vehiculos { get; set; }
    }
}
