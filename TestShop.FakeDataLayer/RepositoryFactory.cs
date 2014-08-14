using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TestShop.DataLayer.Interfaces;

namespace TestShop.FakeDataLayer
{
    public class RepositoryFactory
    {
		private readonly Dictionary<Type, IEnumerable<IEntityBase>> _objects = new Dictionary<Type, IEnumerable<IEntityBase>>(); 
		public IRepository<T> CreateRepository<T>() where T : class, IEntityBase
		{
			IEnumerable<IEntityBase> itemsList;
			if (!_objects.TryGetValue(typeof (T), out itemsList))
			{
				itemsList = _objects[typeof(T)] = new List<IEntityBase>();
			}

			return new FakeRepository<T>(itemsList);
		}
		
	    private static readonly object LockObject = new object();
	    private static RepositoryFactory _instance;

	    public static RepositoryFactory Instance
	    {
		    get
		    {
			    if (_instance == null)
			    {
					lock (LockObject)
				    {
					    if (_instance == null)
					    {
						    _instance = new RepositoryFactory();
					    }
				    }
			    }
			    return _instance;
		    }
	    }
    }
}
