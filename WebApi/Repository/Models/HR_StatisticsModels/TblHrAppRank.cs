using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebApi.Repository.Models.HR_StatisticsModels
{
    [Table("tblHrAppRank")]
    public partial class TblHrAppRank
    {
        [Key]
        [StringLength(10)]
        public string EmplNumber { get; set; }
        [Key]
        public short AppRankYear { get; set; }
        public double? AppValue { get; set; }
        [StringLength(20)]
        public string AppGroup { get; set; }
        public double? RankValue { get; set; }
        [StringLength(20)]
        public string RankGroup { get; set; }
    }
}
