using AutoMapper;
using BackendRentCar2._0.DTOs;
using BackendRentCar2._0.Models;

namespace BackendRentCar2._0.Utilidades.Profiles
{
    public class ModeloProfile : Profile
    {
        public ModeloProfile()
        {
            CreateMap<Modelo, ModelosDTO>().
              ForMember(destino =>
              destino.Nombredemarca,
              opt => opt.MapFrom(origen => origen.IdMarcaNavigation.Descripcion)
              );
            CreateMap<ModelosDTO, Modelo>().
             ForMember(destino =>
             destino.IdMarcaNavigation,
             opt => opt.Ignore()
             );

        }
    }
}
