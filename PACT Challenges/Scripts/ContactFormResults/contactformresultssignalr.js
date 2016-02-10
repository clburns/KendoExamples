$(function () {
    var connection = $.connection;
    var hub = connection.contactFormResultsHub;
    var hubStart = connection.hub.start({ json: true });


    $("#grid").kendoGrid({
        sortable: true,
        groupable: true,
        scrollable: false,
        height: "540px",
        pageable: {
            pageSize: 10
        },
        dataSource: {
            type: "signalr",
            autoSync: false,
            push: function (e) {
                var notification = $("#notification").data("kendoNotification");
                notification.success(e.type)
            },  
            schema: {
                model: {
                    id: "ContactID",
                    fields: {
                        ContactID: {
                            editable: false, nullable: true
                        },
                        FirstName: {
                            validation: {
                                required: true, min: 3, max: 25
                            }
                        },
                        LastName: {
                            validation: {
                                required: true, min: 3, max: 25
                            }
                        },
                        Email: {
                            validation: {
                                required: true
                            }
                        },
                        Company: {
                            validation: {
                                min: 3, max: 50
                            }
                        },
                        PhoneNumber: {
                            validation: {
                                min: 10, max: 10
                            }
                        },
                        SubmittedDateFormatted: {
                            editable: false, nullable: true
                        },
                        SubmittedDate: {
                            editable: false, nullable: true
                        },
                    }
                }
            },
            transport: {
                signalr: {
                    promise: hubStart,
                    hub: hub,
                    server: {
                        read: "read",
                        update: "update",
                        destroy: "destroy",
                        create: "create",
                    },
                    client: {
                        read: "read",
                        update: "update",
                        destroy: "destroy",
                        create: "create",
                    }
                }
            },
        },
        columns: [
            { field: "FirstName", title: "First Name", width: "120px" },
            { field: "LastName", title: "Last Name", width: "120px" },
            { field: "Email", title: "Email", width: "157px" },
            { field: "Company", title: "Company", width: "250px" },
            { field: "PhoneNumber", title: "Phone", width: "90px" },
            { field: "SubmittedDateFormatted", title: "Date", width: "80px" },
            { command: ["edit", "destroy"], title: "&nbsp;", width: "168px" }
        ],
        toolbar: ["create"],
        editable: "inline",
    });

    $("#notification").kendoNotification({
        width: "100%",
        position: {
            top: 0,
            left: 0
        }
    });
});