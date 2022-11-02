using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebApi.Repository.Models.HR_StatisticsModels
{
    [Table("tmp")]
    public partial class Tmp
    {
        public string Job { get; set; }
        [Column("JobID")]
        public string JobId { get; set; }
        public string ActGrp { get; set; }
        [Column("ActGrpID")]
        public string ActGrpId { get; set; }
        public string Act { get; set; }
        [Column("ActID")]
        public string ActId { get; set; }
        public string SubAct { get; set; }
        public string Task { get; set; }
        [Column("TaskID")]
        public string TaskId { get; set; }
        public string T6 { get; set; }
        public string T7 { get; set; }
        [Key]
        [Column("seq1")]
        public int Seq1 { get; set; }
    }
}
