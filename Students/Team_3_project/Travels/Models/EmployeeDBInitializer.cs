using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Travels.Mocks;

namespace Travels.Models
{
    public class EmployeeDBInitializer : DropCreateDatabaseAlways<EmployeeContext>
    {
        protected override void Seed(EmployeeContext db)
        {
            db.Users.Add(new Employee { FirstName = "test", LastName = "last", Password = "123", HashedPassword = Verification.HashPassword("123")});
            db.Users.Add(new Employee { FirstName = "test", LastName = "last", Password = "22", HashedPassword = Verification.HashPassword("22")});
            db.Users.Add(new Employee { FirstName = "test", LastName = "last", Password = "123", HashedPassword = Verification.HashPassword("123")});
            db.Users.Add(new Employee { FirstName = "test", LastName = "last", Password = "123", HashedPassword = Verification.HashPassword("123")});

            base.Seed(db);
        }
    }
}