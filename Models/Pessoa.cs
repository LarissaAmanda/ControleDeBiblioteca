using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeBiblioteca.Models
{
    public class Pessoa
    {
        public string NomeCompleto { get; set; }
        public string Telefone {get; set; }
        public string Email { get; set; }
        public int NumeroDeIndenticacao { get; set; }
    }
}