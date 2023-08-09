using System.ComponentModel.DataAnnotations;

namespace Kanini_Tourism.Models
{
    public class TravelAgent
    {
        [Key]
        public int? TravelAgentId { get; set; }
        public string? UserName { get; set; }
        public string? AgentName { get; set; }
        public string? Password { get; set; }
        public string? IsApproved { get; set; }
        public string? Email { get; set; }
        public string? MobileNumber { get; set; }

        public string? AgentImage { get; set; }

        public ICollection<TravelDetail>? TravelDetails { get; set; }
        public ICollection<Traveler>? Travelers { get; set; }


    }
}
