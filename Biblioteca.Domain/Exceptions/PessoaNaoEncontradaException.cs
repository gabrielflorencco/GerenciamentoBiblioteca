using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Domain.Exceptions
{
    public class PessoaNaoEncontradaException : Exception
    {
        public PessoaNaoEncontradaException() 
            : base("Pessoa não encontrada") { }
    }
}
