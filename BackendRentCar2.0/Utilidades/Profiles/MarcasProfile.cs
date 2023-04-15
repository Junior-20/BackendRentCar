using AutoMapper;
using BackendRentCar2._0.DTOs;
using BackendRentCar2._0.Models;

namespace BackendRentCar2._0.Utilidades.Profiles
{
    public class MarcasProfile:Profile
    {
        public MarcasProfile()
        {
            CreateMap<Marcass, MarcasDTO>().ReverseMap();
        }
    }
}
