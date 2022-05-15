using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace collectIO.Models
{
    public class Like
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int ItemId { get; set; }
    }
}
