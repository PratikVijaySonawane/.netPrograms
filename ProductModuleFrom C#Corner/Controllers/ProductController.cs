using Microsoft.AspNetCore.Mvc;
using ProductModuleFrom_C_Corner.Data;
using ProductModuleFrom_C_Corner.Model;

namespace ProductModuleFrom_C_Corner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly MyAppDbContext _Context;
        public ProductController(MyAppDbContext context)
        {
            _Context = context;

        }

        /* Creating the GetProduct() to get all the Products from the database  Method */
        public IActionResult GetProducts()
        {
            var products = _Context.Products.ToList();
            return Ok(products);
        }

        /* Creating the IAction Method to add the Products from the Api side */
        public IActionResult AddTheProducts(Products p1)
        {
            var product = new Products()
            {
                ProductName = p1.ProductName,
                Price = p1.Price,
                Qty = p1.Qty
            };

            /* Add the Method to add the data in the database */
            _Context.Products.Add(product);
            _Context.SaveChanges();

            return Ok(product);
        }
    }
}
