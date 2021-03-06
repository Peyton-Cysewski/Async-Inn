﻿using AsyncInn.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IHotelRoom
    {
        /// <summary>
        /// Adds a new HotelRoom
        /// </summary>
        /// <param name="hotelRoom">HotelRoom being added</param>
        /// <param name="hotelId">Unique Hotel identifier</param>
        /// <returns>Task of completion</returns>
        Task<HotelRoomDTO> Create(HotelRoomDTO hotelRoom, int hotelId);

        /// <summary>
        /// Gets all HotelRooms
        /// </summary>
        /// <param name="hotelId">Unique Hotel identifier</param>
        /// <returns>task of completion</returns>
        Task<List<HotelRoomDTO>> GetHotelRooms(int hotelId);

        /// <summary>
        /// Gets a specific HotelRoom
        /// </summary>
        /// <param name="hotelId">Unique Hotel identifier</param>
        /// <param name="roomNumber">Unique identifier per Hotel</param>
        /// <returns>Task of completion</returns>
        Task<HotelRoomDTO> GetHotelRoom(int hotelId, int roomNumber);

        /// <summary>
        /// Updates a specific HotelRoom
        /// </summary>
        /// <param name="hotelId">Unique Hotel indentifier</param>
        /// <param name="roomNumber">Unique identifier per Hotel</param>
        /// <param name="hotelRoom">The HotelRoom being updated</param>
        /// <returns>Task of completion</returns>
        Task Update(int hotelId, int roomNumber, HotelRoomDTO hotelRoom);

        /// <summary>
        /// Removes a specific HotelRoom
        /// </summary>
        /// <param name="hotelId">Unique Hotel indentifier</param>
        /// <param name="roomNumber">Unique identifier per Hotel</param>
        /// <returns>Task of completion</returns>
        Task Delete(int hotelId, int roomNumber);
    }
}
