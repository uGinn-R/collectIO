using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace collectIO.Models
{
    public class AppUser : IdentityUser
    {
        public IEnumerable<Collection> OwnCollections { get; set; }
        public string AvatarImagePath { get; set; }
        public DateTime? LastLoggedIn { get; set; }
        public bool isDarkTheme { get; set; }
        public bool Language { get; set; }
    }
}
