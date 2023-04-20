namespace nhibernateexample.Models
{
    public class Restaurant : BaseModel
    {

        public virtual string Name { get; set; }
        public virtual ISet<Chef> Chefs { get; set; }
        public virtual double Rating { get; set; }
    }
}