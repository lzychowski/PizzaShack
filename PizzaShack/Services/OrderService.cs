using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PizzaShack.Models;
using PizzaShack.Repositories;

namespace PizzaShack.Services
{
	public class OrderService : IOrderService
	{
		public IOrderRepository repository;

		public OrderService(IOrderRepository repository)
		{
			this.repository = repository;
		}

		// CREATE

		public order CreateOrder(order order, List<orderingredient> ingredients)
		{
			try
			{
				order.statustypeid = 1;
				order createdOrder = repository.CreateOrder(order);

				AddOrderIngredients(ingredients, createdOrder.orderid);

				return createdOrder;
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		public void AddOrderIngredients(List<orderingredient> ingredients, int orderId)
		{
			try
			{
				foreach (var i in ingredients)
				{
					if (i.quantity < 1)
					{
						continue;
					}

					orderingredient orderIngredient = new orderingredient()
					{
						orderid = orderId,
						ingredientid = i.ingredientid,
						quantity = i.quantity
					};

					repository.AddOrderIngredient(orderIngredient);
				}
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		// READ

		public List<ingredient> GetIngredients()
		{
			try
			{
				return repository.GetIngredients();
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		public List<CustomerOrderResult> GetOrders()
		{
			try
			{
				List<CustomerOrderResult> customerOrders = new List<CustomerOrderResult>();
				List<order> orders = repository.GetOrders();
				List<ingredient> ingredients = repository.GetIngredients();

				foreach (var order in orders)
				{
					CustomerOrderResult customerOrderResult = new CustomerOrderResult()
					{
						orderid = order.orderid,
						name = order.name,
						phonenumber = order.phonenumber,
						pickupdatetime = order.pickupdatetime,
						startdatetime = order.startdatetime,
						enddatetime = order.enddatetime,
						statustypeid = order.statustypeid,
						orderingredientresults = this.GetOrderIngredients(order.orderid),
						islate = this.IsLate(order.pickupdatetime, order.statustypeid)
					};

					foreach (var ingredient in customerOrderResult.orderingredientresults)
					{
						ingredient.name = ingredients.FirstOrDefault(x => x.ingredientid == ingredient.ingredientid).name;
					}

					customerOrders.Add(customerOrderResult);
				}

				return customerOrders;
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		public List<OrderIngredientResult> GetOrderIngredients(int orderId)
		{
			try
			{
				List<orderingredient> orderIngredients = repository.GetOrderIngredients(orderId);
				List<OrderIngredientResult> orderIngredientResults = new List<OrderIngredientResult>();

				foreach (var orderIngredient in orderIngredients)
				{
					orderIngredientResults.Add(new OrderIngredientResult
					{
						orderid = orderIngredient.orderid,
						ingredientid = orderIngredient.ingredientid,
						quantity = orderIngredient.quantity,
						name = null
					});
				}

				return orderIngredientResults;
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		// UPDATE

		public order ChangeOrderStatus(int orderId, int statusTypeId)
		{
			try
			{
				return repository.ChangeOrderStatus(orderId, statusTypeId);
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		// HELPER METHODS

		public bool IsLate(DateTime pickupTime, int statusId)
		{
			try
			{
				int test = DateTime.Compare(pickupTime, DateTime.Now);

				if (DateTime.Compare(pickupTime, DateTime.Now) < 0 && statusId != 3 && statusId != 4)
				{
					return true;
				}

				return false;
			}
			catch (Exception e)
			{
				throw e;
			}
		}
	}
}