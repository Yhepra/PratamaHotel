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

        public Service(IRepository r)
        {
            _repository = r;
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
