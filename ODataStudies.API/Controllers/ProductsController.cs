using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using ODataStudies.API.Models;

namespace ODataStudies.API.Controllers
{
    public class ProductsController : ODataController
    {

        private readonly AppDbContext _appDb;

        public ProductsController(AppDbContext appDb)
        {
            _appDb = appDb;
        }

        [HttpGet]
        [EnableQuery]
        public IActionResult GetProducts()
        {
            return Ok(_appDb.products);
        }
    }
}
