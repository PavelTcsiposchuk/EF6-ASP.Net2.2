using FamilyNet.Data.Interfaces;
using FamilyNet.Models.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FamilyNet.Data.Entity
{
    public class BaseItemType : IEntity
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public int ParentId { get; set; }
        public int ChildId { get; set; }
    }
}