using BackV2.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Back.Data.Entities
{
    public class Race: IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required")]
        [StringLength(60, MinimumLength = 3)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z] *$")]
        public string Name { get; set; }
        public int Lifespan { get; set; }
        public virtual Size Size { get; set; }
        public int SizeId { get; set; }
        //public Coat Coat { get; set; }   
    }

    public class Size: IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Name { get; set; }
    }

    public enum SizeEnum
    {
        Small = 1,
        Medium = 2,
        Large = 3,
    }
}
