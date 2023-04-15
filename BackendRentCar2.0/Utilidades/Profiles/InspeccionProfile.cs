using AutoMapper;
using BackendRentCar2._0.DTOs;
using BackendRentCar2._0.Models;

namespace BackendRentCar2._0.Utilidades.Profiles
{
    public class InspeccionProfile:Profile
    { 
        public InspeccionProfile()
        {
            CreateMap<Inspeccion,InspeccionDTO>()
              .ForMember(destino => destino.NombredeVehiculo,opt => opt.MapFrom(origen => origen.VehiculoNavigation.ModeloNavigation.Descripcion))
              .ForMember(destino => destino.NombredeCliente,opt => opt.MapFrom(origen => origen.IdClienteNavigation.Nombre))
              .ForMember(destino => destino.NombredeEmpleado,opt => opt.MapFrom(origen => origen.EmpleadoInspeccionNavigation.Nombre));

            //Reverse
            CreateMap<InspeccionDTO, Inspeccion>()
            .ForMember(destino =>destino.VehiculoNavigation,opt => opt.Ignore())
            .ForMember(destino => destino.IdClienteNavigation,opt => opt.Ignore())
            .ForMember(destino => destino.EmpleadoInspeccionNavigation,opt => opt.Ignore());
        }
    }
}
