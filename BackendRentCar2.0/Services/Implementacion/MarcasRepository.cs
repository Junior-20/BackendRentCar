using BackendRentCar2._0.Models;
using BackendRentCar2._0.Services.Contrato;
using Microsoft.EntityFrameworkCore;

namespace BackendRentCar2._0.Services.Implementacion
{
    public class MarcasRepository : IMarcasRepository
    {
        private readonly RENTACARContext _context;
        public MarcasRepository(RENTACARContext context)
        {
            _context = context;
        }
        public async Task<Marcass> AddMarca(Marcass marcass)
        {
            try
            {
                _context.Add(marcass);
                await _context.SaveChangesAsync();
                return marcass;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task DeleteMarca(Marcass marcass)
        {
            try
            {
                _context.Marcasses.Remove(marcass);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Marcass> GetMarcaID(int id)
        {
            try
            {
                return await _context.Marcasses.FindAsync(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public  async Task<List<Marcass>> GetMarcas()
        {
            try
            {
                return await _context.Marcasses.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public  async Task UpdateMarca(Marcass marcass)
        {
            try
            {
                var Marcasitems = await _context.Marcasses.FindAsync(marcass.IdMarca);


                if (Marcasitems == null)
                {
                    throw new ArgumentException($"No existe un tipo de vehículo con el ID {marcass.IdMarca}");
                }

                Marcasitems.Descripcion = marcass.Descripcion;
                Marcasitems.Estado = marcass.Estado;

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
