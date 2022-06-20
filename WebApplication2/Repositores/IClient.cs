
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication2.Model;

namespace WebApplication2.Repositores
{
    public interface IClient
    {
        Task<IEnumerable<Client>> Get();

        Task<Client> Get(int Id);
        Task<Client> Create(Client client);
        Task Update(Client client);
        Task Delete(int Id);

    }
}
