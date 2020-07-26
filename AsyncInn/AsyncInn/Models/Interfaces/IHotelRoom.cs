using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IHotelRoom
    {
        Task<HotelRoom> Create(HotelRoom hotelRoom, int hotelId);
        Task<List<HotelRoom>> GetHotelRooms(int hotelId);
        Task<HotelRoom> GetHotelRoom(int hotelId, int roomNumber);
        Task<HotelRoom> Update(int hotelId, int roomNumber, HotelRoom hotelRoom);
        Task Delete(int hotelId, int roomNumber);
    }
}
