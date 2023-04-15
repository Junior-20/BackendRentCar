using BackendRentCar2._0.Models;
using BackendRentCar2._0.Services.Contrato;
using Microsoft.EntityFrameworkCore;

namespace BackendRentCar2._0.Services.Implementacion
{
    public class DocumentosRepository : IDocumentosRepository
    {
        private readonly RENTACARContext _context;
        public DocumentosRepository(RENTACARContext context)
        {
            _context = context;
        }
        public async Task<Documento> AddDocumento(Documento documento)
        {
            try
            {
                _context.Add(documento);
                await _context.SaveChangesAsync();
                return documento;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task DeleteDocumento(Documento documento)
        {
            try
            {
                _context.Documentos.Remove(documento);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("No se pudo Eliminar  el documento a la base de datos.", ex);
            }
        }

        public async Task<Documento> GetDocumentoID(int id)
        {
            try
            {
                return await _context.Documentos.FindAsync(id);
            }
            catch (Exception ex)
            {

                throw new Exception("No se pudo encontrar el documento a la base de datos.", ex);
            }
        }

        public async Task<List<Documento>> GetDocumentos()
        {
            try
            {
                return await _context.Documentos.ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("No se pudo Obtener los Documentos", ex);
            }
        }

        public async Task UpdateDocumento(Documento documento)
        {
            try
            {
                var Documentoitems = await _context.Documentos.FindAsync(documento.IdDocumento);

                if (Documentoitems == null)
                {
                    throw new ArgumentException($"No existe el documento con el ID {documento.IdDocumento}");
                }

                Documentoitems.Descripcion = documento.Descripcion;
                Documentoitems.Estado = documento.Estado;



                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("No se pudo Obtener el cliente", ex);
            }
        }
    }
}
