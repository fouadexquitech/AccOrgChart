using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AccOrgChart.Repository.Models.HR_StatisticsModels
{
    [Keyless]
    public partial class VwJobWorkFlow
    {
        [StringLength(800)]
        [Unicode(false)]
        public string? ActivityGroup { get; set; }
        [StringLength(500)]
        [Unicode(false)]
        public string? Activity { get; set; }
        [StringLength(500)]
        [Unicode(false)]
        public string? SubActivity { get; set; }
        [StringLength(150)]
        [Unicode(false)]
        public string? Role { get; set; }
        [StringLength(500)]
        [Unicode(false)]
        public string? Task { get; set; }
        [Column("jwId")]
        public int JwId { get; set; }
        [Column("jwParentId")]
        public int? JwParentId { get; set; }
        public int GroupId { get; set; }
        public int ActivityId { get; set; }
        public int SubActivityId { get; set; }
        public int TaskId { get; set; }
        public int RoleId { get; set; }
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
        [Unicode(false)]
        public string? JwWorkFlowRoleCode { get; set; }
        [Column("jwWorkFlowCode")]
        [StringLength(50)]
        [Unicode(false)]
        public string? JwWorkFlowCode { get; set; }
        [Column("jwSubWorkFlowCode")]
        [StringLength(50)]
        [Unicode(false)]
        public string? JwSubWorkFlowCode { get; set; }
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
        [Column("jwSort")]
        [StringLength(50)]
        [Unicode(false)]
        public string? JwSort { get; set; }
        [Column("insertedDate", TypeName = "datetime")]
        public DateTime? InsertedDate { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? InsertedBy { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? UpdatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedDate { get; set; }
        [Column("jwParentSubActivity")]
        public int? JwParentSubActivity { get; set; }
        [Column("jwProposedSubAct")]
        [StringLength(500)]
        [Unicode(false)]
        public string? JwProposedSubAct { get; set; }
        [Column("jwProposedTask1")]
        [StringLength(1000)]
        [Unicode(false)]
        public string? JwProposedTask1 { get; set; }
        [Column("jwProposedTask2")]
        [StringLength(1000)]
        [Unicode(false)]
        public string? JwProposedTask2 { get; set; }
        [Column("jwProposedBy")]
        [StringLength(100)]
        [Unicode(false)]
        public string? JwProposedBy { get; set; }
        [Column("jwProposedAction")]
        [StringLength(50)]
        [Unicode(false)]
        public string? JwProposedAction { get; set; }
        [Column("jwProposedTask3")]
        [StringLength(1000)]
        [Unicode(false)]
        public string? JwProposedTask3 { get; set; }
    }
}
