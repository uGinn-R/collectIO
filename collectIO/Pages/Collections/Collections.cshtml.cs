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
    public class CollectionsModel : PageModel
    {
        private readonly ICollectionRepository _db;
        private readonly UserManager<AppUser> _userManager;
        public CollectionsModel(ICollectionRepository db, UserManager<AppUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        public IEnumerable<Collection> collection { get; set; }
        //public IEnumerable<Item> collectionItem { get; set; }
        public void OnGet()
        {

            //    collection = _db.GetMyCollections(_userManager.GetUserId(User));

                collection = _db.GetAllCollections();
            
            //collectionItem = _db.GetAllItems();
        }
        public int GetItemsCount(Collection collection)
        {
            return _db.GetAllCollectionItems(collection.id).Count();
        }

    }
}
