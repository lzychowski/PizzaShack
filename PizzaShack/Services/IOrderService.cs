using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaShack.Models;

namespace PizzaShack.Services
{
	public interface IOrderService
	{
		// CREATE
		order CreateOrder(order order, List<orderingredient> ingredients);
		void AddOrderIngredients(List<orderingredient> ingredients, int orderId);

		// READ
		List<CustomerOrderResult> GetOrders();
		List<ingredient> GetIngredients();

		// UPDATE
		order ChangeOrderStatus(int orderId, int statusTypeId);

		// HELPER METHODS
		bool IsLate(DateTime pickupTime, int statusId);

	}
}
