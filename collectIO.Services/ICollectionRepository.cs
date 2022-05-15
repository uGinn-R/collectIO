using System;
using System.Collections.Generic;
using System.Text;
using collectIO.Models;

namespace collectIO.Services
{
    public interface ICollectionRepository
    {
        IEnumerable<Collection> GetAllCollections();

        Collection GetCollectionDetails(int Id);

        Collection Update(Collection updatedCollection);

        Collection Add(Collection newCollection);

        void DeleteCollection(int Id);

        Item Add(Item newItem);

        IEnumerable<Item> GetAllItems();

        IEnumerable<Item> GetAllCollectionItems(int Id);

        Item GetItemDetails(int Id);

        Item Update(Item updatedItem);

        Comment Add(Comment comment);

        void DeleteItem(int Id);
        IEnumerable<Collection> GetMyCollections(string userId);
        IEnumerable<Comment> GetComments(int id);
        Like Add(Like newLiked);
        void DeleteLike(int ItemId);
        IEnumerable<Like> GetAllLikes();

    }
}
