using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dahlia.Models
{
    public class Tag
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Tag Type")]
        public string TagType { get; set; }
    }
}
