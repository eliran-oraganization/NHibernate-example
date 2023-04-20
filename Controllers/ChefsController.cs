using Microsoft.AspNetCore.Mvc;
using NHibernate;
using NHibernate.Linq;
using nhibernateexample.Models;

namespace nhibernateexample.Controllers
{
    [Route("api/[controller]")]
    public class ChefsController : BaseCrudController<Chef>
    {
        public ChefsController(ISessionFactory sessionFactory) : base(sessionFactory)
        {
        }
    }
}