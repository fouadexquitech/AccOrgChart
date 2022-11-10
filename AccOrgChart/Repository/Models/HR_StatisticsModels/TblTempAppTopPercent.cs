using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AccOrgChart.Repository.Models.HR_StatisticsModels
{
    [Table("tblTempAppTopPercent")]
    [Index("GrpBy", Name = "IX_tblTempAppTopPercent")]
    public partial class TblTempAppTopPercent
    {
        [Key]
        [Column("seq")]
        public int Seq { get; set; }
        [Key]
        [StringLength(10)]
        [Unicode(false)]
        public string EmplNumber { get; set; } = null!;
        [Key]
        [StringLength(30)]
        [Unicode(false)]
        public string UserName { get; set; } = null!;
        [StringLength(100)]
        [Unicode(false)]
        public string? Name { get; set; }
        public int? NewAge { get; set; }
        [StringLength(150)]
        [Unicode(false)]
        public string? CurrentPosition { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DateofJoining { get; set; }
        [Column("Date of Joining", TypeName = "date")]
        public DateTime? DateOfJoining1 { get; set; }
        public int? NewAccServiceYear { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? Designation { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? Nationality { get; set; }
        [StringLength(150)]
        [Unicode(false)]
        public string? Dept { get; set; }
        [StringLength(150)]
        [Unicode(false)]
        public string? Location { get; set; }
        [StringLength(150)]
        [Unicode(false)]
        public string? CareerBand { get; set; }
        public int? GrpStaffCnt { get; set; }
        public int? TotPay { get; set; }
        [StringLength(150)]
        [Unicode(false)]
        public string? JobFamily { get; set; }
        public int? LevelCareerBand { get; set; }
        [Column("Level career band")]
        public int? LevelCareerBand1 { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string? Educationlevel { get; set; }
        [StringLength(150)]
        [Unicode(false)]
        public string? Degree { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string? AppGroup { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string? RankGroup { get; set; }
        public double? AppValue { get; set; }
        public double? RankValue { get; set; }
        public int? AppRankYear { get; set; }
        [StringLength(150)]
        [Unicode(false)]
        public string? GrpBy { get; set; }
        [Column("generation_tmp")]
        public int? GenerationTmp { get; set; }
    }
}
