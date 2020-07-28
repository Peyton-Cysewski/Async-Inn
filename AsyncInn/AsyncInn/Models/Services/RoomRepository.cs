using AsyncInn.Data;
using AsyncInn.Models.DTOs;
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
        public async Task<RoomDTO> Create(RoomDTO dto)
        {
            Room room = new Room()
            {
                Name = dto.Name,
                Layout = dto.Layout
            };
            _context.Entry(room).State = EntityState.Added;
            await _context.SaveChangesAsync();
            dto.ID = room.Id;
            return dto;
        }

        /// <summary>
        /// Removes a specific Room
        /// </summary>
        /// <param name="id">Unique identifier of the Room</param>
        /// <returns>Task of completion</returns>
        public async Task Delete(int id)
        {
            Room room = await _context.Rooms.FindAsync(id);
            _context.Entry(room).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Gets a specific Room
        /// </summary>
        /// <param name="id">Unique identifier of the Room</param>
        /// <returns>Task of completion</returns>
        public async Task<RoomDTO> GetRoom(int id)
        {
            Room room = await _context.Rooms.FindAsync(id);
            RoomDTO dto = new RoomDTO()
            {
                ID = room.Id,
                Name = room.Name,
                Layout = room.Layout
            };
            //var roomAmenity = await _context.RoomAmenities.Where(x => x.RoomId == id).Include(x => x.Amenity).ToListAsync();
            //room.RoomAmenities = roomAmenity;
            return dto;
        }

        /// <summary>
        /// Gets all Rooms
        /// </summary>
        /// <returns>Task of completion</returns>
        public async Task<List<RoomDTO>> GetRooms()
        {
            var list = await _context.Rooms.ToListAsync();
            var rooms = new List<RoomDTO>();
            foreach(var item in list)
            {
                rooms.Add(await GetRoom(item.Id));
            }
            return rooms;
        }

        /// <summary>
        /// Updates a specific Room
        /// </summary>
        /// <param name="id">Unique identifier of the Room</param>
        /// <returns>Task of completion</returns>
        public async Task<Room> Update(RoomDTO dto)
        {
            Room room = new Room()
            {
                Id = dto.ID,
                Name = dto.Name,
                Layout = dto.Layout
            };
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
