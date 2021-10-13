using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ElevenNote.Models.CategoryModels
{
    public class CategoryCreate
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }

        public IEnumerable<SelectListItem> Notes { get; set; }


        public override string ToString()
        {
            return CategoryName;
        }
    }
}
