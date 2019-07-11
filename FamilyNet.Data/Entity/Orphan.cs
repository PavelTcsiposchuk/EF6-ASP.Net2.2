using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FamilyNet.Data.Entity
{
    public class Orphan : Person
    {
        [Required]
        public Orphanage Orphanage { get; set; }
        public virtual ICollection<AuctionLot> AuctionLots { get; set; }
    }
}