using AspTest.Models;
using AspTest.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspTest.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public JsonFileProductService ProductService;
        public IEnumerable<Product> Products { get; private set; }

        //Logging is a service made available by ASP.NET
        //If I want to log to Firewall or Azure, I dont make a logger, I ask for one
        public IndexModel(ILogger<IndexModel> logger,
                          JsonFileProductService productService)
        {

            _logger = logger;
            ProductService = productService;
        }

        public void OnGet()
        {
            Products = ProductService.GetProducts();

        }
    }
}