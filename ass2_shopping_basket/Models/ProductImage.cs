using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

//lab6b images
namespace ass2_shopping_basket.Models
{
    public class ProductImage
    {
        public int ID { get; set; }
        [Display(Name = "File")]
        public string FileName { get; set; }

        //lab6c
        public virtual ICollection<ProductImageMapping> ProductImageMappings { get; set; }

    }
}