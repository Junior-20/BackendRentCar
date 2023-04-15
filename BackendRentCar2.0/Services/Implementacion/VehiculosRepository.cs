using BackendRentCar2._0.Models;
using BackendRentCar2._0.Services.Contrato;
using Microsoft.EntityFrameworkCore;

namespace BackendRentCar2._0.Services.Implementacion
{
    public class VehiculosRepository : IVehiculosRepository
    {
        private readonly RENTACARContext _context;
        public VehiculosRepository(RENTACARContext context)
        {
            _context = context;
        }
        public async Task<Vehiculo> AddVehiculo(Vehiculo vehiculo)
        {
            try
            {
                _context.Add(vehiculo);
                await _context.SaveChangesAsync();
                GetMarcas();
                GetModelo();
                GetTipodeCombustible();
                GetTipoVehiculo();
                return vehiculo;
            }
            catch (Exception ex)
            {

                throw new Exception("No se pudo agregar el vehiculo.", ex);
            }
        }


        public async Task DeleteVehiculo(Vehiculo vehiculo)
        {
            try
            {
                _context.Vehiculos.Remove(vehiculo);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("No se pudo Eliminar  el vehiculo.", ex);
            }
        }

        public async Task<Vehiculo> GetVehiculoID(int id)
        {
            try
            {
                Vehiculo? encontrado = new Vehiculo();
                encontrado = await _context.Vehiculos.Include(v => v.MarcaNavigation)
                                                     .Include(v => v.TipoVehiculoNavigation)
                                                     .Include(v => v.ModeloNavigation)
                                                     .Include(v => v.TipoCombustibleNavigation)
                                                     .Where(e => e.IdVehiculos == id)
                                                     .FirstOrDefaultAsync();
                return encontrado;
            }
            catch (Exception ex)
            {

                throw new Exception("No se pudo Obtener el Vehiculo ", ex);
            }
        }

        public async Task<List<Vehiculo>> GetVehiculos()
        {
            try
            {
                var vehiculos = await _context.Vehiculos.Include(v => v.MarcaNavigation)
                                           .Include(v => v.TipoVehiculoNavigation)
                                           .Include(v => v.ModeloNavigation)
                                           .Include(v => v.TipoCombustibleNavigation)
                                           .ToListAsync();

                return vehiculos;

            }
            catch (Exception ex)
            {

                throw new Exception("No se pudo la lista de Vehiculo ", ex);
            }
        }

        

        public async Task UpdateVehiculo(Vehiculo vehiculo)
        {
            try
            {
                var Vehiculoitems = await _context.Vehiculos.FindAsync(vehiculo.IdVehiculos);

                if (Vehiculoitems == null)
                {
                    throw new ArgumentException($"No existe el Vehiculo con el ID {vehiculo.IdVehiculos}");
                }

                Vehiculoitems.Descripcion = vehiculo.Descripcion;
                Vehiculoitems.NoChasis = vehiculo.NoChasis;
                Vehiculoitems.NoMotor = vehiculo.NoMotor;
                Vehiculoitems.NoPlaca = vehiculo.NoPlaca;
                Vehiculoitems.TipoVehiculo = vehiculo.TipoVehiculo;
                Vehiculoitems.Marca = vehiculo.Marca;
                Vehiculoitems.Modelo = vehiculo.Modelo;
                Vehiculoitems.TipoCombustible = vehiculo.TipoCombustible;
                Vehiculoitems.Estado = vehiculo.Estado;
                


                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("No se pudo Obtener el modelo a la base de datos.", ex);
            }
        }
        private List<Marcass> GetMarcas()
        {
            return _context.Marcasses.ToList();
        }
        private List<TiposdeVehiculo> GetTipoVehiculo()
        {
            return _context.TiposdeVehiculos.ToList();
        }
        private List<Modelo> GetModelo()
        {
            return _context.Modelos.ToList();
        }
        private List<TiposdeCombustible> GetTipodeCombustible()
        {
            return _context.TiposdeCombustibles.ToList();
        }
    }
    }

