using collectIO.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace collectIO.Services
{
    public class SQLCollectionRepository : ICollectionRepository
    {
        private readonly AppDbContext _context;
        public SQLCollectionRepository(AppDbContext context)
        {
            _context = context;
        }
        public Collection Add(Collection newCollection)
        {
            _context.Collections.Add(newCollection);
            _context.SaveChanges();
            return newCollection;
        }

        public Item Add(Item newItem)
        {
            _context.Items.Add(newItem);
            _context.SaveChanges();
            return newItem;
        }

        public void DeleteCollection(int Id)
        {
           var toDelete = _context.Collections.Find(Id);
            if (toDelete != null)
            {
                _context.Collections.Remove(toDelete);
                _context.SaveChanges();
            }
        }

        public void DeleteItem(int Id)
        {
            var toDelete = _context.Items.Find(Id);
            if (toDelete != null)
            {
                _context.Items.Remove(toDelete);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Collection> GetAllCollections()
        {
            if (_context.Collections.CountAsync().Result == 0)
            {
                _context.Database.ExecuteSqlRaw("DBCC CHECKIDENT('Collections', RESEED)"); // reset id counter
            }
            return _context.Collections;
        }

        public IEnumerable<Item> GetAllItems()
        {
            if (_context.Items.CountAsync().Result == 0)
            {
                _context.Database.ExecuteSqlRaw("DBCC CHECKIDENT('Items', RESEED)"); // reset id counter
            }
            return _context.Items;
        }

        public Collection GetCollectionDetails(int Id)
        {
            return _context.Collections.Find(Id);
        }

        public Item GetItemDetails(int Id)
        {
            //return _context.Items.Find(Id);
            return _context.Items.Where(s => s.id == Id).FirstOrDefault();
        }

        public Collection Update(Collection updatedCollection)
        {
            var collection = _context.Collections.Attach(updatedCollection);
            collection.State = EntityState.Modified;
            _context.SaveChanges();
            return updatedCollection;
        }

        public Item Update(Item updatedItem)
        {
            var item = _context.Items.Attach(updatedItem);
            item.State = EntityState.Modified;
            _context.SaveChanges();
            return updatedItem;
        }

        public IEnumerable<Item> GetAllCollectionItems(int Id)
        {
            return  _context.Items.Where(s => s.ParentCollection.id == Id).ToList();
        }

        public IEnumerable<Collection> GetMyCollections(string userId)
        {
            return _context.Collections.Where(s => s.CollectionAuthorID == userId).ToList();
        }

        public IEnumerable<Comment> GetComments(int Id)
        {
            return _context.Comments.Where(s => s.CommentedItem.id == Id).ToList();
        }

        public Comment Add(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
            return comment;
        }

        public Like Add(Like newLiked)
        {
            _context.Likes.Add(newLiked);
            _context.SaveChanges();
            return newLiked;
        }

        public void DeleteLike(int ItemId)
        {
            var toDelete = _context.Likes.Where(i => i.ItemId== ItemId).FirstOrDefault();
            if (toDelete != null)
            {
                _context.Likes.Remove(toDelete);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Like> GetAllLikes()
        {
            return _context.Likes;
        }
    }
}
