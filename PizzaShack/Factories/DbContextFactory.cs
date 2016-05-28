using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PizzaShack.Models;


namespace PizzaShack.Factories
{
	public class DbContextFactory : IDbContextFactory
	{
		private readonly Entities entities;

		public DbContextFactory()
		{
			entities = new Entities();
		}

		public Entities GetContext()
		{
			return entities;
		}
	}
}