using FamilyNet.Data.Interfaces;
using FamilyNet.Models.Interfaces;
using System;

namespace FamilyNet.Data.Entity
{
    public class AuctionLot : IEntity
    {
        public int ID { get; set; }
        public virtual AuctionLotItem AuctionLotItem { get; set; }
        public DateTime Date { get; set; }
    }
}