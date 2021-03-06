﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Data;
using AsyncInn.Models;
using AsyncInn.Models.Interfaces;
using AsyncInn.Models.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace AsyncInn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoom _room;

        public RoomsController(IRoom room)
        {
            _room = room;
        }

        // GET: api/Rooms
        [HttpGet]
        [Authorize(Policy = "DistrictManager")]
        public async Task<ActionResult<IEnumerable<RoomDTO>>> GetRooms()
        {
            return await _room.GetRooms();
        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
        [Authorize(Policy = "DistrictManager")]
        public async Task<ActionResult<RoomDTO>> GetRoom(int id)
        {
            RoomDTO room = await _room.GetRoom(id);
            return room;
        }

        // PUT: api/Rooms/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [Authorize(Policy = "DistrictManager")]
        public async Task<IActionResult> PutRoom(int id, RoomDTO dto)
        {
            if (id != dto.ID)
            {
                return BadRequest();
            }
            await _room.Update(dto);
            return Ok();
        }

        // POST: api/Rooms
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Authorize(Policy = "DistrictManager")]
        public async Task<ActionResult<RoomDTO>> PostRoom(RoomDTO room)
        {

            await _room.Create(room);
            return CreatedAtAction("GetRoom", new { id = room.ID }, room);
        }

        [HttpPost("{roomId}/Amenity/{amenityId}")]
        [Authorize(Policy = "Agent")]
        public async Task<ActionResult> AddRoomAmenityToRoom(int amenityId, int roomId)
        {
            await _room.AddRoomAmenities(amenityId, roomId);
            return Ok();
        }

        [HttpDelete("{roomId}/Amenity/{amenityId}")]
        [Authorize(Policy = "Agent")]
        public async Task<ActionResult> RemoveRoomAmenityFromRoom(int amenityId, int roomId)
        {
            await _room.RemoveRoomAmenity(amenityId, roomId);
            return Ok();
        }

        // DELETE: api/Rooms/5
        [HttpDelete("{id}")]
        [Authorize(Policy = "DistrictManager")]
        public async Task<ActionResult<RoomDTO>> DeleteRoom(int id)
        {
            await _room.Delete(id);
            return NoContent();
        }
    }
}
