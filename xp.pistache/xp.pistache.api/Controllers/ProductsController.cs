using MediatR;
using Microsoft.AspNetCore.Mvc;
using xp.pistache.core.Application.Products.CreateProducts;
using xp.pistache.core.Application.Products.GetProductByID;
using xp.pistache.core.Application.Products.GetProducts;
using xp.pistache.core.Application.Products.UpdateProduct;
using xp.pistache.core.Application.Products.UpdateStatusProduct;
using xp.pistache.core.Domain.DTOs.Products;

namespace xp.pistache.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ISender _sender;

        public ProductsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var clients = await _sender.Send(new GetProductsQuery());

            return Ok(clients);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetByID(int id)
        {
            var client = await _sender.Send(new GetProductByIDQuery(id));

            if (client is null)
                return NotFound();

            return Ok(client);
        }

        [HttpPost]
        public async Task<ActionResult> Post(RequestCreateProductDTO product)
        {
            var command = new CreateProductsCommand(product.ProductID, product.Name, product.Description, product.Price, product.Status);

            var productId = await _sender.Send(command);

            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, RequestUpdateProductDTO product)
        {
            var command = new UpdateProductCommand(id, product.Name, product.Description, product.Price, product.Status);

            var productId = await _sender.Send(command);

            if (productId == 0)
                return NotFound();

            return Created();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new UpdateStatusProductCommand(id, ProductStatusEnum.DISABLE);

            var affectd = await _sender.Send(command);

            if (affectd == 0)
                return NotFound();

            return NoContent();
        }
    }
}
