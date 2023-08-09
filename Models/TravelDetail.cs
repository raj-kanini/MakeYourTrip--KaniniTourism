using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Kanini_Tourism.Models
{
    public class TravelDetail
    {
        [Key]

        public int? PlanId { get; set; }
        public string? PlanTitle { get; set; }
        public string? PlanDescription { get; set; }
        public string? PlanImage { get; set; }
        public int? PlanPrice { get; set; }
        public int? AgentId { get; set; }
        public TravelAgent? TravelAgents { get; set; }
    }
}
