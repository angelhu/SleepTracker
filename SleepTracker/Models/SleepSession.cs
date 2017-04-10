using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SleepTracker.Models
{
    public class SleepSession
    {
        public int SleepSessionID { get; set; }

        [Display (Name = "Start Time")]
        public DateTime StartTime { get; set; }
        [Display (Name = "End Time")]
        public DateTime EndTime { get; set; }

        [Display (Name = "Type of Sleep")]
        public int SleepTypeID { get; set; }
        public virtual SleepType TypeOfSleep { get; set; }
    }
}