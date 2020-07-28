using AsyncInn.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncInn.Data;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Models.DTOs;

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
        public async Task<AmenityDTO> Create(AmenityDTO dto)
        {
            Amenity amenity = new Amenity()
            {
                Name = dto.Name
            };
            _context.Entry(amenity).State = EntityState.Added;
            await _context.SaveChangesAsync();
            dto.ID = amenity.Id;
            return dto;
        }

        /// <summary>
        /// Removes a specific Amenity
        /// </summary>
        /// <param name="id">unique Amenity identifier</param>
        /// <returns>Task of completion</returns>
        public async Task Delete(int id)
        {
            Amenity amenity = await _context.Amenities.FindAsync(id);
            _context.Entry(amenity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Gets all Amenities
        /// </summary>
        /// <returns>Task of completion</returns>
        public async Task<List<AmenityDTO>> GetAmenities()
        {
            var list = await _context.Amenities.ToListAsync();
            var amenities = new List<AmenityDTO>();
            foreach (var item in list)
            {
                amenities.Add(await GetAmenity(item.Id));
            }
            return amenities;
        }

        /// <summary>
        /// Gets a specific Amenity
        /// </summary>
        /// <param name="id">Unique Amenity identifier</param>
        /// <returns>Task of completion</returns>
        public async Task<AmenityDTO> GetAmenity(int id)
        {
            Amenity amenity = await _context.Amenities.FindAsync(id);
            AmenityDTO dto = new AmenityDTO()
            {
                ID = amenity.Id,
                Name = amenity.Name
            };
            return dto;
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
