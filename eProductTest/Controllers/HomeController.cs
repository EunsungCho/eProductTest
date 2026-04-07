using eProductTest.Models;
using eProductTest.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace eProductTest.Controllers
{
    public class HomeController : Controller
    {
        private IDataRepository dataRepository;
        public int PageSize = 4;
        public HomeController(IDataRepository repository)
        {
            dataRepository = repository;
        }
        //public ViewResult Index(int productPage = 1) => View(dataRepository.Products
        //    .OrderBy(p => p.ProductID)
        //    .Skip((productPage - 1) * PageSize)
        //    .Take(PageSize)
        //    );

        public ViewResult Index(string? category, int productPage = 1)
        {
            int skipNumber = (productPage - 1) * PageSize;
            var products = dataRepository.Products
                .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.ProductID).Skip(skipNumber).Take(PageSize);
            eStoreProductListViewModel viewModel = new eStoreProductListViewModel();
            viewModel.Products = products;
            viewModel.PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                TotalItems = dataRepository.Products.Where(p => category == null || p.Category == category).Count()
            };
            viewModel.CurrentCategory = category;

            return View(viewModel);
        }
    }
}
