using Microsoft.AspNetCore.Identity;
using Pizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza.Database.Managers
{
    public class CommentManager : ICommentManager
    {
        private ApplicationDbContext _context;

        public CommentManager(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateComment(Comment comment)
        {
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
        }
    }
}
