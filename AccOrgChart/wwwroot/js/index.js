var selectedNodeId = -1;
var subActivityMode = 'add';
var wfMode = 'add';
function buildChart() {
    let actId = 0;
    let subActId = 0;

    if ($('#ddlSubActivities').val() > 0) {
        subActId = $('#ddlSubActivities').val();
        var ajaxUrl = '/WorkFlow/GetChartOrgSubActivity?subActId=' + subActId;
    }
    else {
        actId = $('#ddlActivities').val();
        if (actId > 0)
            var ajaxUrl = '/WorkFlow/GetChartOrgActivity?actId=' + actId;
        else
            return;
    }


    var oc = $('#chart-container').orgchart({
        'data': ajaxUrl,
        'nodeTitle': 'roleName',
        'nodeContent': 'taskName',
        'nodeType' : 'type',
        'nodeID': 'id',
        'parentNodeSymbol': '',
        'draggable': true,
        'dropCriteria': function ($draggedNode, $dragZone, $dropZone) {
            if ($draggedNode.find('.content').text().indexOf('manager') > -1 && $dropZone.find('.content').text().indexOf('engineer') > -1) {
                return false;
            }
            return true;
        },
        'createNode': function (node, data) {
            /*$(node).dblclick(function () {
                resetForm();
                selectedNodeId = data.id;

                if (data.type == 3) //Task
                {
                    $('#spanModalContentTitle').text(data.role);
                    $('#ddlRoles').val(data.roleId);
                    getTasks(actId, subActId, data.taskId);
                    getRoles(data.roleId);
                    $('#txtTaskDesc').val(data.taskName);
                    $('#modalContent').modal('show');
              
                }
                
            });*/

            

        }

    });

    oc.$chart.on('nodedrop.orgchart', function (event, extraParams) {
        /*console.log('draggedNode:' + extraParams.draggedNode.children('.title').text()
            + ', dragZone:' + extraParams.dragZone.children('.title').text()
            + ', dropZone:' + extraParams.dropZone.children('.title').text()
        );*/

        let id = extraParams.draggedNode[0].id;

        let oldParentId = extraParams.draggedNode[0].getAttribute('data-parent');
        let newParentId = extraParams.dropZone[0].id;
        let parentType = extraParams.dropZone[0].getAttribute('data-type');
        $.ajax({
            'url': '/WorkFlow/UpdateWorkFlowParentId?wfId=' + id + '&parentId=' + newParentId + '&type=' + parentType,
            'dataType': 'json'
        })
            .done(function (data, textStatus, jqXHR) {
                $('#chart-container').empty();
                // build the org-chart
                var $chartContainer = this.$chartContainer;
                if (this.$chart) {
                    this.$chart.remove();
                }

                buildChart();
            })
            .fail(function (jqXHR, textStatus, errorThrown) {
                console.log(errorThrown);
            })
    });
}


function resetForm() {
    $('#frmUpdateTask').trigger("reset");
    $('#chkTask').attr("checked", false);
    $('#txtTaskDesc').attr("readonly", true);
    subActivityMode = 'add';
    wfMode = 'add';
    $('#frmUpdateSubActivity').trigger("reset");
    $('#chkSubActivity').attr("checked", false);
    $('#txtSubActivityDesc').attr("readonly", true);
}

$(document).ready(function () {
    getActivities();
    getSubActivities();
    $.validator.addMethod("requiredSelect", function (value, element) {

        if (value == null || value == '' || value == '0') {
            return false;
        } else {
            return true;
        };
    }, "<span class='text-danger'>Required Field</span>");

    $.validator.addMethod("requiredInput", function (value, element) {

        if (value == null || value == '') {
            return false;
        } else {
            return true;
        };
    }, "<span class='text-danger'>Required Field</span>");

    $("#frmUpdateTask").validate({
        rules: {
            ddlRoles: {
                requiredSelect: true

            },
            ddlTasks: {
                requiredSelect: true,

            },
            txtTaskDesc: {
                requiredInput: true
            }


        }
    });

    $("#frmUpdateSubActivity").validate({
        rules: {
            txtSubActivityName: {
                requiredInput: true
            }

        }
    });

    $.contextMenu({
        selector: '.context-menu-one',
        callback: function (key, options) {
            let id = $(this).attr('id');
            
            let type = $(this).attr('data-type');
            let parentId = $(this).attr('data-parent');
            let roleName = $(this).attr('data-role-name');
            let roleId = $(this).attr('data-role-id');
            let taskId = $(this).attr('data-task-id');
            let taskName = $(this).attr('data-task-name');
            resetForm();
            selectedNodeId = id;
           
            if (type == 3) //Task
            {
                if (key == 'edit') {
                    wfMode = 'edit';
                    $('#spanWfTitle').text('Edit');
                    $('#spanModalContentTitle').text(roleName);
                    $('#ddlRoles').val(roleId);
                    getTasks(0, 0, taskId);
                    getRoles(roleId);
                    $('#txtTaskDesc').val(taskName);
                    $('#modalContent').modal('show');
                }
                else if (wfMode = 'add') {
                    wfMode = 'add';
                }

            }
            else if (type == 2) {
                if (key == 'edit') {
                    subActivityMode = 'edit';
                    $('#spanSubActivityTitle').text('Edit Sub-Activity');
                    $('#txtSubActivityName').val(taskName);
                    $('#modalContentSubActivity').modal('show');
                }
                else if (key == 'add') {
                    wfMode = 'add';
                    $('#spanWfTitle').text('Add');
                    $('#spanModalContentTitle').text(roleName);
                    getTasks(0, 0, 0);
                    getRoles(0);
                    $('#chkTask').attr('checked', false);
                    $('#txtTaskDesc').val('');
                    $('#txtTaskDesc').attr('readonly', true);
                    $('#modalContent').modal('show');
                }

            }
            else if (type == 1) {
                if (key == 'add') {
                    subActivityMode = 'add';
                    $('#spanSubActivityTitle').text('Add New Sub-Activity');
                    $('#txtSubActivityName').val('');
                    $('#modalContentSubActivity').modal('show');
                }
            }
        },
        items: {
            "add": { name: "Add Sub Node", icon: "add" },
            "edit": { name: "Edit", icon: "edit" },
            "delete": { name: "Delete", icon: "delete" },
            /*"sep1": "---------",
            "quit": {
                name: "Quit", icon: function () {
                    return 'context-menu-icon context-menu-icon-quit';
                }
            }*/
        }
    });

    
});

function submitForm() {
    if ($("#frmUpdateTask").valid()) {
        var taskId = $('#ddlTasks').val();
        roleId = $('#ddlRoles').val();
        var updateTask = $('#chkTask').prop('checked');
        var newTaskName = $('#txtTaskDesc').val();
        
        var url = '/WorkFlow/UpdateWorkFlow?wfId=' + selectedNodeId + '&taskId=' + taskId + '&roleId=' + roleId + '&updateTask=' + updateTask + '&newTaskName=' + newTaskName;
        if (wfMode == 'add') {
            url = '/WorkFlow/AddWorkflowToSubActivity?SubActivityId=' + selectedNodeId + '&taskId=' + taskId + '&roleId=' + roleId + '&updateTask=' + updateTask + '&newTaskName=' + newTaskName;
        }
        $.ajax({
            'url': url,
            'dataType': 'json'
        })
            .done(function (data, textStatus, jqXHR) {
                $('#modalContent').modal('hide');
                $('#chart-container').empty();
                // build the org-chart
                var $chartContainer = this.$chartContainer;
                if (this.$chart) {
                    this.$chart.remove();
                }
                buildChart();
            })
            .fail(function (jqXHR, textStatus, errorThrown) {
                console.log(errorThrown);
            });
    }
}

function submitFormSubActivity()
{
    if ($("#frmUpdateSubActivity").valid()) {
        var subActivityName = $('#txtSubActivityName').val();
        var url = '/Activities/UpdateSubActivity?subActivityId=' + selectedNodeId + '&newSubActDesc=' + subActivityName;
        if (subActivityMode == 'add') {
            url = '/Activities/AddSubActivity?ActivityId=' + selectedNodeId + '&SubActivityDesc=' + subActivityName;
        }
        $.ajax({
            'url': url,
            'dataType': 'json'
        })
            .done(function (data, textStatus, jqXHR) {
                $('#modalContentSubActivity').modal('hide');
                $('#chart-container').empty();
                // build the org-chart
                var $chartContainer = this.$chartContainer;
                if (this.$chart) {
                    this.$chart.remove();
                }
                buildChart();
            })
            .fail(function (jqXHR, textStatus, errorThrown) {
                console.log(errorThrown);
            });
    }
}

function changeTaskDesc(sender) {
    let checked = $(sender).prop('checked');
    $('#txtTaskDesc').prop('readonly', !checked)
}

function onTaskChange(sender) {
    $('#txtTaskDesc').val(sender.options[sender.selectedIndex].text);
}

function changeSubActivityDesc(sender) {
    let checked = $(sender).prop('checked');
    $('#txtSubActivityDesc').prop('readonly', !checked)
}

function getRoles(selectedRoleId) {
    $.ajax({
        'url': '/Jobs/GetJobsList',
        'dataType': 'json'
    })
        .done(function (data, textStatus, jqXHR) {
            let $select = $('#ddlRoles');

            if ($select) {
                $select.find('option').remove();
                $select.append('<option value="0"></option>');
                data.forEach(el => {
                    $select.append('<option value="' + el.roleId + '">' + el.roleDesc + '</option>');
                });

                $select.val(selectedRoleId);
            }
        })
        .fail(function (jqXHR, textStatus, errorThrown) {
            console.log(errorThrown);
        })
}

function getSubActivities() {
    $.ajax({
        'url': '/Activities/GetSubActivities',
        'dataType': 'json'
    })
        .done(function (data, textStatus, jqXHR) {
            let $select = $('#ddlSubActivities');
            if ($select) {
                $select.append('<option value="0"></option>');
                data.forEach(el => {
                    $select.append('<option value="' + el.sacSeq + '">' + el.sacDesc + '</option>');
                });
            }
        })
        .fail(function (jqXHR, textStatus, errorThrown) {
            console.log(errorThrown);
        })
}

function subActivityChange(sender) {

    $('#chart-container').empty();
    // build the org-chart
    var $chartContainer = this.$chartContainer;
    if (this.$chart) {
        this.$chart.remove();
    }
    buildChart();
}



function getActivities() {
    $.ajax({
        'url': '/Activities/GetActivities',
        'dataType': 'json'
    })
        .done(function (data, textStatus, jqXHR) {
            let $select = $('#ddlActivities');
            if ($select) {
                $select.append('<option value="0"></option>');
                data.forEach(el => {
                    $select.append('<option value="' + el.actSeq + '">' + el.actDesc + '</option>');
                });

            }
        })
        .fail(function (jqXHR, textStatus, errorThrown) {
            console.log(errorThrown);
        })
}



function activityChange(sender) {

    $('#chart-container').empty();
    // build the org-chart
    var $chartContainer = this.$chartContainer;
    if (this.$chart) {
        this.$chart.remove();
    }
    buildChart();
}


function getTasks(actId, subActId, selectedTaskId) {
    $.ajax({
        'url': '/Activities/GetTasks?actId=' + actId + '?subActId=' + subActId,
        'dataType': 'json'
    })
        .done(function (data, textStatus, jqXHR) {
            let $select = $('#ddlTasks');
            if ($select) {
                $select.find('option').remove();
                $select.append('<option value="0"></option>')
                data.forEach(el => {

                    $select.append('<option value="' + el.tskSeq + '">' + el.tskDesc + '</option>');

                });

                $select.val(selectedTaskId);
            }
        })
        .fail(function (jqXHR, textStatus, errorThrown) {
            console.log(errorThrown);
        })
}