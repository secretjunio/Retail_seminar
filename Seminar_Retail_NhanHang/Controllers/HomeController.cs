using API;
using API.Entities;
using API.Persistance.IRepository;
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
        private readonly IDeliveryOrderRepository _deliveryOrderRepository;

        public HomeController(Context context, IDeliveryOrderRepository deliveryOrderRepository)
        {
            this._context = context;
            _deliveryOrderRepository = deliveryOrderRepository;
        }

        public IActionResult Index()
        {
            ModelView m = new ModelView
            {
                DeliveryOrders = _deliveryOrderRepository.DeliveryOrders().OrderByDescending(m=>m.AutoID)
             };
            return View(m);
        }

        public IActionResult CreateDeliveryOrder()
        {
            return base.View(new Models.DeliveryOrderModel());
        }

        [HttpPost]
        public IActionResult CreateDeliveryOrder(Models.DeliveryOrderModel d)
        {
            if (ModelState.IsValid)
            {
                var deliveryOrder = new API.Entities.DeliveryOrder();
                deliveryOrder.delivery_order_id = Guid.NewGuid().ToString();
                deliveryOrder.delivery_order_date = DateTime.Parse(d.delivery_order_date.ToString().Split(" ")[0]).ToString("dd-MM-yyyy");
                deliveryOrder.order_status = d.order_status;
                deliveryOrder.expected_quantity = d.expected_quantity;       
                _deliveryOrderRepository.createDeliveryOrder(deliveryOrder);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(string id)
        {
            ModelView m = new ModelView {
                DeliveryOrder = _deliveryOrderRepository.FindByID(id),
                DeliveryOrders = _deliveryOrderRepository.DeliveryOrders()
            };
            return View(m);
        }

        [HttpPost]
        public void Edit(DeliveryOrderModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.delivery_order_id != "")
                {
                    API.Entities.DeliveryOrder deliveryOrder = _deliveryOrderRepository.FindByID(model.delivery_order_id);
                    deliveryOrder.delivery_order_date = DateTime.Parse(model.delivery_order_date.ToString().Split(" ")[0]).ToString("dd-MM-yyyy");
                    deliveryOrder.order_status = model.order_status;
                    deliveryOrder.expected_quantity = model.expected_quantity;
                    deliveryOrder.actual_quantity = model.actual_quantity;
                    _deliveryOrderRepository.editDeliveryOrder(deliveryOrder);
                }
            }
            Response.Redirect("/Home/Index");
        }

        public void Delete(string id)
        {
            _deliveryOrderRepository.removeDeliveryOrder(id);
            Response.Redirect("/Home/Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
