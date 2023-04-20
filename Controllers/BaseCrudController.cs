using Microsoft.AspNetCore.Mvc;
using NHibernate;
using NHibernate.Linq;
using nhibernateexample.Models;

namespace nhibernateexample.Controllers
{
    [ApiController]
    public abstract class BaseCrudController<T> : ControllerBase where T : BaseModel
    {
        protected readonly ISessionFactory _sessionFactory;

        public BaseCrudController(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }


        [HttpGet("{id}")]
        public async virtual Task<ActionResult<T>> Read(string id)
        {
            // Open session for interacting with the database
            using var session = _sessionFactory.OpenSession();
            var item = await session.GetAsync<T>(new Guid(id));
            return Ok(item);
        }

        [HttpPost]
        public async virtual Task<ActionResult<T>> Create(T item)
        {
            // Open session for interacting with the database
            using var session = _sessionFactory.OpenSession();
            // For writing operation we should use the transaction object
            using var transaction = session.BeginTransaction();
            var id = (Guid)await session.SaveAsync(item);
            await transaction.CommitAsync();
            item.Id = id;
            return CreatedAtAction(nameof(Read), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async virtual Task<ActionResult<T>> Update(T item, string id)
        {
            // Open session for interacting with the database
            using var session = _sessionFactory.OpenSession();
            var itemExist = await session.GetAsync<T>(new Guid(id));
            if (itemExist == null) return NotFound();
            // For writing operation we should use the transaction object
            using var transaction = session.BeginTransaction();
            item.Id = new Guid(id);
            await session.MergeAsync<T>(item);
            await transaction.CommitAsync();
            return Ok(item);

        }

        [HttpDelete("{id}")]
        public async virtual Task<ActionResult<T>> Delete(string id)
        {
            // Open session for interacting with the database
            using var session = _sessionFactory.OpenSession();
            var itemExist = await session.GetAsync<T>(new Guid(id));
            if (itemExist == null) return NotFound();

            using var transaction = session.BeginTransaction();
            await session.DeleteAsync(new Guid(id));
            await transaction.CommitAsync();

            return NoContent();

        }

    }
}