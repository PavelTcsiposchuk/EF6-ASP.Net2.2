using FamilyNet.Data.Interfaces;
using FamilyNet.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyNet.Data.Entity
{
    public class Orphanage : IEntity
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Address Adress { get; set; }
        public float Rating { get; set; }
        public string Avatar { get; set; }

        public virtual ICollection<Representative> Representatives { get; set; }
        public virtual ICollection<Orphan> OrphansIds { get; set; }
    }
}
