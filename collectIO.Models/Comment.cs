using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace collectIO.Models
{
    public class Comment
    {
        [Key]
        public int id { get; set; }
        public virtual Item CommentedItem { get; set; }
        public string CommentAuthor { get; set; }
        public DateTime Created { get; set; }
        public string Text { get; set; }
    }
}
