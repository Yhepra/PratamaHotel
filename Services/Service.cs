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

        public List<Role> GetRoles()
        {
            return _repository.GetAllRoleAsync().Result;
            
        }

        //CREATE EMPLOYEE
        public bool CreateEmployee(Employee data, IFormFile file)
        {
            DateTime date = DateTime.Now;
            long iDate = long.Parse(date.ToString("yyyyMMddHHmmss")) - 19000000;
            data.id = iDate.ToString();
            data.image = _file.SaveFile(file).Result;

            return _repository.CreateEmployeeAsync(data).Result;
        }

        //UPDATE EMPLOYEE
        public bool UpdateEmployee(Employee data, IFormFile file)
        {
            data.image = _file.SaveFile(file).Result;
            
            return _repository.UpdateEmployeeAsync(data).Result; 
            
        }

        public bool DeleteEmployee(string id)
        {
            var search = _repository.GetEmployeeByIDAsync(id).Result;
            _repository.DeleteEmployeeAsync(search);
            return true;
        }

        //RoomType
        public List<RoomType> GetRoomTypes()
        {
            return _repository.GetRoomTypeAsync().Result;
        }

        public RoomType GetRoomTypeByID(string id)
        {
            return _repository.GetRoomTypeByIDAsync(id).Result;
        }

        public bool CreateRoomType(RoomType data)
        {
            data.numberOfRooms = 0;
            return _repository.CreateRoomTypeAsync(data).Result;
        }

        public bool UpdateRoomType(RoomType data)
        {
            return _repository.UpdateRoomTypeAsync(data).Result;
        }

        public bool DeleteRoomType(string id)
        {
            var search = _repository.GetRoomTypeByIDAsync(id).Result;
            _repository.DeleteRoomTypeAsync(search);
            return true;
        }

        // ROOM ///////////////////////////////////////////////////////////////////////////////////////////////////
        public List<Room> GetRoom()
        {
            return _repository.GetRoomAsync().Result;
        }

        public Room GetRoomByID(string id)
        {
            return _repository.GetRoomByIDAsync(id).Result;
        }

        public bool CreateRoom(Room data)
        {
            return _repository.CreateRoomAsync(data).Result;
        }

        public bool UpdateRoom(Room data)
        {
            return _repository.UpdateRoomAsync(data).Result;
        }

        public bool DeleteRoom(string data)
        {
            var search = _repository.GetRoomByIDAsync(data).Result;
            _repository.DeleteRoomAsync(search);
            return true;
        }
    }
}
