using Microsoft.AspNetCore.Mvc;
using ECommerceApplication.Data;
using ECommerceApplication.Models;
namespace ECommerceApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SpecialTagController : Controller
    {
        private ApplicationDbContext _db;

        public SpecialTagController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.SpecialTags.ToList());
        }

        //Create Get Action Method

        public ActionResult Create()
        {
            return View();
        }

        //Create Post Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SpecialTags specialTags)
        {
            if (ModelState.IsValid)
            {
                _db.SpecialTags.Add(specialTags);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(specialTags);
        }

        //Edit Get Action Method

        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var SpecialTag = _db.SpecialTags.FirstOrDefault(x => x.Id == id);
            if(SpecialTag == null)
            {
                return NotFound();
            }
                return View(SpecialTag);
        }

        //Edit Post Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SpecialTags specialTags)
        {
            if (ModelState.IsValid)
            {
                _db.Update(specialTags);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(specialTags);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var SpecialTag = _db.SpecialTags.FirstOrDefault(x => x.Id == id);
            if (SpecialTag == null)
            {
                return NotFound();
            }
            return View(SpecialTag);
        }

        //Details Post Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(SpecialTags specialTags)
        {
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var SpecialTag = _db.SpecialTags.FirstOrDefault(x => x.Id == id);
            if (SpecialTag == null)
            {
                return NotFound();
            }
            return View(SpecialTag);
        }

        //Delete Post Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id,SpecialTags specialTags)
        {
            if (id == null)
            {
                return NotFound();
            }
            if(specialTags.Id != id)
            {
                return NotFound();
            }
            var SpecialTag = _db.SpecialTags.FirstOrDefault(x => x.Id == id);
            if (SpecialTag == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _db.Remove(SpecialTag);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(SpecialTag);
        }

    }
}
