using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeBiblioteca.Models
{
    public class Usuario : Pessoa
    {
        List<Livro> livroEmprestado = new List<Livro>();
        
    }
}