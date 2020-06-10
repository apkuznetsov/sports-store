using SportsStore.Domain.Abstract;
using System.Web.Mvc;

namespace SportsStore.Webapp.Controllers
{
    public class AdminController : Controller
    {
        private IProductRepository repository;

        public AdminController(IProductRepository repository)
        {
            this.repository = repository;
        }

        public ViewResult Index()
        {
            return View(repository.Products);
        }
    }
}