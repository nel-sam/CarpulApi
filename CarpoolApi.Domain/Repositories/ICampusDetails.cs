using CarpoolApi.Domain.Models;

namespace CarpoolApi.Domain.Repositories
{
    public interface ICampusDetails
    {
        Campus Get(string name);
        void Add(Campus address);
    }
}
