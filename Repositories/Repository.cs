using Microsoft.EntityFrameworkCore;
using PratamaHotel.Data;
using PratamaHotel.Models;
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

        public async Task<List<Employee>> GetAllEmployeeAsync()
        {
            return await _context.Employees.Include(x => x.role).ToListAsync();
        }

        public async Task<Employee> GetEmployeeByIDAsync(string id)
        {
            return await _context.Employees.Include(x => x.role).FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<Employee> GetEmployeeByIDAndPasswordAsync(string id, string password)
        {
            return await _context.Employees.Include(x => x.role).FirstOrDefaultAsync(x => x.id == id && x.password == password);
        }

        public async Task<bool> CreateEmployeeAsync(Employee data)
        {
            _context.Employees.Add(data);
            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<Role> GetRoleByIDAsync(int id)
        {
            return await _context.Roles.FirstOrDefaultAsync(x=>x.id == id);
        }

        public async Task<List<Role>> GetAllRoleAsync()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<bool> UpdateEmployeeAsync(Employee data)
        {
            _context.Employees.Update(data);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteEmployeeAsync(Employee data)
        {
            _context.Employees.Remove(data);
            await _context.SaveChangesAsync();
            return true;
        }

        //RoomType
        public async Task<List<RoomType>> GetRoomTypeAsync()
        {
            return await _context.RoomTypes.ToListAsync();
        }

        public async Task<RoomType> GetRoomTypeByIDAsync(string id)
        {
            return await _context.RoomTypes.FindAsync(id);
        }

        public async Task<bool> CreateRoomTypeAsync(RoomType data)
        {
            _context.RoomTypes.Add(data);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateRoomTypeAsync(RoomType data)
        {
            _context.RoomTypes.Update(data);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteRoomTypeAsync(RoomType data)
        {
            _context.RoomTypes.Remove(data);
            await _context.SaveChangesAsync();
            return true;
        }

        
    }
}
