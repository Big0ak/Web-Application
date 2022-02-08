using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_lab.Models;

namespace Web_lab.Services
{
    public class UserService:IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }
        public User GetById(Guid id)
        {
            return _context.Users.First(l => l.Id == id);
        }

        public bool Save(User user)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Edit(User user)
        {
            try
            {
                var entity = _context.Users.First(l => l.Id == user.Id);
                _context.Users.Remove(entity);
                _context.Users.Add(user);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(Guid Id)
        {
            try
            {
                var entity = _context.Users.First(l => l.Id == Id);
                _context.Users.Remove(entity);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

    public interface IUserService
    {
        List<User> GetAll();
        User GetById(Guid id);
        bool Save(User user);
        bool Edit(User user);
        bool Delete(Guid Id);
    }
}
