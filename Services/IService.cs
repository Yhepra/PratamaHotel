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
        bool UpdateEmployee(Employee data, IFormFile file);
        bool DeleteEmployee(string id);

        List<Role> GetRoles();

        List<RoomType> GetRoomTypes();
        RoomType GetRoomTypeByID(string id);
        bool CreateRoomType(RoomType data);
        bool UpdateRoomType(RoomType data);
        bool DeleteRoomType(string data);

        //room
        List<Room> GetRoom();
        Room GetRoomByID(string id);
        bool CreateRoom(Room data);
        bool UpdateRoom(Room data);
        bool DeleteRoom(string data);
    }
}
