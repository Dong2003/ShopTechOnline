using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShopTechOnline.Models.EF
{
    [Table("Statistical")]

    public class Statistical
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int ID { get; set; }

        public DateTime Time { get; set; }

        public long SoLuongTruyCap {  get; set; }
    }
}