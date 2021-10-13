﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Models.NoteModels
{
    public class NoteEdit
    {
        [Display(Name = "Note ID")]
        public int NoteId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsStarred { get; set; }
    }
}
