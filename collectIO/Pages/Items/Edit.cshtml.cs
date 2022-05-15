using collectIO.Models;
using collectIO.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace collectIO.Pages.Items
{
    public class EditModel : PageModel
    {
        private ICollectionRepository _repository;
        private UserManager<AppUser> _userManager;

        [BindProperty]
        public IFormFile Image { get; set; }
       
        [BindProperty]
        public int CollectionId { get; set; }
        private Collection _collection { get; set; }

        [BindProperty]
        public Item item { get; set; }
        [BindProperty]
        public Dictionary<string,string> ItemOptions { get; set; }
        List<object> Options { get; set; }

        public Dictionary<object,object> itemFields { get; set; }
        public EditModel(ICollectionRepository repository, UserManager<AppUser> userManager)
        {
            _repository = repository;
            _userManager = userManager;
        }
        public IActionResult OnGet(int id)
        {
            var currentUser = _userManager.GetUserId(User);
 
            if (id > 0)
            {
                item = _repository.GetItemDetails(id);
                CollectionId = item.CollectionId;
                _collection = _repository.GetCollectionDetails(CollectionId);
                ItemOptions = _collection.GetItemOptions(_collection);
                itemFields = item.GetOptionsValues(item);
            }
            else // creating new instance
                
                item = new Item();

            return Page();
        }

        public IActionResult OnGetCreateItem(int id)
        {
            CollectionId = id;
            _collection = _repository.GetCollectionDetails(CollectionId);
            ItemOptions = _collection.GetItemOptions(_collection);
            item = new Item();
            itemFields = item.GetOptionsValues(item);
            return Page();
        }
        public IActionResult OnPostDelete()
        {
            _repository.DeleteItem(item.id);

            return RedirectToPage("Collections");
        }

        public IActionResult OnPost()
        {
            _collection = _repository.GetCollectionDetails(CollectionId);

            if (ModelState.IsValid)
            {
                if (Image != null)
                {
                        var response = ImageUploader.UploadImage(Image);
                        if (response.StatusCode == 200) // OK
                        {
                        item.imagePath = response.URL;
                        }
                }
                item.OwnerId = _userManager.GetUserId(User);
                if (item.id > 0) // edit
                {
                    item.CollectionId = CollectionId;
                    item = _repository.Update(item);
                }
                else // create
                {
                    item.CollectionId = CollectionId;
                    item.ParentCollection = _collection;
                    item.CreationDate = DateTime.Now;
                    item = _repository.Add(item);
                }

                return RedirectToPage("/Collections/Collections");
            }
            return Page();
        }
    }
}
