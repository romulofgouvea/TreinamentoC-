using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    class Pessoa
    {
        public string _nome { get; set; }
    }

    class Program
    {

        public static List<Pessoa> LoadData()
        {
            List<Pessoa> list = new List<Pessoa>();
            list.Add( new Pessoa { _nome = "Caio" } );
            list.Add( new Pessoa { _nome = "Rodrigo" } );
            list.Add( new Pessoa { _nome = "Douglas" } );
            list.Add( new Pessoa { _nome = "Rau" } );
            list.Add( new Pessoa { _nome = "Romulo" } );

            return list;
        }

        static void Main( string[] args )
        {
            List<Pessoa> linq = LoadData();

            var en = from p in linq
                                     orderby p._nome
                                     select new;

            var datos = linq.OrderBy( x => x._nome ).Select(x => new { x._nome } );
            
            Console.WriteLine("{0}", datos.GetType());

            foreach ( var p in datos )
            {
                Console.WriteLine( "nome: {0}", p._nome );
            }


            Console.ReadKey();
        }
    }
}
