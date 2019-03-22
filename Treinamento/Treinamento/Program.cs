using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreinamentoCoContravariancia
{
    class Program
    {
        interface IArmazenador<in T>
        {
            void Armazenar( T item );
        }

        interface IRecuperador<out T>
        {
            T Recuperar( int codigo );
        }

        public class Manipulador<T> : IArmazenador<T>, IRecuperador<T>
        {
            List<T> _list = new List<T>();
            public void Armazenar( T item )
            {
                _list.Add( item );
            }

            public T Recuperar( int codigo )
            {
                return _list[ codigo ];
            }
        }

        public class Nivel1
        {

        }

        public class Nivel2: Nivel1
        {

        }

        public class Nivel3: Nivel2
        {

        }

        static void Main( string[] args )
        {
            Manipulador<Nivel2> manipulador = new Manipulador<Nivel2>();

            //ContraVariancia = Generico -> especifico
            //Nivel2 n2 = new Nivel3();
            IArmazenador<Nivel3> arm3 = manipulador;
            arm3.Armazenar( new Nivel3() );

            //Covariancia Especifico -> Generico

            //IArmazenador<Nivel1> arm1 = manipulador;
            //Nivel1 n1 = new Nivel2();
            IRecuperador<Nivel1> rec1 = manipulador;

            Console.WriteLine( "{0}", rec1.Recuperar( 0 ) );




            Console.ReadKey();
        }
    }

    
}
