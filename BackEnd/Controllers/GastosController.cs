using Microsoft.AspNetCore.Mvc;
using ProyectoGastosAPI.Data;
using ProyectoGastosAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gasto>>> GetGastos()
        {
            return await _context.Gastos.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Gasto>> PostGasto(Gasto gasto)
        {
            if (gasto.Monto <= 0)
                return BadRequest("El monto debe ser mayor a 0");

            if (string.IsNullOrWhiteSpace(gasto.Descripcion))
                return BadRequest("La descripción es requerida");

            if (gasto.Descripcion.Length > 250)
                return BadRequest("La descripción no puede exceder 250 caracteres");

            if (gasto.Descripcion.Length < 3)
                return BadRequest("La descripción no puede ser menor a 3 caracteres");

            if (gasto.Fecha > DateTime.Now)
                return BadRequest("La fecha no puede ser futura");

            if (string.IsNullOrWhiteSpace(gasto.NombreComercio))
                return BadRequest("El nombre del comercio es requerido");

            if (gasto.NombreComercio.Length > 250)
                return BadRequest("El nombre del comercio no puede exceder 250 caracteres");

            _context.Gastos.Add(gasto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGastos), new { id = gasto.Id }, gasto);
        }
    }
}