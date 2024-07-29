using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShopTechOnline.Models.EF
{
    [Table("Contact")]

    public class Contact : CommonAbstract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int ID { get; set; }

        [Required(ErrorMessage = "Tên không được để trống ")]
        [StringLength(150, ErrorMessage = " Không được nhập quá 150 ký tự " )]

        public string Name { get; set; }

        public string Website { get; set; }

        [StringLength(150, ErrorMessage = " Không được nhập quá 150 ký tự ")]

        public string Email { get; set; }
        [StringLength(4000, ErrorMessage = " Không được nhập quá 4000 ký tự ")]

        public string Message { get; set; }

        public bool IsRead { get; set; }
    }
}