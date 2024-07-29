using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShopTechOnline.Models.EF
{
    [Table("ProductCategory")]
    public class ProductCategory : CommonAbstract
    {
        public ProductCategory() 
        {
            this.products = new HashSet<Product>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [StringLength(150)]
        public string Title { get; set; }

        [Required]
        [StringLength(150)]
        public string Alias { get; set; }

        public string Description { get; set; }

        [StringLength(250)]
        public string Icon { get; set; }

        [StringLength(250)]
        public string SeoTitle { get; set; }

        [StringLength(550)]
        public string SeoDescription { get; set; }

        [StringLength(250)]
        public string SeoKeywords { get; set; }

        public ICollection<Product> products { get; set; }
    }
}