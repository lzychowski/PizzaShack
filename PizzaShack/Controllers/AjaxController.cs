using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PizzaShack.Models;
using PizzaShack.Services;

namespace PizzaShack.Controllers
{
	public class AjaxController : Controller
	{
		public IOrderService service;

		public AjaxController(IOrderService service)
		{
			this.service = service;
		}

		[HttpPost]
		[Route("orders/{orderId}/status/{statusTypeId}", Name = "ChangeOrderStatusPost")]
		public JsonResult CompleteOrder(int orderId, int statusTypeId)
		{
			try
			{
				service.ChangeOrderStatus(orderId, statusTypeId);
				return Json(string.Empty);
			}
			catch (Exception e)
			{
				return Json(null);
			}
		}
	}
}