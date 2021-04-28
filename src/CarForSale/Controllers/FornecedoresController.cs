using System;
using Microsoft.AspNetCore.Mvc;
using CarForSale.Service;
using CarForSale.Service.Requests;

namespace CarForSale.Controllers
{
    [Route("api/[controller]")]
   [ApiController]
   public class FornecedoresController : ControllerBase
   {
       private readonly IFornecedorService service;

       public FornecedoresController(IFornecedorService service)
       {
           this.service = service;
       }

        
       [HttpGet]
        public IActionResult Get()
        {
            return Ok(service.ObterTodos());
        }

        [HttpGet("{fornecedorId}")]
        public IActionResult GetById([FromRoute] Guid fornecedorId)
        {
            if (fornecedorId == Guid.Empty)
            {
                return BadRequest(ModelState);
            }

            var fornecedor = service.Obter(fornecedorId);

            if (fornecedor == null)
            {
                return NotFound();
            }

            return Ok(fornecedor);
        }

        [HttpPost]
        public IActionResult Adicionar([FromBody] FornecedorRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(service.Adicionar(request));
        }


        [HttpPut("{fornecedorId}")]
        public IActionResult Alterar([FromRoute] Guid fornecedorId, [FromBody] AlterarFornecedorRequest request)
        {
            request.Id = fornecedorId;

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
       
        
       [HttpDelete("{fornecedorId}")]
       public IActionResult Remover([FromRoute] Guid fornecedorId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            service.Remover(fornecedorId);

            return Ok();
        }

        [HttpGet("{fornecedorId}/veiculos")]
        public IActionResult GetVeiculos([FromRoute] Guid fornecedorId)
        {
            return Ok(service.ObterVeiculos(fornecedorId));
        }

        [HttpGet("{fornecedorId}/veiculos/{veiculoId}")]
        public IActionResult GetVeiculoById([FromRoute] Guid fornecedorId, [FromRoute] Guid veiculoId)
        {
            return Ok(service.ObterVeiculo(fornecedorId, veiculoId));
        }

        [HttpPost("{fornecedorId}/veiculos")]
        public IActionResult PostVeiculo([FromRoute] Guid fornecedorId, [FromBody] VeiculoRequest request)
        {
            var veiculo = service.AdicionarVeiculo(fornecedorId, request);
            return CreatedAtAction(nameof(GetVeiculoById), new { fornecedorId = fornecedorId, veiculoId = veiculo.Id }, veiculo);
        }

        [HttpPut("{fornecedorId}/veiculos/{veiculoId}")]
        public IActionResult PutVeiculo([FromRoute] Guid fornecedorId, [FromRoute] Guid veiculoId, [FromBody] VeiculoRequest request)
        {
            return Ok(service.AlterarVeiculo(fornecedorId,veiculoId, request));
        }

        [HttpDelete("{fornecedorId}/veiculos/{veiculoId}")]
        public IActionResult RemoveVeiculo([FromRoute] Guid fornecedorId, [FromRoute] Guid veiculoId)
        {
            service.RemoverVeiculo(fornecedorId, veiculoId);
            return Ok();
        }

    }
}