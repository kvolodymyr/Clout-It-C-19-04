using AppMvc.Models;
using AspNetMvc.Models;
using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AspNetMvc.Controllers
{
    public class HomeController : Controller
    {

        public HomeController() {
            Debugger.Break();
        }


        public ActionResult Index()
        {
            User user = new User
            {
                Name = "test-user"
            };

            return View(user);
        }

        //public async Task<ActionResult> Index()
        //{
        //    User user = await GetUser();

        //    return View(user);
        //}

        //public async Task<ActionResult> Index()
        //{
        //    var _user = await GetUser();
        //    var user = await GetUserName(_user.Name);

        //    if (user == null)
        //    {
        //        user = await AddUser(new User { Name = _user.Name });
        //    }

        //    return View(user);
        //}

        //private async Task<User> GetUserName(string userName)
        //{
        //    User result = null;

        //    using (var appContext = new WebAppContext())
        //    {
        //        result = await appContext.Users.FirstOrDefaultAsync(f => f.Name.ToLower() == userName.ToLower());
        //    }

        //    return result;
        //}

        //public async Task<User> AddUser(User user)
        //{
        //    using (var appContext = new WebAppContext())
        //    {
        //        appContext.Users.Add(user);
        //        await appContext.SaveChangesAsync();
        //    }

        //    return user;
        //}

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page. asfkl 'ajskldfj aklsjdfkjasdk";

            return View();
        }

        public ActionResult Contact(string id)
        {
            ViewBag.Message = $"Your contact page. {id}";

            ViewBag.Message2 = $"AAAAAAAA";

            return View();
        }

        private async Task<User> GetUser() {
            var user = new User();
            using (var client = new HttpClient()) {
                client.BaseAddress = new Uri("http://localhost:11135/");

                var response = await client.GetAsync("api/diagnostic/author");

                user.Name = response.IsSuccessStatusCode ? await response.Content.ReadAsStringAsync() : string.Empty;
            }
            return user;
        }
    }
}