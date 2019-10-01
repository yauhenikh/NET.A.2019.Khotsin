using Microsoft.AspNetCore.Mvc;
using SimpleGallery.Context;
using SimpleGallery.ViewModels;

namespace SimpleGallery.Controllers
{
    public class GalleryController : Controller
    {
        private readonly SimpleGalleryDbContext _context;

        public GalleryController(SimpleGalleryDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var imageList = _context.Images;

            var model = new GalleryImagesViewModel()
            {
                Images = imageList
            };

            return View(model);
        }

        public IActionResult Detail(int id)
        {
            var image = _context.Images.Find(id);

            var model = new GalleryDetailViewModel()
            {
                Id = image.Id,
                Url = image.Url
            };

            return View(model);
        }
    }
}