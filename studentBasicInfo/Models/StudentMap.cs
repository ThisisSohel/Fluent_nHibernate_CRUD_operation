using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;

namespace studentBasicInfo.Models
{
    public class StudentMap : ClassMap<Student>
    {
        public StudentMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Age);
            Map(x => x.Grade);
            Table("Students");
        }
    }
}