using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Data;
using ProductsAPI.Models;
using ProductsAPI.Models.Dto;

namespace ProductsAPI.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductAPIController : ControllerBase
    {
        public ApplicationDbContext _db { get; }
        public ILogger<ProductAPIController> _logger { get; }

        public ProductAPIController(ApplicationDbContext db,ILogger<ProductAPIController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public ActionResult<IEnumerable<ProductDTO>> GetProducts()
        {
            /*_logger.LogInformation("Getting Products");*/
            return Ok(_db.Products);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id:int}", Name = "GetProduct")]
        public ActionResult<ProductDTO> GetProduct(int id)
        {
            if (id == 0) {
                /*_logger.LogError("Get Product Erro with Id" + id);*/
            return BadRequest();
            } 

            var product = _db.Products.FirstOrDefault(u => u.Id == id);

            if (product == null) return NotFound();

            return Ok(product);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<ProductDTO> CreateProduct([FromBody] ProductDTO productDTO)
        {

            if (productDTO == null) return BadRequest();

            Product model = new()
            {
                Name = productDTO.Name,
                Description = productDTO.Description,
                ImageURL = productDTO.ImageURL,
                Price = productDTO.Price,
                CreatedAt = DateTime.Now,
            };

            _db.Products.Add(model);
            _db.SaveChanges();

            return CreatedAtRoute("GetProduct", new { id = model.Id }, model);
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}", Name = "DeleteProduct")]
        public IActionResult DeleteProduct(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var product = _db.Products.FirstOrDefault(u => u.Id == id);

            if(product == null) {
                return NotFound();
            }

            _db.Products.Remove(product);
            _db.SaveChanges();
            return NoContent();
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id:int}", Name = "UpdateProduct")]
        public IActionResult UpdateProduct(int id, [FromBody]ProductDTO productDTO)
        {
            if (productDTO == null) return BadRequest();

            var existingProduct = _db.Products.FirstOrDefault(u => u.Id == id);

            if (existingProduct == null) return NotFound();

            existingProduct.Name = productDTO.Name;
            existingProduct.Description = productDTO.Description;
            existingProduct.ImageURL = productDTO.ImageURL;
            existingProduct.Price = productDTO.Price;

            _db.SaveChanges();
            return Ok(existingProduct);
        }

    }
}
