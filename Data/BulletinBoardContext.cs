using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BulletinBoard.Models;

namespace BulletinBoard.Data
{
    public class BulletinBoardContext : DbContext
    {
        public BulletinBoardContext (DbContextOptions<BulletinBoardContext> options)
            : base(options)
        {
        }

        public DbSet<BulletinBoard.Models.Announcements> Announcements { get; set; } = default!;
    }
}
