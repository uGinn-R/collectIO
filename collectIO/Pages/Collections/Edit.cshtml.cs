using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using collectIO.Services;
using collectIO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Imagekit;
using System.IO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace collectIO.Pages.Collections
{  
    public class EditModel : PageModel
    {
        private ICollectionRepository _repository;
        private UserManager<AppUser> _userManager;

        [BindProperty]
        public IFormFile Image { get; set; }

        [BindProperty]
        public Collection collection { get; set; }

        public EditModel(ICollectionRepository repository, UserManager<AppUser> userManager)
        {
            _repository = repository;
            _userManager = userManager;
        }

        public IActionResult OnGet(int id)
        {
            if (id > 0) // Edit
                collection = _repository.GetCollectionDetails(id);
            else // creating new instance
                
            collection = new Collection();

            return Page();
        }

        public IActionResult OnPostDelete()
        {
            _repository.DeleteCollection(collection.id);

            return RedirectToPage("Collections");
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Image != null)
                {
                        var response = ImageUploader.UploadImage(Image);
                        if (response.StatusCode == 200) // OK
                        {
                        collection.imagePath = response.URL;
                        }
                }
                collection.CollectionAuthorID = _userManager.GetUserId(User);
                if (collection.id > 0)
                {
                    collection = _repository.Update(collection);
                }
                else
                {
                    
                    collection.CreationDate = DateTime.Now;
                    collection = _repository.Add(collection);
                }

                    return RedirectToPage("/UserProfile/UserProfile");
            }
            return Page();
        }
    }
}
