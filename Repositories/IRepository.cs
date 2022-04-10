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

        //RoomType
        Task<List<RoomType>> GetRoomTypeAsync();
        Task<RoomType> GetRoomTypeByIDAsync(string id);
        Task<bool> CreateRoomTypeAsync(RoomType data);
        Task<bool> UpdateRoomTypeAsync(RoomType data);
        Task<bool> DeleteRoomTypeAsync(RoomType data);

        //Room
        Task<List<Room>> GetRoomAsync();
        Task<Room> GetRoomByIDAsync(string idRoom);
        Task<bool> CreateRoomAsync(Room data);
        Task<bool> UpdateRoomAsync(Room data);
        Task<bool> DeleteRoomAsync(Room data);

        //Guest
        Task<List<Guest>> GetGuestAsync();
        Task<Guest> GetGuestByIDAsync(int id);
        Task<bool> CreateGuestAsync(Guest data);
        Task<bool> UpdateGuestAsync(Guest data);
        Task<bool> DeleteGuestAsync(Guest data);
    }
}
