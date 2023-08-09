using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Kanini_Tourism.Models
{
    public class Feedback
    {
        [Key]
        public int FeedbackId { get; set; }
        public int UserId { get; set; } 
        public int TripId { get; set; } 
    
        public string FeedbackText { get; set; }

        public int Rating { get; set; }

    }
}
