using AutoMapper;
using HospitalApi.Entity;
using HospitalApi.Mappers.Models;

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
            CreateMap<Condition, CondicaoInputModel>();
            CreateMap<CondicaoInputModel, Condition>();
        }
    }
}
