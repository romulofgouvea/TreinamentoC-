using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Entidades
{
    public class PessoaFisica:Pessoa
    {
        public virtual string  CPF { get; set; }
    }
}
