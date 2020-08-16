// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $("select[cascade]").trigger("change");
});

$(document).on("change", "select[cascade]", function () {
    var sel = $(this);
    var selectedValue = sel.find(":selected").val();

    var child = $("#" + sel.data("child"));

    child.children("option[data-superior]").wrap('<span/>');
    child.find("option[data-superior=" + selectedValue + "]").unwrap();
    child.val(child.children("option:first").val());
});