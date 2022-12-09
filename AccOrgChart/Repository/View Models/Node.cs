namespace AccOrgChart.Repository.View_Models
{
    public class Node
    {
        public int Id { get; set; }
        public int? RoleId { get; set; }
        public string? RoleName { get; set; }

        public int? TaskId { get; set; }

        public string? TaskName { get; set; }

        public int? verbId { get; set; }
        public string? verbName { get; set; }

        public List<Node>? Children { get; set; }

        public int? Type { get; set; }

        public string? porposedBy { get; set; }


    }
}
