using System.Collections.Generic;
using System.Linq;
using TestShop.DataLayer.Interfaces;

namespace TestShop.FakeDataLayer
{
	public class FakeRepository<T> : IRepository<T> where T : class, IEntityBase
	{
		private readonly IEnumerable<IEntityBase> _entities;
		public FakeRepository(IEnumerable<IEntityBase> entities)
		{
			_entities = entities;
		}

		public IQueryable<T> GetAll()
		{
			return _entities.Cast<T>().AsQueryable();
		}

		public T Get(int entityId)
		{
			return _entities.FirstOrDefault(e => e.EntityId == entityId) as T;
		}

		public void Create(T entity)
		{
			entity.EntityId = _entities.Count();

			((List<IEntityBase>)_entities).Add(entity);
		}

		public void Update(T entity)
		{
			var obj = Get(entity.EntityId);


			if (obj == null)
				return;

			var index = ((List<IEntityBase>)_entities).IndexOf(obj);

			((List<IEntityBase>)_entities).Remove(obj);
			((List<IEntityBase>)_entities).Insert(index, entity);
		}

		public void Delete(T entity)
		{
			var obj = Get(entity.EntityId);


			if (obj == null)
				return;

			((List<IEntityBase>)_entities).Remove(obj);
		}
	}
}
