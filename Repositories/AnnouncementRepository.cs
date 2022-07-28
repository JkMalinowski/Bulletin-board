using BulletinBoard.Data;
using BulletinBoard.Models;

namespace BulletinBoard.Repositories
{
    public class AnnouncementRepository : IAnnouncementRepository
    {
        private readonly BulletinBoardContext _context;

        public AnnouncementRepository(BulletinBoardContext context)
        {
            _context = context;
        }

        public void Add(Announcements announcement)
        {
            _context.Add(announcement);
            _context.SaveChanges();
        }

        public void Delete(int announcementId)
        {
            var result = _context.Announcements.FirstOrDefault(x => x.Id == announcementId);
            if(result != null)
            {
                _context.Announcements.Remove(result);
                _context.SaveChanges();
            }
        }

        public Announcements Get(int announcementId)
            => _context.Announcements.FirstOrDefault(x => x.Id == announcementId);

        public IQueryable<Announcements> GetAllAnnouncements()
            => _context.Announcements.OrderByDescending(a => a.DateAdded);

        public void Update(int announcementId, Announcements announcement)
        {
            var result = _context.Announcements.FirstOrDefault(x => x.Id == announcementId);
            if(result != null)
            {
                result.Title = announcement.Title;
                result.Content = announcement.Content;
                _context.SaveChanges();
            }
        }
        public IQueryable<Announcements> LastTenAnnouncements()
            => _context.Announcements.OrderByDescending(a => a.DateAdded).Take(10).Where(x => x.DateAdded.AddDays(10) > DateTime.Now);
    }
}
