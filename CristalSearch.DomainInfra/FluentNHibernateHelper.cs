using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Linq;
using System.Collections.Generic;

namespace CristalSearch.DomainInfra
{
    public class FluentNHibernateHelper<T> : IDisposable
    {
        public static ISession OpenSession()
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CristalSearchDB;Connect Timeout=3000;";

            ISessionFactory sessionFactory = Fluently.Configure()
                                                .Database(MsSqlConfiguration.MsSql2012.ShowSql().ConnectionString(connectionString).ShowSql())
                                                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<T>())
                                                .ExposeConfiguration(cfg => new SchemaExport(cfg)
                                                .Create(false, false))
                                                .BuildSessionFactory();

            return sessionFactory.OpenSession();
        }

        public static void SaveOrUpdate<TParam>(TParam entity)
        {
            using (var session = FluentNHibernateHelper<TParam>.OpenSession())
            {
                try
                {
                    session.SaveOrUpdate(entity);
                    session.BeginTransaction().Commit();
                }
                catch (Exception e)
                {
                    session.BeginTransaction().Rollback();
                    throw e;
                }
            }

        }

        public static void Save<TParam>(TParam entity)
        {
            using (var session = FluentNHibernateHelper<TParam>.OpenSession())
            {
                try
                {
                    session.Save(entity);
                    session.BeginTransaction().Commit();
                }
                catch (Exception e)
                {
                    session.BeginTransaction().Rollback();
                    throw e;
                }
            }
        }

        public static void Update<TParam>(TParam entity)
        {
            using (var session = FluentNHibernateHelper<TParam>.OpenSession())
            {
                try
                {
                    session.Update(entity);
                    session.BeginTransaction().Commit();
                }
                catch (Exception e)
                {
                    session.BeginTransaction().Rollback();
                    throw e;
                }
            }
        }

        public static TParam Load<TParam>(object id)
        {
            TParam entity;
            using (var session = FluentNHibernateHelper<TParam>.OpenSession())
            {
                try
                {
                    entity = session.Load<TParam>(id);
                    session.BeginTransaction().Commit();
                }
                catch (Exception e)
                {
                    session.BeginTransaction().Rollback();
                    throw e;
                }
            }

            return entity;
        }

        public static IList<TParam> QueryList<TParam>()
        {
            IList<TParam> entity;
            using (var session = FluentNHibernateHelper<TParam>.OpenSession())
            {
                try
                {
                    entity = session.Query<TParam>().AsQueryable().ToList();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            return entity;
        }

        public static void Delete<TParam>(TParam entity)
        {
            using (var session = FluentNHibernateHelper<TParam>.OpenSession())
            {
                try
                {
                    session.Delete(entity);
                    session.BeginTransaction().Commit();
                }
                catch (Exception e)
                {
                    session.BeginTransaction().Rollback();
                    throw e;
                }
            }
        }

        public void Dispose()
        {
            OpenSession().Close();
        }
    }
}
