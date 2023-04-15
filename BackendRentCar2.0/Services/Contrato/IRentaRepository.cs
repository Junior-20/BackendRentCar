using BackendRentCar2._0.Models;

namespace BackendRentCar2._0.Services.Contrato
{
    public interface IRentaRepository
    {
        Task<List<Rentum>> GetRentas();
        Task<Rentum> GetRentaID(int id);
        Task DeleteRenta(Rentum rentum);
        Task<Rentum> AddRenta(Rentum rentum);
        Task UpdateRenta(Rentum rentum);
    }
}
