using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tasks.Web.Models
{
    public class TaskInputModel
    {
        [Required(ErrorMessage ="Task title is required.")]
        [StringLength(200,ErrorMessage ="The {0} most be between {2} and {1} character long",
            MinimumLength =1)]
        [Display(Name ="Title *")]
        public string Title { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name ="Date and Time *")]
        public DateTime StartDateTime { get; set; }
        public TimeSpan? Duration { get; set; }
        public string Description { get; set; }
        [MaxLength(200)]
        public string Location { get; set; }
        [Display(Name ="Is Public")]
        public bool IsPublic { get; set; }
    }
}