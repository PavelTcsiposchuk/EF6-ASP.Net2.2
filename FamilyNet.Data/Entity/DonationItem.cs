using System.Collections.Generic;

namespace FamilyNet.Data.Entity
{
    public class DonationItem : BaseItem
    {
        public virtual ICollection<DonationItemType> DonationItemType { get; set; }
    }
}