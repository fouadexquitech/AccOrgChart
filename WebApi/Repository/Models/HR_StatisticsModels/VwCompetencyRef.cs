using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebApi.Repository.Models.HR_StatisticsModels
{
    [Keyless]
    public partial class VwCompetencyRef
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("compGroupId")]
        public int? CompGroupId { get; set; }
        [Column("codDesc")]
        [StringLength(500)]
        public string CodDesc { get; set; }
        [Column("compCode")]
        [StringLength(250)]
        public string CompCode { get; set; }
    }
}
