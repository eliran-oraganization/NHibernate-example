using Microsoft.AspNetCore.Mvc;
using NHibernate;
using nhibernateexample.Models;

namespace nhibernateexample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantsController : BaseCrudController<Restaurant>
    {
        public RestaurantsController(ISessionFactory sessionFactory) : base(sessionFactory)
        {
        }
    }
}