﻿using AsyncInn.Data;
using AsyncInn.Models.DTOs;
using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Services
{
    public class HotelRepository : IHotel
    {
        private AsyncInnDbContext _context;

        public HotelRepository(AsyncInnDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a new Hotel
        /// </summary>
        /// <param name="hotel">Hotel being added</param>
        /// <returns>Task of completion</returns>
        public async Task<Hotel> Create(Hotel hotel)
        {
            // When I have a hotel, I want to add it to the database.
            _context.Entry(hotel).State = EntityState.Added;
            await _context.SaveChangesAsync();                             
            // The hotel is 'saved' ere, then associated with an id.
            return hotel;
        }

        /// <summary>
        /// Removes a specific Hotel
        /// </summary>
        /// <param name="id">Unique Hotel identifier</param>
        /// <returns>Task of completion</returns>
        public async Task Delete(int id)
        {
            Hotel hotel = await _context.Hotels.FindAsync(id);
            _context.Entry(hotel).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Gets a specific Hotel
        /// </summary>
        /// <param name="id">Unique Hotel identifier</param>
        /// <returns>Task of completion</returns>
        public async Task<HotelDTO> GetHotel(int id)
        {
            Hotel hotel = await _context.Hotels.FindAsync(id);
            //var hotelRoom = await _context.HotelRooms.Where(x => x.HotelId == id).Include(x => x.Room).ToListAsync();
            HotelDTO dto = new HotelDTO()
            {
                ID = hotel.Id,
                Name = hotel.Name,
                StreetAddress = hotel.StreetAddress,
                City = hotel.City,
                State = hotel.State,
                Phone = hotel.Phone,
                Rooms = await new HotelRoomRepository(_context).GetHotelRooms(hotel.Id)
            };
            return dto;  
        }

        /// <summary>
        /// Gets all Hotels
        /// </summary>
        /// <returns>Task of completion</returns>
        public async Task<List<HotelDTO>> GetHotels()
        {
            var list = await _context.Hotels.ToListAsync();
            var hotels = new List<HotelDTO>();
            foreach (var item in list)
            {
                hotels.Add(await GetHotel(item.Id));
            }
            return hotels;
        }

        /// <summary>
        /// Updates a specific Hotel
        /// </summary>
        /// <param name="hotel">Hotel being updated</param>
        /// <returns>Task of completion</returns>
        public async Task Update(Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
