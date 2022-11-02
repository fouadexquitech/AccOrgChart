using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AccOrgChart.Repository.Models.HR_StatisticsModels
{
    [Keyless]
    [Table("tblDataBases")]
    public partial class TblDatabase
    {
        [Required]
        [Column("dbName")]
        [StringLength(50)]
        public string DbName { get; set; }
        [Required]
        [Column("dbDescription")]
        [StringLength(50)]
        public string DbDescription { get; set; }
        [Column("dbConnection")]
        [StringLength(150)]
        public string DbConnection { get; set; }
        [Column("dbServer")]
        [StringLength(50)]
        public string DbServer { get; set; }
        [Column("dbActive")]
        public byte? DbActive { get; set; }
        [Column("dbUserID")]
        [StringLength(20)]
        public string DbUserId { get; set; }
        [Column("dbPass")]
        [StringLength(20)]
        public string DbPass { get; set; }
        [Column("SSRS_Server")]
        [StringLength(100)]
        public string SsrsServer { get; set; }
        [Column("SSRS_User")]
        [StringLength(20)]
        public string SsrsUser { get; set; }
        [Column("SSRS_Pass")]
        [StringLength(20)]
        public string SsrsPass { get; set; }
        [Column("SSRS_Domain")]
        [StringLength(20)]
        public string SsrsDomain { get; set; }
        [Column("dbLocation")]
        [StringLength(50)]
        public string DbLocation { get; set; }
    }
}
