using System;

namespace EntityCRUD.Models
{
    public class Character : BaseEntity
    {
        public int Id {get;set;}
        public string Name {get;set;}
        public DateTime CreatedAt {get;set;}
        public DateTime UpdatedAt {get;set;}

        public int HouseId {get; set;}
        public House House { get; set; }

    }
}