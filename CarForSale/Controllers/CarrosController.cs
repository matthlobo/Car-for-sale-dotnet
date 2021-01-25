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
    public class CarrosController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public CarrosController(ApiDbContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public IEnumerable<Carro> GetCarro()
        {
            return _context.Carro;
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarro([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var carro = await _context.Carro.FindAsync(id);

            if (carro == null)
            {
                return NotFound();
            }

            return Ok(carro);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarro([FromRoute] Guid id, [FromBody] Carro carro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != carro.Id)
            {
                return BadRequest();
            }

            if (CarroVazio(carro))
            {
                return BadRequest();
            }

            _context.Entry(carro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarroExists(id))
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

        [HttpPost]
        public async Task<IActionResult> PostCarro([FromBody] Carro carro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (CarroVazio(carro))
            {
                return BadRequest();
            } 

            _context.Carro.Add(carro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarro", new { id = carro.Id }, carro);
        }

        // DELETE: api/Carros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarro([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var carro = await _context.Carro.FindAsync(id);
            if (carro == null)
            {
                return NotFound();
            }

            _context.Carro.Remove(carro);
            await _context.SaveChangesAsync();

            return Ok(carro);
        }

        private bool CarroVazio(Carro carro)
        {            
            if (carro.Modelo == null || carro.Motor == null || carro.Tipo == null || carro.Cor == null)
            {
                return true;
            }
               
            if (carro.Modelo == "" || carro.Motor == "" || carro.Tipo == "" || carro.Cor == "")
            {
                return true;
            }

            return false;
                        
        }
        private bool CarroExists(Guid id)
        {
            return _context.Carro.Any(e => e.Id == id);
        }
    }
}