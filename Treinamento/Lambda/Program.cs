using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda
{
    class Program
    {
        static Func<int, int, double> pot = ( a, potencia ) => Math.Pow( a, potencia );
        static void Main( string[] args )
        {
            var objeto = new { nome = "romulo", Idade = 23};
            

            msg( objeto.ToString() );

            msg( pot( 2, 5 ).ToString() );
            
            Console.ReadKey();
        }

        static Action<string> msg  = str => Console.WriteLine("{0}", str);
    }
}
