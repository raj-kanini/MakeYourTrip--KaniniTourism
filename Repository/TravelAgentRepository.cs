using Kanini_Tourism.Models;
using Microsoft.EntityFrameworkCore;

namespace Kanini_Tourism.Repository
{
    public class TravelAgentRepository : ITravelAgentRepository
    {
        private readonly TourismDbContext _context;

        public TravelAgentRepository(TourismDbContext context)
        {
            _context = context;
        }
        public void AddTravelAgent(TravelAgent tra)
        {
            _context.TravelAgents.Add(tra);
            _context.SaveChanges();
        }

        public void DeleteTravelAgent(int id)
        {
            var agent = _context.TravelAgents.Find(id);
            if (agent != null)
            {
                _context.TravelAgents.Remove(agent);
                _context.SaveChanges();
            }
        }

        public IEnumerable<TravelAgent> GetAllTravelAgent()
        {
            return _context.TravelAgents.ToList();
        }

        public TravelAgent GetTravelAgentById(int id)
        {
            var userobj = _context.TravelAgents.Find(id);
            return userobj;
        }

        public void UpdateTravelAgent(int id, TravelAgent tra)
        {
            var existingDoctor = _context.TravelAgents.Find(id);
            if (existingDoctor != null)
            {
                existingDoctor.IsApproved = tra.IsApproved;
                _context.TravelAgents.Update(existingDoctor);
                _context.SaveChanges();
            }
        }
    }
}
