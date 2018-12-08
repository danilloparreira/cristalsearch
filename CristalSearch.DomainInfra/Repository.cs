//using NHibernate;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace CristalSearch.DomainInfra
//{
//    public class Repository<T> : IDisposable, IRepository<T> where T : class
//    {
//        //protected ISession session = SessionFactory.Instance.GetSession();

//        //public void Gravar(T entidade)
//        //{
//        //    using (ITransaction transacao = session.BeginTransaction())
//        //    {
//        //    }
//        //}

//        //public void Excluir(T entidade)
//        //{
//        //    using (ITransaction transacao = session.BeginTransaction())
//        //    {
//        //    }
//        //}

//        //public T PesquisarPorId(int Id)
//        //{
//        //    return session.Get<T>(Id);
//        //}

//        //public IList<T> Listar()
//        //{
//        //    return (from c in session.Query<T>() select c).ToList();
//        //}

//        //public void Dispose()
//        //{
//        //    session.Close();
//        //}
//    }
//}
