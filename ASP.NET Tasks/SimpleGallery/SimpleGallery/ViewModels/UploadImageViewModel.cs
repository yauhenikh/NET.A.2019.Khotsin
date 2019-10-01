using Microsoft.AspNetCore.Http;

namespace SimpleGallery.ViewModels
{
    public class UploadImageViewModel
    {
        public IFormFile ImageUpload { get; set; }
    }
}
