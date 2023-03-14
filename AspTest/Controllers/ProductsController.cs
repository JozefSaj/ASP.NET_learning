using AspTest.Models;
using AspTest.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspTest.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public ProductsController(JsonFileProductService productService)
        {
            this.ProductService = productService;
        }

        public JsonFileProductService ProductService { get; }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return ProductService.GetProducts();
        }
        //HttpPut updates the database, HttpPost to make new thing in databse
        [HttpGet]
        [Route("Rate")]
        [HttpGet]
        //example~~~https://localhost:7197/products/rate/?productId=jenlooper-cactus&rating=5
        public ActionResult Get([FromQuery]string productId, int rating)
        {
            ProductService.AddRating(productId, rating);
            return Ok();
        }
    }
}
