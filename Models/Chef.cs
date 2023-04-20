namespace nhibernateexample.Models
{
    public class Chef : BaseModel
    {
        public virtual string FullName { get; set; }
        public virtual DateTime DateOfBirth { get; set; }
        public virtual int YearsOfExperience { get; set; }
    }
}