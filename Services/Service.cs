using Microsoft.AspNetCore.Http;
using PratamaHotel.Models;
using PratamaHotel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PratamaHotel.Services
{
    public class Service : IService
    {
        private readonly IRepository _repository;
        private readonly FileService _file;

        public Service(IRepository r, FileService f)
        {
            _repository = r;
            _file = f;
        }

        public bool CreateEmployee(Employee data, IFormFile file)
        {
            DateTime date = DateTime.Now;
            long iDate = long.Parse(date.ToString("yyyyMMddHHmmss")) - 19000000;
            data.id = iDate.ToString();
            data.image = _file.SaveFile(file).Result;
            data.role = _repository.GetRoleByIDAsync(2).Result;

            return _repository.CreateEmployeeAsync(data).Result;
        }

        public List<Employee> GetAllEmployee()
        {
            return _repository.GetAllEmployeeAsync().Result;
        }

        public Employee GetEmployeeByID(string id)
        {
            return _repository.GetEmployeeByIDAsync(id).Result;
        }

        public Employee GetEmployeeByIDAndPassword(string id, string password)
        {
            return _repository.GetEmployeeByIDAndPasswordAsync(id, password).Result;
        }
    }
}
