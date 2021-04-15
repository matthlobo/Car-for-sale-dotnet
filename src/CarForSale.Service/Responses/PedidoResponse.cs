using CarForSale.Service.Dtos;
using System;

namespace CarForSale.Service.Responses
{
    public class PedidoResponse
    {
        public Guid Id { get; set; }
        public ClienteDto Cliente { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
    }
}
