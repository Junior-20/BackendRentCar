using BackendRentCar2._0.Models;
using BackendRentCar2._0.Services.Contrato;
using Microsoft.EntityFrameworkCore;

namespace BackendRentCar2._0.Services.Implementacion
{
    public class ClientesRepository : IClientesRepository
    {
        private readonly RENTACARContext _context;
        public ClientesRepository(RENTACARContext context)
        {
            _context = context;
        }

        public async Task<Cliente> AddCliente(Cliente cliente)
        {
            try
            {
                _context.Clientes.Add(cliente);
                await _context.SaveChangesAsync();
                return cliente;
            }
            catch (Exception ex)
            {

                throw new Exception("No se pudo agregar el Cliente.", ex);
            }
        }

        public async Task DeleteCliente(Cliente cliente)
        {
            try
            {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("No se pudo Eliminar  el cliente a la base de datos.", ex);
            }
        }

        public async Task<Cliente> GetClienteID(int id)
        {
            try
            {
                return await _context.Clientes.FindAsync(id);
            }
            catch (Exception ex)
            {

                throw new Exception("No se pudo encontrar el Cliente a la base de datos.", ex);
            }

        }

        public async Task<List<Cliente>> GetClientes()
        {
            try
            {
                return await _context.Clientes.ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("No se pudo Obtener los Clientes", ex);
            }
        }

        public async Task UpdateCliente(Cliente cliente)
        {
            try
            {
                var Clienteitems = await _context.Clientes.FindAsync(cliente.IdCliente);

                if (Clienteitems == null)
                {
                    throw new ArgumentException($"No existe el cliente con el ID {cliente.IdCliente}");
                }

                Clienteitems.Nombre = cliente.Nombre;
                Clienteitems.Cedula = cliente.Cedula;
                Clienteitems.TipoPersona = cliente.TipoPersona;
                Clienteitems.NoTarjetaCr = cliente.NoTarjetaCr;
                Clienteitems.LimiteCredito = cliente.LimiteCredito;
                Clienteitems.Estado = cliente.Estado;
               


                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("No se pudo Obtener el cliente", ex);
            }
        }
    }
}
