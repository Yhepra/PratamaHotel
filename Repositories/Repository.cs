using PratamaHotel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PratamaHotel.Repositories
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _context;

        public Repository (AppDbContext context)
        {
            _context = context;
        }
    }
}
