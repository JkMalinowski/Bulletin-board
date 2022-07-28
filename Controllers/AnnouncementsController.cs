using BulletinBoard.Models;
using BulletinBoard.Repositories;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace BulletinBoard.Controllers
{
    public class AnnouncementsController : Controller
    {
        private readonly IAnnouncementRepository _announcementRepository;

        public AnnouncementsController(IAnnouncementRepository announcementRepository)
        {
            _announcementRepository = announcementRepository;
        }

        public IActionResult LastTenAnnouncements()
        {
            return View(_announcementRepository.LastTenAnnouncements().ToList());
        }

        public IActionResult Index(int? page)
        {
            var pageNumber = page ?? 1;
            var perPage = 2;
            return View(_announcementRepository.GetAllAnnouncements().ToPagedList(pageNumber, perPage));
        }

        public IActionResult Details(int id)
        {
            return View(_announcementRepository.Get(id));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Title,Content")] Announcements announcements)
        {
            announcements.DateAdded = DateTime.Now;
            if (ModelState.IsValid)
            {
                TempData["AddedSuccessfully"] = true;
                _announcementRepository.Add(announcements);
                return RedirectToAction(nameof(Index));
            }
            return View(announcements);
        }

        public IActionResult Edit(int id)
        {
            return View(_announcementRepository.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Title,Content")] Announcements announcements)
        {
            _announcementRepository.Update(id, announcements);
            return View(announcements);
        }

        public IActionResult Delete(int id)
        {
            return View(_announcementRepository.Get(id));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _announcementRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
