using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopTechOnline.Models
{
    public abstract class CommonAbstract
    {
        public string Created {  get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiledDate { get; set; }

        public string ModifierBy { get; set; }

    }
}