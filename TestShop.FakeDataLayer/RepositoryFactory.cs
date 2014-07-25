using System;
using System.Collections;
using System.Collections.Generic;
using TestShop.DataLayer.Interfaces;

namespace TestShop.FakeDataLayer
{
    public class RepositoryFactory
    {
	    private readonly Dictionary<Type, IList<IEntityBase>> _objects = new Dictionary<Type, IList<IEntityBase>>(); 
		public IRepository<T> CreateRepository<T>() where T : class, IEntityBase
		{
			IList<IEntityBase> itemsList;
			if (!_objects.TryGetValue(typeof (T), out itemsList))
			{
				_objects[typeof(T)] = new List<IEntityBase>();
			}

			return new FakeRepository<T>((IList<T>) itemsList);
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
