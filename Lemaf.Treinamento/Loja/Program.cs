using Loja.DAO;
using Loja.Entidades;
using Loja.Infra;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja
{
    class Program
    {
        static void Main(string[] args)
        {
            //NhibernateHelper.LoadSchema();
            PessoasDAO pessoasDAO = new PessoasDAO(NhibernateHelper.CreateSession());
            pessoasDAO.Post(new Pessoa() { Nome="Romim", Idade=23,Endereco="Rua Nicolau"});

            Console.ReadKey();
        }
    }
}
