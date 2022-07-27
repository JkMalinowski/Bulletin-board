using BulletinBoard.Data;
using BulletinBoard.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using X.PagedList;

namespace BulletinBoard.Controllers
{
    public class AnnouncementsController : Controller
    {
        private readonly BulletinBoardContext _context;

        public AnnouncementsController(BulletinBoardContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> LastTenAnnouncements()
        {
            DateTime today = DateTime.Now;
            var data = _context.Announcements.OrderByDescending(a => a.DateAdded).Take(10).Where(x => x.DateAdded.AddDays(10) > today);
            return View(await data.ToListAsync());
        }

        public async Task<IActionResult> Index(int? page)
        {
            var announcements = _context.Announcements.OrderByDescending(a => a.DateAdded);
            var pageNumber = page ?? 1;
            var perPage = 15;
            return View(await announcements.ToPagedListAsync(pageNumber, perPage));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Announcements == null)
            {
                return NotFound();
            }

            var announcements = await _context.Announcements
                .FirstOrDefaultAsync(m => m.Id == id);
            if (announcements == null)
            {
                return NotFound();
            }

            return View(announcements);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Content")] Announcements announcements)
        {
            announcements.DateAdded = DateTime.Now;
            if (ModelState.IsValid)
            {
                TempData["AddedSuccessfully"] = true;
                _context.Add(announcements);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(announcements);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Announcements == null)
            {
                return NotFound();
            }

            var announcements = await _context.Announcements.FindAsync(id);
            if (announcements == null)
            {
                return NotFound();
            }
            return View(announcements);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Content")] Announcements announcements)
        {
            if (id != announcements.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var announcement = _context.Announcements.FirstOrDefault(x => x.Id == announcements.Id);
                    announcement.Title = announcements.Title;
                    announcement.Content = announcements.Content;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnnouncementsExists(announcements.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(announcements);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Announcements == null)
            {
                return NotFound();
            }

            var announcements = await _context.Announcements
                .FirstOrDefaultAsync(m => m.Id == id);
            if (announcements == null)
            {
                return NotFound();
            }

            return View(announcements);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Announcements == null)
            {
                return Problem("Entity set 'BulletinBoardContext.Announcements'  is null.");
            }
            var announcements = await _context.Announcements.FindAsync(id);
            if (announcements != null)
            {
                _context.Announcements.Remove(announcements);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnnouncementsExists(int id)
        {
          return (_context.Announcements?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
