using collectIO.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace collectIO.Services
{
    public class MockCollectionRepository : ICollectionRepository
    {
        private List<Collection> _collectionList;

        public MockCollectionRepository()
        {
            _collectionList = new List<Collection>()
            {
                new Collection()
                {
                    id = 1, Name = "Electronic", Description = "Electronic music albums", imagePath = "music.png", collectionType=CollectionType.Music
                },
                 new Collection()
                {
                    id = 2, Name = "Cinema", Description = "Favourite movies", imagePath = "movies.png", collectionType=CollectionType.Movies
                },
                  new Collection()
                {
                    id = 3, Name = "Readings", Description = "Books of choise", imagePath = "books.png", collectionType=CollectionType.Books
                },
                   new Collection()
                {
                    id = 4, Name = "Shooters", Description = "FPS Games", imagePath = "games.png", collectionType=CollectionType.Games
                },
                    new Collection()
                {
                    id = 5, Name = "My Collection", Description = "My own type of collecton", collectionType=CollectionType.None
                },
            };
        }

        public Collection Add(Collection newCollection)
        {
            newCollection.id = _collectionList.Max(x => x.id) + 1;
            _collectionList.Add(newCollection);
            return newCollection;
        }

        public Item Add(Item newItem)
        {
            throw new NotImplementedException();
        }

        public void Delete(int Id)
        {
            var collectionToDelete = _collectionList.FirstOrDefault(x => x.id == Id);
            _collectionList.Remove(collectionToDelete);
        }

        public void DeleteCollection(int Id)
        {
            throw new NotImplementedException();
        }

        public void DeleteItem(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> GetAllCollectionItems(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Collection> GetAllCollections()
        {
            return _collectionList;
        }

        public IEnumerable<Item> GetAllItems()
        {
            throw new NotImplementedException();
        }

        public Collection GetCollectionDetails(int Id)
        {
            return _collectionList.FirstOrDefault(x => x.id == Id);
        }

        public IEnumerable<Comment> GetComments(int id)
        {
            throw new NotImplementedException();
        }

        public Item GetItemDetails(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Collection> GetMyCollections(string userId)
        {
            throw new NotImplementedException();
        }

        public void LikeThisItem(int id)
        {
            throw new NotImplementedException();
        }

        public Collection Update(Collection updatedCollection)
        {
            Collection collection = _collectionList.FirstOrDefault(x => x.id == updatedCollection.id);
            if (collection != null)
            {
                collection.Name = updatedCollection.Name;
                collection.Description = updatedCollection.Description;
                collection.collectionType = updatedCollection.collectionType;
                collection.imagePath = updatedCollection.imagePath;

            }
            return collection;
        }

        public Item Update(Item updatedItem)
        {
            throw new NotImplementedException();
        }

        public Comment Add(Comment comment)
        {
            throw new NotImplementedException();
        }

        public int GetItemLikesCount(int id)
        {
            throw new NotImplementedException();
        }

        public Like Update(Like newLike)
        {
            throw new NotImplementedException();
        }

        public Like Add(Like newLiked)
        {
            throw new NotImplementedException();
        }

        public void DeleteLike(int ItemId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Like> GetAllLikes()
        {
            throw new NotImplementedException();
        }
    }
}

