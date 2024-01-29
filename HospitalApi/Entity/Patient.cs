using HospitalApi.Entity.Contracts;

namespace HospitalApi.Entity
{
    public class Patient : IPatient
    {
        public Patient()
        {
            Condition = new Condition();
            IsDeleted = false;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Sexuality { get; set; }
        public DateTime StartDate { get; set; }
        public bool IsDeleted { get; set; }
        public Condition Condition { get; set; }

        public void Update(string name, int age, string sexuality)
        {
            Name = name;
            Age = age;
            Sexuality = sexuality;
        }

        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
