﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Models.CategoryModels
{
    public class CategoryEdit
    {
        [Display(Name = "Category ID")]
        public int CategorId { get; set; }
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
    }
}
