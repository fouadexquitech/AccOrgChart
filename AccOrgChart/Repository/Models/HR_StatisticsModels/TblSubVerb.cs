using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AccOrgChart.Repository.Models.HR_StatisticsModels
{
    [Table("tblSubVerbs")]
    [Index(nameof(SubVerbDesc), Name = "IX_tblSubVerb", IsUnique = true)]
    public partial class TblSubVerb
    {
        [Key]
        [Column("subVerbId")]
        public int SubVerbId { get; set; }
        [Column("verbId")]
        public int? VerbId { get; set; }
        [Column("subVerbDesc")]
        [StringLength(150)]
        public string SubVerbDesc { get; set; }
    }
}
