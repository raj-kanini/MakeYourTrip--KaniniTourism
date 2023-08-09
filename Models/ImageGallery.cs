using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Kanini_Tourism.Models
{
    public class ImageGallery
    {
        
        
            [Key]
            public int ImageId { get; set; }

            
            public string ?locationName { get; set; }    
     

            public string ?ImageUrl { get; set; }

        

    }
}
