using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaShack.Models;

namespace PizzaShack.Repositories
{
	public interface IOrderRepository
	{
		// CREATE
		order CreateOrder(order order);
		void AddOrderIngredient(orderingredient orderIngredient);

		// READ
		List<order> GetOrders();
		order GetOrder(int orderId);
		List<ingredient> GetIngredients();
		List<orderingredient> GetOrderIngredients(int orderId); 

		// UPDATE
		order ChangeOrderStatus(int orderId, int statusTypeId);
	}
}
