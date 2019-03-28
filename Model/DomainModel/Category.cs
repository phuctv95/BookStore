using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DomainModel
{
    public class Category
    {
        [Key]
        public int CateId { get; set; }
        [Display(Name = "Category name")]
        [Required]
        public string CateName { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
