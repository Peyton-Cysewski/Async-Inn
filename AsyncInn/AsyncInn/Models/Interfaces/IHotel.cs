using AsyncInn.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IHotel
    {
        /// <summary>
        /// Adds a new Hotel
        /// </summary>
        /// <param name="hotel">Hotel being added</param>
        /// <returns>Task of completion</returns>
        Task<Hotel> Create(Hotel hotel);

        /// <summary>
        /// Gets all Hotels
        /// </summary>
        /// <returns>Task of completion</returns>
        Task<List<HotelDTO>> GetHotels();

        /// <summary>
        /// Gets a specific Hotel
        /// </summary>
        /// <param name="id">Unique Hotel identifier</param>
        /// <returns>Task of completion</returns>
        Task<HotelDTO> GetHotel(int id);

        /// <summary>
        /// Updates a specific Hotel
        /// </summary>
        /// <param name="hotel">Hotel being updated</param>
        /// <returns>Task of completion</returns>
        Task Update(Hotel hotel);

        /// <summary>
        /// Removes a specific Hotel
        /// </summary>
        /// <param name="id">Unique Hotel identifier</param>
        /// <returns>Task of completion</returns>
        Task Delete(int id);
    }
}
