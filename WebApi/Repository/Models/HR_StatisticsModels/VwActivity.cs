using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebApi.Repository.Models.HR_StatisticsModels
{
    [Keyless]
    public partial class VwActivity
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("idDesc")]
        [StringLength(50)]
        public string IdDesc { get; set; }
        [Column("groupId")]
        public int GroupId { get; set; }
        [Column("actDesc")]
        [StringLength(500)]
        public string ActDesc { get; set; }
        [Column("actSort")]
        public int? ActSort { get; set; }
    }
}
