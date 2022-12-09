using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AccOrgChart.Repository.Models.HR_StatisticsModels
{
    [Keyless]
    [Table("tblPermGrpUsr")]
    public partial class TblPermGrpUsr
    {
        [Column("prmUser")]
        [StringLength(30)]
        [Unicode(false)]
        public string? PrmUser { get; set; }
        [Column("prmFuncID")]
        [StringLength(30)]
        [Unicode(false)]
        public string? PrmFuncId { get; set; }
        public byte? MinOfprmRead { get; set; }
        public byte? MinOfprmWrite { get; set; }
        public byte? MinOfprmUpdate { get; set; }
        public byte? MinOfprmDelete { get; set; }
        public short? MinOfprmUpdPeriod { get; set; }
    }
}
