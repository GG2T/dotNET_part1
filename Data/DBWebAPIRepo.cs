using _335a1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace _335a1.Data
{

    public class DBWebAPIRepo : IWebAPIRepo
    {
        private readonly WebAPIDBContext _dbContext;

        public DBWebAPIRepo(WebAPIDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Staff GetCard(int id)
        {
            return _dbContext.Staffs.FirstOrDefault(a => a.Id == id);
        }

        public Staff GetStaffByID(int id)
        {
            Staff Staffs = _dbContext.Staffs.FirstOrDefault(a => a.Id == id);
            return Staffs;
        }

        public IEnumerable<Staff> GetStaffs()
        {
            IEnumerable<Staff> Staffs = _dbContext.Staffs.ToList<Staff>();
            return Staffs;
        }


       

        public IEnumerable<Product> GetItems()
        {
            return _dbContext.Products.ToList<Product>();

        }

        public IEnumerable<Product> GetItems(string letter)
        {
            return _dbContext.Products.Where(a => a.Name.Contains(letter) || a.Name.Contains(letter.ToUpper()) || a.Name.Contains(letter.ToLower()));
        }

        public Product GetItemByID(int id)
        {
            Product Products= _dbContext.Products.FirstOrDefault(a => a.Id == id);
            return Products;
        }

        public Comment WriteComment(Comment comments)
        {
            //similiar to AddCustomer
            EntityEntry<Comment> e = _dbContext.Comments.Add(comments);
            Comment c = e.Entity;
            _dbContext.SaveChanges();
            return c;
        }

        public IEnumerable<Comment> GetComments()
        {
            //similar to GetAllStaff
            IEnumerable<Comment> comments = _dbContext.Comments.ToList();
            return comments.Reverse();
           
        }
        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
    }
