using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using collectIO.Models;
using collectIO.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace collectIO.Pages.UserProfile
{
    public class UserProfileModel : PageModel
    {
        private readonly ICollectionRepository _collectionRepository;
        private readonly UserManager<AppUser> _userManager;
        [BindProperty]
        public AppUser thisUser { get; set; }
        [BindProperty]
        public IFormFile Image { get; set; }
        public IEnumerable<Item> ItemsList { get; set; }
        [BindProperty]
        public IEnumerable<Collection> CollectionsList { get; set; }
        public Collection currentCollection { get; set; }
        public int count { get; set; }
        public bool isDarkTheme { get; set; }
        //public int colId { get; set; }

        public UserProfileModel(ICollectionRepository collectionRepository, UserManager<AppUser> userManager)
        {
            _collectionRepository = collectionRepository;
            _userManager = userManager;
        }
        public async Task<IActionResult> OnGet()
        {
            thisUser = await _userManager.GetUserAsync(User);

            if (thisUser == null)
            {
                return Redirect("/Index");
            }

            CollectionsList = _collectionRepository.GetMyCollections(thisUser.Id);
            return Page();
        }

        public int GetItemsCount(Collection collection)
        {
            return _collectionRepository.GetAllCollectionItems(collection.id).Count();
        }
        
        public IActionResult OnPostDelete(int colId)
        {
            _collectionRepository.DeleteCollection(colId);

            return RedirectToPage("/UserProfile/UserProfile");
        }
        public async Task<IActionResult> OnPostUpdateUser(bool isDarkTheme, bool Language)
        {
            thisUser = await _userManager.GetUserAsync(User);

            if (Image != null)
            {
                var response = ImageUploader.UploadImage(Image);
                if (response.StatusCode == 200) // OK
                {
                    thisUser.AvatarImagePath = response.URL;
                }
            }
            thisUser.isDarkTheme = isDarkTheme;
            thisUser.Language = Language;
            
            await _userManager.UpdateAsync(thisUser);
            return RedirectToPage("/UserProfile/UserProfile");
        }
    }
}
