using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulletinBoard.Models
{
    public class Announcements
    {
        [Key, DisplayName("Announcement ID")]
        public int Id { get; set; }
        [Required, MaxLength(128), DisplayName("Announcement title")]
        public string Title { get; set; }
        [Required, MaxLength(2000), DisplayName("Announcement content")]
        public string Content { get; set; }
        [DataType(DataType.DateTime), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm}"), DisplayName("Date added")]
        public DateTime DateAdded { get; set; }
    }
}
