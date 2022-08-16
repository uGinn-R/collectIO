using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using collectIO.Models;
using collectIO.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace collectIO.Pages.Items
{
    public class ItemDetailsModel : PageModel
    {
        private readonly ICollectionRepository _repository;
        private readonly UserManager<AppUser> _userManager;

        public ItemDetailsModel(ICollectionRepository repository, UserManager<AppUser> userManager)
        {
            _repository = repository;
            _userManager = userManager;
        }
        [BindProperty]
        public Item _Item { get; set; }
        public Collection _Collection { get; set; }
        public string buttonStyle { get; set; }
        public bool  AlreadyLiked { get; set; }
        public int LikesCount { get; set; }
        public AppUser thisUser { get; set; }
        public Dictionary<string, object> ItemDetails = new Dictionary<string, object>();

        public IEnumerable<Comment> ItemComments { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            thisUser = await _userManager.GetUserAsync(User);
            _Item = _repository.GetItemDetails(id);
            _Collection = _repository.GetCollectionDetails(_Item.CollectionId);
            ItemDetails = GetItemDetails(_Collection, _Item);
            ItemComments = _repository.GetComments(id);
            IEnumerable<Like> likes = _repository.GetAllLikes();
            if (_Item != null)
            {
                if (User.Identity.IsAuthenticated)
                {
                    var myLikes = likes.Where(i => i.UserId == thisUser.Id).ToList().Where(x => x.ItemId == _Item.id);
                    AlreadyLiked = myLikes.Count() > 0 ? true : false;
                    LikesCount = likes.Where(x => x.ItemId == _Item.id).ToList().Count();
                }
                
                return Page();
            }
            else return RedirectToPage("/Collections/Collections");
        }
        public Dictionary<string, object> GetItemDetails(Collection col, Item itm)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            Dictionary<string,string> opts1 = col.GetItemOptions(col);
            Dictionary<object, object> opts2 = itm.GetOptionsValues(itm);
            foreach (var item in opts1)
            {
                foreach (var item2 in opts2)
                {
                    if (item.Value == item2.Key.ToString())
                    {
                        result.Add(item.Key, item2.Value);
                    }
                }
            }
            return result;
        }
        public IActionResult OnPostDelete(int ItemId)
        {
            _Item = _repository.GetItemDetails(ItemId);
            TempData["CollectionIDYouCameFrom"] = _Item.CollectionId;
            _repository.DeleteItem(ItemId);

            return RedirectToPage("/Collections/CollectionDetails");
        }
        public async Task<IActionResult> OnGetLikeItem(int id)
        {

            ItemComments = _repository.GetComments(id);
            _Item = _repository.GetItemDetails(id);
            thisUser = await _userManager.GetUserAsync(User);
            IEnumerable<Like> likes = _repository.GetAllLikes();
            
            Like newLike = new Like
            {
                UserId = thisUser.Id,
                ItemId = _Item.id
            };
            if (likes.Count() > 0)
            {
                var myLikes = likes.Where(i => i.UserId == thisUser.Id).ToList().Where(x => x.ItemId == _Item.id);
                if (myLikes.Count() > 0) // exist
                {
                    _repository.DeleteLike(_Item.id);
                    return Page();
                }
                else
                {
                    _repository.Add(newLike);
                    return Page();
                }
            }
            else
            {
                _repository.Add(newLike);
                return Page();
            }
        }
        public async Task OnGetAddComment(string message, int ItemId)
        {
            thisUser = await _userManager.GetUserAsync(User);
            _Item = _repository.GetItemDetails(ItemId);
            ItemComments = _repository.GetComments(ItemId);
           
            Comment newComment = new Comment() 
            { 
                Text = message,
                Created = DateTime.Now,
                CommentedItem = _Item,
                CommentAuthor = thisUser.UserName
            };

            _repository.Add(newComment);
        }
    }
}
