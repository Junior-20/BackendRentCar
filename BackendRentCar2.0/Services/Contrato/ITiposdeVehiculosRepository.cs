using BackendRentCar2._0.Models;

namespace BackendRentCar2._0.Services.Contrato
{
    public interface ITiposdeVehiculosRepository
    {
        Task<List<TiposdeVehiculo>> GetVehiculos();
        Task<TiposdeVehiculo> GetVehiculoID(int id);
        Task DeleteVehiculo(TiposdeVehiculo tiposdeVehiculo);
        Task<TiposdeVehiculo> AddVehiculo(TiposdeVehiculo tiposdeVehiculo);
        Task UpdateVehiculo(TiposdeVehiculo tiposdeVehiculo);
    }
}
