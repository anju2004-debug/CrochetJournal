using System.Collections.Generic;
using CrochetJournal.Models;

namespace CrochetJournal.Data
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Content { get; set; }
        public DateTime PostedOn { get; set; }
        //foreign keys
        public int UserId { get; set; }
        public int Id { get; set; }

        //relation with bllogpost and users
        public List<BlogPost> BlogPosts { get; set; }
        public List<User> Users { get; set; }

    }
}