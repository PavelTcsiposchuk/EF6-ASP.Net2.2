using System.Collections.Generic;

namespace FamilyNet.Data.Entity
{
    public class AuctionLotItem : BaseItem
    {
        public virtual ICollection<AuctionLotItemType> AuctionLotItemType { get; set; } 
        
    }
}