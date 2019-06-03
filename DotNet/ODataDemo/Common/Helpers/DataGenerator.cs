using ODataDemo.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODataDemo.Common.Helpers
{
    public static class DataGenerator
    {
        public static void GenerateData(DataContext context)
        {
            var comment1 = new Comment
            {
                Id = "c1",
                UserId = "u1",
                Content = "This is my first comment",
                Likes = 21
            };

            var user1 = new User
            {
                Id = "u1",
                FirstName = "Mark",
                LastName = "Steven",
                Comments = new List<Comment>() { comment1 }
            };

            context.Users.Add(user1);
            context.Comments.Add(comment1);
            context.SaveChanges();
        }
    }
}
