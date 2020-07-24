using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IRoom
    {
        /// <summary>
        /// Adds a new Room
        /// </summary>
        /// <param name="room">Room being added</param>
        /// <returns>Task of completion</returns>
        Task<Room> Create(Room room);

        /// <summary>
        /// Gets all Rooms
        /// </summary>
        /// <returns>Task of completion</returns>
        Task<List<Room>> GetRooms();

        /// <summary>
        /// Gets a specific Room
        /// </summary>
        /// <param name="id">Unique identifier of the Room</param>
        /// <returns>Task of completion</returns>
        Task<Room> GetRoom(int id);

        /// <summary>
        /// Updates a specific Room
        /// </summary>
        /// <param name="id">Unique identifier of the Room</param>
        /// <returns>Task of completion</returns>
        Task<Room> Update(Room room);

        /// <summary>
        /// Removes a specific Room
        /// </summary>
        /// <param name="id">Unique identifier of the Room</param>
        /// <returns>Task of completion</returns>
        Task Delete(int id);

        /// <summary>
        /// Adds a specific RoomAmenity to a specific Room
        /// </summary>
        /// <param name="amenityId">Unique identifier of the Amenity</param>
        /// <param name="roomId">Unique identifier of the Room</param>
        /// <returns>Task of Ccmpletion</returns>
        Task AddRoomAmenities(int amenityId, int roomId);

        /// <summary>
        /// Removes a specific RoomAmenity from a specific Room
        /// </summary>
        /// <param name="amenityId">Unique identifier of the Amenity</param>
        /// <param name="roomId">Unique identifier of the Room</param>
        /// <returns>Task of completion</returns>
        Task RemoveRoomAmenity(int amenityId, int roomId);
    }
}
