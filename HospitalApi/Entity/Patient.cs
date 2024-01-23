namespace HospitalApi.Entity
{
    public class Patient
    {
        public Patient()
        {
            IsDeleted = false;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Sexuality { get; set; }
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
