using AutoMapper;
using BackendRentCar2._0.DTOs;
using BackendRentCar2._0.Models;

namespace BackendRentCar2._0.Utilidades.Profiles
{
    public class VehiculoProfile:Profile
    {
        public VehiculoProfile()
        {
           
            CreateMap<Vehiculo, VehiculosDTO>()
    .ForMember(destino => destino.NombreTipodeVehiculo, opt => opt.MapFrom(origen => origen.TipoVehiculoNavigation.Descripcion))
    .ForMember(destino => destino.NombreMarcadeVehiculo, opt => opt.MapFrom(origen => origen.MarcaNavigation.Descripcion))
    .ForMember(destino => destino.NombreModelodeVehiculo, opt => opt.MapFrom(origen => origen.ModeloNavigation.Descripcion))
    .ForMember(destino => destino.NombreTipoCombustible, opt => opt.MapFrom(origen => origen.TipoCombustibleNavigation.Descripcion));

            //Reverse

            CreateMap<VehiculosDTO, Vehiculo>()
    .ForMember(destino => destino.TipoVehiculoNavigation, opt => opt.Ignore())
    .ForMember(destino => destino.MarcaNavigation, opt => opt.Ignore())
    .ForMember(destino => destino.TipoCombustibleNavigation, opt => opt.Ignore())
    .ForMember(destino => destino.ModeloNavigation, opt => opt.Ignore());

        }
    }
}
