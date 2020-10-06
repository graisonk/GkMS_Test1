using GkMS_Test1.Users.Data.Context;
using GkMS_Test1.Users.Domain.Interfaces;
using GkMS_Test1.Users.Domain.Models;
using GkMS_Test1.Users.Domain.ViewModels;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GkMS_Test1.Users.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _context;

        public UserRepository(UserDbContext context)
        {
            _context = context;
        }

        public void AddUser(UserVM profile)
        {
            //using (IDbContextTransaction transaction = _context.Database.BeginTransaction())
            //{
            try
            {
                _context.Users.Add(profile.User);
                _context.SaveChanges();

                profile.Personal.UserId = profile.User.Id;
                _context.Personals.Add(profile.Personal);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                //transaction.Rollback();
                throw;
            }
            //}
        }

        public void DeleteUser(int id)
        {
            User user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        public UserVM GetUser(int id)
        {
            UserVM profile = new UserVM
            {
                User = _context.Users.Find(id),
                Personal = _context.Personals.Single(p => p.UserId == id)
            };
            return profile;
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users;
        }

        public void ModifyUser(int id, UserVM profile)
        {
            if (id == profile.User.Id)
            {
                _context.Users.Update(profile.User);
                _context.Personals.Update(profile.Personal);
                _context.SaveChanges();
            }
        }
    }
}
