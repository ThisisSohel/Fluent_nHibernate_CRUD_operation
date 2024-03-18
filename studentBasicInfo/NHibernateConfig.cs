using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Tool.hbm2ddl;
using studentBasicInfo.Models;

public class NHibernateConfig
{
    public static ISessionFactory CreateSessionFactory()
    {
        var sessionFactory = Fluently.Configure()
            .Database(MsSqlConfiguration.MsSql2012.ConnectionString("Server=DESKTOP-AHJE16O\\SQLEXPRESS;Database=SchoolDB;Integrated Security=True;"))
            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Student>())
            .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true))
            .BuildSessionFactory();

        return sessionFactory;
    }
}
