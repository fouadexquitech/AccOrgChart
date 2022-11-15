using AccOrgChart.Repository.Interfaces;
using AccOrgChart.Repository.Models.HR_StatisticsModels;
using AccOrgChart.Repository.View_Models;
using System;
using System.Threading.Tasks;


namespace AccOrgChart.Repository.Managers
{
    public class WorkFlowRepository : IWorkFlowRepository
    {
        private readonly HR_StatisticsDbContext _dbContext;

        public WorkFlowRepository(HR_StatisticsDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public Node? GetChartOrgActivity(int actId)
        {
            try
            {
                var roles = _dbContext.TblRoles.ToList();

                var tasks = (from b in _dbContext.TblActivities
                             join c in _dbContext.TblActivitySubs on b.ActSeq equals c.ActId
                             join t in _dbContext.TblActivityTasks on c.SacSeq equals t.SubActId
                             where b.ActSeq == actId
                             select t).ToList();

                var root = _dbContext.TblActivities.Where(x => x.ActSeq == actId).FirstOrDefault();

                var subActs = (from b in _dbContext.TblActivities
                               join c in _dbContext.TblActivitySubs on b.ActSeq equals c.ActId
                               where b.ActSeq == actId
                               select c).ToList();

                Node? mainNode = null;
                if (root != null)
                {
                    mainNode = new Node();
                    mainNode.Id = root.ActSeq;
                    mainNode.RoleId = 0;
                    mainNode.RoleName = "Activity";
                    mainNode.TaskId = 0;
                    mainNode.TaskName = root.ActDesc;
                    mainNode.Type = 1;

                    GetSubActChildrenNodes(mainNode, roles, tasks, subActs);

                    //GetChildrenNodes(mainNode, roles, tasks, workFlows);
                }
                return mainNode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Node? GetChartOrgSubActivity(int subActId)
        {
            try
            {
                var roles = _dbContext.TblRoles.ToList();

                var tasks = _dbContext.TblActivityTasks.Where(x => x.SubActId == subActId).ToList();

                var workFlows = (from b in _dbContext.VwJobWorkFlows
                                 where b.SubActivityId == subActId
                                 select b).ToList();

                var root = workFlows.Where(x => x.JwParentId == null).FirstOrDefault();

                Node? mainNode = null;
                if (root != null)
                {
                    mainNode = new Node();
                    mainNode.Id = root.JwId;
                    mainNode.RoleId = root.RoleId;
                    mainNode.TaskId = root.TaskId;
                    var role = roles.Where(x => x.RoleId == root.RoleId).FirstOrDefault();
                    var task = tasks.Where(x => x.TskSeq == root.TaskId).FirstOrDefault();
                    mainNode.Type = 1;
                    if (role != null)
                    {
                        mainNode.RoleName = role?.RoleDesc;
                    }
                    if (task != null)
                    {
                        mainNode.TaskName = task?.TskDesc;
                    }
                    GetChildrenNodes(mainNode, roles, tasks, workFlows, 1);
                }
                return mainNode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GetSubActChildrenNodes(Node node, List<TblRole> roles, List<TblActivityTask> tasks, List<TblActivitySub> subActs)
        {
            var childSubActivities = subActs;
            var childNodes = new List<Node>();

            if (childSubActivities != null)
            {
                foreach (var subAct in childSubActivities)
                {
                    var childNode = new Node();

                    childNode.Id = subAct.SacSeq;
                    childNode.RoleId = 0;
                    childNode.RoleName = "Sub-Activity";
                    childNode.TaskId = 0;
                    childNode.TaskName = subAct.SacDesc;
                    childNode.Type = 2;

                    childNodes.Add(childNode);
                    node.Children = childNodes;

                    var workFlows = (from b in _dbContext.VwJobWorkFlows
                                     where b.SubActivityId == subAct.SacSeq
                                     select b).ToList();
                    var i = 0;
                    GetChildrenNodes(childNode, roles, tasks, workFlows, i);
                }
            }
        }


        private void GetChildrenNodes(Node node, List<TblRole> roles, List<TblActivityTask> tasks, List<VwJobWorkFlow> workFlows, int i)
        {
            var childWorkflows = new List<VwJobWorkFlow>();

            if (i == 0)
                childWorkflows = workFlows.Where(x => x.SubActivityId == node.Id && x?.JwParentId == null).ToList();
            else
                childWorkflows = workFlows.Where(x => x.JwParentId == node.Id).ToList();

            var childNodes = new List<Node>();
            if (childWorkflows != null)
            {
                foreach (var workflow in childWorkflows)
                {
                    var childNode = new Node();

                    childNode.Id = workflow.JwId;
                    childNode.RoleId = workflow.RoleId;
                    childNode.TaskId = workflow.TaskId;
                    var role = roles.Where(x => x.RoleId == workflow.RoleId).FirstOrDefault();
                    var task = tasks.Where(x => x.TskSeq == workflow.TaskId).FirstOrDefault();
                    if (role != null)
                    {
                        childNode.RoleName = role?.RoleDesc;
                    }
                    if (task != null)
                    {
                        childNode.TaskName = task?.TskDesc;
                    }

                    childNode.Type = 3;

                    childNodes.Add(childNode);
                    node.Children = childNodes;
                    i++;
                    GetChildrenNodes(childNode, roles, tasks, workFlows, i);
                }
            }
        }


        public List<WorkFlow> GetWorkFlowBySubActivity(int subActId)
        {
            var result = (from b in _dbContext.VwJobWorkFlows
                          where b.SubActivityId == subActId

                          select new WorkFlow
                          {
                              wfId = b.JwId,
                              wfSort = b.JwSort,
                              wfParentId = b.JwParentId,
                              RoleId = b.RoleId,
                              Role = b.Role,
                              TaskId = b.TaskId,
                              Task = b.Task
                          }).ToList();

            return result;
        }

        public bool AddWorkFlow(int parentId, int TaskId, int RoleId, bool updateTask, string newTaskName)
        {
            var newWf = new TblJobWorkFlow { JwTaskId = TaskId, JwJobId = RoleId, JwParentId = parentId };
            _dbContext.Add<TblJobWorkFlow>(newWf);
            _dbContext.SaveChanges();
            return true;
        }

        public bool AddWorkflowToSubActivity(int SubActivityId, int TaskId, int RoleId, bool updateTask, string newTaskName)
        {
            var t = _dbContext.Database.BeginTransaction();
            try
            {
                var result = _dbContext.TblJobWorkFlows.Where(x => x.JwTaskId == TaskId && x.JwJobId == RoleId).FirstOrDefault();

                if (result == null)
                {
                    var newWf = new TblJobWorkFlow { JwTaskId = TaskId, JwJobId = RoleId, JwParentSubActivity = SubActivityId };
                    _dbContext.Add<TblJobWorkFlow>(newWf);
                    _dbContext.SaveChanges();

                    if (updateTask)
                    {
                        var task = _dbContext.TblActivityTasks.Where(x => x.TskSeq == TaskId).FirstOrDefault();
                        task.TskDesc = newTaskName;
                        _dbContext.TblActivityTasks.Update(task);
                        _dbContext.SaveChanges();
                    }

                    t.Commit();
                    return true;
                }
                else
                {
                    t.Rollback();
                    return false;
                }
            }
            catch (Exception ex)
            {
                t.Rollback();
                return false;
            }
        }

        public bool UpdateWorkFlowParentId(int wfId, int parentId, int type)
        {
            int parentSubactId= 0;

            var firstWf = _dbContext.TblJobWorkFlows.Where(x => x.JwId == wfId).FirstOrDefault();
            if (firstWf != null)
            {
                var firstTask = _dbContext.TblActivityTasks.Where(x => x.TskSeq == firstWf.JwTaskId).FirstOrDefault();
                if (firstTask != null)
                {
                    if (type == 2)
                    {
                        parentSubactId = parentId;

                        //change the Subactivity of Task on First Work Flow
                        firstTask.SubActId = parentSubactId;


                        _dbContext.TblActivityTasks.Update(firstTask);
                        _dbContext.SaveChanges();

                        firstWf.JwParentId = null;
                        firstWf.JwParentSubActivity = parentId;
                        _dbContext.TblJobWorkFlows.Update(firstWf);
                        _dbContext.SaveChanges();
                    }
                    else if (type == 3)
                    {
                        ////Get Task from library
                        var tasksSubAct = _dbContext.VwJobWorkFlows.Where(x => x.JwId == parentId).FirstOrDefault();

                        //change the Subactivity of Task on First Work Flow
                        firstTask.SubActId = tasksSubAct.SubActivityId;

                        _dbContext.TblActivityTasks.Update(firstTask);
                        _dbContext.SaveChanges();

                        firstWf.JwParentId = parentId;
                        firstWf.JwParentSubActivity = null;
                        _dbContext.TblJobWorkFlows.Update(firstWf);
                        _dbContext.SaveChanges();

                        parentSubactId = tasksSubAct.SubActivityId;
                    }


                    bool found = true;
                    TblJobWorkFlow parentWF = new TblJobWorkFlow();
                    parentWF = firstWf;

                    while (found)
                    {
                        var SecondWf = _dbContext.TblJobWorkFlows.Where(x => x.JwParentId == parentWF.JwId).FirstOrDefault();

                        if (SecondWf == null)
                            found = false;
                        else
                        {
                            parentWF = SecondWf;
                            found = true;

                            var task = _dbContext.TblActivityTasks.Where(x => x.TskSeq == parentWF.JwTaskId).FirstOrDefault();
                            task.SubActId = parentSubactId;

                            _dbContext.TblActivityTasks.Update(task);
                            _dbContext.SaveChanges();
                        }
                    }
                }

                return true;
            }
            else
                return false;
        }




        public bool UpdateWorkFlow(int wfId, int taskId, int roleId, bool updateTask, string newTaskName)
        {
            var t = _dbContext.Database.BeginTransaction();
            try
            {
                var result = _dbContext.TblJobWorkFlows.Where(x => x.JwId == wfId).FirstOrDefault();
                result.JwJobId = roleId;
                result.JwTaskId = taskId;
                //result.JwParentId = parentId;
                _dbContext.TblJobWorkFlows.Update(result);
                _dbContext.SaveChanges();

                if (updateTask)
                {
                    var task = _dbContext.TblActivityTasks.Where(x => x.TskSeq == taskId).FirstOrDefault();
                    task.TskDesc = newTaskName;
                    _dbContext.TblActivityTasks.Update(task);
                    _dbContext.SaveChanges();
                }

                t.Commit();
                return true;
            }
            catch (Exception ex)
            {
                t.Rollback();
                return false;
            }
        }


        public bool DeleteWorkFlow(int wfId)
        {
            var t = _dbContext.Database.BeginTransaction();
            try
            {
                var delWf = _dbContext.TblJobWorkFlows.Where(x => x.JwId == wfId).FirstOrDefault();

                if (delWf != null)
                {
                    var childWf = _dbContext.TblJobWorkFlows.Where(x => x.JwParentId == wfId).FirstOrDefault();

                    if (childWf != null)
                    {
                        if (delWf.JwParentId > 0)
                        {
                            childWf.JwParentId = delWf.JwParentId;
                            childWf.JwParentSubActivity = null;
                        }
                        else if (delWf.JwParentSubActivity > 0)
                        {
                            childWf.JwParentId = null;
                            childWf.JwParentSubActivity = delWf.JwParentSubActivity;
                        }
                    }

                    _dbContext.TblJobWorkFlows.Remove(delWf);
                    _dbContext.SaveChanges();

                    t.Commit();

                    return true;
                }
                else
                    return false;

            }
            catch (Exception ex)
            {
                t.Rollback();
                return false;
            }
        }

    }
}
