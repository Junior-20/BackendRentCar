using BackendRentCar2._0.Models;

namespace BackendRentCar2._0.Services.Contrato
{
    public interface ITiposdeCombustiblesRepository
    {
        Task<List<TiposdeCombustible>> GetCombustibles();
        Task<TiposdeCombustible> GetCombustibleID(int id);
        Task DeleteCombustible(TiposdeCombustible tiposdeCombustible);
        Task<TiposdeCombustible> AddCombustible(TiposdeCombustible tiposdeCombustible);
        Task UpdateCombustible(TiposdeCombustible tiposdeCombustible);
    }
}
