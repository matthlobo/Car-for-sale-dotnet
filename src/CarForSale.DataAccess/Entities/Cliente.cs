using System;
using System.ComponentModel.DataAnnotations;

namespace CarForSale.DataAccess.Entities
{
    public class Cliente
    {
        [Key]
        public Guid Id { get; set; }

        public string Cpf { get; set; }
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
