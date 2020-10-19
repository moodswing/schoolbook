// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var confirmationMessage;

var numericValidation = {
    minNumeric: 0,
    maxNumeric: 999999
}

$(document).ready(function () {
    $("select[cascade]").trigger("change");

    if ($('.datepicker').length > 0) {
        $('.datepicker').datepicker();
    }
});

$(document).on("change", ".datepicker", function () {
    if ($(this).val() != "") $(this).removeClass("error");
});

$(document).on("click", "radiobutton .options", function () {
    $(this).find("[type=radio]").prop("checked", true).change();
});

$(document).on("change", "radiobutton [type=radio]", function () {
    $(this).parents("radiobutton").find(".options").removeClass("selected");
    $(this).parents(".options").first().addClass("selected");
    $(this).closest("radiobutton").removeClass("error");
});

// #region Jquery Plugins

$.fn.loadFadeOut = function (url, data, callback) {
    var container = this;
    container.load(url, data, function () {
        container.hide();
        container.fadeIn(750, function () {
            if (callback != undefined)
                callback();
        });
    });
};

$.fn.onOff = function (events, selector, funct) {
    $(document).off(events, selector);
    $(document).on(events, selector, funct);
};

$.fn.serializeList = function () {
    var result = [];
    
    $(this).find("input, select, textarea").map(function () {
        var value;

        if ($(this).is("[type=checkbox]"))
            value = this.checked;
        else if ($(this).is("[type=radio]")) {
            if ($(this).is(":checked"))
                value = this.value;
        }
        //else if ($(this).is(".datepicker"))
        //    value = this.value.replace(new RegExp("([0-9]*)/([0-9]*)/([0-9]+)"), "$2/$1/$3");
        else
            value = this.value;

        var excludeHiddenAutocomplete = !$(this).closest("autocomplete").is(":not(:visible)");

        if (this.name != "" && value != undefined && excludeHiddenAutocomplete)
            result.push({ name: this.name, value });
    });

    var currentList = "";
    var listIndex = 0;

    result.forEach(function (input) {
        if (input.name.indexOf("[i]") > -1 && currentList != input.name) {
            currentList = input.name;
            listIndex = 0;
        }

        if (input.name.indexOf("[i]") > -1) {
            input.name = input.name.replace("[i]", `[${listIndex}]`);
            listIndex++;
        }
    });

    return result;
}

$.fn.validateForm = function () {
    $(this).validate({ errorPlacement: function (error, element) { }, ignore: [] });
    var result = $(this).valid();

    if ($(this).find("autocomplete:visible").length > 0) {
        var autocomplete = $(this).find("autocomplete");
        if (autocomplete.is("[required]")) {
            var input = autocomplete.find("[type=text]");

            if (autocomplete.is("[multiple-selection]")) {
                if (jQuery.isEmptyObject(getFormData(autocomplete))) {
                    result = false;
                    input.addClass("error");
                }
                else
                    input.removeClass("error");
            }
            else {
                if (autocomplete.find("[type=hidden]").val() == "") {
                    result = false;
                    input.addClass("error");
                }
                else
                    input.removeClass("error");
            }
        }
    }

    var radio = $(this).find("radiobutton:has(.error)");
    if (radio.length != 0) {
        radio.addClass("error");
    }
    else
        radio.removeClass("error");

    return result;
}

jQuery.expr[":"].contains = jQuery.expr.createPseudo(function (arg) {
    return function (elem) {
        return jQuery(elem).text().toUpperCase().indexOf(arg.toUpperCase()) >= 0;
    };
});

$(document).onOff("click focus", ".datepicker + i", function () { $(this).prev().datepicker("show"); });
$(document).onOff("click focus", ".datepicker", function () { $(this).datepicker("show"); });

// #endregion

// #region Filters

function selectorsData(selector) {
    var dataSelected = getFormData($(".subject-data-filters, .selector"));
    dataSelected.selection = JSON.stringify(dataSelected);

    return dataSelected;
}

function getFilteredData() {
    $(".subject-data-filters input[type=hidden]:first").change();
}

function primarySelectorChange(container, action, data) {
    $(container).loadFadeOut(action, data, function () {
        if (container == ".subject-data-filters") {
            getFilteredData();
        }
    });
}

function filtersChange(action) {
    $(".subject-data-container").loadFadeOut(action, selectorsData());
}

// #endregion

// #region Cascade DropDownList

$(document).on("change", "select[cascade]", function () {
    var sel = $(this);
    var selectedValue = sel.find(":selected").val();

    var child = $("#" + sel.data("child"));
    var childSelectedValue = child.find(":selected").val();

    child.children("option[data-superior]").wrap('<span/>');
    child.find("option[data-superior=" + selectedValue + "]").unwrap();
    child.val(child.children("option:first").val());

    if (child.find(`span option[value=${childSelectedValue}]`).length == 0)
        child.val(childSelectedValue);
});

// #endregion

// #region Checkbox

$(document).on("click", "input + .flaticon-check, input + .flaticon-check-box-empty", function () {
    var check = $(this);
    var checkbox = $(this).prev();

    if (checkbox.is(":checked")) {
        check.addClass("flaticon-check-box-empty");
        check.removeClass("flaticon-check");
    }
    else {
        check.addClass("flaticon-check");
        check.removeClass("flaticon-check-box-empty");
    }

    checkbox.prop("checked", !checkbox.is(":checked"));
});

$(document).on("change", "checkbox input", function () {
    var checkbox = $(this);
    var check = $(this).next();

    if (checkbox.is(":checked")) {
        check.addClass("flaticon-check");
        check.removeClass("flaticon-check-box-empty");
    }
    else {
        check.addClass("flaticon-check-box-empty");
        check.removeClass("flaticon-check");
    }
});

// #endregion

// #region Action Confirmation

function confirmSaving(input) {
    var form = $(input).closest("form");
    if (form.length > 0 && !form.validateForm())
        return;

    var actionContainer = $(input).closest("div");
    var confirmationContainer = actionContainer.next(".action-confirmation");

    actionContainer.hide();
    confirmationContainer.find("button").show();
    confirmationContainer.find(".title").removeClass("error-message");
    confirmationContainer.find("i").hide();

    confirmationContainer.fadeToggle(400);
}

function showConfirmationSpinner(input) {
    var actionContainer = $(input).closest(".action-confirmation");
    actionContainer.children().hide();
    actionContainer.find(".spinner").show();
}

function cancelConfirmation(container) {
    var actionContainer = $(container).closest("div").prev();

    actionContainer.next(".action-confirmation").find(".title").text(confirmationMessage);
    actionContainer.next(".action-confirmation").toggle(0, function () {
        actionContainer.fadeToggle(200);
    });
}

function finishAction(result, btn) {
    var confirmationContainer = $(btn).closest(".action-confirmation");

    confirmationContainer.children().show();
    confirmationContainer.find(".spinner").hide();

    confirmationMessage = confirmationContainer.find(".title").text().trim();

    confirmationContainer.find("button").hide();
    confirmationContainer.find(".title").text(result.message);
    confirmationContainer.find("i").show();

    if (result.state != "ok")
        confirmationContainer.find(".title").addClass("error-message");
    else
        confirmationContainer.find(".title").removeClass("error-message");
}

// #endregion

// #region Modals - new Items

$(document).on('shown.bs.modal', '.modal', function () {
    $(this).find('input, textarea').not("[type=hidden]").first().focus();
})  

$(document).on('click', '.subtitle .flaticon-caret-down, .subtitle .flaticon-caret-arrow-up', function () {
    var contenedor = $(this).closest(".display-container > div");
    contenedor.find(".additional-info").slideToggle();
    $(this).toggleClass("flaticon-caret-down flaticon-caret-arrow-up");
})

function saveForm(btn, action, callback) {
    var container = $(btn).closest(".modal");

    if (container.length == 0)
        container = $(btn).closest("form");

    if (!$(btn).closest("form").validateForm())
        return;

    var request = $.ajax({
        type: "POST",
        url: action,
        data: getFormData(container),
        success: function (result) {
            // todo: remove timer + refresh changed grades
            setTimeout(function () {
                finishAction(result, btn);
                if (typeof callback === "function" && callback != undefined)
                    callback();

                setTimeout(function () {
                    if (result.state == "ok") {
                        if (container.is(".modal"))
                            container.modal("hide");
                        else if (container.is("form")) {
                            container.fadeOut(750, function () {
                                container.remove();
                            });
                        }
                    }
                }, 1000);
            }, 2000);
        }
    });
};

function cancelAddItem(btn) {
    $(btn).closest(".add-item-form").fadeOut(750, function () {
        $(btn).closest("form").remove();
    });
}

// #endregion Modals

// #region Validations

$(document).on("blur", "input.numeric", function (event) {
    var input = $(this);
    var grade = input.val().replace(new RegExp("([0-9])[^0-9]*([0-9]*)", "gm"), "$1.$2");

    if (isNaN(Number(grade)))
        grade = "";

    grade = toFixed(Number(grade), 1);

    grade = grade != 0 && grade < numericValidation.minNumeric ? numericValidation.minNumeric : grade;
    grade = grade != 0 && grade > numericValidation.maxNumeric ? numericValidation.maxNumeric : grade;

    grade = grade == 0 ? "" : grade;

    input.val(grade);

    if (numericValidation.numericCallback != undefined)
        numericValidation.numericCallback(input);
});

// #endregion

// #region Others

function getFormData($form) {
    var unindexed_array = $form.serializeList();
    var indexed_array = {};

    $.map(unindexed_array, function (n, i) {
        indexed_array[n['name']] = n['value'];
    });

    return indexed_array;
}

function toFixed(num, precision) {
    return (+(Math.round(+(num + 'e' + precision)) + 'e' + -precision)).toFixed(precision);
}

function scrollToTheBottom() {
    $(document.scrollingElement || document.body).animate({
        scrollTop: document.body.scrollHeight
    }, 400);
}

// #endregion