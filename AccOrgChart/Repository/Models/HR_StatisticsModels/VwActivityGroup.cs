using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AccOrgChart.Repository.Models.HR_StatisticsModels
{
    [Keyless]
    public partial class VwActivityGroup
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("idDesc")]
        public string IdDesc { get; set; }
        [Column("actGrpCode")]
        [StringLength(100)]
        public string ActGrpCode { get; set; }
    }
}
