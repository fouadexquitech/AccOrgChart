using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebApi.Repository.Models.HR_StatisticsModels
{
    [Table("tmpHrAppraisal")]
    public partial class TmpHrAppraisal
    {
        [Key]
        [Column("Empl number")]
        [StringLength(10)]
        public string EmplNumber { get; set; }
        [Column("Ranking 2011")]
        public double? Ranking2011 { get; set; }
        [Column("Ranking 2012")]
        public double? Ranking2012 { get; set; }
        [Column("Ranking 2013")]
        public double? Ranking2013 { get; set; }
        [Column("Ranking 2014")]
        public double? Ranking2014 { get; set; }
        [Column("Ranking 2015")]
        public double? Ranking2015 { get; set; }
        [Column("Ranking 2016")]
        public double? Ranking2016 { get; set; }
        [Column("Appraisal 2010")]
        public double? Appraisal2010 { get; set; }
        [Column("Appraisal 2011")]
        public double? Appraisal2011 { get; set; }
        [Column("Appraisal 2012")]
        public double? Appraisal2012 { get; set; }
        [Column("Appraisal 2013")]
        public double? Appraisal2013 { get; set; }
        [Column("Appraisal 2014")]
        public double? Appraisal2014 { get; set; }
        [Column("Appraisal 2015")]
        public double? Appraisal2015 { get; set; }
    }
}
