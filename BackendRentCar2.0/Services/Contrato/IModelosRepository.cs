using BackendRentCar2._0.Models;

namespace BackendRentCar2._0.Services.Contrato
{
    public interface IModelosRepository
    {
        Task<List<Modelo>> GetModelo();
        Task<Modelo> GetModeloID(int id);
        Task DeleteModelo(Modelo modelo);
        Task<Modelo> AddModelo(Modelo modelo);
        Task UpdateModelo(Modelo modelo);
    }
}
