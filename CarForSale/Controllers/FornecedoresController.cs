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
    public class FornecedoresController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public FornecedoresController(ApiDbContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public IEnumerable<Fornecedor> GetFornecedores()
        {
            return _context.Fornecedores;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFornecedor([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fornecedor = await _context.Fornecedores.FindAsync(id);

            if (fornecedor == null)
            {
                return NotFound();
            }

            return Ok(fornecedor);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFornecedor([FromRoute] Guid id, [FromBody] Fornecedor fornecedor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fornecedor.Id)
            {
                return BadRequest();
            }

            if (FornecedorVazio(fornecedor))
                return BadRequest();

            _context.Entry(fornecedor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FornecedorExists(id))
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
        public async Task<IActionResult> PostFornecedor([FromBody] Fornecedor fornecedor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (FornecedorVazio(fornecedor))
                return BadRequest();

            _context.Fornecedores.Add(fornecedor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFornecedor", new { id = fornecedor.Id }, fornecedor);
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFornecedor([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fornecedor = await _context.Fornecedores.FindAsync(id);
            if (fornecedor == null)
            {
                return NotFound();
            }

            _context.Fornecedores.Remove(fornecedor);
            await _context.SaveChangesAsync();

            return Ok(fornecedor);
        }

        private bool FornecedorVazio(Fornecedor fornecedor)
        {
            if (fornecedor.Nome == null || fornecedor.Codigo == null)
                return true;

            if (fornecedor.Nome == "" || fornecedor.Codigo == "")
                return true;
            
            return false;
        }

        private bool FornecedorExists(Guid id)
        {
            return _context.Fornecedores.Any(e => e.Id == id);
        }

        
        [HttpPost("{id}/carros")]
        public async Task<IActionResult> PostCarros([FromRoute] Guid fornecedorId, [FromBody] Carro carro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //if (FornecedorVazio(fornecedor))
            //    return BadRequest();
            fornecedorId = new Guid("21429e0d-8253-43f6-2ded-08d8d4daace9");
            var fornecedor = _context.Fornecedores.Find(fornecedorId);
            fornecedor.Veiculos.Add(carro);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("{id}/motos")]
        public async Task<IActionResult> PostMotos([FromRoute] Guid fornecedorId, [FromBody] Moto moto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //if (FornecedorVazio(fornecedor))
            //    return BadRequest();
            fornecedorId = new Guid("21429e0d-8253-43f6-2ded-08d8d4daace9");
            var fornecedor = _context.Fornecedores.Find(fornecedorId);
            fornecedor.Veiculos.Add(moto);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}