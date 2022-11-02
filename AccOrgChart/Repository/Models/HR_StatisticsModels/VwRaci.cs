using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AccOrgChart.Repository.Models.HR_StatisticsModels
{
    [Keyless]
    public partial class VwRaci
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("codDesc")]
        public string CodDesc { get; set; }
        [Column("codAbv")]
        [StringLength(100)]
        public string CodAbv { get; set; }
    }
}
