using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ass2_shopping_basket.Models
{
    public class Category
    {
        /*set primary key*/
        [Key]
        public int ID { get; set; }

        //lab5 regex  Data Validation
        [Required(ErrorMessage = "The category name cannot be blank")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Please enter a category name between 3 and 50 characters in length")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$", ErrorMessage = "Please enter a category name beginning with a capital letter and enter only letters and spaces.")]
        
    /*lab4*/
        [Display(Name = "Category Name")]
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}