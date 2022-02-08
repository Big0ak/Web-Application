using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_lab.Models;

namespace Web_lab.Services
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _context;

        public OrderService(AppDbContext context)
        {
            _context = context;
        }

        public List<Order> GetAll()
        {
            return _context.CurrentOrder.ToList();
        }
        public Order GetById(Guid id)
        {
            return _context.CurrentOrder.First(l => l.Id == id);
        }

        public bool Save (Order order)
        {
            try
            {
                _context.CurrentOrder.Add(order);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Edit(Order order)
        {
            try
            {
                var entity = _context.CurrentOrder.First(l => l.Id == order.Id);
                _context.CurrentOrder.Remove(entity);
                _context.CurrentOrder.Add(order);
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
                var entity = _context.CurrentOrder.First(l => l.Id == Id);
                _context.CurrentOrder.Remove(entity);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

    public interface IOrderService
    {
        List<Order> GetAll();
        Order GetById(Guid id);
        bool Save(Order order);
        bool Edit(Order order);
        bool Delete(Guid Id);
    }
}
