using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using collectIO.Services;
using collectIO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;

namespace collectIO.Pages.Collections
{
    public class CollectionDetailsModel : PageModel
    {
        private readonly ICollectionRepository _collectionRepository;
        private readonly UserManager<AppUser> _usermanager;
        public AppUser thisUser { get; set; }

        public string thisUserId { get; set; }

        public CollectionDetailsModel(ICollectionRepository collectionRepository, UserManager<AppUser> userManager)
        {
            _collectionRepository = collectionRepository;
            _usermanager = userManager;
        }
        public Collection Collection { get; private set; }
        public IEnumerable<Item> items { get; set; }
        public IActionResult OnGet(int Id)
        {
            if (TempData["CollectionIDYouCameFrom"] != null)
            {
                Id = (int)TempData["CollectionIDYouCameFrom"];
            }
            Collection = _collectionRepository.GetCollectionDetails(Id);
            items = _collectionRepository.GetAllCollectionItems(Id);
            thisUserId = _usermanager.GetUserId(User);

            if (Collection != null)
            {
                return Page();
            }
            else
                return RedirectToPage("/Index");
        }
    }
}
