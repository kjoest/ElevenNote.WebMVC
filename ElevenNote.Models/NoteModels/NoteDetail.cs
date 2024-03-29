﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Models.NoteModels
{
    public class NoteDetail
    {
        [Display(Name = "Note ID")]
        public int NoteId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        [Display(Name = "Category ID")]
        public int CategoryId { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
