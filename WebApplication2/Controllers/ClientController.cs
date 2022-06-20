using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication2.Model;
using WebApplication2.Repositores;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClient _clientRepository;
        public ClientController(IClient clientRepository)
        {
            _clientRepository = clientRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<Client>> GetClient()
        {
            return await _clientRepository.Get();
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<Client>> GetClient(int Id)
        {
            return await _clientRepository.Get(Id);
        }

        [HttpPost]
        public async Task<ActionResult<Client>> PostClient(int Id, [FromBody] Client client)
        {
            var newClient = await _clientRepository.Create(client);
            return CreatedAtAction(nameof(GetClient), new { Id = newClient.Id }, newClient);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<Client>> Delete(int Id)
        {
            var clientToDelete = await _clientRepository.Get(Id);

            if (clientToDelete == null)
                return NotFound();

            await _clientRepository.Delete(clientToDelete.Id);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult<Client>> PutClient(int Id, [FromBody] Client client)
        {
            if (Id == client.Id)
                return BadRequest();

            await _clientRepository.Update(client);
            return NoContent();
        }
    }
}