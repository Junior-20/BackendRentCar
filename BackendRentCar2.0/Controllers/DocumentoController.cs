using AutoMapper;
using BackendRentCar2._0.DTOs;
using BackendRentCar2._0.Models;
using BackendRentCar2._0.Services.Contrato;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendRentCar2._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDocumentosRepository _documentosRepository;
        public DocumentoController(IMapper mapper, IDocumentosRepository documentosRepository)
        {
            _mapper = mapper;
            _documentosRepository = documentosRepository;
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var listDocumentos = await _documentosRepository.GetDocumentos();
                var listDocumentosDTO = _mapper.Map<IEnumerable<DocumentoDTO>>(listDocumentos);
                return Ok(listDocumentosDTO);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                var FindDocumento = await _documentosRepository.GetDocumentoID(id);
                if (FindDocumento == null)
                {
                    return NotFound();
                }
                var DocumentoDTO = _mapper.Map<DocumentoDTO>(FindDocumento);

                return Ok(DocumentoDTO);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var FindDocumento = await _documentosRepository.GetDocumentoID(id);
                if (FindDocumento == null)
                {
                    return NotFound();
                }

                await _documentosRepository.DeleteDocumento(FindDocumento);
                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost]
        public async Task<ActionResult> Post(DocumentoDTO documentoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var Documentos = _mapper.Map<Documento>(documentoDTO);
                var Documentoadd = await _documentosRepository.AddDocumento(Documentos);
                var Documentoitems = _mapper.Map<DocumentoDTO>(Documentos);
                return CreatedAtAction("Get", new { id = Documentoitems.IdDocumento }, Documentoitems);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPut("{id}")]
        public async Task<ActionResult<DocumentoDTO>> Put(int id, DocumentoDTO documentoDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var Documento = _mapper.Map<Documento>(documentoDTO);
                Documento.IdDocumento = id;

                await _documentosRepository.UpdateDocumento(Documento);

                return _mapper.Map<DocumentoDTO>(Documento);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
