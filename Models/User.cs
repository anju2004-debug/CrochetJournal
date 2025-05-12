using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using CrochetJournal.Data;
namespace CrochetJournal.Models
{
    public class User: IdentityUser
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string Username { get; set; }
        public string Email { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        public DateTime CreatedOn { get; set; }
        //foreign keys
        public int Id { get; set; }

        //relation of users with blogposts and comments
        public List<BlogPost> BlogPosts { get; set; }
        public List<Comment> Comments { get; set; }
    }
}