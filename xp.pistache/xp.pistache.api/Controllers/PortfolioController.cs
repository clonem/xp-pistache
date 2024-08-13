using MediatR;
using Microsoft.AspNetCore.Mvc;
using xp.pistache.core.Application.Portfolio.BuyProduct;
using xp.pistache.core.Application.Portfolio.GetClientProducts;
using xp.pistache.core.Application.Portfolio.GetPurchaseHistory;
using xp.pistache.core.Application.Portfolio.SellProduct;
using xp.pistache.core.Domain.DTOs.Portfolio;

namespace xp.pistache.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        private readonly ISender _sender;

        public PortfolioController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet()]
        public async Task<ActionResult> GetClientProducts(int clientId)
        {
            var query = new GetClientProductsQuery(clientId);

            var clients = await _sender.Send(query);

            return Ok(clients);
        }

        [HttpGet("PurchaseHistory")]
        public async Task<ActionResult> GetPurchaseHistory(int clientId)
        {
            var query = new GetPurchaseHistoryQuery(clientId);

            var clients = await _sender.Send(query);

            return Ok(clients);
        }

        [HttpPost("BuyProduct")]
        public async Task<ActionResult> PostBuyProduct(RequestBuyProductDTO buyProduct)
        {
            var command = new BuyProductCommand(buyProduct.ClientID, buyProduct.ProductID, buyProduct.ProductName, buyProduct.ProductPrice, buyProduct.ProductQuantity);

            var clientID = await _sender.Send(command);

            return Created();
        }

        [HttpPost("SellProduct")]
        public async Task<ActionResult> PostellProduct(RequestBuyProductDTO buyProduct)
        {
            var command = new SellProductCommand(buyProduct.ClientID, buyProduct.ProductID, buyProduct.ProductName, buyProduct.ProductPrice, buyProduct.ProductQuantity);

            var clientID = await _sender.Send(command);

            return Created();
        }
    }
}
