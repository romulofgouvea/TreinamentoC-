using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Treinamento.Dominio;
using Treinamento.Repositorio;

namespace Treinamento.CadastroPessoas
{
    class Program
    {
        private Pessoa pessoa { get; set; }
        static void Main( string[] args )
        {
            Program p = new Program();
            p.pessoa = new Pessoa();
            IRepositorio<Pessoa> repositorio = new PessoaRepositorio();
            int key = 0;
            do
            {
                Console.WriteLine("Pessoas: \n");
                foreach (Pessoa pes in repositorio.GetAll() )
                {
                    Console.WriteLine("{0} - {1}",pes.Id, pes.Nome);
                }

                //Console.WriteLine( "10 - Buscar pessoa" );
                //key = Convert.ToInt32( Console.ReadKey() );
                //if (key == 10)
                //{
                //    Console.WriteLine( "ID: " );
                //    key = Convert.ToInt32( Console.ReadKey() );
                //    repositorio.Get(key);
                //}

                Console.WriteLine( "\nAdicionar Pessoas: " );
                Console.WriteLine( "Digite seu nome: " );
                p.pessoa.Nome = Console.ReadLine();

                Console.WriteLine( "Digite sua idade: " );
                p.pessoa.Idade = Convert.ToInt32( Console.ReadLine() );

                Console.WriteLine( "Digite seu endereço: " );
                p.pessoa.Endereco = Console.ReadLine();

                repositorio.Post( p.pessoa );

                Console.WriteLine( "0 continua..." );
                key = Convert.ToInt32( Console.ReadKey() );
            } while ( key == 0 );

            Console.WriteLine( "Finalizar..." );
            Console.ReadKey();
        }
    }
}

