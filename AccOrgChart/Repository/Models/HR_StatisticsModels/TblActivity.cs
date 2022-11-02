using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AccOrgChart.Repository.Models.HR_StatisticsModels
{
    [Table("tblActivity")]
    [Index(nameof(ActDesc), Name = "IX_tblActivites", IsUnique = true)]
    public partial class TblActivity
    {
        [Key]
        [Column("actSeq")]
        public int ActSeq { get; set; }
        [Key]
        [Column("actGrpID")]
        public int ActGrpId { get; set; }
        [Column("actCode")]
        [StringLength(50)]
        public string ActCode { get; set; }
        [Column("actDesc")]
        [StringLength(500)]
        public string ActDesc { get; set; }
        [Column("actSort")]
        public int? ActSort { get; set; }
    }
}
