using System;
using Microsoft.AspNetCore.Mvc;
using CarForSale.Service;
using CarForSale.Service.Requests;

namespace CarForSale.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService service;

        public ClientesController(IClienteService service)
        {
            this.service = service;
        }

        // GET: api/Clientes
        [HttpGet]
        public IActionResult Get([FromBody] ObterClienteRequest cliente)
        {
            return Ok(service.Obter(cliente));
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest(ModelState);
            }

            var cliente = service.Obter(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        // PUT: api/Clientes/5
        [HttpPut]
        public IActionResult Alterar([FromBody] AlterarClienteRequest request)
        {            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(service.Alterar(request));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }       

        // POST: api/Clientes
        [HttpPost]
        public IActionResult Adicionar([FromBody] ClienteRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(service.Adicionar(request));
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public IActionResult Remover([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            service.Remover(id);

            return Ok();
        }

        //[HttpPatch]
        //public async Task<IActionResult> Patch([FromBody] ClientePatch clientePatch)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var cliente = await _context.Clientes.FindAsync(clientePatch.Id);
        //    if (cliente == null)
        //    {
        //        return NotFound();
        //    }

        //    AtualizarDadosPorReflection(clientePatch, cliente);
        //    await _context.SaveChangesAsync();

        //    return Ok();
        //}

        //private void AtualizarDadosPorReflection(ClientePatch clientePatch, Cliente cliente)
        //{
        //    var clientePatchProperties = clientePatch.GetType().GetProperties().Where(x => x.Name != nameof(clientePatch.Id));
        //    var clienteProperties = cliente.GetType().GetProperties();

        //    foreach (var property in clientePatchProperties)
        //    {
        //        var propertyValue = property.GetValue(clientePatch);

        //        if (propertyValue != null)
        //        {                    
        //            var clienteProperty = clienteProperties.FirstOrDefault(x => x.Name == property.Name);
        //            if (clienteProperty != null)
        //            {
        //                clienteProperty.SetValue(cliente, propertyValue);
        //            }
        //        }
        //    }
        //}

        //private bool ClienteExists(Guid id)
        //{
        //    return _context.Clientes.Any(e => e.Id == id);
        //}
    }
}