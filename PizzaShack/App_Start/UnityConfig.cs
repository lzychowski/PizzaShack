using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using PizzaShack.Services;
using PizzaShack.Repositories;
using PizzaShack.Factories;

namespace PizzaShack
{
	public static class UnityConfig
	{
		public static void RegisterComponents()
		{
			var container = new UnityContainer();

			container.RegisterType<IOrderRepository, OrderRepository>();
			container.RegisterType<IOrderService, OrderService>();
			container.RegisterType<IDbContextFactory, DbContextFactory>();

			DependencyResolver.SetResolver(new UnityDependencyResolver(container));
		}
	}
}