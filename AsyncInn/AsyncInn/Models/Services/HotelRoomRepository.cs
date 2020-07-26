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

        public async Task<HotelRoom> Create(HotelRoom hotelRoom, int hotelId)
        {
            hotelRoom.HotelId = hotelId;
            _context.Entry(hotelRoom).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return hotelRoom;
        }

        public async Task Delete(int hotelId, int roomNumber)
        {
            HotelRoom hotelRoom = await GetHotelRoom(hotelId, roomNumber);
            _context.Entry(hotelRoom).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<HotelRoom> GetHotelRoom(int hotelId, int roomNumber)
        {
            HotelRoom hotelRoom = await _context.HotelRooms.FirstOrDefaultAsync(x => x.HotelId == hotelId && x.RoomNumber == roomNumber);
            var rooms = await _context.Rooms.Where(x => x.Id == hotelRoom.RoomId).Include(x => x.RoomAmenities).ToListAsync();
            hotelRoom.Room = rooms;
            //var hotel = await _context.Hotels.FirstOrDefaultAsync(x => x.Id == hotelId);
            //hotelRoom.Hotel = hotel;
            return hotelRoom;
        }

        public async Task<List<HotelRoom>> GetHotelRooms(int hotelId)
        {
            var hotelRooms = await _context.HotelRooms.Where(x => x.HotelId == hotelId).Include(x => x.Room).ToListAsync();
            return hotelRooms;
        }

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
