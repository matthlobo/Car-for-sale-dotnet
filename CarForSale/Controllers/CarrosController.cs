using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarForSale.Model;
using Microsoft.EntityFrameworkCore.Internal;

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

        // GET: api/Carros
        [HttpGet]
        public IEnumerable<Carro> GetCarros()
        {
            return _context.Carros;
        }

        [HttpGet("{CodigoFornecedor}")]
        public async Task<IActionResult> GetCarrosAssociados([FromRoute] string CodigoFornecedor)        
        {
            //var carrosAssociados = _context.Carros.Where(c => c.Fornecedor.Codigo == c.CodigoFornecedor);

            var carrosAssociados = _context.Carros;
            var fornecedorAssociado =  _context.Fornecedores.Join(carrosAssociados,
                f => f.Codigo,
                c => c.CodigoFornecedor,
                (f, c) => new
                {
                    modelo = c.Modelo,
                    cor = c.Cor,
                    tipo = c.Tipo,
                    motor = c.Motor,
                    NomeFornecedor = f.Nome,
                    codigoFornecedor = f.Codigo
                }).Where(c => c.codigoFornecedor == CodigoFornecedor);

            
            return Ok(fornecedorAssociado);
        }

        // GET: api/Carros/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarro([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var carro = await _context.Carros.FindAsync(id);

            if (carro == null)
            {
                return NotFound();
            }

            return Ok(carro);
        }

        // PUT: api/Carros/5
        [HttpPut]
        public async Task<IActionResult> PutCarro([FromBody] Carro carro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //if (id != carro.Id)
            //{
            //    return BadRequest();
            //}
                      
            
            //carro.Id = id;

            _context.Entry(carro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarroExists(carro.Id))
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

        // POST: api/Carros
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

            _context.Carros.Add(carro);
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

            var carro = await _context.Carros.FindAsync(id);
            if (carro == null)
            {
                return NotFound();
            }

            _context.Carros.Remove(carro);
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
            return _context.Carros.Any(e => e.Id == id);
        }
    }
}