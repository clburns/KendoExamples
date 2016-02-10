(function (kendo, $) {
    'use strict';
    var maskedTextBox = $("#PhoneNumber").data("kendoMaskedTextBox");
    var getValue = function (e) {
        maskedTextBox.value(e);
    }
    var model = new kendo.data.ObservableObject({
        contactForm: {
            FirstName: null,
            LastName: null,
            Email: null,
            Company: null,
            PhoneNumber: null,
        },
        maskStrip: function (e) {
            var that = e.sender,
                stripped = that._unmask(that.value()),
                obs = e.data,
                val = that.element.data("bind");
            if (val) {
                val = val.substring(val.indexOf('value: ') + 7);
                if (val.indexOf(',') > -1) val = val.substring(0, val.indexOf(','));
                obs.set(val, stripped);
            }
        },
        submit: function (e) {
            if ($("input#check").val().length != 0) {
                document.getElementById("contactForm").reset();
                return false;
            }
            else {
                e.preventDefault();
                var validator = $("#contactForm").data("kendoValidator");
                if (validator.validate()) {
                    $("#form input").change();
                    var contactModel = this.get("contactForm").toJSON();
                    $.post("/ContactForm", contactModel)
                        .done(function (data) {
                            $("#success").show();
                            model.set("contactForm", {
                                FirstName: null,
                                LastName: null,
                                Email: null,
                                Company: null,
                                PhoneNumber: null,
                            });
                        })
                }
            }

        },

    });


    $(function () {
        kendo.bind($("#contactForm"), model);
    })
})(kendo, jQuery)