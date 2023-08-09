using Kanini_Tourism.Models;

namespace Kanini_Tourism.Repository
{
    public interface IFeedbackRepository
    {
        IEnumerable<Feedback> GetAllFeedback();
        Feedback GetFeedbackById(int id);
        void AddFeedback(Feedback stu);

        void UpdateFeedback(int id, Feedback stu);
        void DeleteFeedback(int id);
    }
}
