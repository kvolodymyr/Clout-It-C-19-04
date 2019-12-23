using System;
using System.Collections.Generic;
// ERROR: C# State Error CS1660 Cannot convert lambda expression to type 'string' because it is not a delegate type
using System.Data.Entity;
using System.Linq;
// ERROR
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForms.Model;

namespace WebForms.Users
{
    public partial class Users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public IQueryable<Student> studentsGrid_GetData()
        {
            SchoolContext db = new SchoolContext();
            var query = db.Students.Include(s => s.Enrollments.Select(e => e.Course));
            return query;
        }
    }
}