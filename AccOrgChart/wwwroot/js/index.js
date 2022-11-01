var roles = [
    { id: 1, name: 'Operations Manager (OM)' },
    { id: 2, name: 'Project Manager (PM)' },
    { id: 3, name: 'Construction Manager (CM)' },
    { id: 4, name: 'Contract Manager (CtM)' },
    { id: 5, name: 'Adm & Fin Manager' },
    { id: 6, name: 'Chief Accountant' },
    { id: 7, name: 'Accountant' },
    { id: 8, name: 'Accounting Clerk' }
];

var tasks = [
    { id: 1, name: 'Review and endorse for stamp duties and distribution of original & copies' },
    { id: 2, name: 'Check wording, stamp duties and distribution of original & copies' },
    { id: 3, name: 'Receive copy, review and file' },
    { id: 4, name: 'Handles fiscal stamps. Files Client Contracts with lawyer..' },
    { id: 5, name: 'Coordinates fiscal stamps payments. Reviews JV (Off B/S account)' },
    { id: 6, name: 'Creates off B/S account to record full contract value)' },
    { id: 7, name: 'Files JV' }
   
];


var datascource = {
    'id': 1,
    'roleId' : 1,
    'role': 'Operations Manager (OM)',
    'taskId' : 1,
    'task': 'Review and endorse for stamp duties and distribution of original & copies',
    'children': [
        {
            'id': 2, 'roleId': 2, 'role': 'Project Manager (PM)', 'taskId': 2, 'task': 'Check wording, stamp duties and distribution of original & copies',
            'children': [{ 'id': 3, 'roleId': 3, 'role': 'Construction Manager (CM)', 'taskId': 3, 'task': 'Receive copy, review and file' }]
        },
        {
            'id': 4, 'roleId': 4, 'role': 'Contract Manager (CtM)', 'taskId': 3, 'task': 'Receive copy, review and file',
            'children': [
                { 'id': 5, 'roleId': 5, 'role': 'Adm & Fin Manager', 'taskId': 4, 'task': 'Handles fiscal stamps. Files Client Contracts with lawyer..' },
                {
                    'id': 6, 'roleId': 6, 'role': 'Chief Accountant', 'taskId': 5, 'task': 'Coordinates fiscal stamps payments. Reviews JV (Off B/S account)',
                    'children': [
                        { 'id': 7, 'roleId': 7, 'role': 'Accountant', 'taskId': 6, 'task': 'Creates off B/S account to record full contract value)' },
                        { 'id': 8, 'roleId': 8, 'role': 'Accounting Clerk', 'taskId': 7, 'task': 'Files JV' }
                    ]
                }
            ]
        }
    ]
};
$(document).ready(function () {

    roles.forEach(el => {
        $('#ddlRoles').append('<option value="' + el.id + '">' + el.name + '</option>');
    });

    tasks.forEach(el => {
        $('#ddlTasks').append('<option value="' + el.id + '">' + el.name + '</option>');
    });
 
    var oc = $('#chart-container').orgchart({
        'data': datascource,
        'nodeTitle' : 'role',
        'nodeContent': 'task',
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
                
                $('#spanModalContentTitle').text(data.role);
                $('#ddlRoles').val(data.roleId);
                $('#ddlTasks').val(data.taskId);
                $('#txtTaskDesc').val(data.task);
                $('#modalContent').modal('show');
                
            });

        }
    });

    oc.$chart.on('nodedrop.orgchart', function (event, extraParams) {
        console.log('draggedNode:' + extraParams.draggedNode.children('.title').text()
            + ', dragZone:' + extraParams.dragZone.children('.title').text()
            + ', dropZone:' + extraParams.dropZone.children('.title').text()
        );
    });

});

function changeTaskDesc(sender) {
    
    let checked = $(sender).prop('checked');
    
    $('#txtTaskDesc').prop('readonly', !checked);
    

}

function onTaskChange(sender) {
    $('#txtTaskDesc').val(sender.options[sender.selectedIndex].text);
}