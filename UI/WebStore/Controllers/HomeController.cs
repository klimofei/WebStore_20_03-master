﻿using System;
using Microsoft.AspNetCore.Mvc;

namespace WebStore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();

        public IActionResult Throw(string id) => throw new ApplicationException(id);

        public IActionResult SomeAction() => View();

        public IActionResult Error404() => View();

        public IActionResult Blog() => View();

        public IActionResult BlogSingle() => View();

        //public IActionResult Cart() => View();

        //public IActionResult CheckOut() => View();

        public IActionResult ContactUs() => View();

        //public IActionResult Login() => View();

        //public IActionResult Shop() => View();

        //public IActionResult ProductDetails() => View();

        public IActionResult ErrorStatus(string Code) => RedirectToAction(nameof(Error404));
    }
}