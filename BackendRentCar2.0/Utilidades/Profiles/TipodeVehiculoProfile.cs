using AutoMapper;
using BackendRentCar2._0.DTOs;
using BackendRentCar2._0.Models;

namespace BackendRentCar2._0.Utilidades.Profiles
{
    public class TipodeVehiculoProfile:Profile
    {
        public TipodeVehiculoProfile()
        {
            CreateMap<TiposdeVehiculo, TiposdeVehiculosDTO>().ReverseMap();
        }
    }
}
