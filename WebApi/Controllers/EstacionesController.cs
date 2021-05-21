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
    public class EstacionesController : ControllerBase
    {
        private readonly EcoMapsContext _context;

        public EstacionesController(EcoMapsContext context)
        {
            _context = context;
        }

        // GET: api/Estaciones/5
        [HttpGet("{Ciudad}")]
        public async Task<ActionResult<IEnumerable<Estacion>>> GetEstacion(string Ciudad)
        {
            return await _context.Estacions.Where(o => o.Ciudad.Equals(Ciudad)).ToListAsync();
        }
    }
}
