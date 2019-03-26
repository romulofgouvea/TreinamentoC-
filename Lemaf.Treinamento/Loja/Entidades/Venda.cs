using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Entidades
{
    class Venda
    {
        public virtual int Id { get; set; }
        public virtual Pessoa Cliente { get; set; }
        public IList<Produto> Produtos { get; set; }

        public Venda()
        {
            this.Produtos = new List<Produto>();
        }
    }
}
