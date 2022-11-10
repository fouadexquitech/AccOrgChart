using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AccOrgChart.Repository.Models.HR_StatisticsModels
{
    [Table("tblHrAppRank")]
    public partial class TblHrAppRank
    {
        [Key]
        [StringLength(10)]
        [Unicode(false)]
        public string EmplNumber { get; set; } = null!;
        [Key]
        public short AppRankYear { get; set; }
        public double? AppValue { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public string? AppGroup { get; set; }
        public double? RankValue { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public string? RankGroup { get; set; }
    }
}
