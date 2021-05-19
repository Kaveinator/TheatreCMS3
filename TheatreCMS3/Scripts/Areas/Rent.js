

/*---Rental History Checkbox/Label (CREATE & EDIT PAGES)---*/

$(document).ready(function () {
    if ($('#chkDamagesIncurred').is(':checked')) {
        $('#rentaldamaged-chkbox').show().html("Damages Incurred");
    } else {
        $('#rentaldamaged-chkbox').show().html("Notes");
    }

}).change();

$("#chkDamagesIncurred").change(function () {
    if (this.checked) {
        $('#rentaldamaged-chkbox').show().html("Damages Incurred");
    } else {
        $('#rentaldamaged-chkbox').show().html("Notes");
    }
});

// Rentals Dropdown & Page Form Logic (create&edit pages)
$(document).ready(function () {
    $("select").change(function () {

        $(this).find("option:selected").each(function () {
            var optionValue = $(this).attr("value");
            var optionData = $(this).attr("data-rental");
            if (optionValue) {
                $(".box").not("." + optionValue).hide();
                $("." + optionValue).show();
            } else {
                $(".box").hide();
            }
            $("#beginForm").attr("action", optionData);
        });
    }).change();
});

