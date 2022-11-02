using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebApi.Repository.Models.HR_StatisticsModels
{
    [Keyless]
    public partial class VwCompetencyExpectedLevel
    {
        [Column("id")]
        public int? Id { get; set; }
        [Column("codDesc")]
        public string CodDesc { get; set; }
    }
}
