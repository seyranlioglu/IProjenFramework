$(document).ready(function () {
    Projen.Client.UI.getDatatable(
        datatableId = "dtDepartment",
        tablet = 1024,
        phone = 480,
        searchButton = true,
        addnewrowButton = true,
        formId = $("#FormId").val(),
        showhideButton = "C",
        serverside = true,
        ajax = "/Department/DepartmentListDataTable",
        columns = [
            {
                "name": "Id",
                'render': function (data) {
                    return '<a href="/Form/Browse/' + $("#FormId").val() +'?Id=' + data + '"  role="button"><span class="glyphicon glyphicon-pencil"></span></a>';
                }
            },
            { "name": "Id" },
            { "name": "Name" },
            { "name": "Description" },
            { "name": "CreateDate" },
        ]
    );
});