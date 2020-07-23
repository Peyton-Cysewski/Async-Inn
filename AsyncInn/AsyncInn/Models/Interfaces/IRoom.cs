using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IRoom
    {
        // Create
        Task<Room> Create(Room room);
        // Read
        Task<List<Room>> GetRooms(); // all
        Task<Room> GetRoom(int id); // individual
        // Update
        Task<Room> Update(Room room);
        // Delete
        Task Delete(int id);
    }
}
