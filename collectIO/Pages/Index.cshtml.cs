using collectIO.Models;
using collectIO.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace collectIO.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ICollectionRepository _repository;
        private readonly UserManager<AppUser> _userManager;
        public Collection _collection = new Collection();
        public IEnumerable<Collection> AllCollections { get; set; }
        public IEnumerable<Item> LastItems { get; set; }

        public Item _item = new Item();

        public string title { get; set; }
        public IndexModel(ILogger<IndexModel> logger, ICollectionRepository collectionRepository, UserManager<AppUser> userManager)
        {
            _logger = logger;
            _repository = collectionRepository;
            _userManager = userManager;
        }

        public void OnGet()
        {
            LastItems = GetLastAddedItems();
            AllCollections = _repository.GetAllCollections();
        }
        public IEnumerable<Item> GetLastAddedItems()
        {
            return _repository.GetAllItems().Where(s => s.CreationDate > DateTime.Now.AddDays(-2));
        }
        public int GetItemsCount(Collection collection)
        {
            return _repository.GetAllCollectionItems(collection.id).Count();
        }
    }
}
