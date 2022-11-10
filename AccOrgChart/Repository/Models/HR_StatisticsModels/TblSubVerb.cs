using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AccOrgChart.Repository.Models.HR_StatisticsModels
{
    [Table("tblSubVerbs")]
    [Index("SubVerbDesc", Name = "IX_tblSubVerb", IsUnique = true)]
    public partial class TblSubVerb
    {
        [Key]
        [Column("subVerbId")]
        public int SubVerbId { get; set; }
        [Column("verbId")]
        public int? VerbId { get; set; }
        [Column("subVerbDesc")]
        [StringLength(150)]
        [Unicode(false)]
        public string? SubVerbDesc { get; set; }
    }
}
