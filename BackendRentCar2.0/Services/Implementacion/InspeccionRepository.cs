using BackendRentCar2._0.Models;
using BackendRentCar2._0.Services.Contrato;
using Microsoft.EntityFrameworkCore;

namespace BackendRentCar2._0.Services.Implementacion
{
    public class InspeccionRepository : IInspeccionRepository
    {
        private readonly RENTACARContext _context;

        public InspeccionRepository(RENTACARContext context)
        {
            _context = context;
        }

        public async Task<Inspeccion> AddInspeccion(Inspeccion inspeccion)
        {
            try
            {
                _context.Add(inspeccion);
                GetClientes();
                GetEmpleados();
                GetVehiculos();
                await _context.SaveChangesAsync();
                return inspeccion;
            }
            catch (Exception ex)
            {

                throw new Exception("No se pudo agregar la inspeccion", ex);
            }
        }
        public async Task DeleteInspeccion(Inspeccion inspeccion)
        {
            try
            {
                _context.Inspeccions.Remove(inspeccion);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("No se pudo Eliminar  la inspeccion.", ex);
            }
        }

        public async Task<List<Inspeccion>> GetInspecciones()
        {
            try
            {
                var inspeccion = await _context.Inspeccions.Include(v => v.EmpleadoInspeccionNavigation)
                                           .Include(v => v.IdClienteNavigation)
                                           .Include(v => v.VehiculoNavigation)
                                            .ThenInclude(m => m.ModeloNavigation).ToListAsync();

                return inspeccion;

            }
            catch (Exception ex)
            {

                throw new Exception("No se puede mostrar la lista de inspecciones ", ex);
            }
        }

        public async Task<Inspeccion> GetInspeccionID(int id)
        {
            try
            {
                Inspeccion? encontrado = new Inspeccion();
                encontrado = await _context.Inspeccions.Include(v => v.EmpleadoInspeccionNavigation)
                                           .Include(v => v.IdClienteNavigation)
                                           .Include(v => v.VehiculoNavigation)
                                           .FirstOrDefaultAsync();
                return encontrado;
            }
            catch (Exception ex)
            {

                throw new Exception("No se pudo Obtener la inspeccion ", ex);
            }
        }

        public async Task UpdateInspeccion(Inspeccion inspeccion)
        {
            try
            {
                var Inspeccionitems = await _context.Inspeccions.FindAsync(inspeccion.IdTransaccion);

                if (Inspeccionitems == null)
                {
                    throw new ArgumentException($"No existe la inspeccion con el ID {inspeccion.IdTransaccion}");
                }
                Inspeccionitems.Vehiculo = inspeccion.Vehiculo;
                Inspeccionitems.IdCliente = inspeccion.IdCliente;
                Inspeccionitems.TieneRalladuras = inspeccion.TieneRalladuras;
                Inspeccionitems.CantidadCombustible = inspeccion.CantidadCombustible;
                Inspeccionitems.GomaRespuesta = inspeccion.GomaRespuesta;
                Inspeccionitems.Gato = inspeccion.Gato;
                Inspeccionitems.Roturas = inspeccion.Roturas;
                Inspeccionitems.EstadoGomas = inspeccion.EstadoGomas;
                Inspeccionitems.Fecha = inspeccion.Fecha;
                Inspeccionitems.EmpleadoInspeccion = inspeccion.EmpleadoInspeccion;
                Inspeccionitems.Estado = inspeccion.Estado;


                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("No se pudo Obtener la inspeccion a la base de datos.", ex);
            }
        }
        private List<Cliente> GetClientes()
        {
            return _context.Clientes.ToList();
        }
        private List<Vehiculo> GetVehiculos()
        {
            return _context.Vehiculos.ToList();
        }
        private List<Empleado> GetEmpleados()
        {
            return _context.Empleados.ToList();
        }
    }
}
