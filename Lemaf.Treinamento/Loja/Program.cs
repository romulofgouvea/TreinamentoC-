using Loja.DAO;
using Loja.Entidades;
using Loja.Infra;
using NHibernate;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja
{
    class Program
    {
        static void Main(string[] args)
        {
            //NhibernateHelper.LoadSchema();
            //02
            ISession session = NhibernateHelper.CreateSession();
            //GenericDAO<Categoria> categoriaDAO = new GenericDAO<Categoria>( session );
            //Categoria c = new Categoria() { Nome = "Primeira Categoria" };
            //categoriaDAO.Post( c );

            //GenericDAO<Produto> produtoDAO = new GenericDAO<Produto>( session );
            //Produto x = new Produto() { Nome = "Anel", Preco = 5.0M };
            //produtoDAO.Post( x, true );

            //03
            //ITransaction transaction = session.BeginTransaction();

            //Categoria categoria = session.Load<Categoria>( 1 );
            //List<Produto> produtos = categoria.Produtos.ToList();

            //transaction.Commit();
            //session.Close();


            //04
            //IQuery query = session.CreateQuery( "FROM Produto p ORDER BY p.Nome" );
            //IQuery query = session.CreateQuery( "FROM Produto p WHERE p.Preco > ?" );
            //query.SetParameter(0,10);
            //IQuery query = session.CreateQuery( "FROM Produto p WHERE p.Preco > :minimo" );
            //query.SetParameter( "minimo", 10 );
            //IQuery query = session.CreateQuery( "FROM Produto p WHERE p.Preco > :minimo AND p.Categoria.Nome = :categoria" );
            //query.SetParameter( "minimo", 10 );
            //query.SetParameter( "categoria", "Primeira Categoria" );

            //retorna um array de objects, tendo que transforma em uma classe pra gerar o array de categorias em relação aos produtos
            //string hql = "select p.Categoria as Categoria, count( p.id ) as NumeroDePedidos from  Produto p join fetch p.Categoria";
            //IQuery query = session.CreateQuery( hql );
            //query.SetResultTransformer( Transformers.AliasToBean<ProdutosPorCategoria>() );

            //List<ProdutosPorCategoria> produtos = query.List<ProdutosPorCategoria>().ToList();

            //foreach ( Produto p in produtos )
            //{
            //    Console.WriteLine("{0}", p.Nome);
            //}

            //05
            //string hql = @"FROM Produto p join fetch p.Categoria";
            //IQuery query = session.CreateQuery( hql );
            //IList<Produto> produtos = query.List<Produto>();

            //06
            //ProdutoDAO produto = new ProdutoDAO(session);
            //IList<Produto> produtos = ProdutoDAO.BuscaNomePrecoCategoria("",0, "Primeira Categoria" );

            //foreach (var p in produtos)
            //{
            //    Console.WriteLine("Nome: {0}", p.Nome);
            //}

            //07
            //ISession session2 = NhibernateHelper.CreateSession();

            //Categoria c = session.Get<Categoria>(1);
            //Categoria c2 = session.Get<Categoria>(1);

            //Console.WriteLine(c.Produtos.Count);
            //Console.WriteLine(c2.Produtos.Count);

            //session.CreateQuery("FROM Pessoa").SetCacheable( true ).List<Pessoa>();
            //session2.CreateQuery("FROM Pessoa").SetCacheable( true ).List<Pessoa>();

            //session.Close();
            //session2.Close();

            //08
            ITransaction transaction = session.BeginTransaction();

            Venda venda = new Venda();
            Pessoa cliente = session.Get<Pessoa>( 1 );
            venda.Cliente = cliente;

            Produto p1 = session.Get<Produto>( 1 );
            Produto p2 = session.Get<Produto>( 2 );

            venda.Produtos.Add( p1 );
            venda.Produtos.Add( p2 );

            session.Save(venda);

            transaction.Commit();
            session.Close();

            Console.WriteLine("FIM");

            Console.ReadKey();
        }

        public class ProdutosPorCategoria
        {
            public Categoria Categoria { get; set; }
            public long NumeroDePedidos { get; set; }
        }
    }
}
