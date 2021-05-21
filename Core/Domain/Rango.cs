using System;
using System.Collections.Generic;

#nullable disable

namespace ECOAPP.Core.Domain
{
    public partial class Rango
    {
        public int IdRango { get; set; }
        public double? MinimoRecargado { get; set; }
        public double? MaximoRecargado { get; set; }
        public double? PuntosObtenidos { get; set; }
    }
}
