using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace studentBasicInfo.Models
{
    public class Student
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual int Age { get; set; }
        public virtual string Grade { get; set; }
    }

}