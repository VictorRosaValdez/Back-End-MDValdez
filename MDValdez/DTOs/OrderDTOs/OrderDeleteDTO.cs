﻿using MDValdez.Models;

namespace MDValdez.DTOs.AccountDTOs
{
    public class OrderDeleteTO
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public double OrderAmount { get; set; }


    }
}
