using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PizzaShack.Models;
using PizzaShack.Services;

namespace PizzaShack.Controllers
{
	public class HomeController : Controller
	{
		public IOrderService service;

		public HomeController(IOrderService service)
		{
			this.service = service;
		}

		// CREATE
			
		[HttpGet]
		[Route("", Name = "CreateOrder")]
		public ActionResult CreateOrder()
		{
			try
			{
				var list = service.GetIngredients();
				return View(list);
			}
			catch (Exception e)
			{
				ViewBag.Error = "An error has occured. Please contact customer support.";
				return View();
			}
		}

		[HttpPost]
		[Route("orders", Name = "CreateOrderPost")]
		public ActionResult CreateOrderPost(string name, string phoneNumber, double pickupDateTime, List<orderingredient> ingredients)
		{
			try
			{
				DateTime currentDate = DateTime.Now;

				order order = new order()
				{
					name = name,
					phonenumber = phoneNumber,
					pickupdatetime = currentDate.AddMinutes(pickupDateTime)
				};
				service.CreateOrder(order, ingredients);
			}
			catch (Exception e)
			{
				ViewBag.Error = "An error has occured. Please contact customer support.";
				return View("~/Views/Home/CreateOrder.cshtml");
			}

			return RedirectToRoute("ViewPendingOrders");
		}

		// READ

		[HttpGet]
		[Route("orders/completed", Name = "ViewCompletedOrders")]
		public ActionResult ViewCompletedOrders()
		{
			try
			{
				var orders = service.GetOrders();
				return View(orders);
			}
			catch (Exception e)
			{
				ViewBag.Error = "An error has occured. Please contact customer support.";
				return View();
			}
		}

		[HttpGet]
		[Route("orders/pending", Name = "ViewPendingOrders")]
		public ActionResult ViewPendingOrders()
		{
			try
			{
				var orders = service.GetOrders();
				return View(orders);
			}
			catch (Exception e)
			{
				ViewBag.Error = "An error has occured. Please contact customer support.";
				return View();
			}
		}
	}
}