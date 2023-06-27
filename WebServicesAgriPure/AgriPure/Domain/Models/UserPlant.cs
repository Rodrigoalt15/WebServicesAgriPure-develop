﻿using WebServicesAgriPure.Security.Domain.Models;

namespace WebServicesAgriPure.AgriPure.Domain.Models
{
    public class UserPlant
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int PlantId { get; set; }
        public Plant Plant { get; set; }
    }
}
