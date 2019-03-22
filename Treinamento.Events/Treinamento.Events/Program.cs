using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Treinamento.Events
{
    class Program
    {
        public void OcorreuErroNoTeste(object sender, EventArgs e)
        {
            Console.WriteLine("ErroTeste");
        }
        
        public void QuandoExcesso(object sender, EventArgs e)
        {
            ExcessoEventArgs eventArgs = (ExcessoEventArgs)e;

            Console.WriteLine("Excesso: {0}", eventArgs.intensidade);
        }

        static void Main(string[] args)
        {
            Program p = new Program();
            GerenciadorIncremento gerenciador = new GerenciadorIncremento();

            Console.Write("Digite a: ");
            char key;

            do {
                Console.Write("\n");
                key = Console.ReadKey().KeyChar;
               
                if (key == 'l')
                {
                    gerenciador.ExcessoEvent += p.QuandoExcesso;
                    Console.WriteLine("\n{0}", gerenciador.IncrementIntensidade());
                }

            } while (key != 'a');

            Console.ReadKey();
        }

        public class GerenciadorIncremento
        {
            private int _intensidade = 0;

            //delegate
            public delegate void ExcessoHandler(object sender, EventArgs e);
            public event ExcessoHandler ExcessoEvent;//extensão do handler, e somente a classe pode usar(private)

            protected virtual void OnExcesso( EventArgs e)// disparador do evento
            {
                if (ExcessoEvent != null)
                {
                    ExcessoEvent(this, e);
                }
            }

            public int IncrementIntensidade()
            {
                _intensidade = (_intensidade < 100) ? _intensidade += 10 : _intensidade;
                if ( _intensidade == 80 )
                {
                    ExcessoEventArgs e = new ExcessoEventArgs { intensidade = _intensidade};
                    OnExcesso(e);
                }

                return _intensidade;
            }

        }

        public class ExcessoEventArgs : EventArgs
        {
            public int intensidade { get; set; }
        }
    }
}
