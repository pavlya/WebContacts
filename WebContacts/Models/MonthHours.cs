using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebContacts.Models
{
    public class MonthHours
    {
        public const int MaxMonthHours = 180;

        public int Id { get; set; }

        public int ContactModelId { get; set; }

        [Range(0, MaxMonthHours)]
        public int Hours { get; set; }

        public Month MonthOfTheYear { get; set; }
    }

    public enum Month
    {
        January,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December
    }
}