using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarForSale.Model;

namespace CarForSale.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotosController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public MotosController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/Motos
        [HttpGet]
        public IEnumerable<Moto> GetMotos()
        {
            return _context.Motos;
        }

        // GET: api/Motos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMoto([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var moto = await _context.Motos.FindAsync(id);

            if (moto == null)
            {
                return NotFound();
            }

            return Ok(moto);
        }

        // PUT: api/Motos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMoto([FromRoute] Guid id, [FromBody] Moto moto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != moto.Id)
            {
                return BadRequest();
            }

            _context.Entry(moto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MotoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Motos
        [HttpPost]
        public async Task<IActionResult> PostMoto([FromBody] Moto moto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (MotoVazia(moto))
            {
                return BadRequest();
            }

            _context.Motos.Add(moto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMoto", new { id = moto.Id }, moto);
        }

        // DELETE: api/Motos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMoto([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var moto = await _context.Motos.FindAsync(id);
            if (moto == null)
            {
                return NotFound();
            }

            _context.Motos.Remove(moto);
            await _context.SaveChangesAsync();

            return Ok(moto);
        }

        private bool MotoVazia(Moto moto)
        {
            if (moto.Modelo == null || moto.Motor == null || moto.Tipo == null || moto.Cor == null)
            {
                return true;
            }

            if (moto.Modelo == "" || moto.Motor == "" || moto.Tipo == "" || moto.Cor == "")
            {
                return true;
            }

            return false;

        }

        private bool MotoExists(Guid id)
        {
            return _context.Motos.Any(e => e.Id == id);
        }
    }
}