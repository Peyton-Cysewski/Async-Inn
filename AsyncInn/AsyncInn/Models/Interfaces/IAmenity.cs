using AsyncInn.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IAmenity
    {
        // Create
        Task<Amenity> Create(Amenity amenity);
        // Read
        Task<List<Amenity>> GetAmenities(); // all
        Task<Amenity> GetAmenity(int id); // individual
        // Update
        Task<Amenity> Update(Amenity amenity);
        // Delete
        Task Delete(int id);
    }
}
