using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.Webapp.Controllers;
using SportsStore.Webapp.HtmlHelpers;
using SportsStore.Webapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SportsStore.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Paginate()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products)
                .Returns(new Product[]
                {
                    new Product {ProductId = 1, Name = "P1"},
                    new Product {ProductId = 2, Name = "P2"},
                    new Product {ProductId = 3, Name = "P3"},
                    new Product {ProductId = 4, Name = "P4"},
                    new Product {ProductId = 5, Name = "P5"},
                });
            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;

            ProductListViewModel res = (ProductListViewModel)controller.List(null, 2).Model;

            Product[] products = res.Products.ToArray();
            Assert.IsTrue(products.Length == 2);
            Assert.AreEqual(products[0].Name, "P4");
            Assert.AreEqual(products[1].Name, "P5");
        }

        [TestMethod]
        public void Can_Generate_Page_Links()
        {
            HtmlHelper myHtmlHelper = null;
            PagingInfo pagingInfo = new PagingInfo
            {
                CurrPage = 2,
                TotalItems = 28,
                ItemsPerPage = 10
            };
            Func<int, string> pageUrlDelegate = i => "Page" + i;

            MvcHtmlString res = myHtmlHelper.PageLinks(pagingInfo, pageUrlDelegate);

            Assert.AreEqual(@"<a class=""btn btn-default"" href=""Page1"">1</a>"
                + @"<a class=""btn btn-default btn-primary selected"" href=""Page2"">2</a>"
                + @"<a class=""btn btn-default"" href=""Page3"">3</a>",
                res.ToString());
        }

        [TestMethod]
        public void Can_Send_Pagination_View_Model()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products)
                .Returns(new Product[]
                {
                    new Product {ProductId = 1, Name = "P1"},
                    new Product {ProductId = 2, Name = "P2"},
                    new Product {ProductId = 3, Name = "P3"},
                    new Product {ProductId = 4, Name = "P4"},
                    new Product {ProductId = 5, Name = "P5"},
                });
            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;

            ProductListViewModel res = (ProductListViewModel)controller.List(null, 2).Model;

            PagingInfo pageInfo = res.PagingInfo;
            Assert.AreEqual(pageInfo.CurrPage, 2);
            Assert.AreEqual(pageInfo.ItemsPerPage, 3);
            Assert.AreEqual(pageInfo.TotalItems, 5);
            Assert.AreEqual(pageInfo.TotalPages, 2);
        }
    }
}
