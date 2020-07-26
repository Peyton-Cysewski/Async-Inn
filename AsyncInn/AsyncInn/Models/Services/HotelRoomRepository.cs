using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
        public async Task<HotelRoom> Create(HotelRoom hotelRoom, int hotelId)
        {
            hotelRoom.HotelId = hotelId;
            _context.Entry(hotelRoom).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return hotelRoom;
        }

        /// <summary>
        /// Removes a specific HotelRoom
        /// </summary>
        /// <param name="hotelId">Unique Hotel indentifier</param>
        /// <param name="roomNumber">Unique identifier per Hotel</param>
        /// <returns>Task of completion</returns>
        public async Task Delete(int hotelId, int roomNumber)
        {
            HotelRoom hotelRoom = await GetHotelRoom(hotelId, roomNumber);
            _context.Entry(hotelRoom).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Gets a specific HotelRoom
        /// </summary>
        /// <param name="hotelId">Unique Hotel identifier</param>
        /// <param name="roomNumber">Unique identifier per Hotel</param>
        /// <returns>Task of completion</returns>
        public async Task<HotelRoom> GetHotelRoom(int hotelId, int roomNumber)
        {
            HotelRoom hotelRoom = await _context.HotelRooms.FirstOrDefaultAsync(x => x.HotelId == hotelId && x.RoomNumber == roomNumber);
            var rooms = await _context.Rooms.Where(x => x.Id == hotelRoom.RoomId).Include(x => x.RoomAmenities).ToListAsync();
            hotelRoom.Room = rooms;
            //var hotel = await _context.Hotels.FirstOrDefaultAsync(x => x.Id == hotelId);
            //hotelRoom.Hotel = hotel;
            return hotelRoom;
        }

        /// <summary>
        /// Gets all HotelRooms
        /// </summary>
        /// <param name="hotelId">Unique Hotel identifier</param>
        /// <returns>task of completion</returns>
        public async Task<List<HotelRoom>> GetHotelRooms(int hotelId)
        {
            var hotelRooms = await _context.HotelRooms.Where(x => x.HotelId == hotelId).Include(x => x.Room).ToListAsync();
            return hotelRooms;
        }

        /// <summary>
        /// Updates a specific HotelRoom
        /// </summary>
        /// <param name="hotelId">Unique Hotel indentifier</param>
        /// <param name="roomNumber">Unique identifier per Hotel</param>
        /// <param name="hotelRoom">The HotelRoom being updated</param>
        /// <returns>Task of completion</returns>
        public async Task<HotelRoom> Update(int hotelId, int roomNumber, HotelRoom hotelRoom)
        {
            hotelRoom.HotelId = hotelId;
            hotelRoom.RoomNumber = roomNumber;
            _context.Entry(hotelRoom).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return hotelRoom;
        }
    }
}
