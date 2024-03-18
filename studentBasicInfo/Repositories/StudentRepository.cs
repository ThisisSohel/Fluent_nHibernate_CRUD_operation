using System.Collections.Generic;
using System.Linq;
using NHibernate;
using studentBasicInfo.Models;

public class StudentRepository
{
    private readonly ISessionFactory _sessionFactory;

    public StudentRepository()
    {
        _sessionFactory = NHibernateConfig.CreateSessionFactory();
    }

    public void AddStudent(Student student)
    {
        using (var session = _sessionFactory.OpenSession())
        using (var transaction = session.BeginTransaction())
        {
            session.Save(student);
            transaction.Commit();
        }
    }
    public void UpdateStudent(Student student)
    {
        using (var session = _sessionFactory.OpenSession())
        using (var transaction = session.BeginTransaction())
        {
            session.Update(student);
            transaction.Commit();
        }
    }

    public void DeleteStudent(Student student)
    {
        using (var session = _sessionFactory.OpenSession())
        using (var transaction = session.BeginTransaction())
        {
            session.Delete(student);
            transaction.Commit();
        }
    }

    public IList<Student> GetAllStudents()
    {
        using (var session = _sessionFactory.OpenSession())
        {
            return session.Query<Student>().ToList();
        }
    }

    public Student GetStudentById(int id)
    {
        using (var session = _sessionFactory.OpenSession())
        {
            return session.Get<Student>(id);
        }
    }
}
