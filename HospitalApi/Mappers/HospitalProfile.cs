using AutoMapper;
using HospitalApi.Entity;
using HospitalApi.Models;

namespace HospitalApi.Mappers
{
    public class HospitalProfile : Profile
    {
        public HospitalProfile()
        {
            CreateMap<Patient, HospitalViewModel>();
            CreateMap<HospitalViewModel, HospitalInputModel>();
            CreateMap<HospitalInputModel, Patient>();
            CreateMap<Patient, HospitalInputModel>();
        }
    }
}
