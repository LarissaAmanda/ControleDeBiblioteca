using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeBiblioteca.Models
{
    public class Livro
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int AnoDePublicacao { get; set; }
        public int CodigoDoLivro { get; set; }
        public bool MyProperty { get; set; }


    }
}