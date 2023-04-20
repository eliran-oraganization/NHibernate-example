namespace nhibernateexample.Models
{
    public class Dish : BaseModel
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual string Image { get; set; }
        public virtual decimal Price { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }

}