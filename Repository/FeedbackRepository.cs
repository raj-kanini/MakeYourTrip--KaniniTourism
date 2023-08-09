using Kanini_Tourism.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kanini_Tourism.Repository
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly TourismDbContext _context;

        public FeedbackRepository(TourismDbContext context)
        {
            _context = context;
        }

        public void AddFeedback(Feedback feed)
        {
            try
            {
                _context.Feedbacks.Add(feed);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., log the error, throw a custom exception, etc.)
                // You can also use a logging framework like Serilog or NLog to log the error.
                throw new Exception("Error occurred while adding feedback.", ex);
            }
        }

        public void DeleteFeedback(int id)
        {
            try
            {
                var feed = _context.Feedbacks.Find(id);
                if (feed != null)
                {
                    _context.Feedbacks.Remove(feed);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., log the error, throw a custom exception, etc.)
                throw new Exception("Error occurred while deleting feedback.", ex);
            }
        }

        public IEnumerable<Feedback> GetAllFeedback()
        {
            try
            {
                return _context.Feedbacks.ToList();
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., log the error, throw a custom exception, etc.)
                throw new Exception("Error occurred while retrieving feedbacks.", ex);
            }
        }

        public Feedback GetFeedbackById(int id)
        {
            try
            {
                var feedback = _context.Feedbacks.Find(id);
                return feedback;
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., log the error, throw a custom exception, etc.)
                throw new Exception("Error occurred while retrieving feedback by ID.", ex);
            }
        }

        public void UpdateFeedback(int id, Feedback feed)
        {
            try
            {
                var existingFeedback = _context.Feedbacks.Find(id);
                if (existingFeedback != null)
                {
                    existingFeedback.FeedbackText = feed.FeedbackText;
                    existingFeedback.Rating = feed.Rating;
                    // Update other properties as needed
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., log the error, throw a custom exception, etc.)
                throw new Exception("Error occurred while updating feedback.", ex);
            }
        }
    }
}
