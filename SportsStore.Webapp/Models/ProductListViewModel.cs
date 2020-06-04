using SportsStore.Domain.Entities;
using System.Collections.Generic;

namespace SportsStore.Webapp.Models
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}