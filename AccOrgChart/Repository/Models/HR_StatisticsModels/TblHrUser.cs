using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AccOrgChart.Repository.Models.HR_StatisticsModels
{
    [Keyless]
    [Table("tblHrUsers")]
    public partial class TblHrUser
    {
        [Required]
        [Column("usrID")]
        [StringLength(10)]
        public string UsrId { get; set; }
        [Column("usrDesc")]
        [StringLength(40)]
        public string UsrDesc { get; set; }
        [Column("usrPWD")]
        [StringLength(15)]
        public string UsrPwd { get; set; }
        [Column("usrAdmin")]
        public bool? UsrAdmin { get; set; }
        [Column("usrSTID")]
        public short? UsrStid { get; set; }
        public bool? AllowAccess { get; set; }
        public short? Export { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastUpdate { get; set; }
    }
}
