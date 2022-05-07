using API;
using API.Entities;
using API.Persistance.IRepository;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Seminar_Retail_NhanHang.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Seminar_Retail_NhanHang.Controllers
{
    public class HomeController : Controller
    {
        private readonly Context _context;
        private readonly IDeliveryOrderRepository _deliveryOrderRepository;
        private readonly IDeliveryOrderDetailRepository _deliveryOrderDetailRepository;
        private readonly ITagReaderRepository _tagReaderRepository;
        private readonly IProductInstanceRepository _productInstanceRepository;
        private readonly IProductLineRepository _productLineRepository;
        public HomeController(Context context, IDeliveryOrderRepository deliveryOrderRepository,
                            IProductInstanceRepository productInstanceRepository, ITagReaderRepository tagReaderRepository,
                            IProductLineRepository productLineRepository, IDeliveryOrderDetailRepository deliveryOrderDetailRepository)
        {
            _context = context;
            _deliveryOrderRepository = deliveryOrderRepository;
            _deliveryOrderDetailRepository = deliveryOrderDetailRepository;
            _tagReaderRepository = tagReaderRepository;
            _productInstanceRepository = productInstanceRepository;
            _productLineRepository = productLineRepository;
        }

        public IActionResult Index()
        {
            ModelView m = new ModelView
            {
                DeliveryOrders = _deliveryOrderRepository.DeliveryOrders().OrderByDescending(m => m.AutoID)
            };
            return View(m);
        }

        public IActionResult CreateDeliveryOrder()
        {
            return View(new DeliveryOrderModel());
        }

        [HttpPost]
        public IActionResult CreateDeliveryOrder(DeliveryOrderModel d)
        {
            if (ModelState.IsValid)
            { 
                    var deliveryOrder = new DeliveryOrder();
                    deliveryOrder.delivery_order_id = Guid.NewGuid().ToString();
                    deliveryOrder.delivery_order_date = DateTime.Parse(d.delivery_order_date.ToString().Split(" ")[0]).ToString("dd-MM-yyyy");
                    deliveryOrder.order_status = d.order_status;
                    //deliveryOrder.expected_quantity = d.expected_quantity;       
                    _deliveryOrderRepository.createDeliveryOrder(deliveryOrder);
                
               
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(string id)
        {
            ModelView m = new ModelView
            {
                DeliveryOrder = _deliveryOrderRepository.FindById(id),
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
                    API.Entities.DeliveryOrder deliveryOrder = _deliveryOrderRepository.FindById(model.delivery_order_id);
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

        public IActionResult MappingTagAndProduct()
        {
            var tag = _context.TagReaders.ToList();
            var productInstance = _context.ProductInstances.ToList();
            var productLine = _context.ProductLines.ToList();
            ModelView m = new ModelView
            {
                tagReaders = tag,
                ProductLines = productLine,
                ProductInstances = productInstance
            };

            return View(m);
        }

        [HttpPost]
        public IActionResult MappingTagAndProduct(ProductInstanceModel pm)
        {
            try
            {
                if (pm != null)
                {
                    var tmp = new ProductInstance();
                    tmp.product_instance_id = pm.product_instance_id;
                    tmp.product_line_id = pm.product_line_id;
                    _productInstanceRepository.createProductInstance(tmp);
                    var toupdate = _productLineRepository.ProductLines().Where(x => x.product_line_id == tmp.product_line_id).FirstOrDefault();
                    toupdate.stock = toupdate.stock + 1;
                    _productLineRepository.editProductLine(toupdate);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

            }

            return View();
        }

        public IActionResult DetailOrder(string orderId)
        {
            ModelView mv = new ModelView
            {
                DeliveryOrder = _deliveryOrderRepository.FindById(orderId),
                DeliveryOrderDetails = _deliveryOrderDetailRepository.DeliveryOrderDetails().Where(x => x.delivery_order_id == orderId).ToList(),
                ProductLines = _productLineRepository.ProductLines()
            };
            return View(mv);
        }

        public IActionResult AddProductToDetail(string orderId)
        {

            ModelView mv = new ModelView
            {
                DeliveryOrder = _deliveryOrderRepository.FindById(orderId),
                ProductLines = _productLineRepository.ProductLines()
            };

            return View(mv);
        }
        [HttpPost]
        public IActionResult AddProductToDetail(DeliveryOrderDetailModel d)
        {
            var tmp = new DeliveryOrderDetail();
            var a = _deliveryOrderDetailRepository.DeliveryOrderDetails().Where(x => x.product_line_id == d.product_line_id && x.delivery_order_id == d.delivery_order_id).FirstOrDefault();
            if (d.quantity > 0)
            {
                if (a != null)
                {
                    tmp.delivery_order_id = a.delivery_order_id;
                    tmp.product_line_id = a.product_line_id;
                    tmp.quantity = a.quantity + d.quantity;
                    _deliveryOrderDetailRepository.editDeliveryOrderDetail(tmp);
                }
                else
                {
                    tmp.delivery_order_id = d.delivery_order_id;
                    tmp.product_line_id = d.product_line_id;
                    tmp.quantity = d.quantity;
                    _deliveryOrderDetailRepository.createDeliveryOrderDetail(tmp);
                }
                var orderTemp = _deliveryOrderRepository.FindById(d.delivery_order_id);
                orderTemp.expected_quantity = orderTemp.expected_quantity + d.quantity;
                _deliveryOrderRepository.editDeliveryOrder(orderTemp);
            }

            return RedirectToAction("Index");
        }

        public void DeleteDetail(string orderId, string lineId)
        {
            var orderTemp = _deliveryOrderRepository.FindById(orderId);
            var deliveryOrder = _deliveryOrderDetailRepository.FindById(orderId, lineId);
            orderTemp.expected_quantity = orderTemp.expected_quantity - deliveryOrder.quantity;
            _deliveryOrderDetailRepository.removeDeliveryOrderDetail(orderId, lineId);



            if (orderTemp.expected_quantity < 0)
            {
                orderTemp.expected_quantity = 0;
            }
            _deliveryOrderRepository.editDeliveryOrder(orderTemp);
            Response.Redirect("/Home/Index");
        }
        [HttpPost]
        public void Refresh(DeliveryOrderDetailModel d)
        {
            var newquantity = 0;
            var orderTemp = _deliveryOrderRepository.FindById(d.delivery_order_id);
            var deliveryOrder = _deliveryOrderDetailRepository.FindById(d.delivery_order_id, d.product_line_id);
            newquantity = (-deliveryOrder.quantity) + d.quantity;
            orderTemp.expected_quantity = orderTemp.expected_quantity + newquantity;
            deliveryOrder.quantity = d.quantity;

            _deliveryOrderDetailRepository.editDeliveryOrderDetail(deliveryOrder);
            Response.Redirect("/Home/Index");
        }

        //hàm này sẽ là hàm kiểm tra sản phẩm cung cấp có đủ hay không, tạo nút xuất excel trong này luôn
        //bảng productInstance là bảng sản phẩm được cung cấp, bảng deliveryOrderDetail là bảng cho biết sản phẩm mình cần cung cấp
        //lấy 2 bảng này để so sánh
        public IActionResult CheckProduct(string orderId)
        {
            ModelView mv = new ModelView
            {
                DeliveryOrder = _deliveryOrderRepository.FindById(orderId),
                DeliveryOrderDetails = _deliveryOrderDetailRepository.DeliveryOrderDetails().Where(x => x.delivery_order_id == orderId).ToList(),
                ProductInstances = _productInstanceRepository.ProductInstances(),
                ProductLines = _productLineRepository.ProductLines(),
            };
            return View(mv);
        }


        [HttpPost]
        public IActionResult Export(string id)
        {        
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[5] { new DataColumn("Tên sản phẩm"),
                                        new DataColumn("Đơn giá"),
                                        new DataColumn("Số lượng mong muốn"),
                                        new DataColumn("Số lượng nhận được"),
                                        new DataColumn("Kết quả"),
            });

            var deliveryOrderDetails = _deliveryOrderDetailRepository.DeliveryOrderDetails().Where(x => x.delivery_order_id == id).ToList();


            foreach (var i in deliveryOrderDetails)
            {
                var productLines = _productLineRepository.ProductLines().Where(x => x.product_line_id == i.product_line_id).FirstOrDefault();
                var num = i.quantity - productLines.stock;
                if (num > 0)
                {
                    dt.Rows.Add(productLines.name, productLines.price, i.quantity, productLines.stock, "Hàng nhập thiếu " + num);
                }
                else if (num == 0)
                {
                    dt.Rows.Add(productLines.name, productLines.price, i.quantity, productLines.stock, "Đã nhập đủ số lượng ");
                }
                else
                {
                    dt.Rows.Add(productLines.name, productLines.price, i.quantity, productLines.stock, "Đã nhập dư số lượng " + (-num));
                }

            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Baocaoseminar_nhanhang.xlsx");
                }
            }
        }

        [HttpPost]
        public IActionResult ExportExcel(string id)
        {
            float tong = 0;
            float tongchi = 0;
            float numpro1 = 0;
            float numpro2 = 0;
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[5] { new DataColumn("Tổng chi dự kiến"),
                                        new DataColumn("Tổng chi thực tế"),
                                        new DataColumn("Tổng số sản phẩm cần nhập"),
                                        new DataColumn("Tổng số sản phẩm nhận được"),
                                        new DataColumn("Kết luận"),
            });

            var deliveryOrderDetails = _deliveryOrderDetailRepository.DeliveryOrderDetails().Where(x => x.delivery_order_id == id).ToList();

            foreach (var i in deliveryOrderDetails)
            {
                var productLines = _productLineRepository.ProductLines().Where(x => x.product_line_id == i.product_line_id).FirstOrDefault();
                tong = (float)tong + (float)productLines.price * (float)i.quantity;
                tongchi = (float)tongchi + (float)productLines.stock * (float)productLines.price;
                numpro1 = numpro1 + i.quantity;
                numpro2 = numpro2 + productLines.stock;               
            }
            if (tongchi == 0 && tong == 0)
            {
                dt.Rows.Add(tong, tongchi, numpro1, numpro2, "");
            }
            else
            {
                if (tongchi > tong)
                {
                    dt.Rows.Add(tong, tongchi, numpro1, numpro2, "Tổng chi phí vượt quá mong đợi");
                }
                else if (tongchi == tong)
                {
                    dt.Rows.Add(tong, tongchi, numpro1, numpro2, "Tổng chi phí như dự đoán");
                }
                else
                {
                    dt.Rows.Add(tong, tongchi, numpro1, numpro2, "Tổng chi phí thấp hơn dự đoán");
                }

            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Baocaoseminar_nhanhang2.xlsx");
                }
            }
        }
    }
}