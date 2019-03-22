using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos
{
    class Program
    {
        public class IExcessoEventArgs : EventArgs
        {
            public int intensidade { get; set; }
        }

        static void Main( string[] args )
        {
            GerenciadorLatidos _gerenciador = new GerenciadorLatidos();
            _gerenciador.ExcessoEvent += ( sender, e ) =>
            {
                IExcessoEventArgs eventArgs = ( IExcessoEventArgs )e;
                Console.WriteLine( "Excesso: {0}", eventArgs.intensidade );
            };


            int key = 0;
            do
            {
                key = Convert.ToInt32( Console.ReadLine() );

                if ( key == 1 )
                {
                    Console.WriteLine( "{0}", _gerenciador.Latir() );
                }

            } while ( key != 0 );

            Console.WriteLine( "Fim!" );

            Console.ReadKey();
        }

        public class GerenciadorLatidos
        {
            int _intensidade = 0;

            public delegate void ExcessoHandler( object sender, EventArgs e );
            public event ExcessoHandler ExcessoEvent;

            public GerenciadorLatidos()
            {
                _intensidade = 0;
            }

            public int Latir()
            {
                _intensidade = ( _intensidade < 100 ) ? _intensidade += 10 : _intensidade;

                if ( _intensidade == 50 )
                {
                    IExcessoEventArgs e = new IExcessoEventArgs{ intensidade = _intensidade };
                    if ( ExcessoEvent != null )
                    {
                        ExcessoEvent( this, e );
                    }
                }

                return _intensidade;
            }
        }
    }


}
