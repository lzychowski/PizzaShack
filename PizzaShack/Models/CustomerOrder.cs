using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaShack.Models
{
	public class CustomerOrderForAdd : order { }

	public class CustomerOrderResult : order
	{
		public List<OrderIngredientResult> orderingredientresults { get; set; }
		public bool islate { get; set; }
	}
}