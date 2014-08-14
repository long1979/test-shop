using System.Linq;

namespace TestShop.DataLayer.Interfaces
{
	public interface IRepository<T> where T : IEntityBase
	{
		IQueryable<T> GetAll();

		T Get(int entityId);
		 
		void Create(T entity);
		void Update(T entity);
		void Delete(T entity);

	}
}