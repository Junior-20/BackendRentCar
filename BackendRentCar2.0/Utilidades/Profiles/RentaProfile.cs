using AutoMapper;
using BackendRentCar2._0.DTOs;
using BackendRentCar2._0.Models;

namespace BackendRentCar2._0.Utilidades.Profiles
{
    public class RentaProfile : Profile
    {
        public RentaProfile()
        {
            CreateMap<Rentum, RentaDTO>()
             .ForMember(destino => destino.DocCliente, opt => opt.MapFrom(origen => origen.DocGarantiaNavigation.Descripcion))
             .ForMember(destino => destino.NombredeEmpleado, opt => opt.MapFrom(origen => origen.EmpleadoNavigation.Nombre))
             .ForMember(destino => destino.NombredeVehiculo,opt => opt.MapFrom(origen => origen.VehiculoNavigation.ModeloNavigation.Descripcion))
             .ForMember(destino => destino.NombredeCliente,opt => opt.MapFrom(origen => origen.ClienteNavigation.Nombre));
            //Reverse
            CreateMap<RentaDTO, Rentum>()
            .ForMember(destino =>destino.VehiculoNavigation,opt => opt.Ignore())
            .ForMember(destino =>destino.ClienteNavigation,opt => opt.Ignore()) 
            .ForMember(destino =>destino.EmpleadoNavigation,opt => opt.Ignore()) 
            .ForMember(destino =>destino.DocGarantiaNavigation,opt => opt.Ignore());

        }
    }
}
