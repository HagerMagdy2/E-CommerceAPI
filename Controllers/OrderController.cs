﻿using E_CommerceAPI.DTOs.OrderDTO;
using E_CommerceAPI.Models;
using E_CommerceAPI.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        UnitOFWork _unit;
        public OrderController(UnitOFWork _unit)
        {
            this._unit = _unit;
        }
        [HttpPost]
        public IActionResult add(AddOrderDTO _order)
        {
            Order order = new Order()
            {
                cust_id = _order.cust_id,
                status = "create",

                orderDate = new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day),

            };
            _unit.OrdersRepositry.add(order);
            _unit.savechanges();
            decimal totalPrice = 0;
            foreach (var item in _order.products)
            {
                Product product = _unit.ProductsRepositry.selectbyid(item.product_id);
                totalPrice = totalPrice + (product.price * item.quantity);
                OrderDetails _details = new OrderDetails()
                {
                    order_id = order.id,
                    product_id = item.product_id,
                    quantity = item.quantity,
                    unitprice = product.price,
                };
                if (product.stock > _details.quantity)
                {
                    _unit.OrderDetailsRepositry.add(_details);

                    product.stock -= item.quantity;
                    _unit.ProductsRepositry.update(product);

                }
                else
                {
                    _unit.OrdersRepositry.delete(order.id);
                    return BadRequest("Invalid Quantity");
                }
            }
            order.totalprice = totalPrice;
            _unit.OrdersRepositry.update(order);
            _unit.savechanges();
            return Ok();

        }
        
        [HttpDelete]
        public IActionResult delete(int id)
        {
            var order_id = _unit.OrdersRepositry.selectbyid(id);
            _unit.OrdersRepositry.delete(order_id.id);
            _unit.savechanges();
            return Ok();
        }
        [HttpPut]
        //public IActionResult edit(int id, AddOrderDTO _orderdto)
        //{
            //if (ModelState.IsValid)
            //{
            //    Order order = new Order()
            //    {
            //        id = id,
            //        cust_id = _orderdto.cust_id,
            //        status = "updated",
            //    };
            //    foreach (var item in _orderdto.books)
            //    {
            //        Product book = _unit.ProductsRepositry.selectbyid(item.product_id);
            //        OrderDetails _details = new OrderDetails()
            //        {
            //            order_id = id,
            //            product_id = item.product_id,
            //            quantity = item.quantity,
            //            unitprice = book.price,
            //        };
            //        _unit.OrderDetailsRepositry.update(_details);
            //        _unit.savechanges();
            //    }
            //    _unit.OrdersRepositry.update(order);

            //    _unit.savechanges();
            //    return NoContent();

            //}
            //return BadRequest(ModelState);
            //}
            //dont know if it work or not i will check later
            [HttpPut]
        public IActionResult EditOrder(int orderId, EditOrderDTO _order)
        {

            Order existingOrder = _unit.OrdersRepositry.selectbyid(orderId);
            if (existingOrder == null)
            {
                return NotFound("Order not found");
            }


            var existingOrderDetails = _unit.OrderDetailsRepositry.selectall().Where(od => od.order_id == orderId).ToString();


            // Restore previous book stocks
            foreach (var existingDetail in existingOrderDetails)
            {
                var product = _unit.ProductsRepositry.selectbyid(existingDetail);
                product.stock += existingDetail;
                _unit.ProductsRepositry.update(product);
                _unit.OrderDetailsRepositry.delete(existingDetail);
            }

            // Recalculate total price
            decimal totalPrice = 0;
            foreach (var item in _order.products)
            {
                Product product = _unit.ProductsRepositry.selectbyid(item.product_id);
                totalPrice += product.price * item.quantity;

                // Create new order details
                OrderDetails _details = new OrderDetails()
                {
                    order_id = existingOrder.id,
                    product_id = item.product_id,
                    quantity = item.quantity,
                    unitprice = product.price,
                };

                // Check stock availability
                if (product.stock >= _details.quantity)
                {
                    _unit.OrderDetailsRepositry.add(_details);
                    product.stock -= item.quantity;
                    _unit.ProductsRepositry.update(product);
                }
                else
                {
                    // Rollback stock changes
                    foreach (var existingDetail in existingOrderDetails)
                    {
                        var rollbackBook = _unit.ProductsRepositry.selectbyid(existingDetail);
                        rollbackBook.stock += existingDetail;
                        _unit.ProductsRepositry.update(rollbackBook);
                        _unit.OrderDetailsRepositry.delete(existingDetail);
                    }
                    return BadRequest("Invalid Quantity");
                }
            }

            // Update order details
            existingOrder.totalprice = totalPrice;
            existingOrder.orderDate = new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            _unit.OrdersRepositry.update(existingOrder);
            _unit.savechanges();

            return Ok();
        }
    }
}
