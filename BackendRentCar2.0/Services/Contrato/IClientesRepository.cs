using BackendRentCar2._0.Models;

namespace BackendRentCar2._0.Services.Contrato
{
    public interface IClientesRepository
    {
        Task<List<Cliente>> GetClientes();
        Task<Cliente> GetClienteID(int id);
        Task DeleteCliente(Cliente cliente);
        Task<Cliente> AddCliente(Cliente cliente);
        Task UpdateCliente(Cliente cliente);
    }
}
