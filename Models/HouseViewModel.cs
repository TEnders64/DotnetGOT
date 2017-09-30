using System.ComponentModel.DataAnnotations;

namespace EntityCRUD.Models 
{
    public class HouseViewModel : BaseEntity
    {
        [Required]
        [MinLength(3)]
        public string Name {get; set;}

        [Required]
        [MinLength(5)]
        public string Sigil {get; set;}
    }
}