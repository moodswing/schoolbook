var autoComplete = {
    displayAll: false
}

$(document).on("keyup", "autocomplete input[type=text]", function (event) {
    var input = $(this);
    var selected = input.find("~ .autocomplete-list div.selected:visible");
    var position = input.find("~ .autocomplete-list div:visible").index(selected);
    var max = input.find(`~ .autocomplete-list div:visible`).length;

    if (position < max && event.key == "ArrowDown")
        position++;
    else if (position > 0 && event.key == "ArrowUp")
        position--;
    else if (event.key == "Enter") {
        selected.click();

        if (input.find("~ .autocomplete-list div.selected").is(".display-all")) {
            input.parents("div").first().find("~ div autocomplete [type=text]").focus();
            input.find("~ .autocomplete-list").hide();
        }
    }

    input.find(`~ .autocomplete-list div`).removeClass("selected");
    input.find(`~ .autocomplete-list div:visible:eq(${position})`).addClass("selected");
});

$(document).on("mouseover", "autocomplete .autocomplete-list div", function (event) {
    var option = $(this);

    option.parent().find("div").removeClass("selected");
    option.addClass("selected");
});

$(document).on("change keyup focus", "autocomplete input[type=text]", function (event) {
    if (autoComplete.displayAll)
        return autoComplete.displayAll = false;

    var input = $(this);
    var search = input.val();
    var maxItems = input.data("max-items");

    var list = input.find("~ .autocomplete-list");

    if (event.type == "focus")
        list.find(`div`).removeClass("selected");
    else if (event.type == "keyup" && !list.find(".display-all").is(":visible"))
        return;

    list.css("display", "");

    var selected = list.find("div").filter(function () { return $(this).text() == search; });
    if (selected.length > 0) {
        search = "";
        input.nextAll("[type=hidden]").val(selected.data("id"));
    }
    else {
        input.nextAll("[type=hidden]").val("");
    }

    list.find(`div`).hide();
    list.find(`div:contains(${search})`).slice(0, maxItems).show();

    if (list.find("div").length == 1)
        list.find(".display-all").text("No se han ingresado registros aún")
    else if (list.find(":visible").length == 0)
        list.find(".display-all").text("Sin Resultados")
    else
        list.find(".display-all").text("Mostrar todos")

    if (list.find(":not(:visible)").length == 0 && list.find("div").length != 1)
        list.find(".display-all").hide();
    else
        list.find(".display-all").show();
});

$(document).on("click", "autocomplete input[type=text] ~ .autocomplete-list div", function () {
    var selected = $(this);
    var selectedId = $(this).data("id");
    var autocompleteList = $(this).parent();

    var input = autocompleteList.prevAll("input[type=text]");

    if (!selected.is(".display-all")) {
        input.find("~ input[type=hidden]").val(selectedId);
        input.find("~ input[type=hidden]").change();
        input.val(selected.text().trim());
        autocompleteList.hide();

        var autocomplete = selected.closest("autocomplete");
        if (autocomplete.is("[multiple-selection]"))
            AddToTheList(selected, autocomplete);
    }
});

$(document).on("click", "autocomplete .selection-list i", function () {
    var selected = $(this);
    $(this).parent().fadeOut(300, function () { $(this).remove(); })
});

function AddToTheList(btn, autocomplete) {
    var selectionList = autocomplete.find(".selection-list");
    var input = autocomplete.find("[type=text]");
    var listName = input.data("list-name")

    input.removeClass("error");

    if (selectionList.is(`:contains(${btn.text().trim()})`)) return;

    var newItem = $(document.createElement('div'));
    newItem.html(btn.text().trim());

    var removeIcon = $(document.createElement('i'));
    removeIcon.addClass("flaticon-remove-symbol");
    removeIcon.addClass("icon");

    newItem.append(removeIcon);

    var itemId = $(btn).data("id");

    var hdnId = $(document.createElement('input'));
    hdnId.prop("type", "hidden");
    hdnId.prop("name", `${listName}[i].Id`);
    hdnId.prop("value", itemId)
    
    newItem.append(hdnId);

    selectionList.append(newItem);
}

function DisplayAllAutoComplete(btn) {
    var autocomplete = $(btn).parent();

    if (autocomplete.find("div").length == 1) {
        $(btn).removeClass("selected");
        $(btn).hide();

        return;
    }

    autocomplete.find("div").show();

    var input = autocomplete.prevAll("input[type=text]");
    autoComplete.displayAll = true;
    input.focus();

    $(btn).hide();
}