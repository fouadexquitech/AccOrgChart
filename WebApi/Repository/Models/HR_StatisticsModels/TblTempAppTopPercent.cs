using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebApi.Repository.Models.HR_StatisticsModels
{
    [Table("tblTempAppTopPercent")]
    [Index(nameof(GrpBy), Name = "IX_tblTempAppTopPercent")]
    public partial class TblTempAppTopPercent
    {
        [Key]
        [Column("seq")]
        public int Seq { get; set; }
        [Key]
        [StringLength(10)]
        public string EmplNumber { get; set; }
        [Key]
        [StringLength(30)]
        public string UserName { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public int? NewAge { get; set; }
        [StringLength(150)]
        public string CurrentPosition { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DateofJoining { get; set; }
        [Column("Date of Joining", TypeName = "date")]
        public DateTime? DateOfJoining1 { get; set; }
        public int? NewAccServiceYear { get; set; }
        [StringLength(50)]
        public string Designation { get; set; }
        [StringLength(50)]
        public string Nationality { get; set; }
        [StringLength(150)]
        public string Dept { get; set; }
        [StringLength(150)]
        public string Location { get; set; }
        [StringLength(150)]
        public string CareerBand { get; set; }
        public int? GrpStaffCnt { get; set; }
        public int? TotPay { get; set; }
        [StringLength(150)]
        public string JobFamily { get; set; }
        public int? LevelCareerBand { get; set; }
        [Column("Level career band")]
        public int? LevelCareerBand1 { get; set; }
        [StringLength(30)]
        public string Educationlevel { get; set; }
        [StringLength(150)]
        public string Degree { get; set; }
        [StringLength(30)]
        public string AppGroup { get; set; }
        [StringLength(30)]
        public string RankGroup { get; set; }
        public double? AppValue { get; set; }
        public double? RankValue { get; set; }
        public int? AppRankYear { get; set; }
        [StringLength(150)]
        public string GrpBy { get; set; }
        [Column("generation_tmp")]
        public int? GenerationTmp { get; set; }
    }
}
