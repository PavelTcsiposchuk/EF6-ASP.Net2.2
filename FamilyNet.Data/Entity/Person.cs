using FamilyNet.Data.Interfaces;
using FamilyNet.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyNet.Data.Entity
{
    public class Person : IEntity
    {
        public int ID { get; set; }
        [Required]
        public virtual FullName FullName { get; set; }
        public DateTime Birthday { get; set; }
        public virtual Address Address { get; set; }
        public virtual  Contacts Contacts { get; set; }
        public float Rating { get; set; }
        public string PathToAvatar { get; set; }
        //public string testmigrate { get; set; }
    }
}
