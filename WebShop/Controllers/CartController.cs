﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebShop.Data;
using WebShop.Extensions;

namespace WebShop.Controllers
{
    public class CartController : Controller
    {
        const string _sessionKeyName = "_cart";
        ApplicationDbContext _dbContext;

        public CartController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            List<CartItem> cart = HttpContext.Session.GetObjectsFromJson<List<CartItem>>(_sessionKeyName) ?? new List<CartItem>();

            decimal sum = 0;
            ViewBag.TotalPrice = cart.Sum(item => sum + item.GetTotal());

            return View(cart);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddToCart(int productId)
        {
            List<CartItem> cartSession = HttpContext.Session.GetObjectsFromJson<List<CartItem>>(_sessionKeyName) ?? new List<CartItem>();
            if (cartSession.Count == 0)
            {
                var product = _dbContext.Product.Find(productId);

                CartItem cartItem = new CartItem()
                {
                    Product = product,
                    Quantity = 1
                    
                };

                cartSession.Add(cartItem);


                HttpContext.Session.SetObjectAsJson(_sessionKeyName, cartSession);

            }
            else
            {
                var index = IsExistingInCart(productId);

                if (index != -1)
                {
                    cartSession[index].Quantity++;
                }
                else
                {
                    CartItem cartItem = new CartItem()
                    {
                        Product = _dbContext.Product.Find(productId),
                        Quantity = 1
                    };
                    cartSession.Add(cartItem);
                }
                HttpContext.Session.SetObjectAsJson(_sessionKeyName, cartSession);
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult RemoveFromCart(int productId)
        {
            List<CartItem> cartItems = HttpContext.Session.GetObjectsFromJson<List<CartItem>>(_sessionKeyName);
            int index = IsExistingInCart(productId);
            cartItems.RemoveAt(index);
            HttpContext.Session.SetObjectAsJson(_sessionKeyName, cartItems);

            return RedirectToAction(nameof(Index));
        }

        private int IsExistingInCart(int productId)
        {
            List<CartItem> cart = HttpContext.Session.GetObjectsFromJson<List<CartItem>>(_sessionKeyName);

            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.Id == productId)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
