using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Kanini_Tourism.Models
{
    public class BookingDetail
    {
        [Key]
        public int BookingId { get; set; }

          [ForeignKey("TravelDetail")]       
        
          public int? tradeId { get; set; }   
           public string? totalprice { get; set; }  
           public string ? BookingName { get; set; }
           public DateTime? BookingDate { get; set; }
           public TravelDetail? TravelDetail { get; set; }  

    }
}
