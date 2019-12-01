using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using StudentsManagement.Models;

namespace StudentsManagement.cs
{
    public class StuInit:DropCreateDatabaseIfModelChanges<StuDb>
    {
        protected override void Seed(StuDb context)
        {
            base.Seed(context);
        }
    }
}