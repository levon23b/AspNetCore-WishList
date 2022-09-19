using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WishList.Data;
using WishList.Models;

namespace WishList.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemController (ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var allItems = _context.Items.ToList();
            return View("Index", allItems);
        }

        [HttpPost]
        public IActionResult Create(Item item)
        {
            _context.Add(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var item = _context.Items.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                _context.Items.Remove(item);
                _context.SaveChanges();

            }
            return RedirectToAction("Index");
        }
    }
}
