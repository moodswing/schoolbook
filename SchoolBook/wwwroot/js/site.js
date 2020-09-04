// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var confirmationMessage;

$(document).ready(function () {
    $("select[cascade]").trigger("change");
});

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

// #region Action Confirmation

function confirmSaving(input) {
    $(input).closest("div").hide();

    $(input).closest("div").next(".action-confirmation").find("button").show();
    $(input).closest("div").next(".action-confirmation").find("i").hide();

    $(input).closest("div").next(".action-confirmation").fadeToggle(400);
}

function showConfirmationSpinner(input) {
    var actionContainer = $(input).closest(".action-confirmation");
    actionContainer.children().hide();
    actionContainer.find(".spinner").show();
}

function cancelConfirmation(container) {
    var actionContainer = $(container);

    actionContainer.next(".action-confirmation").find(".title").text(confirmationMessage);
    actionContainer.next(".action-confirmation").toggle(0, function () {
        actionContainer.fadeToggle(200);
    });
}

function finishAction(result, container) {
    var confirmationContainer = $(container).next(".action-confirmation");

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

// #region Jquery Plugins

$.fn.loaFadeOut = function (url, data) {
    var container = this;
    container.load(url, data, function () {
        container.hide();
        container.fadeIn(750);
    });
};

// #endregion

// #region Others

function getFormData($form) {
    var unindexed_array = $form.serializeArray();
    var indexed_array = {};

    $.map(unindexed_array, function (n, i) {
        indexed_array[n['name']] = n['value'];
    });

    return indexed_array;
}

function toFixed(num, precision) {
    return (+(Math.round(+(num + 'e' + precision)) + 'e' + -precision)).toFixed(precision);
}

// #endregion