using BackendRentCar2._0.Models;

namespace BackendRentCar2._0.Services.Contrato
{
    public interface IInspeccionRepository
    {
        Task<List<Inspeccion>> GetInspecciones();
        Task<Inspeccion> GetInspeccionID(int id);
        Task DeleteInspeccion(Inspeccion inspeccion);
        Task<Inspeccion> AddInspeccion(Inspeccion inspeccion);
        Task UpdateInspeccion(Inspeccion inspeccion);
    }
}
