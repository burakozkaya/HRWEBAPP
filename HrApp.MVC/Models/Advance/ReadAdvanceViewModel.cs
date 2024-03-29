﻿namespace HrApp.MVC.Models.Advance
{
    public class ReadAdvanceViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? SecondName { get; set; }
        public string Surname { get; set; }
        public string? SecondSurname { get; set; }
        public string AdvanceTypeName { get; set; }
        public int? AdvanceTypeId { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public int? CurrencyId { get; set; }
        public DateTime RequestDate { get; set; }
        public string ApprovalStatus { get; set; }
        public DateTime ApprovalDate { get; set; }
        public string AppUserId { get; set; }
    }
}
