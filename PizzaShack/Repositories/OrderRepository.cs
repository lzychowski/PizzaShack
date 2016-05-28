using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PizzaShack.Models;
using System.Data.SqlClient;
using PizzaShack.Factories;

namespace PizzaShack.Repositories
{
	public class OrderRepository : IOrderRepository
	{
		private Entities db;

		public OrderRepository(IDbContextFactory factory)
		{
			db = factory.GetContext();
		}

		// CREATE

		public order CreateOrder(order order)
		{
			try
			{
				db.orders.Add(order);
				db.SaveChanges();
				return order;
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		public void AddOrderIngredient(orderingredient orderIngredient)
		{
			try
			{
				string query = "INSERT INTO dbo.orderingredients VALUES (" + orderIngredient.orderid + "," + orderIngredient.ingredientid + "," + orderIngredient.quantity + ")";
				db.Database.ExecuteSqlCommand(query);
				db.SaveChanges();
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		// READ

		public List<order> GetOrders()
		{
			try
			{
				return db.orders.ToList();
			}
			catch (Exception e)
			{
				throw e;
			}
			
		}

		public order GetOrder(int orderId)
		{
			try
			{
				return db.orders.FirstOrDefault(x => x.orderid == orderId);
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		public List<ingredient> GetIngredients()
		{
			try
			{
				return db.ingredients.ToList();
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		public List<orderingredient> GetOrderIngredients(int orderId)
		{
			try
			{
				return db.orderingredients.ToList().FindAll(x => x.orderid == orderId);
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
				order order = this.GetOrder(orderId);
				order.statustypeid = statusTypeId;

				db.orders.Attach(order);
				var entry = db.Entry(order);
				entry.Property(e => e.statustypeid).IsModified = true;
				db.SaveChanges();

				return order;
			}
			catch (Exception e)
			{
				throw e;
			}
		}
	}
}