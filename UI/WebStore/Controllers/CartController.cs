﻿using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebStore.Domain.DTO.Orders;
using WebStore.Domain.ViewModels;
using WebStore.Domain.ViewModels.Orders;
using WebStore.Interfaces.Services;

namespace WebStore.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _CartService;

        public CartController(ICartService CartService) => _CartService = CartService;

        public IActionResult Details() => View(new CartOrderViewModel
        {
            CartViewModel = _CartService.TransformFromCart(),
            OrderViewModel = new OrderViewModel()
        });

        public IActionResult AddToCart(int id)
        {
            _CartService.AddToCart(id);
            return RedirectToAction(nameof(Details));
        }

        public IActionResult DecrementFromCart(int id)
        {
            _CartService.DecrementFromCart(id);
            return RedirectToAction(nameof(Details));
        }

        public IActionResult RemoveFromCart(int id)
        {
            _CartService.RemoveFromCart(id);
            return RedirectToAction(nameof(Details));
        }

        public IActionResult RemoveAll()
        {
            _CartService.RemoveAll();
            return RedirectToAction(nameof(Details));
        }

        public async Task<IActionResult> CheckOut(OrderViewModel Model, [FromServices] IOrderService OrderService)
        {
            if (!ModelState.IsValid)
                return View(nameof(Details), new CartOrderViewModel
                {
                    CartViewModel = _CartService.TransformFromCart(),
                    OrderViewModel = Model
                });

            //if (User.Identity.Name is null)
            //    return View("Account/Register");

            var order_model = new CreateOrderModel
            {
                OrderViewModel = Model,
                OrderItems = _CartService.TransformFromCart().Items.Select(item => new OrderItemDTO
                {
                    Id = item.Key.Id,
                    Price = item.Key.Price,
                    Quantity = item.Value
                }).ToList()
            };

            var order = await OrderService.CreateOrderAsync(User.Identity.Name, order_model);

            _CartService.RemoveAll();

            return RedirectToAction(nameof(OrderConfirmed), new { id = order.Id });
        }

        public IActionResult OrderConfirmed(int id)
        {
            ViewBag.OrderId = id;
            return View();
        }

        #region API

        public IActionResult GetCartView() => ViewComponent("Cart");

        public IActionResult AddToCartAPI(int id)
        {
            _CartService.AddToCart(id);
            return Json(new { id, message = $"Товар id:{id} был добавлен в корзину" });
        }

        public IActionResult DecrementFromCartAPI(int id)
        {
            _CartService.DecrementFromCart(id);
            return Json(new { id, message = $"Количество товара с id:{id} былоуменьшено на 1" });
        }

        public IActionResult RemoveFromCartAPI(int id)
        {
            _CartService.RemoveFromCart(id);
            return Json(new { id, message = $"Товар id:{id} был удалён из корзины" });
        }

        public IActionResult RemoveAllAPI()
        {
            _CartService.RemoveAll();
            return Json(new { message = "Корзина была успешно очищена" });
        }

        #endregion
    }
}