using Pizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza.Database.Managers
{
    public interface ICommentManager
    {
        Task CreateComment(Comment comment);
    }
}
