using Microsoft.AspNetCore.Http;
using PratamaHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PratamaHotel.Services
{
    public interface IService
    {
        List<Employee> GetAllEmployee();
        Employee GetEmployeeByID(string id);
        Employee GetEmployeeByIDAndPassword(string id, string password);
        bool CreateEmployee(Employee data, IFormFile file);
    }
}
