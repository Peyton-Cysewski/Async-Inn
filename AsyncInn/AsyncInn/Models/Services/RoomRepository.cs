using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Services
{
    public class RoomRepository : IRoom
    {
        private AsyncInnDbContext _context;

        public RoomRepository(AsyncInnDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a new Room
        /// </summary>
        /// <param name="room">Room being added</param>
        /// <returns>Task of completion</returns>
        public async Task<Room> Create(Room room)
        {
            _context.Entry(room).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return room;
        }

        /// <summary>
        /// Removes a specific Room
        /// </summary>
        /// <param name="id">Unique identifier of the Room</param>
        /// <returns>Task of completion</returns>
        public async Task Delete(int id)
        {
            Room room = await GetRoom(id);
            _context.Entry(room).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Gets a specific Room
        /// </summary>
        /// <param name="id">Unique identifier of the Room</param>
        /// <returns>Task of completion</returns>
        public async Task<Room> GetRoom(int id)
        {
            Room room = await _context.Rooms.FindAsync(id);
            return room;
        }

        /// <summary>
        /// Gets all Rooms
        /// </summary>
        /// <returns>Task of completion</returns>
        public async Task<List<Room>> GetRooms()
        {
            var rooms = await _context.Rooms.ToListAsync();
            return rooms;
        }

        /// <summary>
        /// Updates a specific Room
        /// </summary>
        /// <param name="id">Unique identifier of the Room</param>
        /// <returns>Task of completion</returns>
        public async Task<Room> Update(Room room)
        {
            _context.Entry(room).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return room;
        }

        /// <summary>
        /// Adds a specific RoomAmenity to a specific Room
        /// </summary>
        /// <param name="amenityId">Unique identifier of the Amenity</param>
        /// <param name="roomId">Unique identifier of the Room</param>
        /// <returns>Task of completion</returns>
        public async Task AddRoomAmenities(int amenityId, int roomId)
        {
            RoomAmenities roomAmenity = new RoomAmenities()
            {
                AmenityId = amenityId,
                RoomId = roomId
            };

            _context.Entry(roomAmenity).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Removes a specific RoomAmenity from a specific Room
        /// </summary>
        /// <param name="amenityId">Unique identifier of the Amenity</param>
        /// <param name="roomId">Unique identifier of the Room</param>
        /// <returns>Task of completion</returns>
        public async Task RemoveRoomAmenity(int amenityId, int roomId)
        {
            var result = _context.RoomAmenities.FirstOrDefaultAsync(x => x.AmenityId == amenityId && x.RoomId == roomId);
            _context.Entry(result).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
