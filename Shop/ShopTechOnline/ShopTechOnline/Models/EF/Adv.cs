using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShopTechOnline.Models.EF
{
    [Table("Adv")]

    public class Adv : CommonAbstract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int ID { get; set; }
        [Required]
        [StringLength(150)]
        public string Title { get; set; }

        public string Description { get; set; }
        [StringLength(500)]
        public string Image { get; set; }

        public string Type { get; set; }
        [StringLength(150)]
        public string Link { get; set; }
    }
}