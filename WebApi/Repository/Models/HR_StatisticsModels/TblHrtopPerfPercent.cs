using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebApi.Repository.Models.HR_StatisticsModels
{
    [Table("tblHRTopPerfPercent")]
    [Index(nameof(Seq), Name = "IX_tblHRTopPerfPercent", IsUnique = true)]
    public partial class TblHrtopPerfPercent
    {
        public int Seq { get; set; }
        [Key]
        [StringLength(50)]
        public string PercentDesc { get; set; }
        public int PercentValue { get; set; }
    }
}
