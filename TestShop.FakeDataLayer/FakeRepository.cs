using System.Collections.Generic;
using System.Linq;
using TestShop.DataLayer.Interfaces;

namespace TestShop.FakeDataLayer
{
	public class FakeRepository<T> : IRepository<T> where T : class, IEntityBase
	{
		private readonly IList<T> _entities;

		public FakeRepository(IList<T> entities)
		{
			_entities = entities;
		}

		public IQueryable<T> GetAll()
		{
			return _entities.AsQueryable();
		}

		public T Get(int entityId)
		{
			return _entities.FirstOrDefault(e => e.EntityId == entityId);
		}

		public void Create(T entity)
		{
			_entities.Add(entity);
		}

		public void Update(T entity)
		{
			var obj = Get(entity.EntityId);


			if (obj == null)
				return;

			var index = _entities.IndexOf(obj);

			_entities.Remove(obj);
			_entities.Insert(index, entity);
		}

		public void Delete(T entity)
		{
			var obj = Get(entity.EntityId);


			if (obj == null)
				return;

			_entities.Remove(obj);
		}
	}
}
