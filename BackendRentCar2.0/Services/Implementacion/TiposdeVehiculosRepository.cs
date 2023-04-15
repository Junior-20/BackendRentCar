using BackendRentCar2._0.Models;
using BackendRentCar2._0.Services.Contrato;
using Microsoft.EntityFrameworkCore;

namespace BackendRentCar2._0.Services.Implementacion
{
    public class TiposdeVehiculosRepository : ITiposdeVehiculosRepository
    {
        private readonly RENTACARContext _context;
        public TiposdeVehiculosRepository(RENTACARContext context)
        {
            _context = context;
        }
        public async Task<TiposdeVehiculo> AddVehiculo(TiposdeVehiculo tiposdeVehiculo)
        {
            try
            {
                _context.TiposdeVehiculos.Add(tiposdeVehiculo);
                await _context.SaveChangesAsync();
                return tiposdeVehiculo;
            }
            catch (Exception ex)
            {

                throw new Exception("No se pudo agregar el Tipo de Vehiculo.", ex);
            }
        }

        public async Task DeleteVehiculo(TiposdeVehiculo tiposdeVehiculo)
        {
            try
            {
                _context.TiposdeVehiculos.Remove(tiposdeVehiculo);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("No se pudo Eliminar el Tipo de Vehiculo.", ex);
            }
        }

        public async Task<TiposdeVehiculo> GetVehiculoID(int id)
        {
            try
            {
                return await _context.TiposdeVehiculos.FindAsync(id);
            }
            catch (Exception ex)
            {

                throw new Exception("No se pudo Encontrar el Tipo de Vehiculo.", ex);
            }
        }

        public async Task<List<TiposdeVehiculo>> GetVehiculos()
        {
            try
            {
                return await _context.TiposdeVehiculos.ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("No se pudo Listar el Tipo de Vehiculo.", ex);
            }
        }

        public async Task UpdateVehiculo(TiposdeVehiculo tiposdeVehiculo)
        {

            try
            {
                var Vehiculositems = await _context.TiposdeVehiculos.FindAsync(tiposdeVehiculo.IdTiposVehiculo);


                if (Vehiculositems == null)
                {
                    throw new ArgumentException($"No existe un tipo de vehículo con el ID {tiposdeVehiculo.IdTiposVehiculo}");
                }

                Vehiculositems.Descripcion = tiposdeVehiculo.Descripcion;
                Vehiculositems.Estado = tiposdeVehiculo.Estado;
             

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("No se pudo Editar el Tipo de Vehiculo.", ex);
            }
        }
    }
}
