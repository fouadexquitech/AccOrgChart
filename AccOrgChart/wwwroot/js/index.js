var datascource = {
    'id': 1,
    'name': 'Lao Lao',
    'title': 'general manager',
    'children': [
        {
            'id': 2, 'name': 'Bo Miao', 'title': 'department manager',
            'children': [{ 'id': 3, 'name': 'Li Xin', 'title': 'senior engineer' }]
        },
        {
            'id': 4, 'name': 'Su Miao', 'title': 'department manager',
            'children': [
                { 'id': 5, 'name': 'Tie Hua', 'title': 'senior engineer' },
                {
                    'id': 6, 'name': 'Hei Hei', 'title': 'senior engineer',
                    'children': [
                        { 'id': 7, 'name': 'Pang Pang', 'title': 'engineer' },
                        { 'id': 8, 'name': 'Dan Dan', 'title': 'UE engineer' }
                    ]
                }
            ]
        },
        { 'id': 9, 'name': 'Hong Miao', 'title': 'department manager' }
    ]
};

$(document).ready(function () {
    var oc = $('#chart-container').orgchart({
        'data': datascource,
        'nodeContent': 'title',
        'nodeID': 'id',
        'draggable': true,
        'dropCriteria': function ($draggedNode, $dragZone, $dropZone) {
            if ($draggedNode.find('.content').text().indexOf('manager') > -1 && $dropZone.find('.content').text().indexOf('engineer') > -1) {
                return false;
            }
            return true;
        },
        'createNode': function (node, data) {
            $(node).click(function () {
                console.log(data);
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