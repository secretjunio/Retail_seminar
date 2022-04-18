using API;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Seminar_Retail_NhanHang.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Seminar_Retail_NhanHang.Controllers
{
    public class HomeController : Controller
    {
        private readonly Context _context;

        public HomeController(Context context)
        {
            this._context = context;
        }

        public IActionResult Index()
        {
            ModelView m = new ModelView
            {
                DeliveryOrders = _context.DeliveryOrders.ToList()
             };
            return View(m);
        }
        public IActionResult CreateDeliveryOrder()
        {
            return View();
        }
        [HttpPost]
        public void CreateDeliveryOrder(DeliveryOrder d)
        {
            if (_context.DeliveryOrders.Where(x => x.delivery_order_id == d.delivery_order_id) == null)
            {
                _context.DeliveryOrders.Add(d);
            }
            Redirect("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
