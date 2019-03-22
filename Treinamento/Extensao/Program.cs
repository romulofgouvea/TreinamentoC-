using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensao
{
    public static class IntegerHelper
    {
        public static int quadrado( this int x )
        {
            return x * x;
        }

        public static string novo( this string x )
        {
            return x.ToUpper();
        }

        //static Func<int, int> quad = (this int x) => x* x;
    }

    class Program
    {
        static void Main( string[] args )
        {

            Console.WriteLine( "{0}", 1.quadrado );

            Console.ReadKey();
        }
    }
}
