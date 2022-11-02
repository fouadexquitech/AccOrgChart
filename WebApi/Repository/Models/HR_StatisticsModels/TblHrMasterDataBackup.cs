using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebApi.Repository.Models.HR_StatisticsModels
{
    [Keyless]
    [Table("tblHrMasterData_Backup")]
    public partial class TblHrMasterDataBackup
    {
        [Required]
        [Column("Empl number")]
        [StringLength(10)]
        public string EmplNumber { get; set; }
        [Column("Full Name")]
        [StringLength(255)]
        public string FullName { get; set; }
        [Column("Date of Birth", TypeName = "datetime")]
        public DateTime? DateOfBirth { get; set; }
        public double? Age { get; set; }
        [Column("Date of Joining", TypeName = "date")]
        public DateTime? DateOfJoining { get; set; }
        [Column("ACC Service Years")]
        public double? AccServiceYears { get; set; }
        [Column("Date of Education", TypeName = "date")]
        public DateTime? DateOfEducation { get; set; }
        [Column("Years since Grad")]
        public int? YearsSinceGrad { get; set; }
        [StringLength(255)]
        public string Designation { get; set; }
        [StringLength(255)]
        public string Nationality { get; set; }
        [StringLength(255)]
        public string Dept { get; set; }
        [StringLength(255)]
        public string Location { get; set; }
        [Column("Correction Air Tickets")]
        [StringLength(255)]
        public string CorrectionAirTickets { get; set; }
        [Column("Basic Total")]
        public double? BasicTotal { get; set; }
        [Column("Total Other Allowance")]
        public double? TotalOtherAllowance { get; set; }
        [Column("Grand Total")]
        public double? GrandTotal { get; set; }
        [Column("Career Band")]
        [StringLength(255)]
        public string CareerBand { get; set; }
        [Column("Job Family")]
        [StringLength(255)]
        public string JobFamily { get; set; }
        [StringLength(255)]
        public string Discipline { get; set; }
        [Column("Sub discipline")]
        [StringLength(255)]
        public string SubDiscipline { get; set; }
        [Column("Specialty Discipline")]
        [StringLength(255)]
        public string SpecialtyDiscipline { get; set; }
        [Column("HAYS Ref")]
        public double? HaysRef { get; set; }
        [Column("Level career band")]
        public double? LevelCareerBand { get; set; }
        [Column("Grade Struc")]
        [StringLength(255)]
        public string GradeStruc { get; set; }
        [StringLength(255)]
        public string Remarks { get; set; }
        [Column("Ethnic group")]
        [StringLength(255)]
        public string EthnicGroup { get; set; }
        [Column("Future Job Title")]
        [StringLength(255)]
        public string FutureJobTitle { get; set; }
        [Column("Education level")]
        [StringLength(255)]
        public string EducationLevel { get; set; }
        [StringLength(255)]
        public string Degree { get; set; }
        [Column("Value mid point")]
        [StringLength(255)]
        public string ValueMidPoint { get; set; }
        [Column("Analysis remarks")]
        [StringLength(255)]
        public string AnalysisRemarks { get; set; }
        [Column("Analysis QA Construction")]
        [StringLength(255)]
        public string AnalysisQaConstruction { get; set; }
        [Column("Analysis QA Sub Families")]
        [StringLength(255)]
        public string AnalysisQaSubFamilies { get; set; }
        [Column("Analysis QA Formen")]
        [StringLength(255)]
        public string AnalysisQaFormen { get; set; }
        [Column("Percent compare to Mid")]
        [StringLength(255)]
        public string PercentCompareToMid { get; set; }
        [StringLength(255)]
        public string X { get; set; }
        [StringLength(255)]
        public string Field36 { get; set; }
        [Column("Position generation 1")]
        [StringLength(255)]
        public string PositionGeneration1 { get; set; }
        [Column("generation 1  Years")]
        public double? Generation1Years { get; set; }
        [Column("Position generation 2")]
        [StringLength(255)]
        public string PositionGeneration2 { get; set; }
        [Column("generation 2  Years")]
        public double? Generation2Years { get; set; }
        [Column("Position generation 3")]
        [StringLength(255)]
        public string PositionGeneration3 { get; set; }
        [Column("generation 3  Years")]
        public double? Generation3Years { get; set; }
        [Column("generation_tmp")]
        public double? GenerationTmp { get; set; }
    }
}
