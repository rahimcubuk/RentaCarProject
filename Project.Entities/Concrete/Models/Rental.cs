﻿using Project.Core.Entities;
using System;

namespace Project.Entities.Concrete.Models
{
    public class Rental : IEntity
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public DateTime RentDate { get; set; }
        public Nullable<DateTime> ReturnDate { get; set; }
    }
}
