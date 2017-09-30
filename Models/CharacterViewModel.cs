using System;
using System.ComponentModel.DataAnnotations;

namespace EntityCRUD.Models
{
    public class CharacterViewModel : BaseEntity
    {
        [Required]
        [MinLength(2)]
        public string Name {get;set;}

        [Required]
        public int HouseId {get; set;}
    }
}