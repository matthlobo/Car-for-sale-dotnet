using System;

namespace CarForSale.Service.Requests
{
    public class PedidoRequest
    {
        public Guid ClienteId { get; set; }
        public Guid VeiculoId { get; set; }
        public decimal Valor { get; set; }
    }
}
