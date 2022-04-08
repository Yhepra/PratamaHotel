using PratamaHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PratamaHotel.Repositories
{
    public interface IRepository
    {
        //Employee
        Task<bool> CreateEmployeeAsync(Employee data);
        Task<List<Employee>> GetAllEmployeeAsync();
        Task<Employee> GetEmployeeByIDAsync(string id);
        Task<Employee> GetEmployeeByIDAndPasswordAsync(string id, string password);
        Task<bool> UpdateEmployeeAsync(Employee data);
        Task<bool> DeleteEmployeeAsync(Employee data);

        //Role
        Task<List<Role>> GetAllRoleAsync();
        Task<Role> GetRoleByIDAsync(int id);
    }
}
