using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dahlia.Data;
using Dahlia.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dahlia.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TagController : Controller
    {
        private ApplicationDbContext _db;
        public TagController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Tag.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Tag tag)
        {
            if (ModelState.IsValid)
            {
                _db.Tag.Add(tag);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(tag);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var tag = _db.Tag.Find(id);
            if (tag == null)
            {
                return NotFound();
            }
            return View(tag);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(Tag tag)
        {
            if (ModelState.IsValid)
            {
                _db.Tag.Update(tag);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(tag);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var tag = _db.Tag.Find(id);
            if (tag == null)
            {
                return NotFound();
            }
            return View(tag);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Details(Tag tag)
        {
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var tag = _db.Tag.Find(id);
            if (tag == null)
            {
                return NotFound();
            }
            return View(tag);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Delete(int? id, Tag tag)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (id != tag.Id)
            {
                return NotFound();
            }
            var tags = _db.Tag.Find(id);
            if (tags == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _db.Tag.Remove(tags);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(tag);
        }


    }
}
