using Kanini_Tourism.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kanini_Tourism.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly  TourismDbContext mytb;
        public ImageController(TourismDbContext tb)
        {
            mytb = tb;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllImage()
        {
            var images=mytb.Photos.ToList();
            return Ok(images);
        }
        [HttpPost]
        public async Task<ActionResult> AddImages(ImageGallery ig)
        {
            mytb.Photos.Add(ig);
            mytb.SaveChanges();
            return Ok(ig);
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteImg(int id)
        {
            var img = mytb.Photos.Find(id);
            if(img != null)
            {
                mytb.Remove(img);
                mytb.SaveChanges();
                return Ok(img);

            }
            return NotFound($"No Image Found With  id={id}");
       
        }
    }
}
