using BackendRentCar2._0.Models;
using BackendRentCar2._0.Services.Contrato;
using Microsoft.EntityFrameworkCore;

namespace BackendRentCar2._0.Services.Implementacion
{
    public class ModelosRepository : IModelosRepository
    {
        private readonly RENTACARContext _context;
        public ModelosRepository(RENTACARContext context)
        {
            _context = context;
        }
        public async Task<Modelo> AddModelo(Modelo modelo)
        {
            try
            {
                _context.Modelos.Add(modelo);
                await _context.SaveChangesAsync();
                GetMarcas();
                return modelo;
            }
            catch (Exception ex)
            {

                throw new Exception("No se pudo agregar el modelo a la base de datos.", ex);
            }
        }

        public async Task DeleteModelo(Modelo modelo)
        {
            try
            {
                _context.Modelos.Remove(modelo);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("No se pudo Eliminar  el modelo a la base de datos.", ex);
            }
        }

        public async Task<List<Modelo>> GetModelo()
        {
            try
            {
                return await _context.Modelos.Include(mar => mar.IdMarcaNavigation)
                                             .ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("No se pudo Obtener los modelos a la base de datos.", ex);
            }
        }

        public async Task<Modelo> GetModeloID(int id)
        {
            try
            {
                Modelo? encontrado = new Modelo();
                encontrado = await _context.Modelos.Include(mar => mar.IdMarcaNavigation)
                                                   .Where(e => e.IdModelo == id)
                                                   .FirstOrDefaultAsync();
                return encontrado;
            }
            catch (Exception ex)
            {

                throw new Exception("No se pudo Obtener el modelo a la base de datos.", ex);
            }
        }

        public async Task UpdateModelo(Modelo modelo)
        {
            try
            {
                var Modeloitems = await _context.Modelos.FindAsync(modelo.IdModelo);

                if (Modeloitems == null)
                {
                    throw new ArgumentException($"No existe el modelo con el ID {modelo.IdModelo}");
                }

                Modeloitems.IdMarca = modelo.IdMarca;
                Modeloitems.Descripcion = modelo.Descripcion;
                Modeloitems.Estado = modelo.Estado;


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
    }
}
