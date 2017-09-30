using System;
using System.Collections.Generic;

namespace EntityCRUD.Models
{
    public class House : BaseEntity
    {
        public int Id {get;set;}
        public string Name {get;set;}
        public string Sigil {get;set;}
        public DateTime CreatedAt {get;set;}
        public DateTime UpdatedAt {get;set;}

        public List<Character> Characters {get; set;}
        public House()
        {
            List<Character> Characters = new List<Character>();
        }
    }
}