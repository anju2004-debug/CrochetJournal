using CrochetJournal.Data;

namespace CrochetJournal.Models
{
    public class BlogPost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PostedOn { get; set; }

        //relation with users and comments
        public List<User> Users { get; set; }
        public List<Comment> Comments { get; set; }
    }
}