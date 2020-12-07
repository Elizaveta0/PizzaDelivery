using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public IdentityUser User { get; set; }
        public string Data { get; set; }
        public DateTime PublishDate { get; set; }
        public Pizza Pizza { get; set; }
    }
}
