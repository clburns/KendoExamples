$("#grid").kendoGrid({
    sortable: true,
    groupable: true,
    scrollable: false,
    height: "540px",
    batch: true,
    pageable: {
        pageSize: 10
    },
    dataSource: {
        transport: {
            read: {
                type: "GET",
                url: "/ContactFormResults/Contacts_Read",
                dataType: "Json"
            },
            update: {
                type: "POST",
                url: "/ContactFormResults/Contacts_Update",
                dataType: "Json"
            },
            destroy: {
                url: "/ContactFormResults/Contacts_Destroy",
                dataType: "Json"
            },
            create: {
                type: "POST",
                url: "/ContactFormResults/Contacts_Create",
                dataType: "Json"
            },
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
        { command: ["edit", "destroy"], title: "&nbsp;", width: "168px"}
    ],
    toolbar: ["create"],
    editable: "inline"
});