using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TestShop.Dto.TestGoods
{
	public class CreateDto
	{
		[DisplayName("Название")]
		public string Name { get; set; }
	}
}