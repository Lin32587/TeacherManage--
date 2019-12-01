using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using StudentsManagement.Models;
using StudentsManagement.cs;

namespace StudentsManagement.cs
{
    public class StuInitAlways : DropCreateDatabaseAlways<StuDb>
    {
        protected override void Seed(StuDb context)
        {
            var t1 = new List<User>
            {
                new User{UserID="2016131602",UserName="林浚镔",SClass="16软件工程6班",Pwd="041430"},
                new User{UserID="2016131603",UserName="张三",SClass="16软件工程6班",Pwd="123456"},
                new User{UserID="2016131602AD",UserName="林浚镔",Pwd="123456"},
            };
            t1.ForEach(v => context.User.Add(v));
            context.SaveChanges();
            var t2 = new List<Course>
            {
                new Course{CID="001",CName="软件工程"},
            };
            t2.ForEach(v => context.Course.Add(v));
            context.SaveChanges();
            var t3 = new List<Score>
            {
                new Score{SID="2019061001",UserID="2016131602",CID="001",Grade=90,TestTime=DateTime.Parse("2019-06-10")},
                new Score{SID="2018070101",UserID="2016131602",CID="001",Grade=82,TestTime=DateTime.Parse("2018-07-01")},
                new Score{SID="2019061002",UserID="2016131603",CID="001",Grade=70,TestTime=DateTime.Parse("2019-06-10")},
            };
            t3.ForEach(v => context.Score.Add(v));
            context.SaveChanges();
            base.Seed(context);
        }
    }
}