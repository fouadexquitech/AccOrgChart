using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace AccOrgChart.Repository.View_Models
{
    public class WorkFlow
    {
        public int wfId { get; set; }
        public int? wfParentId { get; set; }
        public string wfSort { get; set; }

        public int GroupId { get; set; }
        public string ActivityGroup { get; set; }

        public int ActivityId { get; set; }
        public string Activity { get; set; }

        public int SubActivityId { get; set; }
        public string SubActivity { get; set; }

        public int TaskId { get; set; }
        public string Task { get; set; }
       
      
        public int RoleId { get; set; }
        public string Role { get; set; }

      
        public int? wfRaci { get; set; }
        public int? wfVerb { get; set; }
        public int? wfComplexityLevel { get; set; }
        public string wfWorkFlowRoleCode { get; set; }
        public string wfWorkFlowCode { get; set; }
        public string wfSubWorkFlowCode { get; set; }
        public int? wfJobCompetencyLevel { get; set; }
        public int? wfCompetencyRef { get; set; }
        public int? wfCompetencyExpectedLevel { get; set; }
        public int? wfFrequencyaction { get; set; }
        public int? wfWayDvlpCpt { get; set; }

        public string InsertedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public List<wfChildren> wfChildrens { get; set; }
    }

    public class wfChildren
    {
        public int id { get; set; }
        public int roleId { get; set; }
        public string role { get; set; }
        public int taskId { get; set; }
        public string task { get; set; }
    }

}
