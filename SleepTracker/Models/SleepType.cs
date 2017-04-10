using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SleepTracker.Models
{
    public class SleepType
    {
        public int SleepTypeID { get; set; }

        [Display (Name = "Type of Sleep")]
        public string Description { get; set; }
    }
}