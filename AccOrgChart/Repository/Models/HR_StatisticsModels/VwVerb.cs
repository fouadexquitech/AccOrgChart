using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AccOrgChart.Repository.Models.HR_StatisticsModels
{
    [Keyless]
    public partial class VwVerb
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("codDesc")]
        [StringLength(150)]
        [Unicode(false)]
        public string? CodDesc { get; set; }
    }
}
