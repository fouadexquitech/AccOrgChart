using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AccOrgChart.Repository.Models.HR_StatisticsModels
{
    [Table("tblHrMasterData")]
    public partial class TblHrMasterDatum
    {
        [Key]
        [Column("Empl number")]
        [StringLength(10)]
        [Unicode(false)]
        public string EmplNumber { get; set; } = null!;
        [Column("Full Name")]
        [StringLength(255)]
        public string? FullName { get; set; }
        [Column("Date of Birth", TypeName = "date")]
        public DateTime? DateOfBirth { get; set; }
        public double? Age { get; set; }
        [Column("Date of Joining", TypeName = "date")]
        public DateTime? DateOfJoining { get; set; }
        [Column("ACC Service Years")]
        public double? AccServiceYears { get; set; }
        [Column("Date of Education", TypeName = "date")]
        public DateTime? DateOfEducation { get; set; }
        [Column("Years since Grad")]
        [StringLength(255)]
        public string? YearsSinceGrad { get; set; }
        [StringLength(255)]
        public string? Designation { get; set; }
        [StringLength(255)]
        public string? Nationality { get; set; }
        [StringLength(255)]
        public string? Dept { get; set; }
        [StringLength(255)]
        public string? Location { get; set; }
        [Column("Correction Air Tickets")]
        [StringLength(255)]
        public string? CorrectionAirTickets { get; set; }
        [Column("Basic Total")]
        public double? BasicTotal { get; set; }
        [Column("Total Other Allowance")]
        public double? TotalOtherAllowance { get; set; }
        [Column("Grand Total")]
        public double? GrandTotal { get; set; }
        [Column("Career Band")]
        [StringLength(255)]
        public string? CareerBand { get; set; }
        [Column("Job Family")]
        [StringLength(255)]
        public string? JobFamily { get; set; }
        [StringLength(255)]
        public string? Discipline { get; set; }
        [Column("Sub discipline ")]
        [StringLength(255)]
        public string? SubDiscipline { get; set; }
        [Column("Specialty Discipline")]
        [StringLength(255)]
        public string? SpecialtyDiscipline { get; set; }
        [Column("HAYS Ref")]
        [StringLength(255)]
        public string? HaysRef { get; set; }
        [Column("Level career band")]
        public double? LevelCareerBand { get; set; }
        [Column("Grade Struc")]
        [StringLength(255)]
        public string? GradeStruc { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Remarks { get; set; }
        [Column("Ethnic group")]
        [StringLength(255)]
        public string? EthnicGroup { get; set; }
        [Column("Future Job Title  ")]
        [StringLength(255)]
        public string? FutureJobTitle { get; set; }
        [Column("Education level")]
        [StringLength(255)]
        public string? EducationLevel { get; set; }
        [StringLength(255)]
        public string? Degree { get; set; }
        [Column("Value mid point")]
        public double? ValueMidPoint { get; set; }
        [Column("Analysis remarks ")]
        [StringLength(255)]
        public string? AnalysisRemarks { get; set; }
        [Column("Analysis QA Construction")]
        [StringLength(255)]
        public string? AnalysisQaConstruction { get; set; }
        [Column("Analysis QA Sub Families")]
        [StringLength(255)]
        public string? AnalysisQaSubFamilies { get; set; }
        [Column("Analysis QA Formen")]
        [StringLength(255)]
        public string? AnalysisQaFormen { get; set; }
        [Column("Percent compare to Mid")]
        [StringLength(255)]
        public string? PercentCompareToMid { get; set; }
        [StringLength(255)]
        public string? Performance { get; set; }
        [Column("Direct Experience career band")]
        [StringLength(255)]
        public string? DirectExperienceCareerBand { get; set; }
        [Column("ACC Experience")]
        [StringLength(255)]
        public string? AccExperience { get; set; }
        [Column("Age Segment")]
        [StringLength(255)]
        public string? AgeSegment { get; set; }
        [Column("Report to")]
        [StringLength(255)]
        public string? ReportTo { get; set; }
        [Column("Position before previous ")]
        [StringLength(255)]
        public string? PositionBeforePrevious { get; set; }
        [Column("Years tenure")]
        public double? YearsTenure { get; set; }
        [Column("Previous Position ACC")]
        [StringLength(255)]
        public string? PreviousPositionAcc { get; set; }
        [Column("Years tenure1")]
        public double? YearsTenure1 { get; set; }
        [Column("Position generation 3")]
        [StringLength(255)]
        public string? PositionGeneration3 { get; set; }
        [Column("Years Current position ")]
        public double? YearsCurrentPosition { get; set; }
        [Column("generation_tmp")]
        public double? GenerationTmp { get; set; }
    }
}
