using Microsoft.EntityFrameworkCore;

namespace Kanini_Tourism.Models
{
    public class TourismDbContext:DbContext
    {
        public DbSet<Administrator> Administrators { get; set; }    
        public DbSet<TravelAgent> TravelAgents { get; set; }
        public DbSet<Traveler> Travelers { get; set; }
        public DbSet<TravelDetail> TravelDetails { get; set; }
        public DbSet<BookingDetail> BookingDetails { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<ImageGallery> Photos { get; set; }
        public TourismDbContext(DbContextOptions<TourismDbContext> options)
        : base(options)
        {
        }

    
    }
}
