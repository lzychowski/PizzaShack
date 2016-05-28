using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzaShack.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using PizzaShack.Models;
using PizzaShack.Repositories;

namespace PizzaShack.Services.Tests
{
	[TestClass()]
	public class OrderServiceTests
	{

		[TestMethod()]
		public void CreateOrderTest()
		{
			order order = new order()
			{
				orderid = 1,
				name = "Bob",
				phonenumber = "888-888-8888",
				pickupdatetime = DateTime.Now,
				statustypeid = 1
			};

			orderingredient cheese = new orderingredient()
			{
				orderid = 1,
				ingredientid = 1,
				quantity = 1
			};

			List<orderingredient> ingredients = new List<orderingredient>();
			ingredients.Add(cheese);

			Mock<IOrderRepository> mockRepository = new Mock<IOrderRepository>();
			mockRepository.Setup(s => s.CreateOrder(It.IsAny<order>())).Returns(() => order);

			OrderService orderService = new OrderService(mockRepository.Object);

			order addedOrder = orderService.CreateOrder(order, ingredients);

			Assert.AreEqual(order, addedOrder);
		}

		[TestMethod()]
		public void GetIngredientsTest_AreEqual()
		{
			ingredient cheese = new ingredient()
			{
				ingredientid = 1,
				name = "Cheese",
				price = 2
			};

			List<ingredient> ingredients = new List<ingredient>();
			ingredients.Add(cheese);

			Mock<IOrderRepository> mockRepository = new Mock<IOrderRepository>();
			mockRepository.Setup(s => s.GetIngredients()).Returns(() => ingredients);

			OrderService orderService = new OrderService(mockRepository.Object);

			List<ingredient> resultIngredients = orderService.GetIngredients();

			Assert.AreEqual(ingredients, resultIngredients);
		}

		[TestMethod()]
		public void GetOrdersTest_AreEqual()
		{
			order order = new order()
			{
				orderid = 1,
				name = "Leszek",
				phonenumber = "888-888-8888",
				pickupdatetime = DateTime.Now,
				startdatetime = DateTime.Now,
				enddatetime = DateTime.Now,
				statustypeid = 1
			};

			List<order> orders = new List<order>();
			orders.Add(order);

			orderingredient orderIngredient = new orderingredient()
			{
				orderid = 1,
				ingredientid = 1,
				quantity = 1
			};

			List<orderingredient> orderIngredients = new List<orderingredient>();
			orderIngredients.Add(orderIngredient);

			ingredient cheese = new ingredient()
			{
				ingredientid = 1,
				name = "Cheese",
				price = 2
			};

			List<ingredient> ingredients = new List<ingredient>();
			ingredients.Add(cheese);

			Mock<IOrderRepository> mockRepository = new Mock<IOrderRepository>();
			mockRepository.Setup(s => s.GetOrders()).Returns(() => orders);
			mockRepository.Setup(s => s.GetOrderIngredients(It.IsAny<int>())).Returns(() => orderIngredients);
			mockRepository.Setup(s => s.GetIngredients()).Returns(() => ingredients);

			OrderService orderService = new OrderService(mockRepository.Object);

			List<CustomerOrderResult> resultOrders = orderService.GetOrders();

			Assert.AreEqual(1, resultOrders.FirstOrDefault().orderid);
			Assert.AreEqual("Cheese", resultOrders.FirstOrDefault().orderingredientresults.FirstOrDefault().name);
		}

		[TestMethod()]
		public void GetOrderIngredientsTest()
		{
			orderingredient orderIngredient = new orderingredient()
			{
				orderid = 1,
				ingredientid = 1,
				quantity = 1
			};

			List<orderingredient> orderIngredients = new List<orderingredient>();
			orderIngredients.Add(orderIngredient);

			Mock<IOrderRepository> mockRepository = new Mock<IOrderRepository>();
			mockRepository.Setup(s => s.GetOrderIngredients(It.IsAny<int>())).Returns(() => orderIngredients);

			OrderService orderService = new OrderService(mockRepository.Object);

			List<OrderIngredientResult> resultIngredients = orderService.GetOrderIngredients(1);

			Assert.AreEqual(orderIngredient.orderid, resultIngredients.FirstOrDefault().orderid);
			Assert.AreEqual(orderIngredient.ingredientid, resultIngredients.FirstOrDefault().ingredientid);
		}

		[TestMethod()]
		public void IsLateTest_False()
		{
			Mock<IOrderRepository> mockRepository = new Mock<IOrderRepository>();
			OrderService orderService = new OrderService(mockRepository.Object);

			DateTime pickupTime = DateTime.Today;
			int statusId = 1;
			Assert.IsTrue(orderService.IsLate(pickupTime, statusId));
		}

		[TestMethod()]
		public void IsLateTest_True()
		{
			Mock<IOrderRepository> mockRepository = new Mock<IOrderRepository>();
			OrderService orderService = new OrderService(mockRepository.Object);

			DateTime pickupTime = DateTime.Now.AddHours(1);
			int statusId = 1;
			Assert.IsFalse(orderService.IsLate(pickupTime, statusId));
		}
	}
}