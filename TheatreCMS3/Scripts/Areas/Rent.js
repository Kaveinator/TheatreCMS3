

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



