using BackendRentCar2._0.Models;

namespace BackendRentCar2._0.Services.Contrato
{
    public interface IMarcasRepository
    {
        Task<List<Marcass>> GetMarcas();
        Task<Marcass> GetMarcaID(int id);
        Task DeleteMarca(Marcass marcass);
        Task<Marcass> AddMarca(Marcass marcass);
        Task UpdateMarca(Marcass marcass);
    }
}
