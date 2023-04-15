using BackendRentCar2._0.Models;

namespace BackendRentCar2._0.Services.Contrato
{
    public interface IVehiculosRepository
    {
        Task<List<Vehiculo>> GetVehiculos();
        Task<Vehiculo> GetVehiculoID(int id);
        Task DeleteVehiculo(Vehiculo vehiculo);
        Task<Vehiculo> AddVehiculo(Vehiculo vehiculo);
        Task UpdateVehiculo(Vehiculo vehiculo);
    }
}
