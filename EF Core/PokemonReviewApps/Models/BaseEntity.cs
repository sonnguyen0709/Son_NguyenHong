﻿namespace PokemonReviewApps.Models
{
    public abstract class BaseEntity
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
 
    }
}
