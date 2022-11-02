using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AccOrgChart.Repository.Models.HR_StatisticsModels
{
    [Table("tblHrAppRankGroup")]
    public partial class TblHrAppRankGroup
    {
        [Column("seq")]
        public byte Seq { get; set; }
        [Key]
        [Column("grpDesc")]
        [StringLength(20)]
        public string GrpDesc { get; set; }
        [Column("grpAppFrom")]
        public int? GrpAppFrom { get; set; }
        [Column("grpAppTo")]
        public int? GrpAppTo { get; set; }
        [Column("grpRankFrom")]
        public int? GrpRankFrom { get; set; }
        [Column("grpRankTo")]
        public int? GrpRankTo { get; set; }
        [Column("grpTopPercent")]
        public int? GrpTopPercent { get; set; }
    }
}
