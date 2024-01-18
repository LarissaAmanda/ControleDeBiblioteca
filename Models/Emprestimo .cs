using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeBiblioteca.Models
{
    public class Emprestimo 
    {
        public int CodigoDoUsuario { get; set; }
        public int CodigoDoLivro { get; set; }
        public int CodigoDoBibliotecario { get; set; }
        public DateTime DataDoEmprestimo { get; set; }
    }
}