using System.ComponentModel.DataAnnotations;

namespace FamilyNet.Data.Entity
{
    public class Representative : Person
    {
        [Required]
        public virtual Orphanage Orphanage { get; set; }
    }
}