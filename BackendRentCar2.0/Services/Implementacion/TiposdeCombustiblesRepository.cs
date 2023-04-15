using BackendRentCar2._0.Models;
using BackendRentCar2._0.Services.Contrato;
using Microsoft.EntityFrameworkCore;

namespace BackendRentCar2._0.Services.Implementacion
{
    public class TiposdeCombustiblesRepository : ITiposdeCombustiblesRepository
    {
        private readonly RENTACARContext _context;
        public TiposdeCombustiblesRepository(RENTACARContext context)
        {
            _context = context;
        }
        public  async Task<TiposdeCombustible> AddCombustible(TiposdeCombustible tiposdeCombustible)
        {
            try
            {
                _context.TiposdeCombustibles.Add(tiposdeCombustible);
                await _context.SaveChangesAsync();
                return tiposdeCombustible;
            }
            catch (Exception ex)
            {

                throw new Exception("No se pudo agregar el Tipo de Combustible.", ex);
            }
        }

        public async Task DeleteCombustible(TiposdeCombustible tiposdeCombustible)
        {
            try
            {
                _context.TiposdeCombustibles.Remove(tiposdeCombustible);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("No se pudo borrar el Tipo de Combustible.", ex);
            }
        }

        public async Task<TiposdeCombustible> GetCombustibleID(int id)
        {
            try
            {
                return await _context.TiposdeCombustibles.FindAsync(id);
            }
            catch (Exception ex)
            {

                throw new Exception("No se pudo Encontrar el Tipo de Combustible.", ex);
            }
        }

        public async Task<List<TiposdeCombustible>> GetCombustibles()
        {
            try
            {
                return await _context.TiposdeCombustibles.ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("No se pudo listar el Tipo de Combustible.", ex);
            }
        }

        public async Task UpdateCombustible(TiposdeCombustible tiposdeCombustible)
        {
            try
            {
                var Combustibleitems = await _context.TiposdeCombustibles.FindAsync(tiposdeCombustible.IdTiposCombustible);


                if (Combustibleitems == null)
                {
                    throw new ArgumentException($"No existe un tipo de Combustible con el ID {tiposdeCombustible.IdTiposCombustible}");
                }

                Combustibleitems.Descripcion = tiposdeCombustible.Descripcion;
                Combustibleitems.Estado = tiposdeCombustible.Estado;


                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("No se puede Actualizar Combustible con el ID.", ex);
            }
        }
    }
}
