using Microsoft.AspNetCore.Mvc;
using NHibernate;
using nhibernateexample.Models;

namespace nhibernateexample.Controllers
{
    [Route("api/[controller]")]
    public class DishesController : BaseCrudController<Dish>
    {
        public DishesController(ISessionFactory sessionFactory) : base(sessionFactory)
        {
        }
    }
}