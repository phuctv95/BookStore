using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public class LoginUser
    {
        [Required]
        [StringLength(20, MinimumLength = 4)]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 8)]
        public string Password { get; set; }
        [Display(Name = "Remember me")]
        [Required]
        public bool RememberMe { get; set; }
    }
}
