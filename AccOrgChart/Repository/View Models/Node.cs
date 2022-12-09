namespace AccOrgChart.Repository.View_Models
{
    public class Node
    {
        public int Id { get; set; }

        //Original
        public int? RoleId { get; set; }
        public string? RoleName { get; set; }
        public int? verbId { get; set; }
        public string? verbName { get; set; }
        public int? TaskId { get; set; }
        public string? TaskName { get; set; }

        //Proposal
        public int? proposedRoleId { get; set; }
        public string? proposedRoleName { get; set; }
        public int? proposedverbId { get; set; }
        public string? proposedverbName { get; set; }
        public string? proposedTaskName { get; set; }
        public string? porposedBy { get; set; }


        public List<Node>? Children { get; set; }
        public int? Type { get; set; }

    }
}
