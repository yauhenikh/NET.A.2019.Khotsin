using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SimpleGallery.Context;
using SimpleGallery.Models;
using SimpleGallery.ViewModels;

namespace SimpleGallery.Controllers
{
    public class UploadImageController : Controller
    {
        SimpleGalleryDbContext _context;
        IWebHostEnvironment _appEnvironment;

        public UploadImageController(SimpleGalleryDbContext context, IWebHostEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }

        public IActionResult Upload()
        {
            var model = new UploadImageViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UploadNewImage(UploadImageViewModel image)
        {
            if (image.ImageUpload != null)
            {
                string path = "/images/" + image.ImageUpload.FileName;
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await image.ImageUpload.CopyToAsync(fileStream);
                }

                ImageModel galleryImage = new ImageModel()
                {
                    Url = path
                };

                _context.Images.Add(galleryImage);
                _context.SaveChanges();
            }

            return RedirectToAction("Index", "Gallery");
        }
    }
}