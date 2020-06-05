using SportsStore.Domain.Abstract;
using SportsStore.Webapp.Models;
using System.Linq;
using System.Web.Mvc;

namespace SportsStore.Webapp.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 4;

        public ProductController(IProductRepository repository)
        {
            this.repository = repository;
        }

        public ViewResult List(string category, int page = 1)
        {
            ProductListViewModel model = new ProductListViewModel()
            {
                Products = repository.Products
                .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.ProductId)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null 
                    ? repository.Products.Count() 
                    : repository.Products.Where(p => p.Category == category).Count()
                },
                CurrCategory = category
            };

            return View(model);
        }
    }
}