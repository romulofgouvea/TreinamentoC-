using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDelegateGenericos
{
    class Program
    {
        decimal Somar( int a, int b )
        {
            return a + b;
        }

        //delegate T Calc<T>(T a, T b);

        static void Main( string[] args )
        {
            Program p = new Program();
            //Calc<int> c = new Calc<int>( p.Somar );

            Func<int, int, decimal> c = p.Somar;//delegate especial

            Action<string> act = p.Imprimir;

            act( c( 3, 3 ).ToString() );

            Console.WriteLine("{0}", c( 2, 2 ) );
            
            Console.ReadKey();
        }

        void Imprimir(string msg)
        {
            Console.WriteLine( "{0}", msg );
        }

        //static void ExibiDelegate<T>( Calc<T> del )
        //{
        //    Console.WriteLine( del.Target );
        //    Console.WriteLine( del.Method );
        //}
    }
}
