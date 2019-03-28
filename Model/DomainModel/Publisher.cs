using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DomainModel
{
    public class Publisher
    {
        [Key]
        public int PubId { get; set; }
        [Required]
        [Display(Name = "Publisher name")]
        public string Name { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public virtual ICollection<Publisher> Publishers { get; set; }
    }
}
