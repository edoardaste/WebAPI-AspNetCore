using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication2.Model;

namespace WebApplication2.Repositores
{
    public class ClientRepository : IClient
    {
        public readonly ClientContext _context;

        public ClientRepository (ClientContext context)
        {
            _context = context;
        }

        public async Task<Client> Create(Client client)
        {
            _context.Add(client);
            await _context.SaveChangesAsync();

            return client;
        }

        public async Task Delete(int Id)
        {
            var clientDelete = await _context.Clients.FindAsync(Id);
            _context.Clients.Remove(clientDelete);
            await _context.SaveChangesAsync();
           
        }

        public async Task<IEnumerable<Client>> Get()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<Client> Get(int Id)
        {
            return await _context.Clients.FindAsync(Id);
        }

        public async Task Update(Client client)
        {
            _context.Entry(client).State = EntityState.Modified;
            await _context.SaveChangesAsync();  
        }
    }
}
