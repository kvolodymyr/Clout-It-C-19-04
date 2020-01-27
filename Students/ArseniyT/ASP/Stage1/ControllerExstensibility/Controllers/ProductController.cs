using ControllerExstensibility.Models;
using System.Web.Mvc;

namespace ControllerExstensibility.Controllers
{
    public class ProductController : Controller
    {
        public ViewResult Index()
        {
            return View("Result", new Result
            {
                ControllerName = "Product",
                ActionName = "Index"
            });
        }

        public ViewResult List()
        {
            return View("Result", new Result
            {
                ControllerName = "Product",
                ActionName = "List"
            });
        }
    }
}