using FamilyNet.Data.Interfaces;
using FamilyNet.Models.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace FamilyNet.Data.Entity
{
    public class Donation : IEntity
    {
        public int ID { get; set; }
        [Required]
        public virtual DonationItem DonationItem { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}