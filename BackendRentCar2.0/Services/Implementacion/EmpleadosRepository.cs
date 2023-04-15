using BackendRentCar2._0.Models;
using BackendRentCar2._0.Services.Contrato;
using Microsoft.EntityFrameworkCore;

namespace BackendRentCar2._0.Services.Implementacion
{
    public class EmpleadosRepository : IEmpleadosRepository
    {
        private readonly RENTACARContext _context;
        public EmpleadosRepository(RENTACARContext context)
        {
            _context = context;
        }
        public async Task<Empleado> AddEmpleado(Empleado empleado)
        {
            try
            {
                _context.Empleados.Add(empleado);
                await _context.SaveChangesAsync();
                return empleado;
            }
            catch (Exception ex)
            {

                throw new Exception("No se pudo agregar el empleado", ex);
            }
        }

        public async Task DeleteEmpleado(Empleado empleado)
        {
            try
            {
                _context.Empleados.Remove(empleado);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("No se pudo Eliminar  el Empleado", ex);
            }
        }

        public async Task<Empleado> GetEmpleadoID(int id)
        {
            try
            {
                return await _context.Empleados.FindAsync(id);
            }
            catch (Exception ex)
            {

                throw new Exception("No se pudo encontrar el Empleado", ex);
            }

        }

        public async Task<List<Empleado>> GetEmpleados()
        {
            try
            {
                return await _context.Empleados.ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("No se pudo Obtener los Empleados", ex);
            }
        }

        public async Task UpdateEmpleado(Empleado empleado)
        {
            try
            {
                var Empleadoitems = await _context.Empleados.FindAsync(empleado.IdEmpleado);

                if (Empleadoitems == null)
                {
                    throw new ArgumentException($"No existe el empleado con el ID {empleado.IdEmpleado}");
                }

                Empleadoitems.Nombre = empleado.Nombre;
                Empleadoitems.Cedula = empleado.Cedula;
                Empleadoitems.TandaLabor= empleado.TandaLabor;
                Empleadoitems.PorcientoComision = empleado.PorcientoComision;
                Empleadoitems.FechaIngreso = empleado.FechaIngreso;
                Empleadoitems.Estado = empleado.Estado;
               
              
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("No se pudo Obtener el empledo", ex);
            }
        }
    }
}
