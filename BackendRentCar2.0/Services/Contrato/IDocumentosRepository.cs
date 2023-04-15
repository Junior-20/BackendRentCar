using BackendRentCar2._0.Models;

namespace BackendRentCar2._0.Services.Contrato
{
    public interface IDocumentosRepository
    {
        Task<List<Documento>> GetDocumentos();
        Task<Documento> GetDocumentoID(int id);
        Task DeleteDocumento(Documento documento);
        Task<Documento> AddDocumento(Documento documento);
        Task UpdateDocumento(Documento documento);
    }
}
