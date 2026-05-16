using Learning.Data;
using Learning.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Learning.Controllers
{
    [Authorize]
    public class ItemController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IHostingEnvironment _host;
        public ItemController(AppDbContext db , IHostingEnvironment host)
        {
            _db = db;
            _host = host;
        }
        public IActionResult Index()
        {
            IEnumerable<Item> items = _db.Items.Include(c => c.category).ToList();
            return View(items);
        }

        public void CreateSelectList(int? selectId = 1)
        {
            List<Category>categories = _db.Categories.ToList();
            SelectList listItems = new SelectList(categories, "category_id", "category_name",selectId);
            ViewBag.CategoryList = listItems;
        }


        //GET
        public IActionResult New()
        {
            CreateSelectList();
            return View();

        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(Item item)
        {
            if (ModelState.IsValid)
            {

                string fileName = string.Empty;
                if (item.clientFile != null)
                {
                    string uploadsFolder = Path.Combine(_host.WebRootPath, "images");
                    fileName = item.clientFile.FileName;
                    string filePath = Path.Combine(uploadsFolder, fileName);
                    item.clientFile.CopyTo(new FileStream(filePath, FileMode.Create));
                    item.imgPath = fileName;

                }
                _db.Items.Add(item);
                _db.SaveChanges();
                TempData["Add Data"] = "Item has been Added successfully";
                return RedirectToAction("Index");
            }

            return View(item);

        }


        //GET
        public IActionResult Edit(int? id)
        {
            if (id == 0 ||id == null)
            {
                return NotFound();
            }
            var item = _db.Items.FirstOrDefault(x => x.ID == id);
            if (item == null) {
            return NotFound();
            }
            CreateSelectList();
            return View(item);

        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Item item)
        {
            if (ModelState.IsValid)
            {
                _db.Items.Update(item);
                _db.SaveChanges();
                TempData["Update Data"] = "Item has been Updated successfully";

                return RedirectToAction("Index");
            }

            return View(item);

        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            var item = _db.Items.FirstOrDefault(x => x.ID == id);
            CreateSelectList();
            return View(item);

        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Item item)
        {
            if (ModelState.IsValid)
            {
                _db.Items.Remove(item);
                _db.SaveChanges();
                TempData["Delete Data"] = "Item has been Deleted successfully";
                return RedirectToAction("Index");
            }

            return View(item);

        }
    }
}
