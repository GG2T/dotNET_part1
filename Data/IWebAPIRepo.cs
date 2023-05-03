using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _335a1.Models;

namespace _335a1.Data
{
    public interface IWebAPIRepo
    {
        IEnumerable<Staff> GetStaffs();

        Staff GetStaffByID(int id);

        //Staff AddStaff(Staff Staffs);

        //void DeleteStaff(int Id);

        Staff GetCard(int id);

        IEnumerable<Product> GetItems();

        IEnumerable<Product> GetItems(string letter);

        Product GetItemByID(int id);


        Comment WriteComment(Comment Comment);

        IEnumerable<Comment> GetComments();


        

        void SaveChanges();

       


    }
}
