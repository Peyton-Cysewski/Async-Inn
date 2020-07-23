using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IHotel
    {
        // Create
        Task<Hotel> Create(Hotel hotel);
        // Read
        Task<List<Hotel>> GetHotels(); // all
        Task<Hotel> GetHotel(int id); // individual
        // Update
        Task<Hotel> Update(Hotel hotel);
        // Delete
        Task Delete(int id);
    }
}
