using SportsStore.Domain.Abstract;
using System.Web.Mvc;

namespace SportsStore.Webapp.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;

        public ProductController(IProductRepository repository)
        {
            this.repository = repository;
        }

        public ViewResult List()
        {
            return View(repository.Products);
        }
    }
}