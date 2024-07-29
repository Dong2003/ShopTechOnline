using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopTechOnline.Models.EF
{
    [Table("ProductImage")]
    public class ProductImage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int ID { get; set; }

        public int ProductID { get; set; }

        public string Image { get; set; }

        public bool IsDefault { get; set; }

        public virtual Product Product { get; set; }
    }
}