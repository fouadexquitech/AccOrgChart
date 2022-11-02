using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AccOrgChart.Repository.Models.HR_StatisticsModels
{
    [Table("tblActivitySub")]
    public partial class TblActivitySub
    {
        [Key]
        [Column("sacSeq")]
        public int SacSeq { get; set; }
        [Key]
        [Column("actID")]
        public int ActId { get; set; }
        [Column("sacCode")]
        [StringLength(50)]
        public string SacCode { get; set; }
        [Column("sacDesc")]
        [StringLength(500)]
        public string SacDesc { get; set; }
        [Column("sacSort")]
        public int? SacSort { get; set; }
    }
}
