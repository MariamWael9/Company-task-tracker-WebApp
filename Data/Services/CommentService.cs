using CompanyWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyWebApp.Data.Services
{
    public class CommentService : ICommentService
    {
        private readonly AppDbContext _context;
        public CommentService (AppDbContext context)
        {
            _context = context;
        }
        public void Add(comment com)
        {
            _context.Add(com);
            _context.SaveChanges();
        }

        public List<comment> getAllcommentsFortask(int taskId)
        {
            var data = _context.comments.Where(k => k.Task_Id == taskId).Include(n => n.employee).ToList();
            return data;
        }
    }
}
