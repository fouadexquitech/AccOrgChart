using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebApi.Repository.Models.HR_StatisticsModels
{
    [Table("tblJobWorkFlow")]
    [Index(nameof(JwJobId), nameof(JwTaskId), Name = "IX_tblJobWorkFlow", IsUnique = true)]
    public partial class TblJobWorkFlow
    {
        [Key]
        [Column("jwId")]
        public int JwId { get; set; }
        [Column("jwJobID")]
        public int JwJobId { get; set; }
        [Column("jwTaskID")]
        public int JwTaskId { get; set; }
        [Column("jwRACI")]
        public int? JwRaci { get; set; }
        [Column("jwVerb")]
        public int? JwVerb { get; set; }
        [Column("jwComplexityLevel")]
        public int? JwComplexityLevel { get; set; }
        [Column("jwWorkFlowRoleCode")]
        [StringLength(50)]
        public string JwWorkFlowRoleCode { get; set; }
        [Column("jwWorkFlowCode")]
        [StringLength(50)]
        public string JwWorkFlowCode { get; set; }
        [Column("jwSubWorkFlowCode")]
        [StringLength(50)]
        public string JwSubWorkFlowCode { get; set; }
        [Column("jwJobCompetencyLevel")]
        public int? JwJobCompetencyLevel { get; set; }
        [Column("jwCompetencyRef")]
        public int? JwCompetencyRef { get; set; }
        [Column("jwCompetencyExpectedLevel")]
        public int? JwCompetencyExpectedLevel { get; set; }
        [Column("jwFrequencyaction")]
        public int? JwFrequencyaction { get; set; }
        [Column("jwWayDvlpCpt")]
        public int? JwWayDvlpCpt { get; set; }
        [Column("insertedDate", TypeName = "datetime")]
        public DateTime? InsertedDate { get; set; }
        [Column("jwSort")]
        [StringLength(50)]
        public string JwSort { get; set; }
        [StringLength(50)]
        public string InsertedBy { get; set; }
        [StringLength(50)]
        public string UpdatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedDate { get; set; }
        [Column("jwParentId")]
        public int? JwParentId { get; set; }
    }
}
