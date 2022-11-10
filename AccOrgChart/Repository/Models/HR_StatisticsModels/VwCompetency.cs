using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AccOrgChart.Repository.Models.HR_StatisticsModels
{
    [Keyless]
    public partial class VwCompetency
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("compGroupId")]
        public int? CompGroupId { get; set; }
        [Column("compCode")]
        [StringLength(250)]
        [Unicode(false)]
        public string? CompCode { get; set; }
        [Column("codeAndDesc")]
        [StringLength(753)]
        [Unicode(false)]
        public string? CodeAndDesc { get; set; }
        [Column("compDesc")]
        [StringLength(500)]
        [Unicode(false)]
        public string? CompDesc { get; set; }
    }
}
