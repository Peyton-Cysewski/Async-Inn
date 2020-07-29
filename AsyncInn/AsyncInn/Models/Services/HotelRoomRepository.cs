                            using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Models.DTOs;

namespace AsyncInn.Models.Services
{
    public class HotelRoomRepository : IHotelRoom
    {

        private AsyncInnDbContext _context;

        public HotelRoomRepository(AsyncInnDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a new HotelRoom
        /// </summary>
        /// <param name="hotelRoom">HotelRoom being added</param>
        /// <param name="hotelId">Unique Hotel identifier</param>
        /// <returns>Task of completion</returns>
        public async Task<HotelRoomDTO> Create(HotelRoomDTO dto, int hotelId)
        {
            HotelRoom hotelRoom = new HotelRoom()
            {
                HotelId = dto.HotelID,
                RoomId = dto.RoomID,
                Rate = dto.Rate,
                RoomNumber = dto.RoomNumber,
                PetFriendly = dto.PetFriendly
            };
            _context.Entry(hotelRoom).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return dto;
        }

        /// <summary>
        /// Removes a specific HotelRoom
        /// </summary>
        /// <param name="hotelId">Unique Hotel indentifier</param>
        /// <param name="roomNumber">Unique identifier per Hotel</param>
        /// <returns>Task of completion</returns>
        public async Task Delete(int hotelId, int roomNumber)
        {
            HotelRoom hotelRoom = await _context.HotelRooms
                                .FirstOrDefaultAsync(x => x.HotelId == hotelId && x.RoomNumber == roomNumber);
            _context.Entry(hotelRoom).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Gets a specific HotelRoom
        /// </summary>
        /// <param name="hotelId">Unique Hotel identifier</param>
        /// <param name="roomNumber">Unique identifier per Hotel</param>
        /// <returns>Task of completion</returns>
        public async Task<HotelRoomDTO> GetHotelRoom(int hotelId, int roomNumber)
        {
            var hotelRoom = await _context.HotelRooms.Where(x => x.HotelId == hotelId && x.RoomNumber == roomNumber)
                                                        .Include(x => x.Room)
                                                        .ThenInclude(x => x.RoomAmenities)
                                                        .ThenInclude(x => x.Amenity)
                                                        .Include(x => x.Hotel)
                                                        .FirstOrDefaultAsync();
            HotelRoomDTO dto = new HotelRoomDTO()
            {
                HotelID = hotelRoom.HotelId,
                RoomNumber = hotelRoom.RoomNumber,
                Rate = hotelRoom.Rate,
                PetFriendly = hotelRoom.PetFriendly,
                RoomID = hotelRoom.RoomId,
                Room = await new RoomRepository(_context).GetRoom(hotelRoom.RoomId)
            };
            return dto;
        }

        /// <summary>
        /// Gets all HotelRooms
        /// </summary>
        /// <param name="hotelId">Unique Hotel identifier</param>
        /// <returns>task of completion</returns>
        public async Task<List<HotelRoomDTO>> GetHotelRooms(int hotelId)
        {
            var list = await _context.HotelRooms.Where(x => x.HotelId == hotelId).Include(x => x.Room).ToListAsync();
            var hotelRooms = new List<HotelRoomDTO>();
            foreach (var room in list)
            {
                hotelRooms.Add(await GetHotelRoom(room.HotelId, room.RoomNumber));
            }
            return hotelRooms;
        }

        /// <summary>
        /// Updates a specific HotelRoom
        /// </summary>
        /// <param name="hotelId">Unique Hotel indentifier</param>
        /// <param name="roomNumber">Unique identifier per Hotel</param>
        /// <param name="hotelRoom">The HotelRoom being updated</param>
        /// <returns>Task of completion</returns>
        public async Task Update(int hotelId, int roomNumber, HotelRoomDTO dto)
        {
            var hotelRoom = new HotelRoom()
            {
                HotelId = hotelId,
                RoomId = dto.RoomID,
                RoomNumber = dto.RoomNumber,
                Rate = dto.Rate,
                PetFriendly = dto.PetFriendly
            };
            _context.Entry(hotelRoom).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
