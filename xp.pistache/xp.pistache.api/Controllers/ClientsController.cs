using MediatR;
using Microsoft.AspNetCore.Mvc;
using xp.pistache.core.Application.Clients.CreateClients;
using xp.pistache.core.Application.Clients.GetClients;
using xp.pistache.core.Application.Products.GetProductByID;
using xp.pistache.core.Domain.DTOs.Client;

namespace xp.pistache.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly ISender _sender;

        public ClientsController(ISender sender)
        {
            _sender = sender;
        }


        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var clients = await _sender.Send(new GetClientsQuery());

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
        public async Task<ActionResult> Post(RequestCreateClientDTO client)
        {
            var command = new CreateClientCommand(client.ClientId, client.Name, client.Email);

            var clientID = await _sender.Send(command);

            return Created();
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Client>>> GetClients()
        //{
        //    return await _context.Clients.ToListAsync();
        //}

        //[HttpGet("{id}")]
        //public async Task<ActionResult<Client>> GetClient(int id)
        //{
        //    var client = await _context.Clients.FindAsync(id);

        //    if (client == null)
        //    {
        //        return NotFound();
        //    }

        //    return client;
        //}

        //[HttpPost]
        //public async Task<ActionResult<Client>> PostClient(Client client)
        //{
        //    _context.Clients.Add(client);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetClient", new { id = client.ClientId }, client);
        //}

        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutClient(int id, Client client)
        //{
        //    if (id != client.ClientId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(client).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!_context.Clients.Any(e => e.ClientId == id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteClient(int id)
        //{
        //    var client = await _context.Clients.FindAsync(id);
        //    if (client == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Clients.Remove(client);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}
    }
}
