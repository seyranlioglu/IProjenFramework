$(document).ready(function () {
    Projen.Client.UI.getDatatable(
        datatableId = "dtCustomer",
        tablet = 1024,
        phone = 480,
        searchButton = true,
        addnewrowButton = true,
        formId = $("#FormId").val(),
        showhideButton = "C",
        serverside = true,
        ajax = "/Customer/CustomerListDataTable",
        columns = [
            {
                "name": "Id",
                'render': function (data) {
                    return '<a href="/Form/Browse/' + $("#FormId").val() + '?Id=' + data + '"  role="button"><span class="glyphicon glyphicon-pencil"></span></a>';
                }
            },
            { "name": "Id" },
            { "name": "DisplayName" },
            { "name": "CommercialTitle" },
            { "name": "TaxOffice" },
            { "name": "TaxNumber" },
            { "name": "Identifier" },
            { "name": "TelephoneNumber" },
            { "name": "EmailAddress" },
            { "name": "WebAddress" },
        ]
    );
});

