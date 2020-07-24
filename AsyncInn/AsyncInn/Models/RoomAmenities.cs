using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class RoomAmenities
    {
        // composite key is these combined
        public int RoomId { get; set; }
        public int AmenityId { get; set; }

        // navigation properties
        public Room Room { get; set; }
        public Amenity Amenity { get; set; }
    }
}
