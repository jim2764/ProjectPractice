﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace ProjectPractice.Models
{
    public partial class PhotoReport
    {
        public int Id { get; set; }
        public int? Reporter { get; set; }
        public int PhotoId { get; set; }
        public DateTime ReportTime { get; set; }

        public virtual Photo Photo { get; set; }
        public virtual Member ReporterNavigation { get; set; }
    }
}