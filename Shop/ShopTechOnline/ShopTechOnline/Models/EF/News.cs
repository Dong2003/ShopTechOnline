using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopTechOnline.Models.EF
{
    [Table("New")]
    public class News : CommonAbstract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int ID { get; set; }

        [Required(ErrorMessage = "Bạn không thể để trống tiêu đề")]
        [StringLength(150)]
        public string Title { get; set; }

        public string Alias { get; set; }

        public int CategoryID { get; set; }

        public string Description { get; set; }
        [AllowHtml]
        public string Detail { get; set; }

        public string Image { get; set; }

        public string SeoTitle { get; set; }

        public string SeoDescription { get; set; }

        public string SeoKeywords { get; set; }

        public bool IsActive { get; set; }

        public virtual Category Category { get; set; }
    }
}