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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public ActionResult<IEnumerable<ProductDTO>> GetProducts()
        {
            return Ok(ProductStore.productList);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id:int}", Name = "GetProduct")]
        public ActionResult<ProductDTO> GetProduct(int id)
        {
            if (id == 0) return BadRequest();

            var product = ProductStore.productList.FirstOrDefault(u => u.Id == id);

            if (product == null) return NotFound();

            return Ok(product);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public ActionResult<ProductDTO> CreateProduct([FromBody] ProductDTO product)
        {
            /*if (!ModelState.IsValid) return BadRequest();*/

            if (product == null) return BadRequest();

            if (product.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            product.Id = ProductStore.productList.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;

            ProductStore.productList.Add(product);

            return CreatedAtRoute("GetProduct", new { id = product.Id }, product);
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
            var product = ProductStore.productList.FirstOrDefault(u => u.Id == id);

            if (product == null) return NotFound();

            ProductStore.productList.Remove(product);

            return NoContent();
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id:int}", Name = "UpdateProduct")]
        public IActionResult UpdateProduct(int id, [FromBody]ProductDTO productDTO)
        {
            if (productDTO == null || id != productDTO.Id) return BadRequest();
            
            var product = ProductStore.productList.FirstOrDefault(u => u.Id == id);

            product.Name = productDTO.Name;
            product.Description = productDTO.Description;
            product.ImageURL = productDTO.ImageURL;
            product.Price = productDTO.Price;

            return Ok(product);
        }
    }
}
