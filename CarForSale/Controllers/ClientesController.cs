using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarForSale.Model;
using Newtonsoft.Json;
using System.Net;
using System.Reflection;

namespace CarForSale.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public ClientesController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/Clientes
        [HttpGet]
        public IEnumerable<Cliente> Get()
        {
            return _context.Clientes;
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        // PUT: api/Clientes/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Cliente cliente)
        {            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (cliente.Id != cliente.Id)
            {
                return BadRequest();
            }

            _context.Entry(cliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(cliente.Id))
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

        // POST: api/Clientes
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var clienteExistente = _context.Clientes.Any(c => c.Cpf == cliente.Cpf);
                       
            if(clienteExistente)
            {               
                return BadRequest(JsonConvert.SerializeObject(new { mensagem = "O CPF já está cadastrado." }));
            }                       

            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCliente", new { id = cliente.Id }, cliente);
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();

            return Ok(cliente);
        }

        [HttpPatch]
        public async Task<IActionResult> Patch([FromBody] ClientePatch clientePatch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cliente = await _context.Clientes.FindAsync(clientePatch.Id);
            if (cliente == null)
            {
                return NotFound();
            }

            AtualizarDadosPorReflection(clientePatch, cliente);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private void AtualizarDadosPorReflection(ClientePatch clientePatch, Cliente cliente)
        {
            var clientePatchProperties = clientePatch.GetType().GetProperties().Where(x => x.Name != nameof(clientePatch.Id));
            var clienteProperties = cliente.GetType().GetProperties();

            foreach (var property in clientePatchProperties)
            {
                var propertyValue = property.GetValue(clientePatch);

                if (propertyValue != null)
                {                    
                    var clienteProperty = clienteProperties.FirstOrDefault(x => x.Name == property.Name);
                    if (clienteProperty != null)
                    {
                        clienteProperty.SetValue(cliente, propertyValue);
                    }
                }
            }
        }

        private bool ClienteExists(Guid id)
        {
            return _context.Clientes.Any(e => e.Id == id);
        }
    }
}