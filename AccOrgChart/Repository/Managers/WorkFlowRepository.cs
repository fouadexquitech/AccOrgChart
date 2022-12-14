using AccOrgChart.Repository.Interfaces;
using AccOrgChart.Repository.Models.HR_StatisticsModels;
using AccOrgChart.Repository.View_Models;
using System;
using System.Data;
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


        /*Get All Nodes for selected Sub Activity*/
        public Node? GetChartOrgSubActivity(int subActId)
        {
            try
            {
                var roles = _dbContext.TblRoles.ToList();
                var verbs = _dbContext.TblVerbs.ToList();
                var tasks = _dbContext.TblActivityTasks.Where(x => x.SubActId == subActId).ToList();

                var workFlows = (from b in _dbContext.VwJobWorkFlows
                                 where b.SubActivityId == subActId & b.JwProposedAction != 3
                                 select b).ToList();

                var root = workFlows.Where(x => ((x.JwParentId ?? 0)) == 0).FirstOrDefault();

                Node? mainNode = null;
                if (root != null)
                {
                    mainNode = new Node();
                    mainNode.Id = root.JwId;
                    mainNode.Type = 1;
                    mainNode.porposedExist = false;


                    //Proposed Job
                    if ((root.JwProposedJobId ?? 0) > 0 & ((root.JwProposedApproved ?? 0) != 2))
                    {
                        mainNode.proposedRoleId = root.JwProposedJobId;
                        mainNode.porposedBy = root.JwProposedBy;
                        mainNode.porposedExist = true;

                        var propRole = roles.Where(x => x.RoleId == mainNode.proposedRoleId).FirstOrDefault();
                        if (propRole != null)
                        {
                            mainNode.proposedRoleName = propRole?.RoleDesc;
                            mainNode.NodeRoleName = propRole?.RoleDesc;
                        }
                    }

                    mainNode.RoleId = root.RoleId;

                    if ((mainNode.proposedRoleId ?? 0) == 0)
                        mainNode.proposedRoleId = mainNode.RoleId;

                    var role = roles.Where(x => x.RoleId == mainNode.RoleId).FirstOrDefault();
                    if (role != null)
                    {
                        mainNode.RoleName = role?.RoleDesc;
                        mainNode.NodeRoleName = role?.RoleDesc;
                    }

                    if ((mainNode.proposedRoleName ?? "") == "")
                    {
                        mainNode.NodeRoleName = mainNode.RoleName;
                        mainNode.proposedRoleName = mainNode.RoleName;
                    }
                    else
                        mainNode.NodeRoleName = mainNode.proposedRoleName;




                    //Proposed Verb
                    if ((root.JwProposedVerbTask1 ?? 0) > 0 & ((root.JwProposedApproved ?? 0) != 2))
                    {
                        mainNode.proposedVerbId = root.JwProposedVerbTask1;
                        mainNode.porposedBy = root.JwProposedBy;
                        mainNode.porposedExist = true;

                        var propVerb = verbs.Where(x => x.VerbId == mainNode.proposedVerbId).FirstOrDefault();
                        if (propVerb != null)
                        {
                            mainNode.proposedVerbName = propVerb?.VerbDesc;
                            mainNode.NodeVerbName = propVerb?.VerbDesc;
                        }
                    }

                    mainNode.verbId = root.JwVerb;
                    if ((mainNode.proposedVerbId ?? 0) == 0)
                        mainNode.proposedVerbId = mainNode.verbId;

                    var verb = verbs.Where(x => x.VerbId == mainNode.verbId).FirstOrDefault();
                    if (verb != null)
                    {
                        mainNode.verbName = verb?.VerbDesc;
                        mainNode.NodeVerbName = verb?.VerbDesc;
                    }


                    if ((mainNode.proposedVerbName ?? "") == "")
                    {
                        mainNode.NodeVerbName = mainNode.verbName;
                        mainNode.proposedVerbName = mainNode.verbName;
                    }
                    else
                        mainNode.NodeVerbName = mainNode.proposedVerbName;


                    //Proposed Task
                    if ((root.JwProposedTask1 ?? "") != "" & ((root.JwProposedApproved ?? 0) != 2))
                    {
                        mainNode.proposedTaskName = root.JwProposedTask1;
                        mainNode.porposedBy = root.JwProposedBy;
                        mainNode.porposedExist = true;
                        mainNode.NodeTaskName = root.JwProposedTask1;
                    }
                    
                    mainNode.TaskId = root.TaskId;
                    var task = tasks.Where(x => x.TskSeq == mainNode.TaskId).FirstOrDefault();
                    if (task != null)
                    {
                        mainNode.TaskName = task?.TskDesc;
                    }


                    if ((mainNode.proposedTaskName ?? "") == "")
                    {
                        mainNode.NodeTaskName = mainNode.TaskName;
                        mainNode.proposedTaskName = mainNode.TaskName;
                    }
                    else
                        mainNode.NodeTaskName = mainNode.proposedTaskName;


                    GetChildrenNodes(mainNode, roles, verbs, tasks, workFlows, 1);
                }
                return mainNode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GetChildrenNodes(Node node, List<TblRole> roles, List<TblVerb> verbs, List<TblActivityTask> tasks, List<VwJobWorkFlow> workFlows, int i)
        {
            var childWorkflows = new List<VwJobWorkFlow>();

            if (i == 0)
                childWorkflows = workFlows.Where(x => x.SubActivityId == node.Id && ((x?.JwParentId ?? 0) == 0)).ToList();
            else
                childWorkflows = workFlows.Where(x => x.JwParentId == node.Id).ToList();

            var childNodes = new List<Node>();
            if (childWorkflows != null)
            {
                foreach (var workflow in childWorkflows)
                {
                    var childNode = new Node();
                    childNode.Id = workflow.JwId;
                    childNode.Type = 3;
                    childNode.porposedExist = false;

                    //Proposed Job
                    if ((workflow.JwProposedJobId ?? 0) > 0 & ((workflow.JwProposedApproved ?? 0) != 2))
                    {
                        childNode.proposedRoleId = workflow.JwProposedJobId;
                        childNode.porposedBy = workflow.JwProposedBy;
                        childNode.porposedExist = true;

                        var propRole = roles.Where(x => x.RoleId == childNode.proposedRoleId).FirstOrDefault();
                        if (propRole != null)
                        {
                            childNode.proposedRoleName = propRole?.RoleDesc;
                            childNode.NodeRoleName = propRole?.RoleDesc;
                        }
                    }

                    childNode.RoleId = workflow.RoleId;

                    if ((childNode.proposedRoleId ?? 0) == 0)
                        childNode.proposedRoleId = childNode.RoleId;

                    var role = roles.Where(x => x.RoleId == childNode.RoleId).FirstOrDefault();
                    if (role != null)
                    {
                        childNode.RoleName = role?.RoleDesc;
                        childNode.NodeRoleName = role?.RoleDesc;
                    }

                    if ((childNode.proposedRoleName ?? "") == "")
                    {
                        childNode.NodeRoleName = childNode.RoleName;
                        childNode.proposedRoleName = childNode.RoleName;
                    }
                    else
                        childNode.NodeRoleName = childNode.proposedRoleName;



                    //Proposed Verb
                    if ((workflow.JwProposedVerbTask1 ?? 0) > 0 & ((workflow.JwProposedApproved ?? 0) != 2))
                    {
                        childNode.proposedVerbId = workflow.JwProposedVerbTask1;
                        childNode.porposedBy = workflow.JwProposedBy;
                        childNode.porposedExist = true;

                        var propVerb = verbs.Where(x => x.VerbId == childNode.proposedVerbId).FirstOrDefault();
                        if (propVerb != null)
                        {
                            childNode.proposedVerbName = propVerb?.VerbDesc;
                            childNode.NodeVerbName = propVerb?.VerbDesc;
                        }
                    }

                    childNode.verbId = workflow.JwVerb;
                    if ((childNode.proposedVerbId ?? 0) == 0)
                        childNode.proposedVerbId = childNode.verbId;

                    var verb = verbs.Where(x => x.VerbId == childNode.verbId).FirstOrDefault();
                    if (verb != null)
                    {
                        childNode.verbName = verb?.VerbDesc;
                        childNode.NodeVerbName = verb?.VerbDesc;
                    }


                    if ((childNode.proposedVerbName ?? "") == "")
                    {
                        childNode.NodeVerbName = childNode.verbName;
                        childNode.proposedVerbName = childNode.verbName;
                    }
                    else
                        childNode.NodeVerbName = childNode.proposedVerbName;



                    //Proposed Task
                    if ((workflow.JwProposedTask1 ?? "") != "" & ((workflow.JwProposedApproved ?? 0) != 2))
                    {
                        childNode.proposedTaskName = workflow.JwProposedTask1;
                        childNode.porposedBy = workflow.JwProposedBy;
                        childNode.porposedExist = true;
                        childNode.NodeTaskName = workflow.JwProposedTask1;
                    }

                    childNode.TaskId = workflow.TaskId;
                    var task = tasks.Where(x => x.TskSeq == childNode.TaskId).FirstOrDefault();
                    if (task != null)
                    {
                        childNode.TaskName = task?.TskDesc;
                    }

                    if ((childNode.proposedTaskName ?? "") == "")
                    {
                        childNode.NodeTaskName = childNode.TaskName;
                        childNode.proposedTaskName = childNode.TaskName;
                    }
                    else
                        childNode.NodeTaskName = childNode.proposedTaskName;



                    childNodes.Add(childNode);
                    node.Children = childNodes;
                    i++;
                    GetChildrenNodes(childNode, roles, verbs, tasks, workFlows, i);
                }
            }
        }

        public Node? GetChartOrgActivity(int actId)
        {
            try
            {
                var roles = _dbContext.TblRoles.ToList();
                var verbs = _dbContext.TblVerbs.ToList();
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
                    mainNode.Type = 1;
                    mainNode.RoleId = 0;
                    mainNode.RoleName = "Activity";
                    mainNode.NodeRoleName = "Activity";
                    mainNode.TaskId = 0;
                    mainNode.TaskName = root.ActDesc;
                    mainNode.NodeTaskName = root.ActDesc;

                    GetSubActChildrenNodes(mainNode, roles, verbs, tasks, subActs);

                    //GetChildrenNodes(mainNode, roles, tasks, workFlows);
                }
                return mainNode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GetSubActChildrenNodes(Node node, List<TblRole> roles, List<TblVerb> verbs, List<TblActivityTask> tasks, List<TblActivitySub> subActs)
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
                    childNode.NodeRoleName = "Sub-Activity";
                    childNode.TaskId = 0;
                    childNode.Type = 2;


                    //Proposed Sub-Activity
                    if ((subAct.ProposedSubActivity ?? "") != "" & ((subAct.ProposedApproved ?? 0) != 2))
                    {
                        childNode.proposedTaskName = subAct.ProposedSubActivity;
                        childNode.porposedBy = subAct.ProposedBy;
                        childNode.porposedExist = true;
                        childNode.NodeTaskName = subAct.ProposedSubActivity;
                    }

                    childNode.TaskName = subAct.SacDesc;

                    if ((childNode.proposedTaskName ?? "") == "")
                    {                  
                        childNode.NodeTaskName = childNode.TaskName;
                        childNode.proposedTaskName = childNode.TaskName;
                    }
                    else
                        childNode.NodeTaskName = childNode.proposedTaskName;


                    childNodes.Add(childNode);
                    node.Children = childNodes;

                    var workFlows = (from b in _dbContext.VwJobWorkFlows
                                     where b.SubActivityId == subAct.SacSeq & b.JwProposedAction != 3
                                     select b).ToList();
                    var i = 0;
                    GetChildrenNodes(childNode, roles, verbs, tasks, workFlows, i);
                }
            }
        }


        public List<WorkFlow> GetWorkFlowBySubActivity(int subActId)
        {
            var result = (from b in _dbContext.VwJobWorkFlows
                          where b.SubActivityId == subActId & b.JwProposedAction != 3

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

        public bool AddWorkFlow(int parentId, int RoleId, int verbId, int TaskId, string newTaskName, string proposedUser, int wfAddMode)
        {
            var t = _dbContext.Database.BeginTransaction();
            try
            {
                var wf = new TblJobWorkFlow();
                int SubActivityId;

                if (wfAddMode == 2)  /*Add to SubActivity Node*/
                {
                    wf = _dbContext.TblJobWorkFlows.Where(x => x.JwTaskId == TaskId && x.JwJobId == RoleId && x.JwParentSubActivity == parentId).FirstOrDefault();
                    SubActivityId = parentId;
                }
                else
                {
                    wf = _dbContext.TblJobWorkFlows.Where(x => x.JwTaskId == TaskId && x.JwJobId == RoleId && x.JwParentId == parentId).FirstOrDefault();

                    /*Get Parent Node SubActivity*/
                    var parentWF = _dbContext.TblJobWorkFlows.Where(x => x.JwId == parentId).FirstOrDefault();
                    if (parentWF != null)
                    {
                        var tskId = parentWF.JwTaskId;
                        var task = _dbContext.TblActivityTasks.Where(x => x.TskSeq == tskId).FirstOrDefault();
                        SubActivityId = (int)task.SubActId;
                    }
                    else
                    {
                        t.Rollback();
                        return false;
                    }
                }

                if (wf == null)
                {
                    var newTask = new TblActivityTask { TskDesc = newTaskName, SubActId = SubActivityId, IsProposed = 1, ProposedBy = proposedUser };
                    _dbContext.Add<TblActivityTask>(newTask);
                    _dbContext.SaveChanges();
                    int createdTaskId = newTask.TskSeq;

                    //var createdTaskId = _dbContext.TblActivityTasks.Where(x => x.TskDesc == newTaskName && x.SubActId == SubActivityId && x.IsProposed == 1 && x.ProposedBy == proposedUser).FirstOrDefault();

                    var newWf = new TblJobWorkFlow();

                    if (wfAddMode == 2)  /*Add to SubActivity Node*/
                        newWf = new TblJobWorkFlow { JwParentId = 0, JwParentSubActivity = parentId, JwJobId = RoleId, JwVerb = verbId, JwTaskId = createdTaskId, JwProposedJobId = RoleId, JwProposedVerbTask1 = verbId, JwProposedTask1 = newTaskName, JwProposedTaskId = createdTaskId, JwProposedBy = proposedUser, JwProposedAction = 1, JwProposedApproved = 1, JwProposedDate = DateTime.Now, JwProposedNew = 1 };
                    else
                        newWf = new TblJobWorkFlow { JwParentId = parentId, JwParentSubActivity = 0, JwJobId = RoleId, JwVerb = verbId, JwTaskId = createdTaskId, JwProposedJobId = RoleId, JwProposedVerbTask1 = verbId, JwProposedTask1 = newTaskName, JwProposedTaskId = createdTaskId, JwProposedBy = proposedUser, JwProposedAction = 1, JwProposedApproved = 1, JwProposedDate = DateTime.Now, JwProposedNew = 1 };

                    _dbContext.Add<TblJobWorkFlow>(newWf);
                    _dbContext.SaveChanges();

                    int createdWfId = newWf.JwId;

                    newTask.WorkFlowId = createdWfId;
                    _dbContext.TblActivityTasks.Update(newTask);
                    _dbContext.SaveChanges();

                    //if (updateTask)
                    //{
                    //    var task = _dbContext.TblActivityTasks.Where(x => x.TskSeq == TaskId).FirstOrDefault();
                    //    task.TskDesc = newTaskName;
                    //    _dbContext.TblActivityTasks.Update(task);
                    //    _dbContext.SaveChanges();
                    //}

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

        public bool AddWorkflowToSubActivity(int SubActivityId, int TaskId, int RoleId, bool updateTask, string newTaskName, int verbId, string proposedUser)
        {
            var t = _dbContext.Database.BeginTransaction();
            try
            {
                var result = _dbContext.TblJobWorkFlows.Where(x => x.JwTaskId == TaskId && x.JwJobId == RoleId && x.JwParentSubActivity == SubActivityId).FirstOrDefault();
                if (result == null)
                {
                    //AH0912
                    //if ((newTaskName == null) | (newTaskName ==""))
                    //{
                    //    var task = _dbContext.TblActivityTasks.Where(x => x.TskSeq == TaskId).FirstOrDefault();
                    //    newTaskName = task.TskDesc;
                    //}

                    var newTask = new TblActivityTask { TskDesc = newTaskName, SubActId = SubActivityId, IsProposed = 1, ProposedBy = proposedUser };
                    _dbContext.Add<TblActivityTask>(newTask);
                    _dbContext.SaveChanges();

                    var newTaskId = _dbContext.TblActivityTasks.Where(x => x.TskDesc == newTaskName && x.SubActId == SubActivityId && x.IsProposed == 1 && x.ProposedBy == proposedUser).FirstOrDefault();

                    var newWf = new TblJobWorkFlow { JwJobId = RoleId, JwVerb = verbId, JwTaskId = newTaskId.TskSeq, JwProposedJobId = RoleId, JwProposedVerbTask1 = verbId, JwProposedTask1 = newTaskName, JwProposedBy = proposedUser, JwProposedAction = 1, JwProposedApproved = 1, JwProposedDate = DateTime.Now, JwParentId = 0, JwParentSubActivity = SubActivityId, JwProposedNew = 1 };
                    //var newWf = new TblJobWorkFlow { JwTaskId = newTaskId.TskSeq, JwJobId = RoleId,JwParentId=0, JwParentSubActivity = SubActivityId,JwVerb= verbId };
                    //AH0912/

                    _dbContext.Add<TblJobWorkFlow>(newWf);
                    _dbContext.SaveChanges();

                    //if (updateTask)
                    //{
                    //    var task = _dbContext.TblActivityTasks.Where(x => x.TskSeq == TaskId).FirstOrDefault();
                    //    task.TskDesc = newTaskName;
                    //    _dbContext.TblActivityTasks.Update(task);
                    //    _dbContext.SaveChanges();
                    //}

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
            int parentSubactId = 0;

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

                        firstWf.JwParentId = 0;
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

        public bool UpdateWorkFlow(int wfId, int taskId, int roleId, bool updateTask, string newTaskName, int verbId, int proposedRoleId, int proposedVerbId, string proposedTaskName, string proposedUser)
        {
            var t = _dbContext.Database.BeginTransaction();
            try
            {
                bool isProposed = false;
                var result = _dbContext.TblJobWorkFlows.Where(x => x.JwId == wfId).FirstOrDefault();

                if (result != null)
                {
                    if ((roleId != proposedRoleId) & (proposedRoleId > 0))
                    {
                        result.JwProposedJobId = proposedRoleId;
                        isProposed = true;
                    }

                    if ((verbId != proposedVerbId) & (proposedVerbId > 0))
                    {
                        result.JwProposedVerbTask1 = proposedVerbId;
                        isProposed = true;
                    }

                    if (proposedTaskName != "")
                    {
                        result.JwProposedTask1 = proposedTaskName;
                        result.JwProposedAction = 1;  //Change Task
                        isProposed = true;
                    }

                    if (isProposed)
                    {
                        result.JwProposedNew = 0;
                        result.JwProposedApproved = 1;  //in case of approval value will be 2
                        result.JwProposedBy = proposedUser;
                        result.JwProposedDate = DateTime.Now;
                    }

                    _dbContext.TblJobWorkFlows.Update(result);
                    _dbContext.SaveChanges();
                }

                //if (updateTask)
                //{
                //    var task = _dbContext.TblActivityTasks.Where(x => x.TskSeq == taskId).FirstOrDefault();
                //    task.TskDesc = newTaskName;
                //    _dbContext.TblActivityTasks.Update(task);
                //    _dbContext.SaveChanges();
                //}

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
                        if ((delWf.JwParentId ?? 0) > 0)
                        {
                            childWf.JwParentId = delWf.JwParentId;
                            childWf.JwParentSubActivity = null;
                        }
                        else if ((delWf.JwParentSubActivity ?? 0) > 0)
                        {
                            childWf.JwParentId = 0;
                            childWf.JwParentSubActivity = delWf.JwParentSubActivity;
                        }
                    }

                    delWf.JwProposedAction = 3;//Eliminate
                    //_dbContext.TblJobWorkFlows.Remove(delWf);
                    _dbContext.TblJobWorkFlows.Update(delWf);
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
