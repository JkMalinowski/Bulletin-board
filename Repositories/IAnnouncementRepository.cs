using BulletinBoard.Models;

namespace BulletinBoard.Repositories
{
    public interface IAnnouncementRepository
    {
        Announcements Get(int announcementId);

        IQueryable<Announcements> GetAllAnnouncements();

        IQueryable<Announcements> LastTenAnnouncements();

        void Add(Announcements announcement);

        void Update(int announcementId, Announcements announcement);

        void Delete(int announcementId);
    }
}
