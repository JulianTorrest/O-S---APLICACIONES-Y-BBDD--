using System.Collections.Generic;
using System.Linq;
using CustomerAccessControl.Data;
using CustomerAccessControl.Models;

namespace CustomerAccessControl.Services
{
    public class EntryService
    {
        private readonly ApplicationDbContext _context;

        public EntryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void RegisterEntry(Entry entry)
        {
            _context.Entries.Add(entry);
            _context.SaveChanges();
        }

        // Additional methods for getting entries can be implemented here
    }
}

