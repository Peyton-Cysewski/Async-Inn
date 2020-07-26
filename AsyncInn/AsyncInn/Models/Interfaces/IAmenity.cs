using AsyncInn.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IAmenity
    {
        /// <summary>
        /// Adds an Amenity
        /// </summary>
        /// <param name="amenity">Unique Amenity identifier</param>
        /// <returns>Task of completion</returns>
        Task<Amenity> Create(Amenity amenity);

        /// <summary>
        /// Gets all Amenities
        /// </summary>
        /// <returns>Task of completion</returns>
        Task<List<Amenity>> GetAmenities();

        /// <summary>
        /// Gets a specific Amenity
        /// </summary>
        /// <param name="id">Unique Amenity identifier</param>
        /// <returns>Task of completion</returns>
        Task<Amenity> GetAmenity(int id);

        /// <summary>
        /// Updates a specific Amenity
        /// </summary>
        /// <param name="amenity">Unique Amenity identifier</param>
        /// <returns>Task of completion</returns>
        Task<Amenity> Update(Amenity amenity);

        /// <summary>
        /// Removes a specific Amenity
        /// </summary>
        /// <param name="id">unique Amenity identifier</param>
        /// <returns>Task of completion</returns>
        Task Delete(int id);
    }
}
