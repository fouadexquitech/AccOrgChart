using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebApi.Repository.Models.HR_StatisticsModels
{
    [Keyless]
    public partial class VwJob
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("familyId")]
        public int? FamilyId { get; set; }
        [Column("codDesc")]
        [StringLength(150)]
        public string CodDesc { get; set; }
    }
}
