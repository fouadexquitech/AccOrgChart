using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AccOrgChart.Repository.Models.HR_StatisticsModels
{
    [Table("tblHRTopPerfPercent")]
    [Index("Seq", Name = "IX_tblHRTopPerfPercent", IsUnique = true)]
    public partial class TblHrtopPerfPercent
    {
        public int Seq { get; set; }
        [Key]
        [StringLength(50)]
        [Unicode(false)]
        public string PercentDesc { get; set; } = null!;
        public int PercentValue { get; set; }
    }
}
