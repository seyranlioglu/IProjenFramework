$(document).ready(function () {
    Projen.Client.UI.getJqGrid(
        tableId = "userright",
        divId = "pjquserright",
        url = "/FormUserRightSet/FormUserRightSetByUser?Id=" + $("#txtUserId").val(),
        colNames = ['Id', 'Form Id', 'Form Adı', 'Görüntüleme', 'Yeni Kayıt', 'Kaydı Güncelle', 'Silme', 'UserTypes', "<button class='btn btn-xs btn-success' id='adduserright' style='margin-right:5px' onclick=\"Projen.Client.UI.getJqGridNewRow('userright');\"><i class='fa fa-plus'></i> Yeni Kayıt</button>"],
        colModel = [
            { key: true, hidden: true, name: 'Id', index: 'Id', editable: true },
            { name: 'FormName', index: 'FormId', editable: false, hidden: true },
            {
                name: 'FormId', index: 'FormName', editable: true, width: 80, edittype: 'select',
                edittype: "select", editoptions: {
                    dataInit: function (elem) {
                        elem.id = "lkpFormId";
                        $(elem).width(150);  // set the width which you need
                        setTimeout(function () {
                            if (jqselected != null) {
                                if (jqselected.FormName != null)
                                    $('#lkpFormId').append('<option value="' + jqselected.FormName + '">' + jqselected.FormId + '</option>');
                                Projen.Client.UI.getSelect2Combobox(elem.id, "/Form/GetAllForms?Id=" + (jqselected.FormName || 0));
                            } else {
                                Projen.Client.UI.getSelect2Combobox(elem.id, "/Form/GetAllForms?Id=0");
                            }

                            $("#lkpFormId").change(function () {
                                console.log($(this).val());
                            });
                        }, 100);
                    }
                }
            },
            {
                name: 'ViewRight',
                index: 'ViewRight',
                width: 50,
                align: "center",
                edittype: "checkbox",
                editable: true,
                editoptions: {
                    value: "True:Var;False:Yok",
                    dataInit: function (elem) {
                        elem.id = "chViewRight";
                        if (jqselected != null) {
                            if (jqselected.ViewRight == "Var")
                                $("#chViewRight").prop("checked", true);
                        }
                    }
                },

            },
            {
                name: 'InsertRight',
                index: 'InsertRight',
                width: 50,
                align: "center",
                edittype: "checkbox",
                editable: true,
                editoptions: {
                    value: "True:Var;False:Yok",
                    dataInit: function (elem) {
                        elem.id = "chInsertRight";
                        if (jqselected != null) {
                            if (jqselected.InsertRight == "Var")
                                $("#chInsertRight").prop("checked", true);
                        }
                    }
                },

            },
            {
                name: 'UpdateRight',
                index: 'UpdateRight',
                width: 50,
                align: "center",
                edittype: "checkbox",
                editable: true,
                editoptions: {
                    value: "True:Var;False:Yok",
                    dataInit: function (elem) {
                        elem.id = "chUpdateRight";
                        if (jqselected != null) {
                            if (jqselected.UpdateRight == "Var")
                                $("#chUpdateRight").prop("checked", true);
                        }
                    }
                },

            },
            {
                name: 'DeleteRight',
                index: 'DeleteRight',
                width: 50,
                align: "center",
                edittype: "checkbox",
                editable: true,
                editoptions: {
                    value: "True:Var;False:Yok",
                    dataInit: function (elem) {
                        elem.id = "chDeleteRight";
                        if (jqselected != null) {
                            if (jqselected.DeleteRight == "Var")
                                $("#chDeleteRight").prop("checked", true);
                        }
                    }
                },

            },
            {
                name: 'UserId', index: 'UserId', hidden: true, editable: true, editoptions: {
                    defaultValue: $("#txtUserId").val()
                }
            },
            { name: 'act', index: 'act', sortable: false }
        ],
        editurl = "/FormUserRightSet/AddOrUpdateFormUserRightSet?UserTypes=1",
        caption = "",
        multiselect = false,
        deleteurl = "/FormUserRightSet/DeleteFormUserRightSet",
    );
});

$(window).on('resize.jqGrid', function () {
    $("#jqgrid").jqGrid('setGridWidth', $("#myTabContent1").width() - 20);
});