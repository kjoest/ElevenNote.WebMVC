using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Data
{
    public class Category
    {
        [Key]
        [Display(Name = "Category ID")]
        public int CategoryId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string CategoryName { get; set; }

        public List<Note> Notes { get; set; } = new List<Note>();
    }
}
