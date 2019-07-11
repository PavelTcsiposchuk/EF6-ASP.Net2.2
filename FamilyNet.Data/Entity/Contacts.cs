using FamilyNet.Data.Interfaces;
using FamilyNet.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyNet.Data.Entity
{
    public class Contacts : IEntity
    {
        public int ID { get; set; }
        [Required]
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
