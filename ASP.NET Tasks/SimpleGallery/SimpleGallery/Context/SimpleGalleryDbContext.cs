using Microsoft.EntityFrameworkCore;
using SimpleGallery.Models;

namespace SimpleGallery.Context
{
    public class SimpleGalleryDbContext : DbContext
    {
        public SimpleGalleryDbContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<ImageModel> Images { get; set; }
    }
}
