using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AccOrgChart.Repository.Models.HR_StatisticsModels
{
    [Table("tblActivityGroup")]
    [Index("ActGrpDesc", Name = "IX_tblActivityGroup", IsUnique = true)]
    public partial class TblActivityGroup
    {
        [Key]
        [Column("actGrpSeq")]
        public int ActGrpSeq { get; set; }
        [Column("actGrpCode")]
        [StringLength(100)]
        [Unicode(false)]
        public string? ActGrpCode { get; set; }
        [Column("actGrpDesc")]
        [StringLength(800)]
        [Unicode(false)]
        public string? ActGrpDesc { get; set; }
    }
}
