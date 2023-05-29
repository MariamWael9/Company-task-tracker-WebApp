using CompanyWebApp.Models;

namespace CompanyWebApp.Data.Services
{
    public interface ICommentService
    {
        List<comment> getAllcommentsFortask(int taskId);
        void Add(comment com);

    }
}
