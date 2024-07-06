using System.Collections.Generic;
using System.Linq;
using CustomerAccessControl.Data;
using CustomerAccessControl.Models;

namespace CustomerAccessControl.Services
{
    public class CenterService
    {
        private readonly ApplicationDbContext _context;

        public CenterService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Center> GetAllCenters()
        {
            return _context.Centers.ToList();
        }

        public Center GetCenterById(int id)
        {
            return _context.Centers.Find(id);
        }

        public Center CreateCenter(Center center)
        {
            _context.Centers.Add(center);
            _context.SaveChanges();
            return center;
        }

        public void UpdateCenter(int id, Center centerIn)
        {
            var center = _context.Centers.Find(id);
            if (center != null)
            {
                center.Name = centerIn.Name;
                _context.SaveChanges();
            }
        }

        public void DeleteCenter(int id)
        {
            var center = _context.Centers.Find(id);
            if (center != null)
            {
                _context.Centers.Remove(center);
                _context.SaveChanges();
            }
        }
    }
}

