using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using TestShop.DataLayer.Interfaces;

namespace TestShop.DataLayer
{
	public class TestEntity: IEntityBase
	{
		public int EntityId { get; set; }

		public string Name { get; set; }
	}
}
