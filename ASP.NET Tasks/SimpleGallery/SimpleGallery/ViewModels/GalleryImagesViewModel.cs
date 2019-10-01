using SimpleGallery.Models;
using System.Collections.Generic;

namespace SimpleGallery.ViewModels
{
    public class GalleryImagesViewModel
    {
        public IEnumerable<ImageModel> Images { get; set; }
    }
}
