var contactGrid = {
    createGrid: function () {
        $("#contactGrid").jsGrid({
            width: "100%",
            height: "auto",

            filtering: true,
            inserting: false,
            editing: false,
            sorting: true,
            paging: true,
            autoload: true,
            noDataContent: "No contacts found",
            loadIndication: true,
            loadShading: true,

            controller: {
                loadData: function (filter) {
                    var d = $.Deferred();
                    $.ajax({
                        type: "GET",
                        url: "/Email/GetEmails",
                        data: { "token": sessionStorage.getItem("emailToken") },
                        dataType: "json",
                        contentType: "application/json"
                    }).done(function (response) {
                        var jsonResponse = JSON.parse(response);

                        var contacts = $.map(jsonResponse,
                            function(el) {
                                return el.EmailContacts;
                            });

                        var filteredResponse = contacts.filter(
                            function (el) {
                                return el.Id.includes(filter.Id) &&
                                    el.EmailAddress.includes(filter.EmailAddress) &&
                                    (!el.DisplayName || el.DisplayName.includes(filter.DisplayName)) &&
                                    el.EmailLogId.includes(filter.EmailLogId) &&
                                    el.ContactType.includes(filter.ContactType);
                            });

                        d.resolve(filteredResponse);
                    });

                    return d.promise();
                }
            },

            fields: [
                { name: "Id", visible: true, type: "text" },
                { name: "EmailAddress", title: "Email Address", visible: true, type: "text" },
                { name: "DisplayName", title: "Display Name", visible: true, type: "text" },
                { name: "EmailLogId", title: "Email Log Id", visible: true, type: "text" },
                { name: "ContactType", title: "Contact Type", visible: true, type: "text" }
            ]
        });
    }
}