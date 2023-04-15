using BackendRentCar2._0.Models;

namespace BackendRentCar2._0.Services.Contrato
{
    public interface IEmpleadosRepository
    {
        Task<List<Empleado>> GetEmpleados();
        Task<Empleado> GetEmpleadoID(int id);
        Task DeleteEmpleado(Empleado empleado);
        Task<Empleado> AddEmpleado(Empleado empleado);
        Task UpdateEmpleado(Empleado empleado);
    }
}
