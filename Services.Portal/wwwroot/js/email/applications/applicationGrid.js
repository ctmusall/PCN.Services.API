var applicationGrid = {
    createGrid: function () {
        $("#applicationGrid").jsGrid({
            width: "100%",
            height: "auto",

            filtering: true,
            inserting: true,
            editing: false,
            sorting: true,
            paging: true,
            autoload: true,
            noDataContent: "No applications found",
            loadIndication: true,
            loadShading: true,

            controller: {
                loadData: function (filter) {
                    var d = $.Deferred();
                    $.ajax({
                        type: "GET",
                        url: "/EmailApplications/GetEmailApplications",
                        data: { "token": sessionStorage.getItem("emailToken") },
                        dataType: "json",
                        contentType: "application/json"
                    }).done(function (response) {
                        var jsonResponse = JSON.parse(response);

                        var filteredResponse = jsonResponse.filter(
                            function (el) {
                                return el.Id.includes(filter.Id) &&
                                    el.Name.includes(filter.Name);
                            });

                        d.resolve(filteredResponse);
                    });

                    return d.promise();
                },
                insertItem: function (item) {
                    $.ajax({
                        type: "POST",
                        url: "/EmailApplications/AddEmailApplication",
                        data: jQuery.param({ applicationName: item.Name }),
                        success: function () {
                        }
                    });
                },
                deleteItem: function (item) {
                    $.ajax({
                        type: "DELETE",
                        url: "/EmailApplications/DeleteEmailApplication",
                        data: jQuery.param(
                            { applicationId: item.Id, token: sessionStorage.getItem("emailToken") }),
                        success: function() {
                        }
                    });
                }
            },

            fields: [
                { name: "Id", visible: true, type: "text", inserting: false },
                { name: "Name", visible: true, type: "text", validate: "required" },
                { type: "control" }
            ]
        });
    }
}