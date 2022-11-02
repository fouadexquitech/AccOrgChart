using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace AccOrgChart.Repository.View_Models
{
    public class Codes
    {
        public int codSeq { get; set; }
        public int? codType { get; set; }
        public int? codGroup { get; set; }
        public int? codNum { get; set; }
        public string codDesc { get; set; }
        public string codAbv { get; set; }
        public int? codCategory { get; set; }
        public int? codCategoryType { get; set; }
    }
}
