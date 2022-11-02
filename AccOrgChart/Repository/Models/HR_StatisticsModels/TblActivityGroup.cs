using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AccOrgChart.Repository.Models.HR_StatisticsModels
{
    [Table("tblActivityGroup")]
    [Index(nameof(ActGrpDesc), Name = "IX_tblActivityGroup", IsUnique = true)]
    public partial class TblActivityGroup
    {
        [Key]
        [Column("actGrpSeq")]
        public int ActGrpSeq { get; set; }
        [Column("actGrpCode")]
        [StringLength(100)]
        public string ActGrpCode { get; set; }
        [Column("actGrpDesc")]
        [StringLength(800)]
        public string ActGrpDesc { get; set; }
    }
}
