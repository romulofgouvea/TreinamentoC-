using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Treinamento.Persistencia.EF;

namespace Treinamento.Repositorio
{
    public interface IRepositorio<TTpo>
    {
        //CRUD
        List<TTpo> GetAll();

        TTpo Get(int id);

        int Post(TTpo objeto);

        //int Put();

        //int Delete();

    }
}
