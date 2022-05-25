﻿namespace FamilyIncomeApi.Models.Entities
{
    public class Revenue
    {
        public int id { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public DateTime Date { get; set; }
    }
}