using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ECOAPP.Core.Domain;

namespace ECOAPP.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransaccionesController : ControllerBase
    {
        private readonly EcoMapsContext _context;

        public TransaccionesController(EcoMapsContext context)
        {
            _context = context;
        }

        [HttpGet("{MatriculaVehiculo}")]
        public async Task<ActionResult<IEnumerable<Transaccione>>> ObtenerHistorial(string MatriculaVehiculo)
        {
            return await _context.Transacciones.Where(o => o.MatriculaVehiculo.Equals(MatriculaVehiculo)).ToListAsync();
        }

        // POST: api/Transacciones
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Transaccione>> PostTransaccione(Transaccione transaccione)
        {
            double? PuntosASumar = 0;

            _context.Transacciones.Add(transaccione);
            //await _context.SaveChangesAsync();

            PuntosxVehiculo puntosxVehiculo = await _context.PuntosxVehiculos.Where(o => o.MatriculaVehiculo.Equals(transaccione.MatriculaVehiculo)).SingleOrDefaultAsync();
            if (_context.Rangos.Where(o => transaccione.CantidadRecargada >= o.MinimoRecargado && transaccione.CantidadRecargada <= o.MaximoRecargado).FirstOrDefault() != null)
            {
                PuntosASumar = _context.Rangos.Where(o => transaccione.CantidadRecargada >= o.MinimoRecargado && transaccione.CantidadRecargada <= o.MaximoRecargado).FirstOrDefault().PuntosObtenidos;
            }
            else
            {
                PuntosASumar = 0;
            }
            puntosxVehiculo.PuntosAcumulados = (int)(puntosxVehiculo.PuntosAcumulados + PuntosASumar);

            _context.Set<PuntosxVehiculo>().Update(puntosxVehiculo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransacciones", new { id = transaccione.IdTransaccion }, transaccione);

        }

    }
}
