using EFCoreRelations.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EFCoreRelations.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _appDbContext;

        public HomeController(ILogger<HomeController> logger, AppDbContext appDbContext)
        {
            _logger = logger;
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            var category = _appDbContext.Categories.Where(cat => cat.CategoryName == product.Category.CategoryName).First();
            var company = _appDbContext.Companies.Where(com => com.CompanyName == product.Companies[0].CompanyName).First();
            product.Category = category;
            product.Companies = new List<Company> { company };
            _appDbContext.Products.Add(product);
            _appDbContext.SaveChanges();
            return View();
        }
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            _appDbContext.Categories.Add(category);
            _appDbContext.SaveChanges();
            return View();
        }
        public IActionResult AddCompany()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCompany(Company company)
        {
            _appDbContext.Companies.Add(company);
            _appDbContext.SaveChanges();
            return View();
        }
        public IActionResult AddCategoryDetail()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategoryDetail(CategoryDetail categoryDetail)
        {
            var category = _appDbContext.Categories.Where(cat => cat.CategoryName == categoryDetail.Category.CategoryName).First();
            categoryDetail.Category = category;
            _appDbContext.CategoriesDetail.Add(categoryDetail);
            _appDbContext.SaveChanges();
            return View();
        }
        public IActionResult GetProduct()
        {
            HttpContext.
            var list = _appDbContext.Products.Include("Category").Include(nameof(Category) + "." + nameof(CategoryDetail)).Include("Companies").ToList();
            return View(list);
        }

    }
}