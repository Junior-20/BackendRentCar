using AutoMapper;
using BackendRentCar2._0.DTOs;
using BackendRentCar2._0.Models;

namespace BackendRentCar2._0.Utilidades.Profiles
{
    public class EmpleadoProfile : Profile
    {
        public EmpleadoProfile()
        {
            CreateMap<Empleado, EmpleadosDTO>()
                .ReverseMap();
        }
    }
}

