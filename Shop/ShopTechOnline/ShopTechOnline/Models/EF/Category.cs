using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShopTechOnline.Models.EF
{
    [Table("Category")]

    public class Category : CommonAbstract
    {
        public Category() 
        {
            this.News = new HashSet<News>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int ID { get; set; }

        [Required(ErrorMessage = " Tên danh mục không được để trống ")]
        [StringLength(150)]
        public string Title { get; set; }

        public string Alias { get; set; }

        //[StringLength(150)]
        //public string TypeCode { get; set; }

        //public string Link { get; set; }

        public string Description { get; set; }

        public string Position { get; set; }

        [StringLength(150)]
        public string SeoTitle { get; set; }

        [StringLength(250)]
        public string SeoDescription { get; set; }

        public string SeoKeywords { get; set; }

        public bool IsActive { get; set; }

        public ICollection<News> News { get; set; }

        public ICollection<Post> posts { get; set; }

    }
}