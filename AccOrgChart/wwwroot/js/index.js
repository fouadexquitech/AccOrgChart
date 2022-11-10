var selectedWfId = -1;
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
            $(node).dblclick(function () {
                resetForm();
                selectedWfId = data.id;
                var type = data.type;

                console.log(data);

                if (type == 3) //Task
                {
                    $('#spanModalContentTitle').text(data.role);
                    $('#ddlRoles').val(data.roleId);
                    getTasks(actId, subActId, data.taskId);
                    getRoles(data.roleId);
                    $('#txtTaskDesc').val(data.taskName);
                    $('#modalContent').modal('show');
                    $('#frmUpdateSubActivity').modal('hide');
                    $('#frmUpdateTask').modal('show');
                }
                else
                    if (type == 2) //Sub Activity
                    {
                        $('#txtSubActivityDesc').val(data.roleName);
                        $('#modalContent').modal('show');
                        $('#frmUpdateTask').modal('hide');
                        $('#frmUpdateSubActivity').modal('show');
                    }
            });
        }

    });

    oc.$chart.on('nodedrop.orgchart', function (event, extraParams) {
        console.log('draggedNode:' + extraParams.draggedNode.children('.title').text()
            + ', dragZone:' + extraParams.dragZone.children('.title').text()
            + ', dropZone:' + extraParams.dropZone.children('.title').text()
        );

        let id = extraParams.draggedNode[0].id;

        let oldParentId = extraParams.draggedNode[0].getAttribute('data-parent');
        let newParentId = extraParams.dropZone[0].id;

        $.ajax({
            'url': '/WorkFlow/UpdateWorkFlowParentId?wfId=' + id + '&parentId=' + newParentId,
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
});

function submitForm() {
    if ($("#frmUpdateTask").valid()) {
        var taskId = $('#ddlTasks').val();
        roleId = $('#ddlRoles').val();
        var updateTask = $('#chkTask').prop('checked');
        var newTaskName = $('#txtTaskDesc').val();
        $.ajax({
            'url': '/WorkFlow/UpdateWorkFlow?wfId=' + selectedWfId + '&taskId=' + taskId + '&roleId=' + roleId + '&updateTask=' + updateTask + '&newTaskName=' + newTaskName,
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