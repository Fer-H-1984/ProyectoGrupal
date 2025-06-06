using Microsoft.AspNetCore.Mvc;
using ProyectoGastosAPI.Data;
using ProyectoGastosAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ProyectoGastosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GastosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GastosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/gastos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gasto>>> GetGastos()
        {
            return await _context.Gastos.ToListAsync();
        }

        // POST: api/gastos
        [HttpPost]
        public async Task<ActionResult<Gasto>> PostGasto(Gasto gasto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Gastos.Add(gasto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGastos), new { id = gasto.Id }, gasto);
        }
    }
}

