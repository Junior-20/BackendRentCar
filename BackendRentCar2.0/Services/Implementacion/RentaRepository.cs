using BackendRentCar2._0.Models;
using BackendRentCar2._0.Services.Contrato;
using Microsoft.EntityFrameworkCore;

namespace BackendRentCar2._0.Services.Implementacion
{
    public class RentaRepository : IRentaRepository
    {
        private readonly RENTACARContext _context;
        public RentaRepository(RENTACARContext context)
        {
            _context = context;
        }
        public async Task<Rentum> AddRenta(Rentum rentum)
        {
            try
            {
                _context.Add(rentum);
                await _context.SaveChangesAsync();
                Vehiculo vh = await _context.Vehiculos.FindAsync(rentum.Vehiculo);
                vh.Estado = "Rentado";
                await _context.SaveChangesAsync();
                GetCliente();
                GetDoc();
                GetEmpleado();
                GetVehiculo();
                return rentum;
            }
            catch (Exception ex)
            {

                throw new Exception("No se pudo agregar la renta", ex);
            }
        }

        public async Task DeleteRenta(Rentum rentum)
        {
            try
            {
                _context.Renta.Remove(rentum);
                Vehiculo vh = await _context.Vehiculos.FindAsync(rentum.Vehiculo);
                vh.Estado = "Disponible";
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("No se pudo Eliminar  la Renta.", ex);
            }
        }

        public async Task<Rentum> GetRentaID(int id)
        {
            try
            {
                Rentum? encontrado = new Rentum();
                encontrado = await _context.Renta.Include(v => v.DocGarantiaNavigation)
                                           .Include(v => v.ClienteNavigation)
                                           .Include(v => v.EmpleadoNavigation)
                                           .Include(v => v.VehiculoNavigation)
                                           .FirstOrDefaultAsync();
                return encontrado;
            }
            catch (Exception ex)
            {

                throw new Exception("No se pudo Obtener la renta ", ex);
            }
        }

        public async Task<List<Rentum>> GetRentas()
        {

            try
            {
                var rentas = await _context.Renta.Include(v => v.DocGarantiaNavigation)
                                           .Include(v => v.ClienteNavigation)
                                           .Include(v => v.EmpleadoNavigation)
                                           .Include(v => v.VehiculoNavigation)
                                            .ThenInclude(m => m.ModeloNavigation) // Inclusión de la propiedad de navegación de "Modelo" en "Vehiculo"
            .ToListAsync();

                return rentas;

            }
            catch (Exception ex)
            {

                throw new Exception("No se puede mostrar la lista de rentas ", ex);
            }
        }

        public async Task UpdateRenta(Rentum rentum)
        {
            try
            {
                var Rentaitems = await _context.Renta.FindAsync(rentum.IdRenta);

                if (Rentaitems == null)
                {
                    throw new ArgumentException($"No existe la renta con el ID {rentum.IdRenta}");
                }

                Rentaitems.DocGarantia = rentum.DocGarantia;
                Rentaitems.Empleado = rentum.Empleado;
                Rentaitems.Vehiculo = rentum.Vehiculo;
                Rentaitems.Cliente = rentum.Cliente;
                Rentaitems.FechaRenta = rentum.FechaRenta;
                Rentaitems.FechaDevolucion = rentum.FechaDevolucion;
                Rentaitems.MontoxDia = rentum.MontoxDia;
                Rentaitems.CantidadDias = rentum.CantidadDias;
                Rentaitems.Abono = rentum.Abono;
                Rentaitems.Comentario = rentum.Comentario;
                Rentaitems.Estado = rentum.Estado;


                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("No se pudo Obtener la renta .", ex);
            }
        }
        private List<Documento> GetDoc()
        {
            return _context.Documentos.ToList();
        }
        private List<Empleado> GetEmpleado()
        {
            return _context.Empleados.ToList();
        }
        private List<Cliente> GetCliente()
        {
            return _context.Clientes.ToList();
        }
        private List<Vehiculo> GetVehiculo()
        {
            return _context.Vehiculos.ToList();
        }
    }
}
