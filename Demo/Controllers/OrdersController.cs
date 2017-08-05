using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Webdiyer.MvcPagerCoreDemo.Models;
using Webdiyer.WebControls.AspNetCore;

namespace Demo.Controllers
{
    public class OrdersController : Controller
    {
        private readonly DemoDbContext _context;

        public OrdersController(DemoDbContext context)
        {
            _context = context;    
        }
        
        public IActionResult Default(int pageindex=1)
        {
            var model = _context.Orders.OrderByDescending(o => o.OrderDate).ToPagedList(pageindex, 10);
            return View(model);
        }
        
    }
}
