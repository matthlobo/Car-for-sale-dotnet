using System;

namespace CarForSale.Model
{
    public class ClientePatch
    {      
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }        
        public string Senha { get; set; }
    }
}
