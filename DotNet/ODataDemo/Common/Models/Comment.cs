using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ODataDemo.Common.Models
{
    public class Comment
    {
        [Key]
        public string Id { get; set; }

        public string UserId { get; set; }

        public string Content { get; set; }

        public int Likes { get; set; }

    }
}
