using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreinamentoDelegates
{
    class Program
    {

        public static int Mensagem1()
        {
            Console.WriteLine( "Mensagem 1" );
            return 1;
        }

        public static void Mensagem2()
        {
            Console.WriteLine( "Mensagem 2" );
        }

        public static void Mensagem3()
        {
            Console.WriteLine( "Mensagem 3" );
        }

        public delegate int EscreverMensagem();

        static void ExecultaMSG( EscreverMensagem e )
        {
            e();
        }

        static void Main( string[] args )
        {
            ExecultaMSG( Mensagem1 );

            Console.ReadKey();
        }
    }
}