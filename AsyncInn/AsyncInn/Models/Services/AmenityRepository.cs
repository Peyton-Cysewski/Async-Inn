using AsyncInn.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncInn.Data;
using Microsoft.EntityFrameworkCore;

namespace AsyncInn.Models.Services
{
    public class AmenityRepository : IAmenity

    {
        private readonly AsyncInnDbContext _context;
        public AmenityRepository(AsyncInnDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds an Amenity
        /// </summary>
        /// <param name="amenity">Unique Amenity identifier</param>
        /// <returns>Task of completion</returns>
        public async Task<Amenity> Create(Amenity amenity)
        {
            _context.Entry(amenity).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return amenity;
        }

        /// <summary>
        /// Removes a specific Amenity
        /// </summary>
        /// <param name="id">unique Amenity identifier</param>
        /// <returns>Task of completion</returns>
        public async Task Delete(int id)
        {
            Amenity amenity = await GetAmenity(id);
            _context.Entry(amenity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Gets all Amenities
        /// </summary>
        /// <returns>Task of completion</returns>
        public async Task<List<Amenity>> GetAmenities()
        {
            var amenities = await _context.Amenities.ToListAsync();
            return amenities;
        }

        /// <summary>
        /// Gets a specific Amenity
        /// </summary>
        /// <param name="id">Unique Amenity identifier</param>
        /// <returns>Task of completion</returns>
        public async Task<Amenity> GetAmenity(int id)
        {
            Amenity amenity = await _context.Amenities.FindAsync(id);
            var roomAmenities = await _context.RoomAmenities.Where(x => x.AmenityId == id).Include(x => x.Room).ToListAsync();
            amenity.RoomAmenities = roomAmenities;
            return amenity;
        }

        /// <summary>
        /// Updates a specific Amenity
        /// </summary>
        /// <param name="amenity">Unique Amenity identifier</param>
        /// <returns>Task of completion</returns>
        public async Task<Amenity> Update(Amenity amenity)
        {
            _context.Entry(amenity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return amenity;
        }
    }
}
