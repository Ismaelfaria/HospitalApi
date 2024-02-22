using HospitalApi.Entity;

namespace HospitalApi.Mappers.Models
{
    public class HospitalInputModel : HospitalModel
    {
        public CondicaoInputModel Condition { get; set; }
    }
}
