using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

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
        [Unicode(false)]
        public string? SacCode { get; set; }
        [Column("sacDesc")]
        [StringLength(500)]
        [Unicode(false)]
        public string? SacDesc { get; set; }
        [Column("sacSort")]
        public int? SacSort { get; set; }
        [Column("insertdate", TypeName = "datetime")]
        public DateTime? Insertdate { get; set; }
        [Column("proposedSubActivity")]
        [StringLength(500)]
        [Unicode(false)]
        public string? ProposedSubActivity { get; set; }
        [Column("proposedBy")]
        [StringLength(50)]
        [Unicode(false)]
        public string? ProposedBy { get; set; }
        [Column("proposedDate", TypeName = "datetime")]
        public DateTime? ProposedDate { get; set; }
        [Column("proposedNew")]
        public byte? ProposedNew { get; set; }
        [Column("proposedApproved")]
        public byte? ProposedApproved { get; set; }
        [Column("isProposed")]
        public byte? IsProposed { get; set; }
    }
}
