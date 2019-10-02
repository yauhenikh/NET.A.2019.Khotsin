using Microsoft.AspNetCore.Mvc;
using SimpleGallery.Context;
using SimpleGallery.Helpers;
using SimpleGallery.Models;
using SimpleGallery.ViewModels;
using System;
using System.Linq;

namespace SimpleGallery.Controllers
{
    public class GalleryController : Controller
    {
        private readonly SimpleGalleryDbContext _context;

        private const int PageSize = 3;

        public GalleryController(SimpleGalleryDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var imageList = new PagedData<ImageModel>();

            imageList.Data = _context.Images.Take(PageSize);
            imageList.NumberOfPages = Convert.ToInt32(Math.Ceiling((double)_context.Images.Count() / PageSize));
            imageList.CurrentPage = 1;

            return View(imageList);
        }

        public IActionResult ImageList(int page)
        {
            var imageList = new PagedData<ImageModel>();

            imageList.Data = _context.Images.Skip(PageSize * (page - 1)).Take(PageSize);
            imageList.NumberOfPages = Convert.ToInt32(Math.Ceiling((double)_context.Images.Count() / PageSize));
            imageList.CurrentPage = page;

            return PartialView(imageList);
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