using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DomainModel
{
    public class Author
    {
        public int AuthorId { get; set; }
        [Display(Name = "Author name")]
        [Required]
        public string AuthorName { get; set; }
        [DataType(DataType.MultilineText)]
        public string History { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
