using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AccOrgChart.Repository.Models.HR_StatisticsModels
{
    [Keyless]
    public partial class VwActivitySub
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("idDesc")]
        [StringLength(500)]
        [Unicode(false)]
        public string? IdDesc { get; set; }
        [Column("actID")]
        public int ActId { get; set; }
        [Column("sacCode")]
        [StringLength(50)]
        [Unicode(false)]
        public string? SacCode { get; set; }
    }
}
