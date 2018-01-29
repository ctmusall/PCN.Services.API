var emailGrid = {
    createGrid: function () {

        var DateField = function(config) {
            jsGrid.Field.call(this, config);
        }

        DateField.prototype = new jsGrid.Field({
            sorter: function(date1, date2) {
                return new Date(date1) - new Date(date2);
            },

            itemTemplate: function (value) {
                return new Date(Date.parse(value)).toLocaleString();
            },

            filterTemplate: function() {
                var now = new Date();
                this._fromPicker = $("<input>").datepicker({ defaultDate: now.setFullYear(now.getFullYear() - 1) });
                this._toPicker = $("<input>").datepicker({ defaultDate: now.setFullYear(now.getFullYear() + 1) });

                var grid = this._grid;

                this._fromPicker.on("keypress", function (e) {
                    if (e.which === 13) {
                        grid.search();
                        e.preventDefault();
                    }
                });

                this._toPicker.on("keypress", function (e) {
                    if (e.which === 13) {
                        grid.search();
                        e.preventDefault();
                    }
                });

                return $("<div>").append(this._fromPicker).append(this._toPicker);
            },

            filterValue: function() {
                return {
                    from: this._fromPicker.datepicker("getDate"),
                    to: this._toPicker.datepicker("getDate")
                };
            }
        });

        jsGrid.fields.dateField = DateField;

        $("#emailGrid").jsGrid({
            width: "100%",
            height: "auto",

            filtering: true,
            inserting: false,
            editing: false,
            sorting: true,
            paging: true,
            autoload: true,
            noDataContent: "No emails found",
            loadIndication: true,
            loadShading: true,

            controller: {
                loadData: function(filter) {
                    var d = $.Deferred();
                    $.ajax({
                        type: "GET",
                        url: "/Email/GetEmails",
                        data: { "token":  sessionStorage.getItem("emailToken") },
                        dataType: "json",
                        contentType: "application/json"
                    }).done(function (response) {
                        var jsonResponse = JSON.parse(response);

                        var filteredResponse = jsonResponse.filter(
                            function(el) {
                                return el.Subject.includes(filter.Subject) &&
                                    el.Id.includes(filter.Id) &&
                                    el.Body.includes(filter.Body) &&                                     
                                    (!filter.DateTimeSent.from || new Date(el.DateTimeSent) >= filter.DateTimeSent.from) &&
                                    (!filter.DateTimeSent.to || new Date(el.DateTimeSent) <= filter.DateTimeSent.to) &&
                                    el.Priority.includes(filter.Priority);
                            });

                        d.resolve(filteredResponse);
                    });

                    return d.promise();
                }
            },

            fields: [
                { name: "Id", visible: true, type: "text" },
                { name: "Subject", visible: true, type: "text" },
                { name: "Body", visible: true, type: "text" },
                { name: "DateTimeSent", title: "Date/Time Sent", visible: true, type: "dateField" },
                { name: "Priority", visible: true, type: "text" }
            ]
        });
    }
}